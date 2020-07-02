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
    [Route("api/" + Routes.DoktoriRoute)]
    public class DoktorController : BaseCRUDController<Doktor, DoktorDtoLL, DoktorDtoEL, DoktorResourceParameters, DoktorUpsertDto, DoktorUpsertDto>
    {
        public DoktorController(ICRUDService<Doktor, DoktorDtoLL, DoktorDtoEL, DoktorResourceParameters, DoktorUpsertDto, DoktorUpsertDto> crudService) : base(crudService)
        {
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> Insert(DoktorUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [Authorize(AuthorizationPolicies.DoktorPolicy)]
        public override async Task<IActionResult> Update(int id, DoktorUpsertDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }

        [Authorize(AuthorizationPolicies.DoktorPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<DoktorUpsertDto> patchDocument)
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