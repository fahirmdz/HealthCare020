using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.Services
{
    public class ZdravstvenoStanjeService : BaseCRUDService<ZdravstvenoStanjeDto,ZdravstvenoStanjeDto, ZdravstvenoStanjeResourceParameters, ZdravstvenoStanje, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto>
    {
        public ZdravstvenoStanjeService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
        }
    }
}