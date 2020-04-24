using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/naucne-oblasti")]
    public class NaucnaOblastController : BaseCRUDController<NaucnaOblast, TwoFieldsDto, TwoFieldsDto, TwoFieldsResourceParameters, NaucnaOblastUpsertDto, NaucnaOblastUpsertDto>
    {
        public NaucnaOblastController(ICRUDService<NaucnaOblast, TwoFieldsDto, TwoFieldsDto, TwoFieldsResourceParameters, NaucnaOblastUpsertDto, NaucnaOblastUpsertDto> crudService) : base(crudService)
        {
        }
    }
}