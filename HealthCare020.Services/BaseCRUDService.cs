using AutoMapper;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class BaseCRUDService<TDto, TDtoEagerLoaded, TResourceParameters, TEntity, TDtoForCreation, TDtoForUpdate> : BaseService<TDto, TDtoEagerLoaded,
        TResourceParameters, TEntity>, ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate>
        where TEntity : class
        where TResourceParameters : BaseResourceParameters
        where TDtoForUpdate : class
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseCRUDService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual async Task<ServiceResult<TDto>> Insert(TDtoForCreation dtoForCreation)
        {
            var entity = _mapper.Map<TEntity>(dtoForCreation);

            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult<TDto>(_mapper.Map<TDto>(entity));
        }

        public virtual async Task<ServiceResult<TDto>> Update(int id, TDtoForUpdate dtoForUpdate)
        {
            var query = _dbContext.Set<TEntity>();
            var entity = await query.FindAsync(id);
            if (entity == null)
                return new ServiceResult<TDto>(HttpStatusCode.NotFound);

            await Task.Run(() =>
           {
               entity = _mapper.Map(dtoForUpdate, entity);

               query.Update(entity);
           });

            await _dbContext.SaveChangesAsync();

            return new ServiceResult<TDto>(_mapper.Map<TDto>(entity));
        }

        public async Task<ServiceResult<TDtoForUpdate>> GetAsUpdateDto(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);

            if (entity == null)
                return new ServiceResult<TDtoForUpdate>(HttpStatusCode.NotFound);

            return new ServiceResult<TDtoForUpdate>(_mapper.Map<TDtoForUpdate>(entity));
        }

        public virtual async Task<ServiceResult<TDto>> Delete(int id)
        {
            var query = _dbContext.Set<TEntity>();

            var entity = await query.FindAsync(id);
            if (entity == null)
                return new ServiceResult<TDto>(HttpStatusCode.NotFound);

            await Task.Run(() =>
           {
               query.Remove(entity);
           });
            await _dbContext.SaveChangesAsync();

            return new ServiceResult<TDto>();
        }
    }
}