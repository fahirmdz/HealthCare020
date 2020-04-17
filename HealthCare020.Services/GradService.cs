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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class GradService : BaseCRUDService<GradDto, GradDtoEagerLoaded, GradResourceParameters, Grad, GradUpsertDto, GradUpsertDto>
    {
        public GradService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
        }

        public override IQueryable<Grad> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Gradovi.Include(x => x.Drzava).AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<GradDto> Insert(GradUpsertDto request)
        {
            if (!await _dbContext.Drzave.AnyAsync(x => x.Id == request.DrzavaId))
            {
                throw new NotFoundException($"Drzava sa ID-em {request.DrzavaId} nije pronadjena");
            }

            var entity = _mapper.Map<Grad>(request);

            await _dbContext.Gradovi.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<GradDto>(entity);
        }

        public override GradDto Update(int id, GradUpsertDto request)
        {
            var entity = _dbContext.Gradovi.Find(id);

            if (entity == null)
                throw new NotFoundException("Grad nije pronadjen");

            if (!_dbContext.Drzave.Any(x => x.Id == request.DrzavaId))
            {
                throw new NotFoundException($"Drzava sa ID-em {request.DrzavaId} nije pronadjena");
            }

            _mapper.Map(request, entity);

            _dbContext.Gradovi.Update(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<GradDto>(entity);
        }

        public override async Task<PagedList<Grad>> FilterAndPrepare(IQueryable<Grad> result, GradResourceParameters resourceParameters)
        {
            if (resourceParameters.EagerLoaded)
                PropertyCheck<GradDtoEagerLoaded>(resourceParameters.Fields,resourceParameters.OrderBy);

            return PagedList<Grad>.Create(result, resourceParameters.PageNumber,
                resourceParameters.PageSize);
        }

        public override IEnumerable PrepareDataForClient(IEnumerable<Grad> data, GradResourceParameters resourceParameters)
        {
            if (resourceParameters.EagerLoaded)
                return data.Select(x => _mapper.Map<GradDtoEagerLoaded>(x));
            return data.Select(x => _mapper.Map<GradDto>(x));
        }
    }
}