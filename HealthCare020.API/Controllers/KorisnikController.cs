using HealthCare020.API.Constants;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    [Route("api/" + Routes.KorisniciRoute)]
    public class KorisnikController : BaseCRUDController<KorisnickiNalog, KorisnickiNalogDtoLL, KorisnickiNalogDtoEL, KorisnickiNalogResourceParameters, KorisnickiNalogUpsertDto, KorisnickiNalogUpsertDto>
    {
        private IKorisnikService _korisnikService;

        public KorisnikController(ICRUDService<KorisnickiNalog, KorisnickiNalogDtoLL, KorisnickiNalogDtoEL, KorisnickiNalogResourceParameters,
            KorisnickiNalogUpsertDto, KorisnickiNalogUpsertDto> crudService)
            : base(crudService)
        {
            _korisnikService = _crudService as IKorisnikService;
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> Insert(KorisnickiNalogUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> Update(int id, KorisnickiNalogUpsertDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<KorisnickiNalogUpsertDto> patchDocument)
        {
            return await base.PartiallyUpdate(id, patchDocument);
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        [HttpPut("{id}/lock")]
        public async Task<IActionResult> Lock(int id, KorisnickiNalogLockUpsertRequest request)
        {
            var result = await _korisnikService.ToggleLock(id, true, request.Until);

            return !result.Succeeded ? WithStatusCode(result.StatusCode, result.Message) : Ok(result.Data);
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        [HttpDelete("{id}/lock")]
        public async Task<IActionResult> Lock(int id)
        {
            var result = await _korisnikService.ToggleLock(id, false);

            return !result.Succeeded ? WithStatusCode(result.StatusCode, result.Message) : Ok(result.Data);
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        [HttpPut("{id}/roles")]
        public async Task<IActionResult> AddInRoles(int id, KorisnickiNalogRolesUpsertDto request)
        {
            var result = await _korisnikService.AddInRoles(id, request);

            if (!result.Succeeded)
            {
                return WithStatusCode(result.StatusCode, result.Message);
            }

            return Ok(result.Data);
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        [HttpDelete("{id}/roles")]
        public async Task<IActionResult> RemoveFromRoles(int id, KorisnickiNalogRolesUpsertDto request)
        {
            var result = await _korisnikService.RemoveFromRoles(id, request);

            if (!result.Succeeded)
            {
                return WithStatusCode(result.StatusCode, result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost(Routes.ChangePasswordRoute)]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
        {
            var result = await _korisnikService.ChangePassword(dto.CurrentPassword, dto.NewPassword);

            if (!result.Succeeded)
            {
                return WithStatusCode(result.StatusCode, result.Message);
            }

            return Ok();
        }

        [HttpPost("zakljucan")]
        [AllowAnonymous]
        public async Task<IActionResult> AccountLocked(LoginDto loginData)
        {
            var result = await _korisnikService.AccountLocked(loginData.Username, loginData.Password);

            return WithStatusCode(result.StatusCode, result.Message);
        }


    }
}