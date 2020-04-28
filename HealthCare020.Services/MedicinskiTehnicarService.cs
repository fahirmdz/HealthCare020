using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Services
{
    public class MedicinskiTehnicarService : BaseCRUDService<MedicinskiTehnicarDtoLL, MedicinskiTehnicarDtoEL, MedicinskiTehnicarResourceParameters, MedicinskiTehnicar, MedicinskiTehnicarUpsertDto, MedicinskiTehnicarUpsertDto>
    {
        private readonly IRadnikService _radnikService;

        public MedicinskiTehnicarService(IMapper mapper,
            HealthCare020DbContext dbContext, 
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService, 
            IRadnikService radnikService,
            IHttpContextAccessor httpContextAccessor) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService,httpContextAccessor)
        {
            _radnikService = radnikService;
        }

         public override IQueryable<MedicinskiTehnicar> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.MedicinskiTehnicari
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

        public override async Task<MedicinskiTehnicarDtoLL> Insert(MedicinskiTehnicarUpsertDto request)
        {
            var radnikInsert = await _radnikService.Insert(request);

            var entity = new MedicinskiTehnicar { RadnikId = radnikInsert.Id };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<MedicinskiTehnicarDtoLL>(entity);
        }

        public override async Task<MedicinskiTehnicarDtoLL> Update(int id, MedicinskiTehnicarUpsertDto dtoForUpdate)
        {
            var radnikPrijemFromDb = await _dbContext.RadniciPrijem
                .Include(x => x.Radnik)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (radnikPrijemFromDb == null)
                throw new NotFoundException($"Medicinski tehnicar sa ID-em {id} nije pronadjen");

            _mapper.Map(dtoForUpdate, radnikPrijemFromDb.Radnik);
            var radnikUpdated = await _radnikService.Update(radnikPrijemFromDb.RadnikId, dtoForUpdate);

            return _mapper.Map<MedicinskiTehnicarDtoLL>(radnikPrijemFromDb);
        }

        public override async Task Delete(int id)
        {
            var entity = await _dbContext.RadniciPrijem.FindAsync(id);

            await Task.Run(() =>
            {
                if (entity == null)
                    throw new NotFoundException($"Medicinski tehnicar sa ID-em {id} nije pronadjen.");
                _radnikService.Delete(id);

                _dbContext.Remove(entity);
            });
            
            await _dbContext.SaveChangesAsync();
        }

        public override async Task<PagedList<MedicinskiTehnicar>> FilterAndPrepare(IQueryable<MedicinskiTehnicar> result, MedicinskiTehnicarResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (!string.IsNullOrEmpty(resourceParameters.Ime) && await result.AnyAsync())
                result = result.Where(x => x.Radnik.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.Ime.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Prezime))
                result = result.Where(x => x.Radnik.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.Prezime.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Username))
                result = result.Where(x => x.Radnik.KorisnickiNalog.Username.ToLower().StartsWith(resourceParameters.Username.ToLower()));

            result = result.Include(x => x.Radnik.LicniPodaci);

            if (resourceParameters.EagerLoaded)
                PropertyCheck<MedicinskiTehnicarDtoEL>(resourceParameters.Fields, resourceParameters.OrderBy);

            var pagedResult = PagedList<MedicinskiTehnicar>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedResult;
        }
       
    }
}