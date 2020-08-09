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
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class ZdravstvenaKnjizicaService : BaseCRUDService<ZdravstvenaKnjizicaDtoLL, ZdravstvenaKnjizicaDtoEL, ZdravstvenaKnjizicaResourceParameters, ZdravstvenaKnjizica, ZdravstvenaKnjizicaUpsertDto, ZdravstvenaKnjizicaUpsertDto>
    {
        private ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> _licniPodaciService;

        public ZdravstvenaKnjizicaService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> licniPodaciService,
            IAuthService authService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
            _licniPodaciService = licniPodaciService;
        }

        public override IQueryable<ZdravstvenaKnjizica> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.ZdravstvenaKnjizica
                .Include(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .Include(x => x.Doktor)
                .ThenInclude(x => x.Radnik)
                .ThenInclude(x => x.LicniPodaci)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult> Insert(ZdravstvenaKnjizicaUpsertDto dtoForCreation)
        {
            if (!await _dbContext.ZdravstvenaKnjizica.AnyAsync(x => x.DoktorId == dtoForCreation.DoktorId))
                return ServiceResult.NotFound($"Doktor sa ID-em {dtoForCreation.DoktorId} nije pronadjen.");

            var licniPodaciInsertResult = await _licniPodaciService.Insert(dtoForCreation.LicniPodaci);
            if (!licniPodaciInsertResult.Succeeded)
                return ServiceResult.WithStatusCode(licniPodaciInsertResult.StatusCode, licniPodaciInsertResult.Message);

            var zdravstvenaKnjizica = new ZdravstvenaKnjizica
            {
                LicniPodaciId = ((LicniPodaciDto)licniPodaciInsertResult.Data).Id,
                DoktorId = dtoForCreation.DoktorId
            };

            await _dbContext.AddAsync(zdravstvenaKnjizica);
            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(
                _mapper.Map<ZdravstvenaKnjizicaDtoLL>(zdravstvenaKnjizica));
        }

        public override async Task<ServiceResult> Update(int id, ZdravstvenaKnjizicaUpsertDto dtoForUpdate)
        {
            var zdravstvenaKnjizicaFromDb = await _dbContext.ZdravstvenaKnjizica.FindAsync(id);

            if (zdravstvenaKnjizicaFromDb == null)
                return ServiceResult.NotFound($"Zdravstvena knjizica sa ID-em {id} nije pronadjena.");

            if (!await _dbContext.ZdravstvenaKnjizica.AnyAsync(x => x.DoktorId == dtoForUpdate.DoktorId))
                return ServiceResult.NotFound($"Doktor sa ID-em {dtoForUpdate.DoktorId} nije pronadjen.");

            var licniPodaciUpdateResult =
                await _licniPodaciService.Update(zdravstvenaKnjizicaFromDb.LicniPodaciId, dtoForUpdate.LicniPodaci);
            if (!licniPodaciUpdateResult.Succeeded)
                return ServiceResult.WithStatusCode(licniPodaciUpdateResult.StatusCode, licniPodaciUpdateResult.Message);

            zdravstvenaKnjizicaFromDb.DoktorId = dtoForUpdate.DoktorId;
            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(
                _mapper.Map<ZdravstvenaKnjizicaDtoLL>(zdravstvenaKnjizicaFromDb));
        }

        public override async Task<ServiceResult> Delete(int id)
        {
            var zdravstvenaKnjizicaFromDb = await _dbContext.ZdravstvenaKnjizica.FindAsync(id);

            if (zdravstvenaKnjizicaFromDb == null)
                return ServiceResult.NotFound($"Zdravstvena knjizica sa ID-em {id} nije pronadjena.");

            if (await _dbContext.Pacijenti.AnyAsync(x => x.ZdravstvenaKnjizicaId == id))
                return ServiceResult.BadRequest($"Ne mozete izbrisati zdravstvenu knjizicu, jer postoji pacijent koji je koristi.");

            await Task.Run(() =>
            {
                _dbContext.Remove(zdravstvenaKnjizicaFromDb.LicniPodaci);
                _dbContext.Remove(zdravstvenaKnjizicaFromDb);
            });

            await _dbContext.SaveChangesAsync();

            return ServiceResult.NoContent();
        }

        public override async Task<PagedList<ZdravstvenaKnjizica>> FilterAndPrepare(IQueryable<ZdravstvenaKnjizica> result, ZdravstvenaKnjizicaResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (resourceParameters != null)
            {
                if (!string.IsNullOrWhiteSpace(resourceParameters.DoktorIme))
                {
                    var nazivToSearch = resourceParameters.DoktorIme.ToLower();
                    if (result.Where(x => x.Doktor.Radnik.LicniPodaci.Ime.StartsWith(nazivToSearch)) is { } filtered && await filtered.AnyAsync())
                    {
                        result = filtered;
                    }
                    else if (!string.IsNullOrWhiteSpace(resourceParameters.DoktorPrezime))
                    {
                        result = result.Where(x =>
                            x.Doktor.Radnik.LicniPodaci.Prezime.ToLower()
                                .StartsWith(resourceParameters.DoktorPrezime.ToLower()));
                    }
                }

                if (await result.AnyAsync())
                {
                    if (!string.IsNullOrWhiteSpace(resourceParameters.Ime))
                    {
                        var nazivToSearch = resourceParameters.Ime.ToLower();
                        if (result.Where(x => x.LicniPodaci.Ime.ToLower().StartsWith(nazivToSearch)) is { } filtered && await filtered.AnyAsync())
                        {
                            result = filtered;
                        }
                        else if (!string.IsNullOrWhiteSpace(resourceParameters.DoktorPrezime))
                        {
                            result = result.Where(x =>
                                x.Doktor.Radnik.LicniPodaci.Prezime.ToLower()
                                    .StartsWith(resourceParameters.DoktorPrezime.ToLower()));
                        }
                    }
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }

                if (await result.AnyAsync())
                {
                    if (resourceParameters.DoktorId.HasValue)
                        result = result.Where(x => x.DoktorId == resourceParameters.DoktorId);
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }

        public override async Task<bool> AuthorizePacijentForGetById(int id)
        {
            var pacijent = await _authService.GetCurrentLoggedInPacijent();
            if (pacijent == null)
                return false;

            return pacijent.ZdravstvenaKnjizicaId == id;
        }
    }
}