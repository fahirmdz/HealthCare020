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

    }
}