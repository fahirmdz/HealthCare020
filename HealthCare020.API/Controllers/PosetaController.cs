using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+Routes.PoseteRoute)]
    public class PosetaController : BaseCRUDController<Poseta, PosetaDtoLL, PosetaDtoEL, PosetaResourceParameters, PosetaUpsertDto, PosetaUpsertDto>
    {
        public PosetaController(ICRUDService<Poseta, PosetaDtoLL, PosetaDtoEL, PosetaResourceParameters, PosetaUpsertDto, PosetaUpsertDto> crudService)
            : base(crudService)
        {
        }
    }
}