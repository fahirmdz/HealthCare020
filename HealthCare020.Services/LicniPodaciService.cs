using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class LicniPodaciService : BaseCRUDService<LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaci, LicniPodaciUpsertDto, LicniPodaciUpsertDto>
    {
        public LicniPodaciService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor)
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor)
        {
        }

        public override IQueryable<LicniPodaci> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.LicniPodaci
                .Include(x => x.Grad)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<LicniPodaciDto> Insert(LicniPodaciUpsertDto request)
        {
            if (!await _dbContext.Gradovi.AnyAsync(x => x.Id == request.GradId))
                throw new NotFoundException($"Grad sa ID-em {request.GradId} nije pronadjen");

            var entity = _mapper.Map<LicniPodaci>(request);

            await _dbContext.LicniPodaci.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            entity.Grad = await _dbContext.Gradovi.Include(x => x.Drzava).FirstOrDefaultAsync(x => x.Id == entity.GradId);
            return _mapper.Map<LicniPodaciDto>(entity);
        }

        public override async Task<LicniPodaciDto> Update(int id, LicniPodaciUpsertDto request)
        {
            var entity = await _dbContext.LicniPodaci.FindAsync(id);

            await Task.Run(() =>
            {
                if (entity == null)
                    throw new NotFoundException("Licni podaci nisu pronadjeni");

                if (!_dbContext.Gradovi.Any(x => x.Id == request.GradId))
                {
                    throw new NotFoundException($"Grad sa ID-em {request.GradId} nije pronadjen");
                }

                _mapper.Map(request, entity);

                _dbContext.LicniPodaci.Update(entity);
            });

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<LicniPodaciDto>(entity);
        }
    }
}