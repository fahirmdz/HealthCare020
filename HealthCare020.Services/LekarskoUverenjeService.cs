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
    public class LekarskoUverenjeService : BaseCRUDService<LekarskoUverenjeDtoLL, LekarskoUverenjeDtoEL, LekarskoUverenjeResourceParameters, LekarskoUverenje, LekarskoUverenjeUpsertDto, LekarskoUverenjeUpsertDto>
    {
        public LekarskoUverenjeService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService)
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
        }

        public override IQueryable<LekarskoUverenje> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.LekarskaUverenja
                .Include(x => x.Pregled)
                .ThenInclude(x => x.Doktor)
                .AsQueryable();

            return id.HasValue ? result = result.Where(x => x.Id == id) : result;
        }

        public override async Task<ServiceResult> Insert(LekarskoUverenjeUpsertDto dtoForCreation)
        {
            if (await ValidateModel(dtoForCreation) is { } result && !result.Succeeded)
                return ServiceResult.WithStatusCode(result.StatusCode, result.Message);

            var lekarskoUverenje = _mapper.Map<LekarskoUverenje>(dtoForCreation);

            await _dbContext.AddAsync(lekarskoUverenje);
            await _dbContext.SaveChangesAsync();

            return ServiceResult<LekarskoUverenjeDtoLL>.OK(_mapper.Map<LekarskoUverenjeDtoLL>(lekarskoUverenje));
        }

        public override async Task<ServiceResult> Update(int id, LekarskoUverenjeUpsertDto dtoForUpdate)
        {
            var uverenjeFromDb = await _dbContext.LekarskaUverenja.FindAsync(id);

            if (uverenjeFromDb == null)
                return ServiceResult.NotFound($"Lekarsko uverenje sa ID-em {id} nije pronadjeno.");

            if (await ValidateModel(dtoForUpdate) is { } result && !result.Succeeded)
                return ServiceResult.WithStatusCode(result.StatusCode, result.Message);

            _mapper.Map(dtoForUpdate, uverenjeFromDb);
            await _dbContext.SaveChangesAsync();

            return ServiceResult<LekarskoUverenjeDtoLL>.OK(_mapper.Map<LekarskoUverenjeDtoLL>(uverenjeFromDb));
        }

        public override async Task<PagedList<LekarskoUverenje>> FilterAndPrepare(IQueryable<LekarskoUverenje> result, LekarskoUverenjeResourceParameters resourceParameters)
        {
            if (result == null)
                return null;

            if (resourceParameters != null)
            {
                if (!string.IsNullOrWhiteSpace(resourceParameters.OpisStanja))
                    result = result.Where(x =>
                        x.OpisStanja.ToLower().Contains(resourceParameters.OpisStanja.ToLower()));

                if (await result.AnyAsync() && resourceParameters.PregledId.HasValue)
                    result = result.Where(x => x.PregledId == resourceParameters.PregledId);

                if (await result.AnyAsync() && resourceParameters.ZdravstvenoStanjeId.HasValue)
                    result = result.Where(x => x.ZdravstvenoStanjeId == resourceParameters.ZdravstvenoStanjeId);
            }

            //CONSTRAINT -> Pacijent moze samo svoje preglede videti
            if (_authService.UserIsPacijent() && await _authService.GetCurrentLoggedInPacijent() is { } pacijent)
                result = result.Where(x => x.Pregled.PacijentId == pacijent.Id);

            return await base.FilterAndPrepare(result, resourceParameters);
        }

        public override async Task<bool> AuthorizePacijentForGetById(int id)
        {
            var pacijent = await _authService.GetCurrentLoggedInPacijent();
            if (pacijent == null)
                return false;

            return await _dbContext.LekarskaUverenja.AnyAsync(x => x.Pregled.PacijentId == pacijent.Id && x.Id == id);
        }

        private async Task<ServiceResult> ValidateModel(LekarskoUverenjeUpsertDto dto)
        {
            if (!await _dbContext.Pregledi.AnyAsync(x => x.Id == dto.PregledId))
                return ServiceResult.NotFound($"Pregled sa ID-em {dto.PregledId} nije pronadjen.");

            if (!await _dbContext.ZdravstvenaStanja.AnyAsync(x => x.Id == dto.ZdravstvenoStanjeId))
                return ServiceResult.NotFound($"Zdravstveno stanje sa ID-em {dto.ZdravstvenoStanjeId} nije pronadjeno.");

            if (await _dbContext.LekarskaUverenja.AnyAsync(x => x.PregledId == dto.PregledId))
                return ServiceResult.BadRequest($"Vec postoji lekarsko uverenje za pregled sa ID-em {dto.PregledId}.");

            return ServiceResult.WithStatusCode(HttpStatusCode.OK);
        }
    }
}