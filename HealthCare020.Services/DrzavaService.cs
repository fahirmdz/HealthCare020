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
    public class DrzavaService : BaseCRUDService<DrzavaDto,DrzavaDto, DrzavaResourceParameters, Drzava, DrzavaUpsertRequest, DrzavaUpsertRequest>
    {
        public DrzavaService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor,authService)

        {
        }

        public override async Task<ServiceResult> Delete(int id)
        {
            if(await _dbContext.Gradovi.AnyAsync(x=>x.DrzavaId==id))
                return ServiceResult.BadRequest("Postoje gradovi koji su referencirani na ovu drzavu");

            return await base.Delete(id);
        }

        public override  async Task<PagedList<Drzava>> FilterAndPrepare(IQueryable<Drzava> result, DrzavaResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if(resourceParameters!=null)
            {
                if (!string.IsNullOrWhiteSpace(resourceParameters.Naziv))
                    result = result.Where(x => x.Naziv.ToLower().StartsWith(resourceParameters.Naziv.ToLower()));

                if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.PozivniBroj))
                    result = result.Where(x => x.PozivniBroj.StartsWith(resourceParameters.PozivniBroj));
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}