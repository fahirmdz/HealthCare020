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
using HealthCare020.Services;
using HealthCare020.Services.Constants;

namespace HealthCare020.API.Controllers
{
    [Route("api/" + Routes.ZahtevZaPosetuRoute)]
    public class ZahtevZaPosetuController : BaseCRUDController<ZahtevZaPosetu, ZahtevZaPosetuDtoLL, ZahtevZaPosetuDtoEL, ZahtevZaPosetuResourceParameters,ZahtevZaPosetuUpsertDto, ZahtevZaPosetuPatchDto>
    {
        public ZahtevZaPosetuController(ICRUDService<ZahtevZaPosetu, ZahtevZaPosetuDtoLL,
            ZahtevZaPosetuDtoEL, ZahtevZaPosetuResourceParameters, ZahtevZaPosetuUpsertDto, ZahtevZaPosetuPatchDto> crudService)
            : base(crudService)
        { }

        [AllowAnonymous]
        public override async Task<IActionResult> Insert(ZahtevZaPosetuUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [NonAction]
        public override async Task<IActionResult> Update(int id, ZahtevZaPosetuPatchDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }

        [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<ZahtevZaPosetuPatchDto> patchDocument)
        {
            return await base.PartiallyUpdate(id, patchDocument);
        }

        [HttpGet("auto-scheduling")]
        [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)]
        public async Task<IActionResult> AutoScheduling()
        {
            if (_crudService is ZahtevZaPosetuService service)
            {
                var result = await service.AutoScheduling();
                return WithStatusCode(result.StatusCode, result.Message);
            }

            return StatusCode(500);
        }
    }
}