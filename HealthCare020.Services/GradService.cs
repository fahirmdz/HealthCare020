using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HealthCare020.Services
{
    public class GradService : BaseCRUDService<GradDtoLL, GradDtoEL, GradResourceParameters, Grad, GradUpsertDto, GradUpsertDto>
    {
        public GradService(IMapper mapper, 
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor) 
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService,httpContextAccessor)
        {
        }

        public override IQueryable<Grad> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Gradovi.Include(x => x.Drzava).AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<GradDtoLL> Insert(GradUpsertDto request)
        {
            if (!await _dbContext.Drzave.AnyAsync(x => x.Id == request.DrzavaId))
            {
                throw new NotFoundException($"Drzava sa ID-em {request.DrzavaId} nije pronadjena");
            }

            var entity = _mapper.Map<Grad>(request);

            await _dbContext.Gradovi.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<GradDtoLL>(entity);
        }

        public override async Task<GradDtoLL> Update(int id, GradUpsertDto request)
        {
            var entity = await _dbContext.Gradovi.FindAsync(id);

            await Task.Run(() =>
            {
                if (entity == null)
                    throw new NotFoundException("Grad nije pronadjen");

                if (!_dbContext.Drzave.Any(x => x.Id == request.DrzavaId))
                {
                    throw new NotFoundException($"Drzava sa ID-em {request.DrzavaId} nije pronadjena");
                }

                _mapper.Map(request, entity);

                _dbContext.Gradovi.Update(entity);
            });

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<GradDtoLL>(entity);
        }

        public override async Task<PagedList<Grad>> FilterAndPrepare(IQueryable<Grad> result, GradResourceParameters resourceParameters)
        {
            if (resourceParameters.EagerLoaded)
                PropertyCheck<GradDtoEL>(resourceParameters.Fields, resourceParameters.OrderBy);

            return PagedList<Grad>.Create(result, resourceParameters.PageNumber,
                resourceParameters.PageSize);
        }
    }
}