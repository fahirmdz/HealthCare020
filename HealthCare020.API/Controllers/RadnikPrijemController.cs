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
    [Route("api/" + Routes.RadniciPrijemRoute)]
    public class RadnikPrijemController : BaseCRUDController<RadnikPrijem, RadnikPrijemDtoLL, RadnikPrijemDtoEL, RadnikPrijemResourceParameters, RadnikPrijemUpsertDto, RadnikPrijemUpsertDto>
    {
        public RadnikPrijemController(ICRUDService<RadnikPrijem, RadnikPrijemDtoLL, RadnikPrijemDtoEL, RadnikPrijemResourceParameters, RadnikPrijemUpsertDto, RadnikPrijemUpsertDto> crudService) : base(crudService)
        {
        }

        [Authorize]
        public override async Task<IActionResult> Get(RadnikPrijemResourceParameters resourceParameters)
        {
            return await base.Get(resourceParameters);
        }

        [Authorize]
        public override async Task<IActionResult> GetById(int id, bool? EagerLoaded)
        {
            return await base.GetById(id, EagerLoaded);
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> Insert(RadnikPrijemUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<RadnikPrijemUpsertDto> patchDocument)
        {
            return await base.PartiallyUpdate(id, patchDocument);
        }

        [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)]
        public override async Task<IActionResult> Update(int id, RadnikPrijemUpsertDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }

        [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}