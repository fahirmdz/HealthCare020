using System.Threading.Tasks;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Constants;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/" + Routes.PacijentNaLecenjuRoute)]
    public class PacijentNaLecenjuController : BaseCRUDController<PacijentNaLecenju, PacijentNaLecenjuDtoLL, PacijentNaLecenjuDtoEL, PacijentNaLecenjuResourceParameters, PacijentNaLecenjuUpsertDto, PacijentNaLecenjuUpsertDto>
    {
        public PacijentNaLecenjuController(ICRUDService<PacijentNaLecenju, PacijentNaLecenjuDtoLL, PacijentNaLecenjuDtoEL,
            PacijentNaLecenjuResourceParameters, PacijentNaLecenjuUpsertDto, PacijentNaLecenjuUpsertDto> crudService)
            : base(crudService)
        {
        }

        [AllowAnonymous]
        public override async Task<IActionResult> Get(PacijentNaLecenjuResourceParameters resourceParameters)
        {
            return await base.Get(resourceParameters);
        }

        [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)]
        public override async Task<IActionResult> Insert(PacijentNaLecenjuUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)]
        public override async Task<IActionResult> Update(int id, PacijentNaLecenjuUpsertDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }

        [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<PacijentNaLecenjuUpsertDto> patchDocument)
        {
            return await base.PartiallyUpdate(id, patchDocument);
        }
    }
}