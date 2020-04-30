using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using HealthCare020.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Update;

namespace HealthCare020.Services
{
    public class PacijentService : BaseCRUDService<PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, Pacijent, PacijentUpsertDto, PacijentDtoForUpdate>
    {
        private readonly ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters,
            LicniPodaciUpsertDto, LicniPodaciUpsertDto> _licniPodaciService;

        public PacijentService(IMapper mapper, 
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> licniPodaciService,
            IHttpContextAccessor httpContextAccessor) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService,httpContextAccessor)
        {
            _licniPodaciService = licniPodaciService;
        }

        public override IQueryable<Pacijent> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Set<Pacijent>()
                .Include(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .ThenInclude(x => x.Drzava)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<PacijentDtoLL> Insert(PacijentUpsertDto dtoForCreation)
        {
            var uputZaLecenjeFromDb = await _dbContext.Set<UputZaLecenje>().FindAsync(dtoForCreation.UputZaLecenjeId);

            if (uputZaLecenjeFromDb == null)
                throw new NotFoundException($"Uput za lečenje sa ID-em {dtoForCreation.UputZaLecenjeId} nije pronadjen.");

            if(await _dbContext.Set<Pacijent>().AnyAsync(x=>x.LicniPodaciId==uputZaLecenjeFromDb.LicniPodaciId))
                throw new UserException("Pacijent je vec prijavljen na lecenje");

            var newEntity = new Pacijent
            {
                LicniPodaciId = uputZaLecenjeFromDb.LicniPodaciId
            };

            await _dbContext.AddAsync(newEntity);
            await _dbContext.SaveChangesAsync();

            var noviTokenPoseta = new TokenPoseta
            {
                Value = GenerateTokenPoseta(),
                PacijentId = newEntity.Id
            };

            await _dbContext.AddAsync(noviTokenPoseta);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PacijentDtoLL>(newEntity);
        }

        public override async Task<PacijentDtoLL> Update(int id, PacijentDtoForUpdate dtoForUpdate)
        {
            var entity = await _dbContext.Set<Pacijent>().FindAsync(id);

            if (entity == null)
                throw new NotFoundException($"Pacijent sa ID-em {id} nije pronadjen.");

            await _licniPodaciService.Update(id, dtoForUpdate.LicniPodaci);

            return _mapper.Map<PacijentDtoLL>(entity);
        }

        public override async Task<PagedList<Pacijent>> FilterAndPrepare(IQueryable<Pacijent> result, PacijentResourceParameters resourceParameters)
        {
            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.Ime))
            {
                result = result.Where(x => x.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.Ime.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.Prezime) && await result.AnyAsync())
            {
                result = result.Where(x =>
                    x.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.Prezime.ToLower()));
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }

        private string GenerateTokenPoseta()
        {
            var rand = new Random();
            string token = string.Empty;

            do
            {
                token = rand.Next(100000, 999999).ToString("D6");
            } while (_dbContext.Set<TokenPoseta>().Any(x => x.Value == token));

            return token;
        }
    }
}