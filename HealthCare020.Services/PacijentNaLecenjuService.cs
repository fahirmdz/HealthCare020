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
    public class PacijentNaLecenjuService : BaseCRUDService<PacijentNaLecenjuDtoLL, PacijentNaLecenjuDtoEL, PacijentNaLecenjuResourceParameters, PacijentNaLecenju, PacijentNaLecenjuUpsertDto, PacijentNaLecenjuUpsertDto>
    {
        private ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters,
            LicniPodaciUpsertDto, LicniPodaciUpsertDto> _licniPodaciService;

        public PacijentNaLecenjuService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService,
            ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> licniPodaciService)
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
            _licniPodaciService = licniPodaciService;
        }

        public override IQueryable<PacijentNaLecenju> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.PacijentiNaLecenju
                .Include(x => x.StacionarnoOdeljenje)
                .Include(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .AsQueryable();

            return id.HasValue ? result = result.Where(x => x.Id == id) : result;
        }

        public override async Task<ServiceResult> Insert(PacijentNaLecenjuUpsertDto dtoForCreation)
        {
            if (!await _dbContext.StacionarnaOdeljenja.AnyAsync(x => x.Id == dtoForCreation.StacionarnoOdeljenjeId))
                return ServiceResult.NotFound($"Stacionarno odeljenje sa ID-em {dtoForCreation.StacionarnoOdeljenjeId} nije pronadjeno.");

            var licniPodaciInsertResult = await _licniPodaciService.Insert(dtoForCreation.LicniPodaci);
            if (!licniPodaciInsertResult.Succeeded)
                return ServiceResult.WithStatusCode(licniPodaciInsertResult.StatusCode, licniPodaciInsertResult.Message);

            var pacijentNaLecenju = new PacijentNaLecenju
            {
                LicniPodaciId = ((LicniPodaciDto)licniPodaciInsertResult.Data).Id,
                StacionarnoOdeljenjeId = dtoForCreation.StacionarnoOdeljenjeId
            };

            await _dbContext.AddAsync(pacijentNaLecenju);
            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(_mapper.Map<PacijentNaLecenjuDtoLL>(pacijentNaLecenju));
        }

        public override async Task<ServiceResult> Update(int id, PacijentNaLecenjuUpsertDto dtoForUpdate)
        {
            var pacijentNaLecenjuFromDb = await _dbContext.PacijentiNaLecenju
                .Include(x => x.LicniPodaci)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pacijentNaLecenjuFromDb == null)
                return ServiceResult.NotFound($"Pacijent na lecenju sa ID-em {id} nije pronadjen.");

            if (pacijentNaLecenjuFromDb.StacionarnoOdeljenjeId != dtoForUpdate.StacionarnoOdeljenjeId)
            {
                if (!await _dbContext.StacionarnaOdeljenja.AnyAsync(x => x.Id == dtoForUpdate.StacionarnoOdeljenjeId))
                    return ServiceResult.NotFound(
                        $"Stacionarno odeljenje sa ID-em {dtoForUpdate.StacionarnoOdeljenjeId} nije pronadjeno.");

                pacijentNaLecenjuFromDb.StacionarnoOdeljenjeId = dtoForUpdate.StacionarnoOdeljenjeId;
                await _dbContext.SaveChangesAsync();
            }

            var licniPodaciUpdateResult = await _licniPodaciService.Update(pacijentNaLecenjuFromDb.LicniPodaciId, dtoForUpdate.LicniPodaci);
            if (!licniPodaciUpdateResult.Succeeded)
                return ServiceResult.WithStatusCode(licniPodaciUpdateResult.StatusCode, licniPodaciUpdateResult.Message);

            return ServiceResult.OK(
                _mapper.Map<PacijentNaLecenjuDtoLL>(pacijentNaLecenjuFromDb));
        }

        public override async Task<ServiceResult> Delete(int id)
        {
            var pacijentNaLecenjuFromDb = await _dbContext.PacijentiNaLecenju
                .Include(x => x.LicniPodaci)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pacijentNaLecenjuFromDb == null)
                return ServiceResult.NotFound($"Pacijent na lecenju sa ID-em {id} nije pronadjen.");

            await Task.Run(() =>
            {
                _dbContext.Remove(pacijentNaLecenjuFromDb.LicniPodaci);
                _dbContext.Remove(pacijentNaLecenjuFromDb);
            });

            await _dbContext.SaveChangesAsync();

            return ServiceResult.NoContent();
        }

        public override async Task<PagedList<PacijentNaLecenju>> FilterAndPrepare(IQueryable<PacijentNaLecenju> result, PacijentNaLecenjuResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if(resourceParameters!=null)
            {
                if (!string.IsNullOrWhiteSpace(resourceParameters.Ime))
                    result = result.Where(x =>
                        x.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.Ime.Trim().ToLower()));

                if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.Prezime))
                    result = result.Where(x =>
                        x.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.Prezime.Trim().ToLower()));

                if (await result.AnyAsync() && resourceParameters.StacionarnoOdeljenjeId.HasValue)
                    result = result.Where(x => x.StacionarnoOdeljenjeId == resourceParameters.StacionarnoOdeljenjeId);
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}