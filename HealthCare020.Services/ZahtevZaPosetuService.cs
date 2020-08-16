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
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class ZahtevZaPosetuService : BaseCRUDService<ZahtevZaPosetuDtoLL, ZahtevZaPosetuDtoEL, ZahtevZaPosetuResourceParameters, ZahtevZaPosetu, ZahtevZaPosetuUpsertDto, ZahtevZaPosetuPatchDto>
    {
        private readonly ISMSGateway _smsGateway;

        public ZahtevZaPosetuService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService,
            ISMSGateway smsGateway)
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
            _smsGateway = smsGateway;
        }

        public override IQueryable<ZahtevZaPosetu> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.ZahteviZaPosetu
                .Include(x => x.PacijentNaLecenju)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .ThenInclude(x => x.Drzava)
                .Include(x => x.PacijentNaLecenju)
                .ThenInclude(x => x.StacionarnoOdeljenje)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<List<int>> Count(int MonthsCount)
        {
            if (MonthsCount == 0)
                return new List<int> { await _dbContext.Set<ZahtevZaPosetu>().CountAsync() };

            int startMonth = DateTime.Now.Month - MonthsCount + 1;
            int firstMonth = DateTime.Now.Month - MonthsCount + 1;
            int lastMonth = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            if (startMonth < 1)
            {
                startMonth += 12;
                year = DateTime.Now.Year - 1;
            }

            var daysOfStartMonth = DateTime.DaysInMonth(year, startMonth);
            var dayInMonth = DateTime.Now.Day;
            var lastDayOfLastMonthToInclude = dayInMonth == 1 ? DateTime.DaysInMonth(year, DateTime.Now.Month) : dayInMonth;
            var startDayInFirstMonthToInclude = dayInMonth == 1 ? 1 : dayInMonth;
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
                monthsCountsList.Add(await _dbContext.Set<ZahtevZaPosetu>().CountAsync(x =>x.IsObradjen &&  x.DatumVremeKreiranja.Year == year
                                                                                             && x.DatumVremeKreiranja.Month == startMonth
                                                                                             && (startMonth != firstMonth || x.DatumVremeKreiranja.Day >= startDayInFirstMonthToInclude)
                                                                                             && (startMonth != lastMonth || x.DatumVremeKreiranja.Day <= lastDayOfLastMonthToInclude)));
                startMonth++;
            }

            return monthsCountsList;
        }

        public override async Task<ServiceResult> Insert(ZahtevZaPosetuUpsertDto dtoForCreation)
        {
            if (!await _dbContext.PacijentiNaLecenju.AnyAsync(x => x.Id == dtoForCreation.PacijentNaLecenjuId))
                return ServiceResult.NotFound($"Pacijent na lecenju sa ID-em {dtoForCreation.PacijentNaLecenjuId} nije pronadjen.");

            var zahtevZaPosetu = new ZahtevZaPosetu
            {
                PacijentNaLecenjuId = dtoForCreation.PacijentNaLecenjuId,
                BrojTelefonaPosetioca = dtoForCreation.BrojTelefonaPosetioca.Trim(),
                DatumVremeKreiranja = DateTime.Now
            };

            await _dbContext.AddAsync(zahtevZaPosetu);
            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(_mapper.Map<ZahtevZaPosetuDtoLL>(zahtevZaPosetu));
        }

        public override async Task<ServiceResult> Update(int id, ZahtevZaPosetuPatchDto dtoForUpdate)
        {
            if (!await _dbContext.PacijentiNaLecenju.AnyAsync(x => x.Id == dtoForUpdate.PacijentNaLecenjuId))
                return ServiceResult.NotFound($"Pacijent na lecenju sa ID-em {dtoForUpdate.PacijentNaLecenjuId} nije pronadjen.");

            var zahtevFromDb = await _dbContext.ZahteviZaPosetu.FindAsync(id);
            _mapper.Map(dtoForUpdate, zahtevFromDb);
            zahtevFromDb.IsObradjen = dtoForUpdate.ZakazanoDatumVreme.HasValue;

            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(_mapper.Map<ZahtevZaPosetuDtoLL>(zahtevFromDb));
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

            return ServiceResult.NoContent();
        }

        public override async Task<PagedList<ZahtevZaPosetu>> FilterAndPrepare(IQueryable<ZahtevZaPosetu> result, ZahtevZaPosetuResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (resourceParameters != null)
            {
                if (!string.IsNullOrWhiteSpace(resourceParameters.PacijentIme))
                {
                    var nazivToSearch = resourceParameters.PacijentIme.ToLower();
                    if (await result.AnyAsync(x =>
                        x.PacijentNaLecenju.LicniPodaci.Ime.ToLower().StartsWith(nazivToSearch)))
                    {
                        result = result.Where(x =>
                            x.PacijentNaLecenju.LicniPodaci.Ime.ToLower().StartsWith(nazivToSearch));
                    }
                    else if (!string.IsNullOrWhiteSpace(resourceParameters.PacijentPrezime))
                    {
                        result = result.Where(x =>
                            x.PacijentNaLecenju.LicniPodaci.Ime.ToLower()
                                .StartsWith(resourceParameters.PacijentPrezime.ToLower()));
                    }
                }

                if (await result.AnyAsync())
                {
                    if (!string.IsNullOrWhiteSpace(resourceParameters.BrojTelefonaPosetioca))
                        result = result.Where(x =>
                            x.BrojTelefonaPosetioca.StartsWith(resourceParameters.BrojTelefonaPosetioca.Trim()));
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }

                if (await result.AnyAsync())
                {
                    if (resourceParameters.Datum.HasValue)
                        result = result.Where(x => x.IsObradjen && x.ZakazanoDatumVreme.Value.Date == resourceParameters.Datum.Value.Date);
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }

                if (await result.AnyAsync())
                {
                    if (resourceParameters.NeobradjeneOnly)
                        result = result.Where(x => !x.IsObradjen);
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }

                if (await result.AnyAsync())
                {
                    if (resourceParameters.ObradjeneOnly)
                        result = result.Where(x => x.IsObradjen);
                }
                else
                {
                    return await base.FilterAndPrepare(result, resourceParameters);
                }
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }

        public async Task<ServiceResult> AutoScheduling()
        {
            var zahteviZaPoseteDanas = _dbContext.ZahteviZaPosetu
                .Include(x => x.PacijentNaLecenju)
                .Where(x => !x.IsObradjen)
                .ToList();

            if (!zahteviZaPoseteDanas.Any())
                return ServiceResult.BadRequest("Trenutno nema zahteva za posete");

            var maxBrojPosetiocaPoPacijentu = 2;
            var dnevniBrojTerminaZaPosete = 2;

            var currentDate = DateTime.Now.Date;
            var prviTerminPosetePocetak = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 14, 30, 0);

            var drugiTerminPosetePocetak = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 18, 0, 0);

            if (DateTime.Now >= drugiTerminPosetePocetak)
                return ServiceResult.BadRequest("Vrijeme današnjih poseta je isteklo");

            if (DateTime.Now >= prviTerminPosetePocetak)
            {
                dnevniBrojTerminaZaPosete = 1;
            }
            bool IsPrviTerminPoseteIstekao = dnevniBrojTerminaZaPosete == 1;

            var pacijentiZaPosete = zahteviZaPoseteDanas
                .GroupBy(x => x.PacijentNaLecenjuId)
                .Select(x => x.Key)
                .ToList();

            zahteviZaPoseteDanas.ForEach(x => x.IsObradjen = true);

            foreach (var pacijentId in pacijentiZaPosete)
            {
                //==== SINGLE PACIJENT ITERATION ====

                var zahteviZaPacijenta = zahteviZaPoseteDanas.Where(x => x.PacijentNaLecenjuId == pacijentId).ToList();

                if (zahteviZaPacijenta.Count > maxBrojPosetiocaPoPacijentu * dnevniBrojTerminaZaPosete)
                {
                    //If the number of requests exceeds maxBrojPosetiocaPoPacijentu * dnevniBrojTerminaZaPosete
                    zahteviZaPacijenta = zahteviZaPacijenta
                        .OrderBy(x => x.DatumVremeKreiranja)
                        .Take(maxBrojPosetiocaPoPacijentu * dnevniBrojTerminaZaPosete)
                        .ToList();
                }

                var flagCounter = 0;
                var vrijeme = IsPrviTerminPoseteIstekao ? drugiTerminPosetePocetak : prviTerminPosetePocetak; // Ako je prvi istekao, bice dostupan samo drugi termin za posetu
                foreach (var zahtev in zahteviZaPacijenta)
                {
                    if (!IsPrviTerminPoseteIstekao && flagCounter == maxBrojPosetiocaPoPacijentu)
                        vrijeme = drugiTerminPosetePocetak;

                    zahtev.ZakazanoDatumVreme = vrijeme;

                    //SMS notifications
                    _smsGateway.Send(zahtev.BrojTelefonaPosetioca, "Zahtev za posetu koji ste poslali je odobren. Odobreno vreme je: " +
                                                                   $"{zahtev.ZakazanoDatumVreme.Value.ToString("G", CultureInfo.CreateSpecificCulture("de-De"))}");
                    flagCounter++;
                }

                await _dbContext.SaveChangesAsync();
            }

            return ServiceResult.OK();
        }
    }
}