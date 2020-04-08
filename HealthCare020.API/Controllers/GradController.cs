using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class GradController : BaseCRUDController<Grad,GradModel, GradSearchRequest,GradUpsertRequest, GradUpsertRequest>
    {
        public GradController(ICRUDService<Grad, GradModel, GradSearchRequest, GradUpsertRequest, GradUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}