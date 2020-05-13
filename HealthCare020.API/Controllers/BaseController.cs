using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController<TEntity, TDto, TDtoEagerLoaded, TResourceParameters> : ControllerBase where TResourceParameters : BaseResourceParameters
    {
        private readonly IService<TEntity, TResourceParameters> _service;

        public BaseController(IService<TEntity, TResourceParameters> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TResourceParameters resourceParameters)
        {
            var result = await _service.Get(resourceParameters);

            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.PaginationMetadata));

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery]TResourceParameters resourceParameters)
        {
            var result = await _service.GetById(id, resourceParameters);
            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            return Ok(result);
        }

        protected IActionResult WithStatusCode(HttpStatusCode statusCode, string message = "")
        {
            switch (statusCode)
            {
                case HttpStatusCode.NotFound:
                    return NotFound(message);

                case HttpStatusCode.Forbidden:
                    return StatusCode(403);

                case HttpStatusCode.Unauthorized:
                    return Unauthorized();

                default:
                    return BadRequest();
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
    }
}