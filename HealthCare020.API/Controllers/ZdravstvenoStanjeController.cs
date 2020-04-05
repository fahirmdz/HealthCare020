using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZdravstvenoStanjeController : BaseController<TwoFields, object>
    {
        public ZdravstvenoStanjeController(IService<TwoFields, object> service) : base(service)
        {
        }
    }
}