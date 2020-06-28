using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Enums;
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
    public class ZahtevZaPregledService : BaseCRUDService<ZahtevZaPregledDtoLL, ZahtevZaPregledDtoEL, ZahtevZaPregledResourceParameters, ZahtevZaPregled, ZahtevZaPregledUpsertDto, ZahtevZaPregledUpsertDto>
    {
        public ZahtevZaPregledService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
        }

        public override IQueryable<ZahtevZaPregled> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Set<ZahtevZaPregled>()
                .Include(x => x.Pacijent)
                .ThenInclude(x => x.ZdravstvenaKnjizica)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .Include(x => x.Doktor)
                .ThenInclude(x => x.Radnik)
                .ThenInclude(x => x.LicniPodaci)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<List<int>> Count(int MonthsCount)
        {
            if (MonthsCount == 0)
                return new List<int> { await _dbContext.ZahteviZaPregled.CountAsync() };

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
                monthsCountsList.Add(await _dbContext.ZahteviZaPregled.CountAsync(x => x.DatumVreme.Year == year && x.DatumVreme.Month == startMonth));
                startMonth++;
            }

            return monthsCountsList;
        }

        public override async Task<ServiceResult> Insert(ZahtevZaPregledUpsertDto dtoForCreation)
        {
            var user = await _authService.LoggedInUser();
            if (user == null)
                return ServiceResult.Unauthorized();

            var pacijent = await _dbContext.Pacijenti.FirstOrDefaultAsync(x => x.KorisnickiNalogId == user.Id);
            if (pacijent == null)
                return ServiceResult.Forbidden($"Samo pacijenti mogu kreirati zahtev za pregled.");

            if (await ValidateModel(dtoForCreation) is { } result && !result.Succeeded)
                return ServiceResult.WithStatusCode(result.StatusCode, result.Message);

            var entity = new ZahtevZaPregled
            {
                DoktorId = dtoForCreation.DoktorId,
                PacijentId = pacijent.Id,
                UputnicaId = dtoForCreation.UputnicaId,
                Napomena = dtoForCreation.Napomena,
                DatumVreme = DateTime.Now
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(_mapper.Map<ZahtevZaPregledDtoLL>(entity));
        }

        public override async Task<ServiceResult> Update(int id, ZahtevZaPregledUpsertDto dtoForUpdate)
        {
            if (!await _authService.CurrentUserIsInRoleAsync(RoleType.Pacijent))
                return ServiceResult.Forbidden($"Samo pacijenti imaju pristup ovom resursu.");

            var zahtevFromDb = await _dbContext.ZahteviZaPregled.FindAsync(id);

            if (zahtevFromDb == null)
                return new ServiceResult();

            if (await ValidateModel(dtoForUpdate) is { } result && !result.Succeeded)
                return ServiceResult.WithStatusCode(result.StatusCode, result.Message);

            _mapper.Map(dtoForUpdate, zahtevFromDb);

            await Task.Run(() =>
            {
                _dbContext.ZahteviZaPregled.Update(zahtevFromDb);
            });
            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(_mapper.Map<ZahtevZaPregledDtoLL>(zahtevFromDb));
        }

        public override async Task<PagedList<ZahtevZaPregled>> FilterAndPrepare(IQueryable<ZahtevZaPregled> result, ZahtevZaPregledResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (resourceParameters != null)
            {
                if (!string.IsNullOrEmpty(resourceParameters.PacijentIme))
                {
                    var imeForSearch = resourceParameters.PacijentIme.ToLower();
                    if (!await result.AnyAsync(x =>
                        x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.Ime.ToLower()
                            .Contains(imeForSearch)))
                    {
                        result = result.Where(x =>
                            x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.Prezime.ToLower()
                                .Contains(resourceParameters.PacijentPrezime.ToLower()));
                    }
                    else
                    {
                        result = result.Where(x =>
                            x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.Ime.ToLower()
                                .Contains(imeForSearch));
                    }
                }

                if (await result.AnyAsync() && (string.IsNullOrWhiteSpace(resourceParameters.PacijentIme) && !string.IsNullOrEmpty(resourceParameters.PacijentPrezime)))
                {
                    result = result.Where(x =>
                        x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.Prezime.ToLower()
                            .Contains(resourceParameters.PacijentPrezime.ToLower()));
                }

                if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.DoktorIme))
                {
                    result = result.Where(x =>
                        x.Doktor.Radnik.LicniPodaci.Ime.ToLower().Contains(resourceParameters.DoktorIme.ToLower()));
                }

                if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.DoktorPrezime))
                {
                    result = result.Where(x =>
                        x.Doktor.Radnik.LicniPodaci.Prezime.ToLower()
                            .Contains(resourceParameters.DoktorPrezime.ToLower()));
                }

                if (await result.AnyAsync() && resourceParameters.PacijentId.HasValue)
                {
                    result = result.Where(x => x.PacijentId == resourceParameters.PacijentId);
                }

                if (await result.AnyAsync() && resourceParameters.DoktorId.HasValue)
                {
                    result = result.Where(x => x.DoktorId == resourceParameters.DoktorId);
                }

                if (await result.AnyAsync() && resourceParameters.UputnicaId.HasValue)
                {
                    result = result.Where(x => x.UputnicaId == resourceParameters.UputnicaId);
                }

                if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.Napomena))
                {
                    result = result.Where(x => x.Napomena.ToLower().Contains(resourceParameters.Napomena.ToLower()));
                }
            }

            //CONSTRAINT -> Pacijent moze samo svoje zahteve za pregled videti
            if (_authService.UserIsPacijent() && await _authService.GetCurrentLoggedInPacijent() is { } pacijent)
                result = result.Where(x => x.PacijentId == pacijent.Id);

            if (await result.AnyAsync())
            {
                result = result.OrderBy(x=>x.IsObradjen?1:0).ThenBy(x => x.DatumVreme);
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }

        public override async Task<bool> AuthorizePacijentForGetById(int id)
        {
            var pacijent = await _authService.GetCurrentLoggedInPacijent();
            if (pacijent == null)
                return false;

            return await _dbContext.ZahteviZaPregled.AnyAsync(x => x.PacijentId == pacijent.Id && x.Id == id);
        }

        private async Task<ServiceResult> ValidateModel(ZahtevZaPregledUpsertDto dto)
        {
            if (dto.UputnicaId.HasValue && await _dbContext.ZahteviZaPregled.AnyAsync(x => x.UputnicaId == dto.UputnicaId))
                return ServiceResult.BadRequest($"Vec postoji zahtev za pregled povezan sa uputnicom {dto.UputnicaId}.");

            if (!await _dbContext.Doktori.AnyAsync(x => x.Id == dto.DoktorId))
                return ServiceResult.NotFound($"Doktor sa ID-em {dto.DoktorId} nije pronadjen.");

            if (dto.UputnicaId.HasValue && !await _dbContext.Uputnice.AnyAsync(x => x.Id == dto.UputnicaId))
                return ServiceResult.NotFound($"Uputnica sa ID-em {dto.DoktorId} nije pronadjena.");

            return ServiceResult.WithStatusCode(HttpStatusCode.OK);
        }
    }
}