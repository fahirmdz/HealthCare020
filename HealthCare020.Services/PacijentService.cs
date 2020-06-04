using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor)
        {
            _licniPodaciService = licniPodaciService;
        }

        public override IQueryable<Pacijent> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Set<Pacijent>()
                .Include(x=>x.ZdravstvenaKnjizica)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .ThenInclude(x => x.Drzava)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult<PacijentDtoLL>> Insert(PacijentUpsertDto dtoForCreation)
        {
            var newEntity = new Pacijent
            {
            };

            return new ServiceResult<PacijentDtoLL>(_mapper.Map<PacijentDtoLL>(newEntity));
        }

        public override async Task<ServiceResult<PacijentDtoLL>> Update(int id, PacijentDtoForUpdate dtoForUpdate)
        {
            var entity = await _dbContext.Set<Pacijent>().FindAsync(id);

            if (entity == null)
                return new ServiceResult<PacijentDtoLL>(HttpStatusCode.NotFound, $"Pacijent sa ID-em {id} nije pronadjen.");

            await _licniPodaciService.Update(id, dtoForUpdate.LicniPodaci);

            return new ServiceResult<PacijentDtoLL>(_mapper.Map<PacijentDtoLL>(entity));
        }

        public override async Task<PagedList<Pacijent>> FilterAndPrepare(IQueryable<Pacijent> result, PacijentResourceParameters resourceParameters)
        {
            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.Ime))
            {
                result = result.Where(x => x.ZdravstvenaKnjizica.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.Ime.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.Prezime) && await result.AnyAsync())
            {
                result = result.Where(x =>
                    x.ZdravstvenaKnjizica.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.Prezime.ToLower()));
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}