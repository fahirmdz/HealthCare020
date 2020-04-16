using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Services
{
    public class LicniPodaciService: BaseCRUDService<LicniPodaciDto,LicniPodaciResourceParameters,LicniPodaci,LicniPodaciUpsertDto,LicniPodaciUpsertDto>
    {
        public LicniPodaciService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
        }

        public override async Task<LicniPodaciDto> FindWithEagerLoad(int id)
        {
            var result = await _dbContext.LicniPodaci
                .Include(x => x.Grad)
                .ThenInclude(x=>x.Drzava)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Licni podaci nisu pronadjen");

            return _mapper.Map<LicniPodaciDto>(result);
        }

        public override async Task<IList<LicniPodaciDto>> GetWithEagerLoad(LicniPodaciResourceParameters search)
        {
            var result =  _dbContext.LicniPodaci
                .Include(x => x.Grad)
                .ThenInclude(x=>x.Drzava)
                .AsQueryable();

            if (await result.AnyAsync())
            {
                return await result.Select(x => _mapper.Map<LicniPodaciDto>(x)).ToListAsync();
            }

            return new List<LicniPodaciDto>();
        }

        public override async Task<LicniPodaciDto> Insert(LicniPodaciUpsertDto request)
        {
            if(!await _dbContext.Gradovi.AnyAsync(x=>x.Id==request.GradId))
                throw new NotFoundException($"Grad sa ID-em {request.GradId} nije pronadjen");

            var entity = _mapper.Map<LicniPodaci>(request);

            await _dbContext.LicniPodaci.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            entity.Grad = await _dbContext.Gradovi.Include(x=>x.Drzava).FirstOrDefaultAsync(x=>x.Id==entity.GradId);
            return _mapper.Map<LicniPodaciDto>(entity);
        }

        public override LicniPodaciDto Update(int id, LicniPodaciUpsertDto request)
        {
            var entity =  _dbContext.LicniPodaci.Find(id);

            if(entity==null)
                throw new NotFoundException("Licni podaci nisu pronadjeni");

            if (!_dbContext.Gradovi.Any(x => x.Id == request.GradId))
            {
                throw new NotFoundException($"Grad sa ID-em {request.GradId} nije pronadjen");
            }

            _mapper.Map(request, entity);

            _dbContext.LicniPodaci.Update(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<LicniPodaciDto>(entity);
        }

        
    }
}