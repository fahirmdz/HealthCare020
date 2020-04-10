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
    public class RoleKorisnikService : BaseCRUDService<RoleKorisnickiNalogModel, KorisnickiNalogRoleSearchRequest, RoleKorisnickiNalog, KorisnickiNalogRoleUpsertRequest, KorisnickiNalogRoleUpsertRequest>
    {
        public RoleKorisnikService(IMapper mapper, HealthCare020DbContext dbContext) : base(mapper, dbContext)
        {
        }

        public override async Task<IList<RoleKorisnickiNalogModel>> Get(KorisnickiNalogRoleSearchRequest search)
        {
            var result = _dbContext.RolesKorisnickiNalozi.AsQueryable();

            if (await result.AnyAsync())
            {
                result = await SearchFilter(result, search);
                return await result.Select(x => _mapper.Map<RoleKorisnickiNalogModel>(x)).ToListAsync();
            }

            return new List<RoleKorisnickiNalogModel>();
        }

        public override async Task<IList<RoleKorisnickiNalogModel>> GetWithEagerLoad(KorisnickiNalogRoleSearchRequest search)
        {
            var result = _dbContext.RolesKorisnickiNalozi
                .Include(x => x.KorisnickiNalog)
                .Include(x => x.Role)
                .AsQueryable();

            if (await result.AnyAsync())
            {
                result = await SearchFilter(result, search);
                return await result.Select(x => _mapper.Map<RoleKorisnickiNalogModel>(x)).ToListAsync();
            }

            return new List<RoleKorisnickiNalogModel>();
        }

        public override async Task<RoleKorisnickiNalogModel> Insert(KorisnickiNalogRoleUpsertRequest request)
        {
            if (!await _dbContext.KorisnickiNalozi.AnyAsync(x => x.Id == request.KorisnickiNalogId))
                throw new NotFoundException($"Korisnicki nalog sa ID-em {request.KorisnickiNalogId} nije pronadjen");

            if (!await _dbContext.Roles.AnyAsync(x => x.Id == request.RoleId))
                throw new NotFoundException($"Role sa ID-em {request.RoleId} nije pronadjena");

            if(await _dbContext.RolesKorisnickiNalozi.AnyAsync(x=>x.RoleId==request.RoleId && x.KorisnickiNalogId==request.KorisnickiNalogId))
                throw new UserException("Korisnik vec ima navedenu role-u");

            var entity = _mapper.Map<RoleKorisnickiNalog>(request);

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<RoleKorisnickiNalogModel>(entity);
        }

        public override RoleKorisnickiNalogModel Update(int id, KorisnickiNalogRoleUpsertRequest request)
        {
            var entity = _dbContext.RolesKorisnickiNalozi.Find(id);

            if(entity==null)
                throw new NotFoundException("Not Found");

            if(_dbContext.RolesKorisnickiNalozi.Any(x=>x.RoleId==request.RoleId && x.KorisnickiNalogId==request.KorisnickiNalogId))
                throw new UserException("Korisnik vec ima navedenu role-u");

            _mapper.Map(request, entity);

            _dbContext.Update(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<RoleKorisnickiNalogModel>(entity);
        }

        public override async Task<RoleKorisnickiNalogModel> FindWithEagerLoad(int id)
        {
            var entity = await _dbContext.RolesKorisnickiNalozi
                .Include(x => x.KorisnickiNalog)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new NotFoundException("Not Found");

            return _mapper.Map<RoleKorisnickiNalogModel>(entity);
        }

        private async Task<IQueryable<RoleKorisnickiNalog>> SearchFilter(IQueryable<RoleKorisnickiNalog> result, KorisnickiNalogRoleSearchRequest search)
        {
            if (search.RoleId.HasValue)
                result = result.Where(x => x.RoleId == search.RoleId);

            if (await result.AnyAsync() && search.KorisnickiNalogId.HasValue)
                result = result.Where(x => x.KorisnickiNalogId == search.KorisnickiNalogId);

            return result;
        }
    }
}