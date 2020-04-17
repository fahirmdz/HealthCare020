using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/role/korisnicki-nalog/")]
    public class RoleKorisnickiNalogController : BaseCRUDController<RoleKorisnickiNalog, RoleKorisnickiNalogDto,RoleKorisnickiNalogDto, KorisnickiNalogRoleResourceParameters, KorisnickiNalogRoleUpsertDto, KorisnickiNalogRoleUpsertDto>
    {
        public RoleKorisnickiNalogController(ICRUDService<RoleKorisnickiNalog, RoleKorisnickiNalogDto,RoleKorisnickiNalogDto, KorisnickiNalogRoleResourceParameters, KorisnickiNalogRoleUpsertDto, KorisnickiNalogRoleUpsertDto> crudService) : base(crudService)
        {
        }
    }
}