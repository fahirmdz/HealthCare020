using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HealthCare020.Core.ResourceParameters;

namespace HealthCare020.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity,TDto, TResourceParameters> : ControllerBase where TResourceParameters:BaseResourceParameters
    {
        private readonly IService<TEntity,TDto, TResourceParameters> _service;

        public BaseController(IService<TEntity, TDto, TResourceParameters> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TResourceParameters resourceParameters)
        {
            var result = await _service.Get(resourceParameters);

            return Ok(result);
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id,[FromQuery]TResourceParameters resourceParameters)
        {
            var result = await _service.GetById(id, resourceParameters);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}