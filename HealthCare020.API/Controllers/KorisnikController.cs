using HealthCare020.API.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HealthCare020.Core.Constants;
using HealthCare020.Core.ServiceModels;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+Routes.KorisniciRoute)]
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
        [HttpPut("{id}/lock")]
        public async Task<IActionResult> Lock(int id, KorisnickiNalogLockUpsertRequest request)
        {
            var result = await _korisnikService.ToggleLock(id, true, request.Until) as ServiceResult<KorisnickiNalogDtoLL>;

            return !result.Succeeded ? WithStatusCode(result.StatusCode, result.Message) : Ok(result.Data);
        }

        [Authorize(AuthorizationPolicies.AdminPolicy)]
        [HttpDelete("{id}/lock")]
        public async Task<IActionResult> Lock(int id)
        {
            var result = await _korisnikService.ToggleLock(id, false) as ServiceResult<KorisnickiNalogDtoLL>;

            return !result.Succeeded ? WithStatusCode(result.StatusCode, result.Message) : Ok(result.Data);
        }

        [Authorize(AuthorizationPolicies.AdminPolicy)]
        [HttpPut("{id}/roles")]
        public async Task<IActionResult> AddInRoles(int id, KorisnickiNalogRolesUpsertDto request)
        {
            var result = await _korisnikService.AddInRoles(id, request) as ServiceResult<KorisnickiNalogDtoLL>;

            if (!result.Succeeded)
            {
                return WithStatusCode(result.StatusCode, result.Message);
            }

            return Ok(result.Data);
        }

        [Authorize(AuthorizationPolicies.AdminPolicy)]
        [HttpDelete("{id}/roles")]
        public async Task<IActionResult> RemoveFromRoles(int id, KorisnickiNalogRolesUpsertDto request)
        {
            var result = await _korisnikService.RemoveFromRoles(id, request) as ServiceResult<KorisnickiNalogDtoLL>;

            if (!result.Succeeded)
            {
                return WithStatusCode(result.StatusCode, result.Message);
            }

            return Ok(result.Data);
        }
    }
}