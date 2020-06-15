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
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class PregledService : BaseCRUDService<PregledDtoLL, PregledDtoEL, PregledResourceParameters, Pregled, PregledUpsertDto, PregledUpsertDto>
    {
        public PregledService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService, IHttpContextAccessor httpContextAccessor,
            IAuthService authService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        { }

        public override IQueryable<Pregled> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Pregledi
                .Include(x => x.Pacijent)
                .ThenInclude(x => x.ZdravstvenaKnjizica)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .Include(x => x.Doktor)
                .ThenInclude(x => x.Radnik)
                .ThenInclude(x => x.LicniPodaci)
                .Include(x => x.ZahtevZaPregled)
                .AsQueryable();

            if (id.HasValue)
            {
                result = result.Where(x => x.Id == id);
            }

            return result;
        }

        public override async Task<ServiceResult> Insert(PregledUpsertDto dtoForCreation)
        {
            if (!await _dbContext.Doktori.AnyAsync(x => x.Id == dtoForCreation.DoktorId))
                return ServiceResult.NotFound($"Doktor sa ID-em {dtoForCreation.DoktorId} nije pronadjen.");

            if (!await _dbContext.Pacijenti.AnyAsync(x => x.Id == dtoForCreation.PacijentId))
                return ServiceResult.NotFound($"Pacijent sa ID-em {dtoForCreation.PacijentId} nije pronadjen.");

            if (!await _dbContext.ZahteviZaPregled.AnyAsync(x => x.Id == dtoForCreation.ZahtevZaPregledId))
                return ServiceResult.NotFound($"Zahtev za pregled sa ID-em {dtoForCreation.ZahtevZaPregledId} nije pronadjen.");

            if (dtoForCreation.DatumPregleda.Year < DateTime.Now.Year)
                return ServiceResult.BadRequest($"Datum pregleda nije validan.");

            var entity = new Pregled
            {
                DoktorId = dtoForCreation.DoktorId,
                PacijentId = dtoForCreation.PacijentId,
                ZahtevZaPregledId = dtoForCreation.ZahtevZaPregledId,
                DatumPregleda = dtoForCreation.DatumPregleda,
                IsOdradjen = false
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return ServiceResult<PregledDtoLL>.OK(_mapper.Map<PregledDtoLL>(entity));
        }

        public override async Task<ServiceResult> Update(int id, PregledUpsertDto dtoForUpdate)
        {
            var pregledFromDb = await _dbContext.Pregledi.FindAsync(id);

            if (pregledFromDb == null)
                return ServiceResult.NotFound($"Pregled sa ID-em {id} nije pronadjen.");

            if (!await _dbContext.Doktori.AnyAsync(x => x.Id == dtoForUpdate.DoktorId))
                return ServiceResult.NotFound($"Doktor sa ID-em {dtoForUpdate.DoktorId} nije pronadjen.");

            if (!await _dbContext.Pacijenti.AnyAsync(x => x.Id == dtoForUpdate.PacijentId))
                return ServiceResult.NotFound($"Pacijent sa ID-em {dtoForUpdate.PacijentId} nije pronadjen.");

            if (!await _dbContext.ZahteviZaPregled.AnyAsync(x => x.Id == dtoForUpdate.ZahtevZaPregledId))
                return ServiceResult.NotFound($"Zahtev za pregled sa ID-em {dtoForUpdate.ZahtevZaPregledId} nije pronadjen.");

            if (dtoForUpdate.DatumPregleda.Year < DateTime.Now.Year)
                return ServiceResult.BadRequest($"Datum pregleda nije validan.");

            _mapper.Map(dtoForUpdate, pregledFromDb);

            return ServiceResult<PregledDtoLL>.OK(_mapper.Map<PregledDtoLL>(pregledFromDb));
        }

        public override async Task<PagedList<Pregled>> FilterAndPrepare(IQueryable<Pregled> result, PregledResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (resourceParameters != null)
            {
                if (!string.IsNullOrWhiteSpace(resourceParameters.PacijentIme))
                    result = result.Where(x =>
                        x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.Ime.ToLower()
                            .StartsWith(resourceParameters.PacijentIme.ToLower()));

                if (!string.IsNullOrEmpty(resourceParameters.PacijentIme))
                {
                    result = result.Where(x =>
                        x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.Ime.ToLower()
                            .StartsWith(resourceParameters.PacijentIme.ToLower()));
                }

                if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.PacijentPrezime))
                {
                    result = result.Where(x =>
                        x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.Prezime.ToLower()
                            .StartsWith(resourceParameters.PacijentPrezime.ToLower()));
                }

                if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.DoktorIme))
                {
                    result = result.Where(x =>
                        x.Doktor.Radnik.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.DoktorIme.ToLower()));
                }

                if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.DoktorPrezime))
                {
                    result = result.Where(x =>
                        x.Doktor.Radnik.LicniPodaci.Prezime.ToLower()
                            .StartsWith(resourceParameters.DoktorPrezime.ToLower()));
                }

                if (await result.AnyAsync() && resourceParameters.PacijentId.HasValue)
                {
                    result = result.Where(x => x.PacijentId == resourceParameters.PacijentId);
                }

                if (await result.AnyAsync() && resourceParameters.DoktorId.HasValue)
                {
                    result = result.Where(x => x.DoktorId == resourceParameters.DoktorId);
                }

                if (await result.AnyAsync() && resourceParameters.ZahtevZaPregledId.HasValue)
                {
                    result = result.Where(x => x.ZahtevZaPregledId == resourceParameters.ZahtevZaPregledId);
                }

                if (await result.AnyAsync() && resourceParameters.IsOdradjen.HasValue)
                {
                    result = result.Where(x => x.IsOdradjen == resourceParameters.IsOdradjen.Value);
                }
            }

            return PagedList<Pregled>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);
        }
    }
}