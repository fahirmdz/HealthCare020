using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Services
{
    public class NaucnaOblastService : BaseCRUDService<TwoFieldsDto, TwoFieldsDto, TwoFieldsResourceParameters, NaucnaOblast, NaucnaOblastUpsertDto, NaucnaOblastUpsertDto>
    {
        public NaucnaOblastService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
        }

        public override async Task<PagedList<NaucnaOblast>> FilterAndPrepare(IQueryable<NaucnaOblast> result, TwoFieldsResourceParameters resourceParameters)
        {
            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.Naziv))
                result = result.Where(x =>
                    x.Naziv.ToLower().StartsWith(resourceParameters.Naziv.ToLower()));

            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}