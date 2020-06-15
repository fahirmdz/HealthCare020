using AutoMapper;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ResponseModels;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
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
        protected readonly IAuthService _authService;

        public BaseService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService,
            IAuthService authService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _propertyMappingService = propertyMappingService;
            _propertyCheckerService = propertyCheckerService;
            _authService = authService;
        }

        public virtual async Task<ServiceResult> Get(TResourceParameters resourceParameters)
        {
            IQueryable<TEntity> result;

            if (resourceParameters != null)
            {
                if (ShouldEagerLoad(resourceParameters))
                {
                    //check prop and prop mapping
                    var propertyCheckResult = PropertyCheck<TDtoEagerLoaded>(resourceParameters.OrderBy);
                    if (!propertyCheckResult.Succeded)
                        return ServiceResult.BadRequest(propertyCheckResult.Message);

                    result = GetWithEagerLoad();
                }
                else
                {
                    //check prop and prop mapping
                    var propertyCheckResult = PropertyCheck<TDto>(resourceParameters.OrderBy);
                    if (!propertyCheckResult.Succeded)
                        return ServiceResult.BadRequest(propertyCheckResult.Message);
                }
            }
            result = _dbContext.Set<TEntity>().AsQueryable();

            var pagedResult = await FilterAndPrepare(result, resourceParameters) ?? new PagedList<TEntity>(new List<TEntity>(), 0, 0, 0);

            var serviceResultToReturn = new SequenceResult()
            {
                PaginationMetadata = new PaginationMetadata()
                {
                    CurrentPage = pagedResult.CurrentPage,
                    PageSize = pagedResult.PageSize,
                    TotalCount = pagedResult.TotalCount,
                    TotalPages = pagedResult.TotalPages
                },
                Data = PrepareDataForClient(pagedResult, resourceParameters: resourceParameters),
                HasNext = pagedResult.HasNext,
                HasPrevious = pagedResult.HasPrevious
            };
            return ServiceResult<SequenceResult>.OK(serviceResultToReturn);
        }

        public virtual IQueryable<TEntity> GetWithEagerLoad(int? id = null)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ServiceResult> GetById(int id, bool EagerLoaded)
        {
            TEntity result;

            if (EagerLoaded)
            {
                result = GetWithEagerLoad(id).FirstOrDefault();
            }
            else
            {
                result = await _dbContext.Set<TEntity>().FindAsync(id);
            }

            if (result == null)
                return ServiceResult.NotFound();

            if (EagerLoaded)
                return ServiceResult<dynamic>.OK(PrepareDataForClient<TDtoEagerLoaded>(result));

            return ServiceResult<dynamic>.OK(PrepareDataForClient<TDto>(result));
        }

#pragma warning disable 1998

        /// <summary>
        /// Filtering and pagination
        /// </summary>
        public virtual async Task<PagedList<TEntity>> FilterAndPrepare(IQueryable<TEntity> result, TResourceParameters resourceParameters)
        {
            //Apply pagination
            return PagedList<TEntity>.Create(result, resourceParameters?.PageNumber ?? 1, resourceParameters?.PageSize ?? 6);
        }

#pragma warning restore 1998

        /// <summary>
        /// Mapping entities to the data type for a client
        /// </summary>
        public virtual IEnumerable PrepareDataForClient(IEnumerable<TEntity> data, TResourceParameters resourceParameters)
        {
            if (ShouldEagerLoad(resourceParameters))
            {
                var dataWithFinalTypeEagerLoaded = data.Select(x => _mapper.Map<TDtoEagerLoaded>(x));

                if (resourceParameters != null && !string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
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

            if (resourceParameters != null && !string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
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
        public virtual T PrepareDataForClient<T>(TEntity data)
        {
            return _mapper.Map<T>(data);
        }

        /// <summary>
        /// Get the value of EagerLoad property from ResourceParameters if it exists.
        /// </summary>
        public bool ShouldEagerLoad(TResourceParameters resourceParameters)
        {
            var eagerLoadedProp = resourceParameters?.GetType().GetProperty("EagerLoaded")?.GetValue(resourceParameters);

            return eagerLoadedProp != null && (bool)eagerLoadedProp;
        }

        /// <summary>
        /// Check if properties exist
        /// </summary>
        public (bool Succeded, string Message) PropertyCheck<TType>(string orderBy)
        {
            //if (!_propertyCheckerService.TypeHasProperties<TType>(fields))
            //{
            //    throw new UserException($"One or more properties are invalid");
            //}

            if (!_propertyMappingService.ValidMappingExistsFor<TType, TEntity>(orderBy))
            {
                return (false, $"Invalid OrderBy fields -> {orderBy}");
            }

            return (true, string.Empty);
        }
    }
}