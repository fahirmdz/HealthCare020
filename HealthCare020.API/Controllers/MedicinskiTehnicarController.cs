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
    [Route("api/"+Routes.MedicinskiTehnicariRoute)]
    public class MedicinskiTehnicarController : BaseCRUDController<MedicinskiTehnicar, MedicinskiTehnicarDtoLL, MedicinskiTehnicarDtoEL, MedicinskiTehnicarResourceParameters, MedicinskiTehnicarUpsertDto, MedicinskiTehnicarUpsertDto>
    {
        public MedicinskiTehnicarController(ICRUDService<MedicinskiTehnicar, MedicinskiTehnicarDtoLL, MedicinskiTehnicarDtoEL, MedicinskiTehnicarResourceParameters, MedicinskiTehnicarUpsertDto, MedicinskiTehnicarUpsertDto> crudService) : base(crudService)
        {
        }

        [Authorize(AuthorizationPolicies.AdministratorPolicy)]
        public override async Task<IActionResult> Insert(MedicinskiTehnicarUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [Authorize(AuthorizationPolicies.MedicinskiTehnicarPolicy)]
        public override async Task<IActionResult> Update(int id, MedicinskiTehnicarUpsertDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }

        [Authorize(AuthorizationPolicies.MedicinskiTehnicarPolicy)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        [Authorize(AuthorizationPolicies.MedicinskiTehnicarPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<MedicinskiTehnicarUpsertDto> patchDocument)
        {
            return await base.PartiallyUpdate(id, patchDocument);
        }
    }
}