using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.Services
{
    public class GradService : BaseCRUDService<GradDto, GradResourceParameters, Grad, GradUpsertDto, GradUpsertDto>
    {
        public GradService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
        }

        public override async Task<GradDto> FindWithEagerLoad(int id)
        {
            var result = await _dbContext.Gradovi.Include(x => x.Drzava).FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Grad nije pronadjen");

            return _mapper.Map<GradDto>(result);
        }

        public override async Task<IList<GradDto>> GetWithEagerLoad(GradResourceParameters search)
        {
            var result = _dbContext.Gradovi.Include(x => x.Drzava);

            if (await result.AnyAsync())
            {
                return await result.Select(x => _mapper.Map<GradDto>(x)).ToListAsync();
            }

            return new List<GradDto>();
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

       
    }
}