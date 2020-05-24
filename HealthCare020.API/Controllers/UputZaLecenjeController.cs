using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+Routes.UputiZaLecenjeRoute)]
    [ApiController]
    public class UputZaLecenjeController : BaseCRUDController<UputZaLecenje, UputZaLecenjeDtoLL, UputZaLecenjeDtoEL, UputZaLecenjeResourceParameters, UputZaLecenjeUpsertDto, UputZaLecenjeUpsertDto>
    {
        public UputZaLecenjeController(ICRUDService<UputZaLecenje, UputZaLecenjeDtoLL, UputZaLecenjeDtoEL, UputZaLecenjeResourceParameters, UputZaLecenjeUpsertDto, UputZaLecenjeUpsertDto> crudService) : 
            base(crudService)
        {
        }
    }
}