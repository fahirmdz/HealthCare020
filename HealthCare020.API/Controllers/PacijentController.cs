using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/pacijenti")]
    public class PacijentController : BaseCRUDController<Pacijent, PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, PacijentUpsertDto, PacijentDtoForUpdate>
    {
        public PacijentController(ICRUDService<Pacijent, PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, PacijentUpsertDto, PacijentDtoForUpdate> crudService) :
            base(crudService)
        {
        }
    }
}