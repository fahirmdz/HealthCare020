using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HealthCare020.Core.ResourceParameters;

namespace HealthCare020.API.Controllers
{
    [Route("api/korisnici")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _service;

        public KorisnikController(IKorisnikService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] KorisnickiNalogResourceParameters request)
        {
            return Ok(await _service.Get(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(KorisnickiNalogUpsertDto request)
        {
            return Ok(await _service.Insert(request));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, KorisnickiNalogUpsertDto request)
        {
            return Ok(_service.Update(id, request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}