using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class RoleController : BaseCRUDController<Role,TwoFields, TwoFieldsSearchRequest, RoleUpsertRequest, RoleUpsertRequest>
    {
        public RoleController(ICRUDService<Role, TwoFields, TwoFieldsSearchRequest, RoleUpsertRequest, RoleUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}