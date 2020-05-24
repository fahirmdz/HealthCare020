using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+Routes.GradoviRoute)]
    public class GradController : BaseCRUDController<Grad,GradDtoLL,GradDtoEL, GradResourceParameters,GradUpsertDto, GradUpsertDto>
    {
        public GradController(ICRUDService<Grad, GradDtoLL, GradDtoEL, GradResourceParameters, GradUpsertDto, GradUpsertDto> crudService) : base(crudService)
        {
        }
    }
}