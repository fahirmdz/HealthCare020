using System.Threading.Tasks;
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

namespace HealthCare020.API.Controllers
{
    [Route("api/" + Routes.UputnicaRoute)]
    [Authorize(AuthorizationPolicies.PacijentPolicy)]
    public class UputnicaController : BaseCRUDController<Uputnica, UputnicaDtoLL, UputnicaDtoEL, UputnicaResourceParameters, UputnicaUpsertDto, UputnicaUpsertDto>
    {
        public UputnicaController(ICRUDService<Uputnica, UputnicaDtoLL, UputnicaDtoEL,
            UputnicaResourceParameters, UputnicaUpsertDto, UputnicaUpsertDto> crudService)
            : base(crudService)
        {
        }

        [Authorize(AuthorizationPolicies.DoktorPolicy)]
        public override async Task<IActionResult> Insert(UputnicaUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [Authorize(AuthorizationPolicies.DoktorPolicy)]
        public override async Task<IActionResult> Update(int id, UputnicaUpsertDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }

        [Authorize(AuthorizationPolicies.DoktorPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<UputnicaUpsertDto> patchDocument)
        {
            return await base.PartiallyUpdate(id, patchDocument);
        }

        [Authorize(AuthorizationPolicies.DoktorPolicy)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}