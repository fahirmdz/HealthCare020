using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Services
{
    public class UputZaLecenjeService : BaseCRUDService<UputZaLecenjeDtoLL, UputZaLecenjeDtoEL, UputZaLecenjeResourceParameters, UputZaLecenje, UputZaLecenjeUpsertDto, UputZaLecenjeUpsertDto>
    {
        private readonly ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters,LicniPodaciUpsertDto, LicniPodaciUpsertDto> _licniPodaciService;

        public UputZaLecenjeService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService, 
            ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> licniPodaciService) : 
            base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
            _licniPodaciService = licniPodaciService;
        }

        public override IQueryable<UputZaLecenje> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Set<UputZaLecenje>()
                .Include(x => x.Doktor)
                .ThenInclude(x=>x.Radnik)
                .ThenInclude(x=>x.LicniPodaci)
                .Include(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .ThenInclude(x => x.Drzava)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id.Value);

            return result;
        }

        public override async Task<UputZaLecenjeDtoLL> Insert(UputZaLecenjeUpsertDto dtoForCreation)
        {
            if(!await _dbContext.Set<Doktor>().AnyAsync(x=>x.Id==dtoForCreation.DoktorId))
                throw new NotFoundException($"Doktor sa ID-em {dtoForCreation.DoktorId} nije pronadjen.");

            var licniPodaciResult=await _licniPodaciService.Insert(dtoForCreation.LicniPodaci);

            var newEntity = new UputZaLecenje
            {
                DatumVreme = DateTime.Now,
                DoktorId = dtoForCreation.DoktorId,
                LicniPodaciId = licniPodaciResult.Id,
                OpisStanja = dtoForCreation.OpisStanja
            };

            await _dbContext.AddAsync(newEntity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<UputZaLecenjeDtoLL>(newEntity);
        }

        public override async Task<UputZaLecenjeDtoLL> Update(int id, UputZaLecenjeUpsertDto dtoForUpdate)
        {
            var entity = await _dbContext.Set<UputZaLecenje>().FindAsync(id);

            if (entity == null)
                throw new NotFoundException($"Uput za lecenje sa ID-em {id} nije pronadjen");

            if(!await _dbContext.Set<Doktor>().AnyAsync(x=>x.Id==dtoForUpdate.DoktorId))
                throw new NotFoundException($"Doktor sa ID-em {dtoForUpdate.DoktorId} nije pronadjen.");

            await _licniPodaciService.Update(entity.LicniPodaciId, dtoForUpdate.LicniPodaci);

             await Task.Run(() =>
            {
                _mapper.Map(dtoForUpdate,entity);

                _dbContext.Set<UputZaLecenje>().Update(entity);
            });

             await _dbContext.SaveChangesAsync();
            return _mapper.Map<UputZaLecenjeDtoLL>(entity);
        }

        public override async Task Delete(int id)
        {
            var query = _dbContext.Set<UputZaLecenje>();

            var entity = await query.FindAsync(id);
            if (entity == null)
                throw new NotFoundException("Not Found");

            await _licniPodaciService.Delete(entity.LicniPodaciId);
            await Task.Run(() =>
            {
                query.Remove(entity);
            });
        }

        public override async Task<PagedList<UputZaLecenje>> FilterAndPrepare(IQueryable<UputZaLecenje> result, UputZaLecenjeResourceParameters resourceParameters)
        {
            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.ImePacijenta))
            {
                result = result.Where(x =>
                    x.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.ImePacijenta.ToLower()));
            }

            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.PrezimePacijenta))
            {
                result = result.Where(x =>
                    x.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.PrezimePacijenta.ToLower()));
            }

            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.ImeDoktora))
            {
                result = result.Where(x =>
                    x.Doktor.Radnik.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.ImeDoktora.ToLower()));
            }


            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}