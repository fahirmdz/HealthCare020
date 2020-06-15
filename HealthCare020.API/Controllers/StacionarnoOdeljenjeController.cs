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
    [Route("api/"+Routes.StacionarnaOdeljenjaRoute)]
    public class StacionarnoOdeljenjeController : BaseCRUDController<StacionarnoOdeljenje, TwoFieldsDto, TwoFieldsDto, TwoFieldsResourceParameters, StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenjeUpsertDto>
    {
        public StacionarnoOdeljenjeController(ICRUDService<StacionarnoOdeljenje, TwoFieldsDto, TwoFieldsDto, TwoFieldsResourceParameters, StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenjeUpsertDto> crudService) : base(crudService)
        {
        }

        [Authorize(AuthorizationPolicies.AdminPolicy)]
        public override async Task<IActionResult> Insert(StacionarnoOdeljenjeUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [Authorize(AuthorizationPolicies.AdminPolicy)]
        public override async Task<IActionResult> Update(int id, StacionarnoOdeljenjeUpsertDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }

        [Authorize(AuthorizationPolicies.AdminPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<StacionarnoOdeljenjeUpsertDto> patchDocument)
        {
            return await base.PartiallyUpdate(id, patchDocument);
        }

        [Authorize(AuthorizationPolicies.AdminPolicy)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}