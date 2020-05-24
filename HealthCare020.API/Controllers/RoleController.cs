using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+Routes.RolesRoute)]
    public class RoleController : BaseCRUDController<Role,TwoFieldsDto,TwoFieldsDto, TwoFieldsResourceParameters, RoleUpsertDto, RoleUpsertDto>
    {
        public RoleController(ICRUDService<Role, TwoFieldsDto,TwoFieldsDto, TwoFieldsResourceParameters, RoleUpsertDto, RoleUpsertDto> crudService) : base(crudService)
        {
        }
    }
}