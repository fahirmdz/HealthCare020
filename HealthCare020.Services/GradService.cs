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

namespace HealthCare020.Services
{
    public class GradService : BaseCRUDService<GradModel, GradSearchRequest, Grad, GradUpsertRequest, GradUpsertRequest>
    {
        public GradService(IMapper mapper, HealthCare020DbContext dbContext) : base(mapper, dbContext)
        {
        }

        public override async Task<GradModel> FindWithEagerLoad(int id)
        {
            var result = await _dbContext.Gradovi.Include(x => x.Drzava).FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Grad nije pronadjen");

            return _mapper.Map<GradModel>(result);
        }

        public override async Task<IList<GradModel>> GetWithEagerLoad(GradSearchRequest search)
        {
            var result = _dbContext.Gradovi.Include(x => x.Drzava);

            if (await result.AnyAsync())
            {
                return await result.Select(x => _mapper.Map<GradModel>(x)).ToListAsync();
            }

            return new List<GradModel>();
        }

        public override async Task<GradModel> Insert(GradUpsertRequest request)
        {
            if (!await _dbContext.Drzave.AnyAsync(x => x.Id == request.DrzavaId))
            {
                throw new NotFoundException($"Drzava sa ID-em {request.DrzavaId} nije pronadjena");
            }

            var entity = _mapper.Map<Grad>(request);

            await _dbContext.Gradovi.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<GradModel>(entity);
        }

        public override GradModel Update(int id, GradUpsertRequest request)
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

            return _mapper.Map<GradModel>(entity);
        }
    }
}