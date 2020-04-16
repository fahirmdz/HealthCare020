using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity,TDto, TResourceParameters> : ControllerBase
    {
        private readonly IService<TEntity,TDto, TResourceParameters> _service;

        public BaseController(IService<TEntity, TDto, TResourceParameters> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TResourceParameters resourceParameters,bool? eagerLoaded=false)
        {
            var result = eagerLoaded.HasValue && eagerLoaded.Value ? await _service.GetWithEagerLoad(resourceParameters):await _service.Get(resourceParameters);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, bool? eagerLoaded=false)
        {
            var result =eagerLoaded.HasValue && eagerLoaded.Value ? await _service.FindWithEagerLoad(id): await _service.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}