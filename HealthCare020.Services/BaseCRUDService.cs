using System;
using AutoMapper;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using HealthCare020.Services.Helpers;

namespace HealthCare020.Services
{
    public class BaseCRUDService<TDto, TDtoEagerLoaded, TResourceParameters, TEntity, TDtoForCreation, TDtoForUpdate> : BaseService<TDto, TDtoEagerLoaded,
        TResourceParameters, TEntity>, ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate>
        where TEntity : class
        where TResourceParameters : BaseResourceParameters
        where TDtoForUpdate : class
    {
        public BaseCRUDService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
        }

        public virtual async Task<TDto> Insert(TDtoForCreation dtoForCreation)
        {
            var entity = _mapper.Map<TEntity>(dtoForCreation);

            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> Update(int id, TDtoForUpdate dtoForUpdate)
        {
            var query = _dbContext.Set<TEntity>();
            var entity = await query.FindAsync(id);

            await Task.Run(() =>
           {
               if (entity == null)
                   throw new NotFoundException("Not Found");

               entity = _mapper.Map(dtoForUpdate, entity);

               query.Update(entity);
           });

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDtoForUpdate> GetAsUpdateDto(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);

            if(entity==null)
                throw new NotFoundException(string.Empty);

            return _mapper.Map<TDtoForUpdate>(entity);
        }

        public virtual async Task Delete(int id)
        {
            var query = _dbContext.Set<TEntity>();

            var entity = await query.FindAsync(id);

            await Task.Run(() =>
           {
               if (entity == null)
                   throw new NotFoundException("Not Found");

               query.Remove(entity);
           });
            await _dbContext.SaveChangesAsync();
        }
    }
}