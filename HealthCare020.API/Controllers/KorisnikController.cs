using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HealthCare020.API.Constants;
using Microsoft.AspNetCore.Authorization;

namespace HealthCare020.API.Controllers
{
    [Route("api/korisnici")]
    public class KorisnikController : BaseCRUDController<KorisnickiNalog, KorisnickiNalogDtoLL, KorisnickiNalogDtoEL, KorisnickiNalogResourceParameters, KorisnickiNalogUpsertDto, KorisnickiNalogUpsertDto>
    {
        private IKorisnikService _korisnikService;

        public KorisnikController(ICRUDService<KorisnickiNalog, KorisnickiNalogDtoLL, KorisnickiNalogDtoEL, KorisnickiNalogResourceParameters,
            KorisnickiNalogUpsertDto, KorisnickiNalogUpsertDto> crudService)
            : base(crudService)
        {
            _korisnikService = _crudService as IKorisnikService;
        }

        [Authorize(AuthorizationPolicies.AdminPolicy)]
        [HttpPost("{id}/lock")]
        public async Task<IActionResult> Lock(int id, KorisnickiNalogLockUpsertRequest request)
        {
            var result = await _korisnikService.ToggleLock(id, true, request.Until);

            return !result.Succeeded ? WithStatusCode(result.StatusCode, result.Message) : Ok(result.Data);
        }

        [Authorize(AuthorizationPolicies.AdminPolicy)]
        [HttpDelete("{id}/lock")]
        public async Task<IActionResult> Lock(int id)
        {
            var result = await _korisnikService.ToggleLock(id, false);

            return !result.Succeeded ? WithStatusCode(result.StatusCode, result.Message) : Ok(result.Data);
        }
    }
}