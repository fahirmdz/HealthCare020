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
    public class ZahtevZaPosetuService : BaseCRUDService<ZahtevZaPosetuDtoLL, ZahtevZaPosetuDtoEL, ZahtevZaPosetuResourceParameters, ZahtevZaPosetu, ZahtevZaPosetuUpsertDto, ZahtevZaPosetuUpsertDto>
    {
        public ZahtevZaPosetuService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService)
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
        }

        public override IQueryable<ZahtevZaPosetu> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.ZahteviZaPosetu
                .Include(x => x.PacijentNaLecenju)
                .ThenInclude(x => x.StacionarnoOdeljenje)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult> Insert(ZahtevZaPosetuUpsertDto dtoForCreation)
        {
            if (!await _dbContext.PacijentiNaLecenju.AnyAsync(x => x.Id == dtoForCreation.PacijentNaLecenjuId))
                return ServiceResult.NotFound($"Pacijent na lecenju sa ID-em {dtoForCreation.PacijentNaLecenjuId} nije pronadjen.");

            var zahtevZaPosetu = new ZahtevZaPosetu
            {
                PacijentNaLecenjuId = dtoForCreation.PacijentNaLecenjuId,
                DatumVreme = dtoForCreation.DatumVreme,
                BrojTelefonaPosetioca = dtoForCreation.BrojTelefonaPosetioca.Trim()
            };

            await _dbContext.AddAsync(zahtevZaPosetu);
            await _dbContext.SaveChangesAsync();

            return ServiceResult<ZahtevZaPosetuDtoLL>.OK(_mapper.Map<ZahtevZaPosetuDtoLL>(zahtevZaPosetu));
        }

        public override async Task<ServiceResult> Update(int id, ZahtevZaPosetuUpsertDto dtoForUpdate)
        {
            return ServiceResult.WithStatusCode(HttpStatusCode.OK);
        }

        public override async Task<ServiceResult> Delete(int id)
        {
            var zahtevFromDb = await _dbContext.ZahteviZaPosetu.FindAsync(id);

            if (zahtevFromDb == null)
                return ServiceResult.NotFound($"Zahtev za posetu sa ID-em {id} nije pronadjen.");

            await Task.Run(() =>
            {
                _dbContext.Remove(zahtevFromDb);
            });

            await _dbContext.SaveChangesAsync();

            return ServiceResult<ZahtevZaPosetuDtoLL>.NoContent();
        }

        public override async Task<PagedList<ZahtevZaPosetu>> FilterAndPrepare(IQueryable<ZahtevZaPosetu> result, ZahtevZaPosetuResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (!string.IsNullOrWhiteSpace(resourceParameters.PacijentIme))
                result = result.Where(x =>
                    x.PacijentNaLecenju.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.PacijentIme.Trim().ToLower()));

            if(await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.PacijentPrezime))
                result = result.Where(x =>
                    x.PacijentNaLecenju.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.PacijentPrezime.Trim().ToLower()));

            if(await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.BrojTelefonaPosetioca))
                result = result.Where(x =>
                    x.BrojTelefonaPosetioca.StartsWith(resourceParameters.BrojTelefonaPosetioca.Trim()));

            if (await result.AnyAsync() && resourceParameters.Datum.HasValue)
                result = result.Where(x => x.DatumVreme.Date == resourceParameters.Datum.Value.Date);

            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}