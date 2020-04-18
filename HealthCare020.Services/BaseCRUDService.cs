using AutoMapper;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Interfaces;
using System.Threading.Tasks;
using HealthCare020.Core.ResourceParameters;

namespace HealthCare020.Services
{
    public class BaseCRUDService<TDto,TDtoEagerLoaded, TResourceParameters, TEntity, TDtoForCreation, TDtoForUpdate> : BaseService<TDto,TDtoEagerLoaded, 
        TResourceParameters, TEntity>, ICRUDService<TEntity, TDto,TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate>
        where TEntity : class where TResourceParameters: BaseResourceParameters
    {

        public BaseCRUDService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService) : base(mapper, dbContext,propertyMappingService,propertyCheckerService)
        {
        }

        public virtual async Task<TDto> Insert(TDtoForCreation dtoForCreation)
        {
            var entity = _mapper.Map<TEntity>(dtoForCreation);

            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        public virtual TDto Update(int id, TDtoForUpdate dtoForUpdate)
        {
            var query = _dbContext.Set<TEntity>();
            var entity = query.Find(id);
            if (entity == null)
                throw new NotFoundException("Not Found");

            entity = _mapper.Map(dtoForUpdate, entity);

            query.Update(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<TDto>(entity);
        }

        public virtual void Delete(int id)
        {
            var query = _dbContext.Set<TEntity>();

            var entity = query.Find(id);

            if (entity == null)
                throw new NotFoundException("Not Found");

            query.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}