using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/dnevni-izvestaji")]
    public class DnevniIzvestajController : BaseCRUDController<DnevniIzvestaj, DnevniIzvestajDtoLL, DnevniIzvestajDtoEL, DnevniIzvestajResourceParameters, DnevniIzvestajUpsertDto, DnevniIzvestajUpsertDto>
    {
        public DnevniIzvestajController(ICRUDService<DnevniIzvestaj, DnevniIzvestajDtoLL, DnevniIzvestajDtoEL,
            DnevniIzvestajResourceParameters, DnevniIzvestajUpsertDto, DnevniIzvestajUpsertDto> crudService)
            : base(crudService)
        {
        }
    }
}