using AutoMapper;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class BaseService<TDto, TDtoEagerLoaded, TResourceParameters, TEntity> : IService<TEntity, TResourceParameters> where TEntity : class where TResourceParameters : BaseResourceParameters
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

        public virtual async Task<ServiceSequenceResult> Get(TResourceParameters resourceParameters)
        {
            IQueryable<TEntity> result;

            if (ShouldEagerLoad(resourceParameters))
            {
                //check prop and prop mapping
                PropertyCheck<TDtoEagerLoaded>(resourceParameters.OrderBy);

                result = GetWithEagerLoad();
            }
            else
            {
                //check prop and prop mapping
                PropertyCheck<TDto>(resourceParameters.OrderBy);

                result = _dbContext.Set<TEntity>().AsQueryable();
            }

            var pagedResult = await FilterAndPrepare(result, resourceParameters) ?? new PagedList<TEntity>(new List<TEntity>(), 0, 0, 0);

            var serviceResultToReturn = new ServiceSequenceResult
            {
                PaginationMetadata = new PaginationMetadata
                {
                    CurrentPage = pagedResult.CurrentPage,
                    PageSize = pagedResult.PageSize,
                    TotalCount = pagedResult.TotalCount,
                    TotalPages = pagedResult.TotalPages
                },
                Data = PrepareDataForClient(pagedResult, resourceParameters),
                HasNext = pagedResult.HasNext,
                HasPrevious = pagedResult.HasPrevious
            };
            return serviceResultToReturn;
        }

        public virtual IQueryable<TEntity> GetWithEagerLoad(int? id = null)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetById(int id, TResourceParameters resourceParameters)
        {
            TEntity result;
            var eagerLoad = ShouldEagerLoad(resourceParameters);

            if (eagerLoad)
            {
                //check prop and prop mapping
                PropertyCheck<TDtoEagerLoaded>(resourceParameters.OrderBy);

                result = GetWithEagerLoad(id).FirstOrDefault();
            }
            else
            {
                //check prop and prop mapping
                PropertyCheck<TDto>(resourceParameters.OrderBy);

                result = await _dbContext.Set<TEntity>().FindAsync(id);
            }

            if (result == null)
                throw new NotFoundException("Not Found");

            if (eagerLoad)
                return PrepareDataForClient<TDtoEagerLoaded>(result, resourceParameters);

            return PrepareDataForClient<TDto>(result, resourceParameters);
        }

        /// <summary>
        /// Filtering and pagination
        /// </summary>
        public virtual async Task<PagedList<TEntity>> FilterAndPrepare(IQueryable<TEntity> result, TResourceParameters resourceParameters)
        {
            //Apply pagination
            return PagedList<TEntity>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);
        }

        /// <summary>
        /// Mapping entities to the data type for a client
        /// </summary>
        public virtual IEnumerable PrepareDataForClient(IEnumerable<TEntity> data, TResourceParameters resourceParameters)
        {
            if (ShouldEagerLoad(resourceParameters))
            {
                var dataWithFinalTypeEagerLoaded = data.Select(x => _mapper.Map<TDtoEagerLoaded>(x));

                if (!string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
                {
                    var propertyMappingDictionary =
                        _propertyMappingService.GetPropertyMapping<TDtoEagerLoaded, TEntity>();

                    dataWithFinalTypeEagerLoaded = dataWithFinalTypeEagerLoaded.AsQueryable()
                       .ApplySort(resourceParameters.OrderBy, propertyMappingDictionary);
                }

                return dataWithFinalTypeEagerLoaded;
                //return dataWithFinalTypeEagerLoaded.ShapeData(resourceParameters.Fields);
            }

            var dataWithFinalTypeLazyLoaded = data.Select(x => _mapper.Map<TDto>(x));

            if (!string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
            {
                var propertyMappingDictionary =
                    _propertyMappingService.GetPropertyMapping<TDto, TEntity>();

                dataWithFinalTypeLazyLoaded = dataWithFinalTypeLazyLoaded.AsQueryable()
                    .ApplySort(resourceParameters.OrderBy, propertyMappingDictionary);
            }

            return dataWithFinalTypeLazyLoaded;
            //return dataWithFinalTypeLazyLoaded.ShapeData(resourceParameters.Fields);
        }

        /// <summary>
        /// Mapping entity to the data type for a client
        /// </summary>
        public virtual T PrepareDataForClient<T>(TEntity data, TResourceParameters resourceParameters)
        {
            return _mapper.Map<T>(data);
        }

        /// <summary>
        /// Get the value of EagerLoad property from ResourceParameters if it exists.
        /// </summary>
        public bool ShouldEagerLoad(TResourceParameters resourceParameters)
        {
            var eagerLoadedProp = resourceParameters.GetType().GetProperty("EagerLoaded")?.GetValue(resourceParameters);

            return eagerLoadedProp != null && (bool)eagerLoadedProp;
        }

        /// <summary>
        /// Check if properties exist
        /// </summary>
        public void PropertyCheck<TType>(string orderBy)
        {
            //if (!_propertyCheckerService.TypeHasProperties<TType>(fields))
            //{
            //    throw new UserException($"One or more properties are invalid");
            //}

            if (!_propertyMappingService.ValidMappingExistsFor<TType, TEntity>(orderBy))
            {
                throw new UserException($"Invalid OrderBy fields -> {orderBy}");
            }
        }
    }
}