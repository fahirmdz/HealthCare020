using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TSearch> : ControllerBase
    {
        private readonly IService<TModel, TSearch> _service;

        public BaseController(IService<TModel, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IList<TModel>> Get([FromQuery] TSearch serach)
        {
            return await _service.Get(serach);
        }

        [HttpGet("{id}")]
        public async Task<TModel> GetById(int id)
        {
            return await _service.GetById(id);
        }
    }
}