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
    public class DoktorService : BaseCRUDService<DoktorDtoLL, DoktorDtoEL, DoktorResourceParameters, Doktor, DoktorUpsertDto, DoktorUpsertDto>
    {
        private readonly IRadnikService _radnikService;

        public DoktorService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IRadnikService radnikService,
            IHttpContextAccessor httpContextAccessor) : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor)
        {
            _radnikService = radnikService;
        }

        public override IQueryable<Doktor> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Doktori
                .Include(x => x.NaucnaOblast)
                .Include(x => x.Radnik)
                .ThenInclude(x => x.KorisnickiNalog)
                .Include(x => x.Radnik)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .Include(x => x.Radnik)
                .ThenInclude(x => x.StacionarnoOdeljenje)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult<DoktorDtoLL>> Insert(DoktorUpsertDto request)
        {
            if (!await _dbContext.NaucneOblasti.AnyAsync(x => x.Id == request.NaucnaOblastId))
                return new ServiceResult<DoktorDtoLL>(HttpStatusCode.NotFound, $"Naucna oblast sa ID-em {request.NaucnaOblastId} nije pronadjena.");

            var radnikInsert = await _radnikService.Insert(request);

            var entity = _mapper.Map<Doktor>(request);
            entity.RadnikId = radnikInsert.Data.Id;

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult<DoktorDtoLL>(_mapper.Map<DoktorDtoLL>(entity));
        }

        public override async Task<ServiceResult<DoktorDtoLL>> Update(int id, DoktorUpsertDto dtoForUpdate)
        {
            var radnikPrijemFromDb = await _dbContext.RadniciPrijem
                .Include(x => x.Radnik)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (radnikPrijemFromDb == null)
                return new ServiceResult<DoktorDtoLL>(HttpStatusCode.NotFound, $"Doktor sa ID-em {id} nije pronadjen");

            if (!await _dbContext.NaucneOblasti.AnyAsync(x => x.Id == dtoForUpdate.NaucnaOblastId))
                return new ServiceResult<DoktorDtoLL>(HttpStatusCode.NotFound, $"Naucna oblast sa ID-em {dtoForUpdate.NaucnaOblastId} nije pronadjena.");

            _mapper.Map(dtoForUpdate, radnikPrijemFromDb.Radnik);
            var radnikUpdated = await _radnikService.Update(radnikPrijemFromDb.RadnikId, dtoForUpdate);

            return new ServiceResult<DoktorDtoLL>(_mapper.Map<DoktorDtoLL>(radnikPrijemFromDb));
        }

        public override async Task<ServiceResult<DoktorDtoLL>> Delete(int id)
        {
            var entity = await _dbContext.RadniciPrijem.FindAsync(id);
            if (entity == null)
                return new ServiceResult<DoktorDtoLL>(HttpStatusCode.NotFound, $"Doktor sa ID-em {id} nije pronadjen.");

            await Task.Run(() =>
            {
                _radnikService.Delete(id);

                _dbContext.Remove(entity);
            });

            await _dbContext.SaveChangesAsync();

            return new ServiceResult<DoktorDtoLL>();
        }

        public override async Task<PagedList<Doktor>> FilterAndPrepare(IQueryable<Doktor> result, DoktorResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (!string.IsNullOrEmpty(resourceParameters.Ime))
                result = result.Where(x => x.Radnik.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.Ime.ToLower()));

            if (!string.IsNullOrEmpty(resourceParameters.Prezime) && await result.AnyAsync())
                result = result.Where(x => x.Radnik.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.Prezime.ToLower()));

            if (!string.IsNullOrEmpty(resourceParameters.Username) && await result.AnyAsync())
                result = result.Where(x => x.Radnik.KorisnickiNalog.Username.ToLower().StartsWith(resourceParameters.Username.ToLower()));

            if (!string.IsNullOrEmpty(resourceParameters.NaucnaOblast) && await result.AnyAsync())
                result = result.Where(x => x.NaucnaOblast.Naziv.ToLower().StartsWith(resourceParameters.NaucnaOblast.ToLower()));

            result = result.Include(x => x.Radnik.LicniPodaci);

            if (resourceParameters.EagerLoaded)
                PropertyCheck<DoktorDtoEL>(resourceParameters.OrderBy);

            var pagedResult = PagedList<Doktor>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedResult;
        }
    }
}