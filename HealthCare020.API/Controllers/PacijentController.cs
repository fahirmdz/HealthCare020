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
    [Authorize(AuthorizationPolicies.PacijentPolicy)]
    public class PacijentController : BaseCRUDController<Pacijent, PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, PacijentUpsertDto, PacijentUpsertDto>
    {
        public PacijentController(ICRUDService<Pacijent, PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, PacijentUpsertDto, PacijentUpsertDto> crudService) :
            base(crudService)
        {
        }

        [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)]
        public override async Task<IActionResult> Get(PacijentResourceParameters resourceParameters)
        {
            return await base.Get(resourceParameters);
        }


        [AllowAnonymous]
        public override async Task<IActionResult> Insert(PacijentUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }
    }
}