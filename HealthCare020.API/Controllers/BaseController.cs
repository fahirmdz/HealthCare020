using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity,TModel, TSearch> : ControllerBase
    {
        private readonly IService<TEntity,TModel, TSearch> _service;

        public BaseController(IService<TEntity, TModel, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TSearch serach,bool? eagerLoaded=false)
        {
            var result = eagerLoaded.HasValue && eagerLoaded.Value ? await _service.GetWithEagerLoad(serach):await _service.Get(serach);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, bool? eagerLoaded=false)
        {
            _service.TempId = id;
            var result =eagerLoaded.HasValue && eagerLoaded.Value ? await _service.FindWithEagerLoad(_service.GetFilterForId()): await _service.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}