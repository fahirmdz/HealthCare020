using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    [Route("api/" + Routes.PacijentiRoute)]
    public class PacijentController : BaseCRUDController<Pacijent, PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, PacijentUpsertDto, PacijentUpsertDto>
    {
        public PacijentController(ICRUDService<Pacijent, PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, PacijentUpsertDto, PacijentUpsertDto> crudService) :
            base(crudService)
        {
        }

        [AllowAnonymous]
        public override async Task<IActionResult> Insert(PacijentUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }
    }
}