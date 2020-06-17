using System.Collections.Generic;
using System.Linq;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using HealthCare020.API.Constants;

namespace HealthCare020.API.Controllers
{
    [ApiController]
    [ResponseCache(VaryByHeader = "User-Agent",CacheProfileName = CacheProfilesConstants.CacheProfile240Seconds)]
    public class BaseController<TEntity, TDto, TDtoEagerLoaded, TResourceParameters> : ControllerBase where TResourceParameters : BaseResourceParameters
    {
        private readonly IService<TEntity, TResourceParameters> _service;

        public BaseController(IService<TEntity, TResourceParameters> service)
        {
            _service = service;
        }

        [HttpGet]
        [HttpHead]
        public virtual async Task<IActionResult> Get([FromQuery] TResourceParameters resourceParameters)
        {
            var result = await _service.Get(resourceParameters);

            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            var resultWithData = result as ServiceResult<SequenceResult>;
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(resultWithData.Data.PaginationMetadata));

            if(ShouldEagerLoad(resourceParameters))
                return Ok((resultWithData.Data.Data as IEnumerable<TDtoEagerLoaded>).ToList());
            return Ok((resultWithData.Data.Data as IEnumerable<TDto>).ToList());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id, [FromQuery] bool? EagerLoaded = false)
        {
            var result = await _service.GetById(id, EagerLoaded ?? false);

            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            var resultWithData = result as ServiceResult<object>;

            return Ok(resultWithData.Data);
        }

        protected IActionResult WithStatusCode(HttpStatusCode statusCode, string message = "")
        {
            switch (statusCode)
            {
                case HttpStatusCode.NotFound:
                    return NotFound(message);

                case HttpStatusCode.Forbidden:
                    return StatusCode(403,message);

                case HttpStatusCode.Unauthorized:
                    return Unauthorized();


                default:
                    return BadRequest(message);
            }
        }

        //----HATEOAS support----
        //protected virtual string CreateResourceUri(TResourceParameters resourceParameters, ResourceUriType type)
        //{
        //    var resourceParams = new BaseResourceParameters
        //    {
        //        Fields = resourceParameters.Fields,
        //        OrderBy = resourceParameters.OrderBy,
        //        PageSize = resourceParameters.PageSize,
        //        PageNumber = resourceParameters.PageNumber
        //    };

        //    switch (type)
        //    {
        //        case ResourceUriType.PreviousPage:
        //            resourceParams.PageNumber -= 1;
        //            break;

        //        case ResourceUriType.NextPage:
        //            resourceParams.PageNumber += 1;
        //            break;
        //    }

        //    return Url.Link("GetAll", resourceParams);
        //}

        //private IEnumerable<LinkDto> CreateLinksForResource(int id, string fields)
        //{
        //    var links = new List<LinkDto>();

        //    if (string.IsNullOrWhiteSpace(fields))
        //    {
        //        links.Add(new LinkDto(Url.Link("GetById", new { id = id }), "self", "GET"));
        //    }
        //    else
        //    {
        //        links.Add(new LinkDto(Url.Link("GetById", new { id, fields }), "self", "GET"));
        //    }

        //    return links;
        //}

        //protected IEnumerable<LinkDto> CreateLinksForResources(TResourceParameters resourceParameters, bool hasNext, bool hasPrevious)
        //{
        //    var links = new List<LinkDto>();

        //    //self
        //    links.Add(new LinkDto(CreateResourceUri(resourceParameters, ResourceUriType.CurrentPage), "self", "GET"));

        //    if (hasNext)
        //    {
        //        links.Add(new LinkDto(CreateResourceUri(resourceParameters, ResourceUriType.NextPage), "nextPage", "GET"));
        //    }

        //    if (hasPrevious)
        //    {
        //        links.Add(new LinkDto(CreateResourceUri(resourceParameters, ResourceUriType.PreviousPage), "previousPage", "GET"));
        //    }

        //    return links;
        //}

        /// <summary>
        /// Get the value of EagerLoad property from ResourceParameters if it exists.
        /// </summary>
        protected bool ShouldEagerLoad(TResourceParameters resourceParameters)
        {
            var eagerLoadedProp = resourceParameters?.GetType().GetProperty("EagerLoaded")?.GetValue(resourceParameters);

            return eagerLoadedProp != null && (bool)eagerLoadedProp;
        }
    }
}