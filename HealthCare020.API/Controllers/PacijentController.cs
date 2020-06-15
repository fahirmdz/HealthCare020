using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HealthCare020.API.Constants;
using HealthCare020.Core.ServiceModels;
using Microsoft.AspNetCore.Authorization;

namespace HealthCare020.API.Controllers
{
    [Route("api/" + Routes.PacijentiRoute)]
    public class PacijentController : BaseCRUDController<Pacijent, PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, PacijentUpsertDto, PacijentUpsertDto>
    {
        public PacijentController(ICRUDService<Pacijent, PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, PacijentUpsertDto, PacijentUpsertDto> crudService) :
            base(crudService)
        {
        }

        [AllowAnonymous]
        public override Task<IActionResult> Insert(PacijentUpsertDto dtoForCreation)
        {
            return base.Insert(dtoForCreation);
        }

        [NonAction]
        public override Task<IActionResult> Update(int id, PacijentUpsertDto dtoForUpdate)
        {
            return base.Update(id, dtoForUpdate);
        }

        [HttpPut]
        [Authorize(AuthorizationPolicies.PacijentPolicy)]
        public async Task<IActionResult> UpdateNew(PacijentUpsertDto dtoForUpdate)
        {
            //0 zbog toga sto se u servisu uzima trenutno logirani pacijent
            var result = await _crudService.Update(0, dtoForUpdate);
            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            return Ok((result as ServiceResult<PacijentDtoLL>).Data);
        }

        [NonAction]
        [Authorize(AuthorizationPolicies.PacijentPolicy)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [HttpDelete]
        public async Task<IActionResult> NewDelete(int id=0)
        {
            //0 zbog toga sto se u servisu uzima trenutno logirani pacijent
            var result = await _crudService.Delete(id);
            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            return NoContent();
        }
    }
}