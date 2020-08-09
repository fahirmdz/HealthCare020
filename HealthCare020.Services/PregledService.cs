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
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public override async Task<List<int>> Count(int MonthsCount)
        {
            if (MonthsCount == 0)
                return new List<int> { await _dbContext.Pregledi.CountAsync() };

            int startMonth = DateTime.Now.Month - MonthsCount;
            var year = DateTime.Now.Year;

            if (startMonth < 1)
            {
                startMonth += 12;
                year = DateTime.Now.Year - 1;
            }

            var monthsCountsList = new List<int>();

            for (int i = 0; i < MonthsCount; i++)
            {
                if (startMonth > 12)
                {
                    startMonth = 1;
                    year++;
                }
                monthsCountsList.Add(await _dbContext.Pregledi.CountAsync(x => x.IsOdradjen &&
                                                                               x.DatumPregleda.Year == year && x.DatumPregleda.Month == startMonth));
                startMonth++;
            }

            return monthsCountsList;
        }

        public override async Task<ServiceResult> Insert(PregledUpsertDto dtoForCreation)
        {
            var doktor = await _authService.GetCurrentLoggedInDoktor();
            if (doktor == null)
                return ServiceResult.Forbidden($"Samo doktori mogu kreirati novi pregled.");

            if (await ValidateModel(dtoForCreation) is { } result && !result.Succeeded)
                return ServiceResult.WithStatusCode(result.StatusCode, result.Message);

            var entity = new Pregled
            {
                DoktorId = doktor.Id,
                PacijentId = dtoForCreation.PacijentId,
                ZahtevZaPregledId = dtoForCreation.ZahtevZaPregledId,
                DatumPregleda = dtoForCreation.DatumPregleda,
                IsOdradjen = false
            };

            var zahtevFromDb = await _dbContext.ZahteviZaPregled.FindAsync(dtoForCreation.ZahtevZaPregledId);
            zahtevFromDb.IsObradjen = true;

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(_mapper.Map<PregledDtoLL>(entity));
        }

        public override async Task<ServiceResult> Update(int id, PregledUpsertDto dtoForUpdate)
        {
            var getPregledResult = await GetPregledForManipulation(id);
            if (!getPregledResult.Succeeded)
                return ServiceResult.WithStatusCode(getPregledResult.StatusCode, getPregledResult.Message);

            var pregledFromDb = getPregledResult.Data as Pregled;

            if (await ValidateModel(dtoForUpdate) is { } result && !result.Succeeded)
                return ServiceResult.WithStatusCode(result.StatusCode, result.Message);

            _mapper.Map(dtoForUpdate, pregledFromDb);

            return ServiceResult.OK(_mapper.Map<PregledDtoLL>(pregledFromDb));
        }

        public override async Task<ServiceResult> Delete(int id)
        {
            var getPregledResult = await GetPregledForManipulation(id);
            if (!getPregledResult.Succeeded)
                return ServiceResult.WithStatusCode(getPregledResult.StatusCode, getPregledResult.Message);

            var pregledFromDb = getPregledResult.Data as Pregled;

            if (await _dbContext.LekarskaUverenja.AnyAsync(x => x.PregledId == id))
                return ServiceResult.BadRequest($"Ne mozete brisati pregled sve dok ima lekarskih uverenja povezanih sa ovim pregledom.");

            await Task.Run(() =>
            {
                _dbContext.Remove(pregledFromDb);
            });

            await _dbContext.SaveChangesAsync();

            return ServiceResult.NoContent();
        }

        public override async Task<PagedList<Pregled>> FilterAndPrepare(IQueryable<Pregled> result, PregledResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            //CONSTRAINT -> Pacijent moze samo svoje preglede videti
            if (_authService.UserIsPacijent() && await _authService.GetCurrentLoggedInPacijent() is { } pacijent)
                result = result.Where(x => x.PacijentId == pacijent.Id);
            else if (_authService.UserIsDoktor() && await _authService.GetCurrentLoggedInDoktor() is { } doktor)
                result = result.Where(x => x.DoktorId == doktor.Id);

            if (resourceParameters != null)
            {
                if (!string.IsNullOrWhiteSpace(resourceParameters.PacijentIme))
                {
                    var nazivToSearch = resourceParameters.PacijentIme.ToLower();
                    if (await result.AnyAsync(x => x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.Ime.StartsWith(nazivToSearch)))
                    {
                        result = result.Where(x => x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.Ime.ToLower().StartsWith(nazivToSearch));
                    }
                    else if (!string.IsNullOrWhiteSpace(resourceParameters.PacijentPrezime))
                    {
                        result = result.Where(x => x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.PacijentPrezime.ToLower()));
                    }
                }

                if (await result.AnyAsync())
                {
                    if (!string.IsNullOrWhiteSpace(resourceParameters.DoktorIme))
                    {
                        var nazivToSearch = resourceParameters.DoktorIme.ToLower();
                        if (await result.AnyAsync(x => x.Doktor.Radnik.LicniPodaci.Ime.StartsWith(nazivToSearch)))
                        {
                            result = result.Where(x => x.Doktor.Radnik.LicniPodaci.Ime.ToLower().StartsWith(nazivToSearch));
                        }
                        else if (!string.IsNullOrWhiteSpace(resourceParameters.DoktorPrezime))
                        {
                            result = result.Where(x => x.Doktor.Radnik.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.DoktorPrezime.ToLower()));
                        }
                    }
                }

                if (await result.AnyAsync())
                {
                    if (resourceParameters.PacijentId.HasValue)
                        result = result.Where(x => x.PacijentId == resourceParameters.PacijentId);
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

                if (await result.AnyAsync())
                {
                    if (resourceParameters.ZahtevZaPregledId.HasValue)
                        result = result.Where(x => x.ZahtevZaPregledId == resourceParameters.ZahtevZaPregledId);
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }

                if (await result.AnyAsync())
                {
                    if (resourceParameters.IsOdradjen.HasValue)
                        result = result.Where(x => x.IsOdradjen == resourceParameters.IsOdradjen.Value);
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }

                if (await result.AnyAsync())
                {
                    if (resourceParameters.OnlyZakazani)
                        result = result.Where(x => !x.IsOdradjen);
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }
            }
            result = result.OrderBy(x => x.IsOdradjen ? 1 : 0).ThenBy(x => x.DatumPregleda);

            return await base.FilterAndPrepare(result, resourceParameters);
        }

        /// <summary>
        /// Returns Pregled if Doktor is authorized for it
        /// </summary>
        /// <returns></returns>
        private async Task<ServiceResult> GetPregledForManipulation(int id)
        {
            var doktor = await _authService.GetCurrentLoggedInDoktor();
            if (doktor == null)
                return ServiceResult.Forbidden($"Samo doktori mogu vrsiti izmene pregleda.");

            var pregledFromDb = await _dbContext.Pregledi.FindAsync(id);
            if (pregledFromDb == null)
                return ServiceResult.NotFound($"Pregled sa ID-em {id} nije pronadjen.");

            if (pregledFromDb.DoktorId != doktor.Id)
                return ServiceResult.Forbidden($"Nemate permisije za izmenu pregleda koje je kreirao drugi doktor.");

            return ServiceResult.OK(pregledFromDb);
        }

        public override async Task<bool> AuthorizePacijentForGetById(int id)
        {
            var pacijent = await _authService.GetCurrentLoggedInPacijent();
            if (pacijent == null)
                return false;

            return await _dbContext.Pregledi.AnyAsync(x => x.PacijentId == pacijent.Id && x.Id == id);
        }

        private async Task<ServiceResult> ValidateModel(PregledUpsertDto dto)
        {
            if (await _dbContext.Pregledi.AnyAsync(x => x.ZahtevZaPregledId == dto.ZahtevZaPregledId))
                return ServiceResult.BadRequest($"Na zahtev sa ID-em {dto.ZahtevZaPregledId}, vec je odradjen pregled.");

            if (!await _dbContext.Pacijenti.AnyAsync(x => x.Id == dto.PacijentId))
                return ServiceResult.NotFound($"Pacijent sa ID-em {dto.PacijentId} nije pronadjen.");

            if (!await _dbContext.ZahteviZaPregled.AnyAsync(x => x.Id == dto.ZahtevZaPregledId))
                return ServiceResult.NotFound($"Zahtev za pregled sa ID-em {dto.ZahtevZaPregledId} nije pronadjen.");

            if (dto.DatumPregleda.Year < DateTime.Now.Year)
                return ServiceResult.BadRequest($"Datum pregleda nije validan.");

            return ServiceResult.WithStatusCode(HttpStatusCode.OK);
        }
    }
}