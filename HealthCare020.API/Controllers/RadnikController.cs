using System.Threading.Tasks;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    public class RadnikController : BaseCRUDController<Radnik, RadnikDtoEagerLoaded, RadnikResourceParameters, RadnikUpsertDto, RadnikUpsertDto>
    {
        public RadnikController(ICRUDService<Radnik, RadnikDtoEagerLoaded, RadnikResourceParameters, RadnikUpsertDto, RadnikUpsertDto> crudService) : base(crudService)
        {
        }

        
    }
}