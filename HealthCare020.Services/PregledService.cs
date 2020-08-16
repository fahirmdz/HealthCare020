using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using HealthCare020.Services.Properties;
using HealthCare020.Services.ServiceModels.Recommender;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class PregledService : BaseCRUDService<PregledDtoLL, PregledDtoEL, PregledResourceParameters, Pregled, PregledUpsertDto, PregledUpsertDto>, IPregledService
    {
        private static readonly string MODEL_FOLDER_PATH = Path.Combine(Environment.CurrentDirectory, "Data");
        private static readonly string MODEL_PATH = Path.Combine(Environment.CurrentDirectory, "Data",Resources.MLModelName);
        private static readonly MLContext mlContext = new MLContext(1);
        private static readonly uint[] TimeOfDayHalfsUids = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }; // => Starts at 9 AM and every iteration is 30 minutes to add

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
                return new List<int> { await _dbContext.Set<Pregled>().CountAsync() };

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
                monthsCountsList.Add(await _dbContext.Set<Pregled>().CountAsync(x => x.DatumPregleda.Year == year
                                                                                             && x.DatumPregleda.Month == startMonth
                                                                                             && (startMonth != firstMonth || x.DatumPregleda.Day >= startDayInFirstMonthToInclude)
                                                                                             && (startMonth != lastMonth || x.DatumPregleda.Day <= lastDayOfLastMonthToInclude)));
                startMonth++;
            }

            return monthsCountsList;
        }

        public override async Task<ServiceResult> Insert(PregledUpsertDto dtoForCreation)
        {
            var doktor = await _authService.GetCurrentLoggedInDoktor();
            if (doktor == null)
                return ServiceResult.Forbidden("Samo doktori mogu kreirati novi pregled.");
            if (await ValidateModel(dtoForCreation) is { } result && !result.Succeeded)
                return ServiceResult.WithStatusCode(result.StatusCode, result.Message);

            if (await _dbContext.Pregledi.AnyAsync(x => x.DatumPregleda == dtoForCreation.DatumPregleda))
            {
                return ServiceResult.BadRequest($"Termin {dtoForCreation.DatumPregleda:g} je već zauzet");
            }
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

            var pacijent = await _dbContext.Pacijenti
                .Include(x => x.ZdravstvenaKnjizica)
                .ThenInclude(x => x.LicniPodaci)
                .FirstOrDefaultAsync(x => x.Id == entity.PacijentId);

            await AddAndTrainModel(new GodisteVrijemeIdModel
            {
                Godiste = (uint)pacijent.ZdravstvenaKnjizica.LicniPodaci.DatumRodjenja.Year,
                VrijemeUid = GetVrijemeUid(entity.DatumPregleda.TimeOfDay.Minutes)
            });

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

            if (pregledFromDb == null)
                return ServiceResult.NotFound();

            if (await _dbContext.LekarskaUverenja.AnyAsync(x => x.PregledId == id))
                return ServiceResult.BadRequest("Ne mozete brisati pregled sve dok ima lekarskih uverenja povezanih sa ovim pregledom.");

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
                return ServiceResult.Forbidden("Samo doktori mogu vrsiti izmene pregleda.");

            var pregledFromDb = await _dbContext.Pregledi.FindAsync(id);
            if (pregledFromDb == null)
                return ServiceResult.NotFound($"Pregled sa ID-em {id} nije pronadjen.");

            if (pregledFromDb.DoktorId != doktor.Id)
                return ServiceResult.Forbidden("Nemate permisije za izmenu pregleda koje je kreirao drugi doktor.");

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
                return ServiceResult.BadRequest("Datum pregleda nije validan.");

            return ServiceResult.WithStatusCode(HttpStatusCode.OK);
        }

        public async Task<DateTime> GetRecommendedVrijemePregleda(int godistePacijenta)
        {
            var recommendedMinutesToAdd = await RecommendTimeForPregled(godistePacijenta);
            var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTime = dateTime.AddHours(9);//POCETAK RADNOG VREMENA

            dateTime = dateTime.AddMinutes(recommendedMinutesToAdd);
            if (dateTime.Hour >= 16)
            {
                dateTime = dateTime.AddHours(17); // Pocetak radnog vremena 9AM
            }

            while (await _dbContext.Pregledi.AnyAsync(x => x.DatumPregleda == dateTime))
            {
                dateTime = dateTime.AddMinutes(30);
                if (dateTime.Hour >= 16)
                {
                    dateTime = dateTime.AddHours(17); // Pocetak radnog vremena 9AM
                }
            }

            return dateTime;
        }

        //====================RECOMMENDATION SYSTEM====================

        #region RecommendationSystem

        /// <summary>
        /// Recommend time for Pregled for specific year of birth
        /// </summary>
        /// <param name="godistePacijenta"></param>
        /// <returns>Minutes to add from 9AM for specific day</returns>
        public async Task<uint> RecommendTimeForPregled(int godistePacijenta)
        {
            ITransformer model;
            if (Directory.Exists(MODEL_FOLDER_PATH) && File.Exists(MODEL_PATH))
            {
                model = mlContext.Model.Load(MODEL_PATH, out _);
            }
            else
            {
                model = await CreateModel();
            }

            var predictionResult = new List<Tuple<uint, float>>();
            var predictionEngine = mlContext.Model.CreatePredictionEngine<GodisteVrijemeIdModel, PredictionResult>(model);

            foreach (var Uid in TimeOfDayHalfsUids)
            {
                var prediction = predictionEngine.Predict(new GodisteVrijemeIdModel
                {
                    Godiste = (uint)godistePacijenta,
                    VrijemeUid = Uid
                });

                predictionResult.Add(new Tuple<uint, float>(Uid, prediction.Score));
            }

            predictionResult = predictionResult.OrderByDescending(x => x.Item2).ToList(); //Highest score on top
            foreach (var predict in predictionResult)
            {
                if (predict != null)
                    Console.WriteLine($@"{predict.Item1} => {predict.Item2}");
            }

            Console.WriteLine();
            return GetMinutesToAddBasedOnVrijemeUid(predictionResult.First().Item1);
        }

        private async Task AddAndTrainModel(GodisteVrijemeIdModel toAdd)
        {
            await CreateModel(toAdd);
        }

        private async Task<ITransformer> CreateModel(GodisteVrijemeIdModel toAdd = null)
        {
            MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = nameof(GodisteVrijemeIdModel.Godiste),
                MatrixRowIndexColumnName = nameof(GodisteVrijemeIdModel.VrijemeUid),
                LabelColumnName = "Label",
                LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                Alpha = 0.01,
                Lambda = 0.025
            };

            var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

            var dataFromDb = await _dbContext.Pregledi.Select(x => new GodisteVrijemeIdModel
            {
                Godiste = (uint)x.Pacijent.ZdravstvenaKnjizica.LicniPodaci.DatumRodjenja.Year,
                VrijemeUid = x.VrijemePregledaUid
            }).ToListAsync();
            if (toAdd != null)
                dataFromDb.Add(toAdd);
            var dataView = mlContext.Data.LoadFromEnumerable(dataFromDb);

            var model = est.Fit(dataView);

            if (!Directory.Exists(MODEL_FOLDER_PATH))
                Directory.CreateDirectory(MODEL_FOLDER_PATH);
            mlContext.Model.Save(model, dataView.Schema, MODEL_PATH);
            return model;
        }

        #endregion RecommendationSystem

        //====================/RECOMMENDATION SYSTEM====================

        //====================HELPERS====================

        #region Helpers

        private static uint GetVrijemeUid(int minutes)
        {
            var temp = (uint)minutes - 539 / 30;
            return temp < 1 ? 1 : temp > TimeOfDayHalfsUids.Length ? (uint)TimeOfDayHalfsUids.Length - 1 : temp;
        }

        /// <summary>
        /// Vraca broj minuta u koji treba dodati na pocetak radnog vremena
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        private uint GetMinutesToAddBasedOnVrijemeUid(uint uid)
        {
            return uid * 30;
        }

        #endregion Helpers

        //===============================================
    }
}