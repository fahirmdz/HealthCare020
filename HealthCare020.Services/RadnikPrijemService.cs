using System;
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
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class RadnikPrijemService : BaseCRUDService<RadnikPrijemDto, RadnikPrijemDtoEagerLoaded, RadnikPrijemResourceParameters, RadnikPrijem, RadnikPrijemUpsertDto, RadnikPrijemUpsertDto>
    {
        private readonly IRadnikService _radnikService;

        public RadnikPrijemService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService, 
            IRadnikService radnikService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
            _radnikService = radnikService;
        }

        public override IQueryable<RadnikPrijem> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.RadniciPrijem
                .Include(x=>x.Radnik)
                .ThenInclude(x => x.KorisnickiNalog)
                .Include(x=>x.Radnik)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .Include(x=>x.Radnik)
                .ThenInclude(x => x.StacionarnoOdeljenje)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<RadnikPrijemDto> Insert(RadnikPrijemUpsertDto request)
        {
            var radnikInsert = await _radnikService.Insert(request);

            var entity = new RadnikPrijem {  RadnikId=radnikInsert.Id };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<RadnikPrijemDto>(entity).Map(_mapper,entity.Radnik);
        }

        public override RadnikPrijemDto Update(int id, RadnikPrijemUpsertDto dtoForUpdate)
        {
            var radnikPrijemFromDb =  _dbContext.RadniciPrijem
                .Include(x=>x.Radnik)
                .FirstOrDefault(x=>x.Id==id);

            if (radnikPrijemFromDb == null)
                throw new NotFoundException($"Radnik sa ID-em {id} nije pronadjen");

            _mapper.Map(dtoForUpdate, radnikPrijemFromDb.Radnik);
            var radnikUpdated = _radnikService.Update(radnikPrijemFromDb.RadnikId, dtoForUpdate);

            return _mapper.Map<RadnikPrijemDto>(radnikPrijemFromDb);
        }

        public override void Delete(int id)
        {
            var entity = _dbContext.RadniciPrijem.Find(id);

            if(entity==null)
                throw new NotFoundException($"RadnikPrijem sa ID-em {id} nije pronadjen.");
            _radnikService.Delete(id);

            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public override async Task<PagedList<RadnikPrijem>> FilterAndPrepare(IQueryable<RadnikPrijem> result, RadnikPrijemResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (!string.IsNullOrEmpty(resourceParameters.Ime))
                result = result.Where(x => x.Radnik.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.Ime.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Prezime))
                result = result.Where(x => x.Radnik.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.Prezime.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Username))
                result = result.Where(x => x.Radnik.KorisnickiNalog.Username.ToLower().StartsWith(resourceParameters.Username.ToLower()));

            result = result.Include(x => x.Radnik.LicniPodaci);

            if (resourceParameters.EagerLoaded)
                PropertyCheck<RadnikPrijemDtoEagerLoaded>(resourceParameters.Fields, resourceParameters.OrderBy);

            var pagedResult = PagedList<RadnikPrijem>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedResult;
        }

        public override IEnumerable<ExpandoObject> PrepareDataForClient(IEnumerable<RadnikPrijem> data, RadnikPrijemResourceParameters resourceParameters)
        {
            if (ShouldEagerLoad(resourceParameters))
            {
                var dataWithFinalTypeEagerLoaded = data.Select(x => _mapper.Map<RadnikPrijemDtoEagerLoaded>(x)
                     .Map(_mapper,x.Radnik)
                     .Map(_mapper, x.Radnik.LicniPodaci)
                     .Map(_mapper, x.Radnik.KorisnickiNalog)
                     .Map(_mapper, x.Radnik.StacionarnoOdeljenje));

                if (!string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
                {
                    var propertyMappingDictionary =
                        _propertyMappingService.GetPropertyMapping<RadnikPrijemDtoEagerLoaded, RadnikPrijem>();

                    dataWithFinalTypeEagerLoaded = dataWithFinalTypeEagerLoaded.AsQueryable()
                        .ApplySort(resourceParameters.OrderBy, propertyMappingDictionary);
                }

                return dataWithFinalTypeEagerLoaded.ShapeData(resourceParameters.Fields);
            }

            var dataWithFinalTypeLazyLoaded = data.Select(x => _mapper.Map<RadnikPrijemDto>(x).Map(_mapper,x.Radnik));

            if (!string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
            {
                var propertyMappingDictionary =
                    _propertyMappingService.GetPropertyMapping<RadnikPrijemDto, RadnikPrijem>();

                dataWithFinalTypeLazyLoaded = dataWithFinalTypeLazyLoaded.AsQueryable()
                    .ApplySort(resourceParameters.OrderBy, propertyMappingDictionary);
            }

            return dataWithFinalTypeLazyLoaded.ShapeData(resourceParameters.Fields);
        }

        public override T PrepareDataForClient<T>(RadnikPrijem data, RadnikPrijemResourceParameters resourceParameters)
        {
            return _mapper.Map<T>(data).Map(_mapper, data.Radnik.LicniPodaci).Map(_mapper, data.Radnik.KorisnickiNalog).Map(_mapper, data.Radnik.StacionarnoOdeljenje);
        }
    }
}