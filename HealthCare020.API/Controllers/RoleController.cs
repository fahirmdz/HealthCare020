using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class RoleController : BaseCRUDController<Role,TwoFieldsDto, TwoFieldsResourceParameters, RoleUpsertDto, RoleUpsertDto>
    {
        public RoleController(ICRUDService<Role, TwoFieldsDto, TwoFieldsResourceParameters, RoleUpsertDto, RoleUpsertDto> crudService) : base(crudService)
        {
        }
    }
}