using AutoMapper;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class BaseService<TDto, TResourceParameters, TEntity> : IService<TEntity, TDto, TResourceParameters> where TEntity : class where TResourceParameters : BaseResourceParameters
    {
        protected readonly HealthCare020DbContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly IPropertyMappingService _propertyMappingService;
        protected readonly IPropertyCheckerService _propertyCheckerService;

        public BaseService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _propertyMappingService = propertyMappingService;
            _propertyCheckerService = propertyCheckerService;
        }

        public virtual async Task<IEnumerable> Get(TResourceParameters resourceParameters)
        {
            var eagerLoadedProp = resourceParameters.GetType().GetProperty("EagerLoaded")?.GetValue(resourceParameters);

            IQueryable<TEntity> result;

            if (eagerLoadedProp != null && (bool)eagerLoadedProp)
            {
                result = GetWithEagerLoad();
            }
            else
            {
                //check prop and prop mapping
                PropertyCheck<TDto>(resourceParameters.Fields);

                result = _dbContext.Set<TEntity>();
            }

            var resultToReturn = await FilterAndPrepare(result, resourceParameters);

            return resultToReturn;
        }

        public virtual IQueryable<TEntity> GetWithEagerLoad(int? id = null)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpandoObject> GetById(int id, TResourceParameters resourceParameters)
        {
            var eagerLoadedProp = resourceParameters.GetType().GetProperty("EagerLoaded")?.GetValue(resourceParameters);

            TEntity result;

            if (eagerLoadedProp != null && (bool)eagerLoadedProp)
            {
                result = GetWithEagerLoad(id).FirstOrDefault();
            }
            else
            {
                //check prop and prop mapping
                PropertyCheck<TDto>(resourceParameters.Fields);

                result = _dbContext.Set<TEntity>().Find(id);
            }

            if (result == null)
                throw new NotFoundException("Not Found");

            var resultToReturn = await FilterAndPrepare(result,resourceParameters);

            return resultToReturn;
        }

        /// <summary>
        /// Prepare data for client
        /// </summary>
        /// <param name="result"></param>
        /// <param name="resourceParameters"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable> FilterAndPrepare(IQueryable<TEntity> result, TResourceParameters resourceParameters)
        {
            return result.Select(x => _mapper.Map<TDto>(x)).AsEnumerable().ShapeData(resourceParameters.Fields);
        }

        public virtual async Task<ExpandoObject> FilterAndPrepare(TEntity entity, TResourceParameters resourceParameters)
        {
            return _mapper.Map<TDto>(entity).ShapeData(resourceParameters.Fields);
        }

        public void PropertyCheck<TType>(string fields)
        {
            if (!_propertyCheckerService.TypeHasProperties<TType>(fields))
            {
                throw new UserException($"One or more properties are invalid");
            }

            if (!_propertyMappingService.ValidMappingExistsFor<TType, TEntity>(fields))
            {
                throw new UserException(string.Empty);
            }
        }
    }
}