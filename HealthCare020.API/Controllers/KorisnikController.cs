using System.Threading.Tasks;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;

namespace HealthCare020.API.Controllers
{
    [Route("api/korisnici")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _korisnikService;

        public KorisnikController(IKorisnikService korisnikService)
        {
            _korisnikService = korisnikService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] KorisnickiNalogResourceParameters resourceParameters)
        {
            var result = await _korisnikService.Get(resourceParameters);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, [FromQuery] KorisnickiNalogResourceParameters resourceParameters)
        {
            var result = await _korisnikService.GetById(id, resourceParameters);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(KorisnickiNalogUpsertDto request)
        {
            var result = await _korisnikService.Insert(request);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, KorisnickiNalogUpsertDto request)
        {
            var result = _korisnikService.Update(id, request);

            return Ok(result);
        }
    }
}