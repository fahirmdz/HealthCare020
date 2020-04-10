using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Services
{
    public class LicniPodaciService: BaseCRUDService<LicniPodaciModel,LicniPodaciSearchRequest,LicniPodaci,LicniPodaciUpsertRequest,LicniPodaciUpsertRequest>
    {
        public LicniPodaciService(IMapper mapper, HealthCare020DbContext dbContext) : base(mapper, dbContext)
        {
        }

        public override async Task<LicniPodaciModel> FindWithEagerLoad(int id)
        {
            var result = await _dbContext.LicniPodaci
                .Include(x => x.Grad)
                .ThenInclude(x=>x.Drzava)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Licni podaci nisu pronadjen");

            return _mapper.Map<LicniPodaciModel>(result);
        }

        public override async Task<IList<LicniPodaciModel>> GetWithEagerLoad(LicniPodaciSearchRequest search)
        {
            var result =  _dbContext.LicniPodaci
                .Include(x => x.Grad)
                .ThenInclude(x=>x.Drzava)
                .AsQueryable();

            if (await result.AnyAsync())
            {
                return await result.Select(x => _mapper.Map<LicniPodaciModel>(x)).ToListAsync();
            }

            return new List<LicniPodaciModel>();
        }

        public override async Task<LicniPodaciModel> Insert(LicniPodaciUpsertRequest request)
        {
            if(!await _dbContext.Gradovi.AnyAsync(x=>x.Id==request.GradId))
                throw new NotFoundException($"Grad sa ID-em {request.GradId} nije pronadjen");

            var entity = _mapper.Map<LicniPodaci>(request);

            await _dbContext.LicniPodaci.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<LicniPodaciModel>(entity);
        }

        public override LicniPodaciModel Update(int id, LicniPodaciUpsertRequest request)
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

            return _mapper.Map<LicniPodaciModel>(entity);
        }
    }
}