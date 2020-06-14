using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace HealthCare020.Services
{
    public class RoleService:BaseCRUDService<TwoFieldsDto,TwoFieldsDto,TwoFieldsResourceParameters,Role,RoleUpsertDto,RoleUpsertDto>
    {
        public RoleService(IMapper mapper,
            HealthCare020DbContext dbContext, 
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor,authService)
        {
        }
    }
}