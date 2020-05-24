using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+ Routes.CustomIzvestajiRoute)]
    public class CustomIzvestajController : BaseCRUDController<CustomIzvestaj, CustomIzvestajDtoLL, CustomIzvestajDtoEL, CustomIzvestajResourceParameters, CustomIzvestajUpsertDto, CustomIzvestajUpsertDto>
    {
        public CustomIzvestajController(ICRUDService<CustomIzvestaj, CustomIzvestajDtoLL, CustomIzvestajDtoEL,
            CustomIzvestajResourceParameters, CustomIzvestajUpsertDto, CustomIzvestajUpsertDto> crudService)
            : base(crudService)
        {
        }
    }
}