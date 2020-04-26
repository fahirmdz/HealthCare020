using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class DoktorService : BaseCRUDService<DoktorDtoLL, DoktorDtoEL, DoktorResourceParameters, Doktor, DoktorUpsertDto, DoktorUpsertDto>
    {
        private readonly IRadnikService _radnikService;

        public DoktorService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService, IRadnikService radnikService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
            _radnikService = radnikService;
        }

        public override IQueryable<Doktor> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Doktori
                .Include(x=>x.NaucnaOblast)
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

        public override async Task<DoktorDtoLL> Insert(DoktorUpsertDto request)
        {
            if(!await _dbContext.NaucneOblasti.AnyAsync(x=>x.Id==request.NaucnaOblastId))
                throw new NotFoundException($"Naucna oblast sa ID-em {request.NaucnaOblastId} nije pronadjena.");

            var radnikInsert = await _radnikService.Insert(request);

            var entity = _mapper.Map<Doktor>(request);
            entity.RadnikId = radnikInsert.Id;

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DoktorDtoLL>(entity);
        }

        public override async Task<DoktorDtoLL> Update(int id, DoktorUpsertDto dtoForUpdate)
        {
            var radnikPrijemFromDb = await _dbContext.RadniciPrijem
                .Include(x => x.Radnik)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (radnikPrijemFromDb == null)
                throw new NotFoundException($"Doktor sa ID-em {id} nije pronadjen");

            if(!await _dbContext.NaucneOblasti.AnyAsync(x=>x.Id==dtoForUpdate.NaucnaOblastId))
                throw new NotFoundException($"Naucna oblast sa ID-em {dtoForUpdate.NaucnaOblastId} nije pronadjena.");

            _mapper.Map(dtoForUpdate, radnikPrijemFromDb.Radnik);
            var radnikUpdated = await _radnikService.Update(radnikPrijemFromDb.RadnikId, dtoForUpdate);

            return _mapper.Map<DoktorDtoLL>(radnikPrijemFromDb);
        }

        public override async Task Delete(int id)
        {
            var entity = await _dbContext.RadniciPrijem.FindAsync(id);

            await Task.Run(() =>
            {
                if (entity == null)
                    throw new NotFoundException($"Doktor sa ID-em {id} nije pronadjen.");
                _radnikService.Delete(id);

                _dbContext.Remove(entity);
            });

            await _dbContext.SaveChangesAsync();
        }

        public override async Task<PagedList<Doktor>> FilterAndPrepare(IQueryable<Doktor> result, DoktorResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (!string.IsNullOrEmpty(resourceParameters.Ime))
                result = result.Where(x => x.Radnik.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.Ime.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Prezime))
                result = result.Where(x => x.Radnik.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.Prezime.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Username))
                result = result.Where(x => x.Radnik.KorisnickiNalog.Username.ToLower().StartsWith(resourceParameters.Username.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.NaucnaOblast))
                result = result.Where(x => x.NaucnaOblast.Naziv.ToLower().StartsWith(resourceParameters.NaucnaOblast.ToLower()));

            result = result.Include(x => x.Radnik.LicniPodaci);

            if (resourceParameters.EagerLoaded)
                PropertyCheck<DoktorDtoEL>(resourceParameters.Fields, resourceParameters.OrderBy);
            
            var pagedResult = PagedList<Doktor>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedResult;
        }
    }
}