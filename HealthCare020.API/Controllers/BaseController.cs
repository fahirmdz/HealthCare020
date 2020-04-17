using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
            var result = await _service.Get(resourceParameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.PaginationMetadata));

            return Ok(result.Data);
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