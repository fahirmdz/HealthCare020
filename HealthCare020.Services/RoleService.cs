using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

        public override async Task<ServiceResult> Delete(int id)
        {
            if(await _dbContext.RolesKorisnickiNalozi.AnyAsync(x=>x.RoleId==id))
                return ServiceResult.BadRequest("Ne mozete izbrisati ovu rolu sve dok je dodijeljena nekom od korisnika");

            return await base.Delete(id);
        }

        public override async Task<PagedList<Role>> FilterAndPrepare(IQueryable<Role> result, TwoFieldsResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (!string.IsNullOrWhiteSpace(resourceParameters.Naziv))
                result = result.Where(x => x.Naziv.ToLower().StartsWith(resourceParameters.Naziv.ToLower().Trim()));

            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}