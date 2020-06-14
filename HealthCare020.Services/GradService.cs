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
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HealthCare020.Services.Constants;
using Microsoft.AspNetCore.Authorization;

namespace HealthCare020.Services
{
    public class GradService : BaseCRUDService<GradDtoLL, GradDtoEL, GradResourceParameters, Grad, GradUpsertDto, GradUpsertDto>
    {
        public GradService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor,authService)
        {
        }

        public override IQueryable<Grad> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Gradovi.Include(x => x.Drzava).AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult> Insert(GradUpsertDto request)
        {
            if (!await _dbContext.Drzave.AnyAsync(x => x.Id == request.DrzavaId))
            {
                return ServiceResult.NotFound($"Drzava sa ID-em {request.DrzavaId} nije pronadjena");
            }

            var entity = _mapper.Map<Grad>(request);

            await _dbContext.Gradovi.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult<GradDtoLL>(_mapper.Map<GradDtoLL>(entity));
        }

        public override async Task<ServiceResult> Update(int id, GradUpsertDto request)
        {
            var entity = await _dbContext.Gradovi.FindAsync(id);
            if (entity == null)
                return ServiceResult.NotFound("Grad nije pronadjen");

            if (!_dbContext.Drzave.Any(x => x.Id == request.DrzavaId))
            {
                return ServiceResult.NotFound($"Drzava sa ID-em {request.DrzavaId} nije pronadjena");
            }
            await Task.Run(() =>
            {
                _mapper.Map(request, entity);

                _dbContext.Gradovi.Update(entity);
            });

            await _dbContext.SaveChangesAsync();

            return new ServiceResult<GradDtoLL>(_mapper.Map<GradDtoLL>(entity));
        }

        public override async Task<PagedList<Grad>> FilterAndPrepare(IQueryable<Grad> result, GradResourceParameters resourceParameters)
        {
            if (!string.IsNullOrWhiteSpace(resourceParameters.Naziv) && await result.AnyAsync())
            {
                result = result.Where(x => x.Naziv.ToLower().StartsWith(resourceParameters.Naziv.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.DrzavaNaziv) && await result.AnyAsync())
            {
                result = result.Where(
                    x => x.Drzava.Naziv.ToLower().StartsWith(resourceParameters.DrzavaNaziv.ToLower()));
            }

            if (resourceParameters.DrzavaId.HasValue && await result.AnyAsync())
            {
                result = result.Where(x => x.DrzavaId == resourceParameters.DrzavaId);
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}