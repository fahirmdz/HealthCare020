using System;
using System.Collections;
using System.Dynamic;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HealthCare020.Services.Helpers;

namespace HealthCare020.Services
{
    public class GradService : BaseCRUDService<GradDto, GradResourceParameters, Grad, GradUpsertDto, GradUpsertDto>
    {
        public GradService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
        }

        public override IQueryable<Grad> GetWithEagerLoad(int? id = null)
        {
            if (id.HasValue)
            {
                return _dbContext.Gradovi.Include(x => x.Drzava).Where(x => x.Id == id);
            }
            return _dbContext.Gradovi.Include(x => x.Drzava);
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

        public override async Task<IEnumerable> FilterAndPrepare(IQueryable<Grad> result, GradResourceParameters resourceParameters)
        {

            if (resourceParameters.EagerLoaded)
            {
                if (!_propertyCheckerService.TypeHasProperties<GradDtoEagerLoaded>(resourceParameters.Fields))
                {
                    throw new UserException($"One or more properties are invalid");
                }

                if (!_propertyMappingService.ValidMappingExistsFor<GradDtoEagerLoaded, Grad>(resourceParameters.Fields))
                {
                    throw new UserException(string.Empty);
                }

                return result.Select(x => _mapper.Map<GradDtoEagerLoaded>(x)).AsEnumerable().ShapeData(resourceParameters.Fields);
            }

            return result.Select(x => _mapper.Map<GradDto>(x)).AsEnumerable().ShapeData(resourceParameters.Fields);
        }

        public override async Task<ExpandoObject> FilterAndPrepare(Grad entity, GradResourceParameters resourceParameters)
        {
            if (resourceParameters.EagerLoaded)
            {
                PropertyCheck<GradDtoEagerLoaded>(resourceParameters.Fields);

                return _mapper.Map<GradDtoEagerLoaded>(entity).ShapeData(resourceParameters.Fields);
            }

            return _mapper.Map<GradDto>(entity).ShapeData(resourceParameters.Fields);
        }
    }
}