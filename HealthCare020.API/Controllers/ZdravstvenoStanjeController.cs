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
    [Route("api/"+Routes.ZdravstvenaStanjaRoute)]
    public class ZdravstvenoStanjeController : BaseCRUDController<ZdravstvenoStanje, ZdravstvenoStanjeDto,ZdravstvenoStanjeDto,ZdravstvenoStanjeResourceParameters, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto>
    {
        public ZdravstvenoStanjeController(ICRUDService<ZdravstvenoStanje, ZdravstvenoStanjeDto,ZdravstvenoStanjeDto, ZdravstvenoStanjeResourceParameters, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto> crudService) : base(crudService)
        {
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> Insert(ZdravstvenoStanjeUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> Update(int id, ZdravstvenoStanjeUpsertDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }


        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<ZdravstvenoStanjeUpsertDto> patchDocument)
        {
            return await base.PartiallyUpdate(id, patchDocument);
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}