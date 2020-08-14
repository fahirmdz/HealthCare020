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
using AuthorizationPolicies = HealthCare020.API.Constants.AuthorizationPolicies;

namespace HealthCare020.API.Controllers
{
    [Route("api/" + Routes.LekarskoUverenjeRoute)]
    public class LekarskoUverenjeController : BaseCRUDController<LekarskoUverenje, LekarskoUverenjeDtoLL, LekarskoUverenjeDtoEL, LekarskoUverenjeResourceParameters, LekarskoUverenjeUpsertDto, LekarskoUverenjeUpsertDto>
    {
        public LekarskoUverenjeController(ICRUDService<LekarskoUverenje, LekarskoUverenjeDtoLL, LekarskoUverenjeDtoEL, LekarskoUverenjeResourceParameters, LekarskoUverenjeUpsertDto, LekarskoUverenjeUpsertDto> crudService) : base(crudService)
        {
        }

        [Authorize(AuthorizationPolicies.PacijentPolicy)]
        public override async Task<IActionResult> Get(LekarskoUverenjeResourceParameters resourceParameters)
        {
            return await base.Get(resourceParameters);
        }

        [Authorize(AuthorizationPolicies.PacijentPolicy)]
        public override async Task<IActionResult> GetById(int id, bool? EagerLoaded = false)
        {
            return await base.GetById(id, EagerLoaded);
        }

        [Authorize(AuthorizationPolicies.PacijentPolicy)]
        public override async Task<IActionResult> Insert(LekarskoUverenjeUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [Authorize(AuthorizationPolicies.PacijentPolicy)]
        public override async Task<IActionResult> Update(int id, LekarskoUverenjeUpsertDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }

        [Authorize(AuthorizationPolicies.PacijentPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<LekarskoUverenjeUpsertDto> patchDocument)
        {
            return await base.PartiallyUpdate(id, patchDocument);
        }
    }
}