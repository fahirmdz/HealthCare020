using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+Routes.MedicinskiTehnicariRoute)]
    public class MedicinskiTehnicarController : BaseCRUDController<MedicinskiTehnicar, MedicinskiTehnicarDtoLL, MedicinskiTehnicarDtoEL, MedicinskiTehnicarResourceParameters, MedicinskiTehnicarUpsertDto, MedicinskiTehnicarUpsertDto>
    {
        public MedicinskiTehnicarController(ICRUDService<MedicinskiTehnicar, MedicinskiTehnicarDtoLL, MedicinskiTehnicarDtoEL, MedicinskiTehnicarResourceParameters, MedicinskiTehnicarUpsertDto, MedicinskiTehnicarUpsertDto> crudService) : base(crudService)
        {
        }
    }
}