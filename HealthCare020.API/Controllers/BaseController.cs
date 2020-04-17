using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    [Route("api/[controller]")]
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
            var result = await _service.Get(resourceParameters) as PagedList<TEntity>;
            var paginationMetadata = new PaginationMetadata
            {
                CurrentPage = result.CurrentPage,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
                TotalPages = result.TotalPages
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            if (_service.ShouldEagerLoad(resourceParameters))
            {
                var resultToReturn = _service.PrepareDataForClient(result, resourceParameters) as IEnumerable<TDtoEagerLoaded>;
                return Ok(resultToReturn.ShapeData(resourceParameters.Fields));
            }

            var resultToReturnLazyLoaded = _service.PrepareDataForClient(result, resourceParameters) as IEnumerable<TDto>;
            return Ok(resultToReturnLazyLoaded.ShapeData(resourceParameters.Fields));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery]TResourceParameters resourceParameters)
        {
            var result = await _service.GetById(id, resourceParameters);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}