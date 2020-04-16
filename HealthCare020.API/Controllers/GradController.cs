using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class GradController : BaseCRUDController<Grad,GradDto, GradResourceParameters,GradUpsertDto, GradUpsertDto>
    {
        public GradController(ICRUDService<Grad, GradDto, GradResourceParameters, GradUpsertDto, GradUpsertDto> crudService) : base(crudService)
        {
        }
    }
}