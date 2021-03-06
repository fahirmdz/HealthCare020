﻿using AutoMapper;
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
using System.Linq.Expressions;
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
                return new List<int> { await _dbContext.Set<ZahtevZaPregled>().CountAsync() };

            int startMonth = DateTime.Now.Month - MonthsCount+1;
            int firstMonth = DateTime.Now.Month - MonthsCount+1;
            int lastMonth = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            if (startMonth < 1)
            {
                startMonth += 12;
                year = DateTime.Now.Year - 1;
            }

            var daysOfStartMonth = DateTime.DaysInMonth(year, startMonth);
            var dayInMonth = DateTime.Now.Day;
            var lastDayOfLastMonthToInclude = dayInMonth==1?DateTime.DaysInMonth(year,DateTime.Now.Month):dayInMonth;
            var startDayInFirstMonthToInclude = dayInMonth==1?1:dayInMonth;
            if (startDayInFirstMonthToInclude > daysOfStartMonth)
                startDayInFirstMonthToInclude = daysOfStartMonth;



            var monthsCountsList = new List<int>();

            for (int i = 0; i < MonthsCount; i++)
            {
                if (startMonth > 12)
                {
                    startMonth = 1;
                    year++;
                }
                monthsCountsList.Add(await _dbContext.Set<ZahtevZaPregled>().CountAsync(x => x.DatumVreme.Year == year
                                                                                     && x.DatumVreme.Month == startMonth
                                                                                     && (startMonth != firstMonth || x.DatumVreme.Day >= startDayInFirstMonthToInclude)
                                                                                     && (startMonth != lastMonth || x.DatumVreme.Day <= lastDayOfLastMonthToInclude)));
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
                return ServiceResult.Forbidden("Samo pacijenti mogu kreirati zahtev za pregled.");

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
                return ServiceResult.Forbidden("Samo pacijenti imaju pristup ovom resursu.");

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

            //CONSTRAINT -> Pacijent moze videti samo zahteve za pregled koje je on kreirao
            if (_authService.UserIsPacijent() && await _authService.GetCurrentLoggedInPacijent() is { } pacijent)
                result = result.Where(x => x.PacijentId == pacijent.Id);
            //CONSTRAINT -> Doktor moze videti samo zahteve za pregled kod njega
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
                    if (resourceParameters.UputnicaId.HasValue)
                        result = result.Where(x => x.UputnicaId == resourceParameters.UputnicaId);
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }

                if (await result.AnyAsync())
                {
                    if (!string.IsNullOrWhiteSpace(resourceParameters.Napomena))
                        result = result.Where(x => x.Napomena.ToLower().Contains(resourceParameters.Napomena.ToLower()));
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }
            }

            result = result.OrderByDescending(x => x.DatumVreme);

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