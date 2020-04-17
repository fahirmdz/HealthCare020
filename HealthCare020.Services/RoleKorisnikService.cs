using System.Collections;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.Services
{
    public class RoleKorisnikService : BaseCRUDService<RoleKorisnickiNalogDto,RoleKorisnickiNalogDto, KorisnickiNalogRoleResourceParameters, RoleKorisnickiNalog, KorisnickiNalogRoleUpsertDto, KorisnickiNalogRoleUpsertDto>
    {
        public RoleKorisnikService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
        }

        public override async Task<RoleKorisnickiNalogDto> Insert(KorisnickiNalogRoleUpsertDto request)
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

            return _mapper.Map<RoleKorisnickiNalogDto>(entity);
        }

        public override RoleKorisnickiNalogDto Update(int id, KorisnickiNalogRoleUpsertDto request)
        {
            var entity = _dbContext.RolesKorisnickiNalozi.Find(id);

            if(entity==null)
                throw new NotFoundException("Not Found");

            if(_dbContext.RolesKorisnickiNalozi.Any(x=>x.RoleId==request.RoleId && x.KorisnickiNalogId==request.KorisnickiNalogId))
                throw new UserException("Korisnik vec ima navedenu role-u");

            _mapper.Map(request, entity);

            _dbContext.Update(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<RoleKorisnickiNalogDto>(entity);
        }

        private async Task<IQueryable<RoleKorisnickiNalog>> SearchFilter(IQueryable<RoleKorisnickiNalog> result, KorisnickiNalogRoleResourceParameters search)
        {
            if (search.RoleId.HasValue)
                result = result.Where(x => x.RoleId == search.RoleId);

            if (await result.AnyAsync() && search.KorisnickiNalogId.HasValue)
                result = result.Where(x => x.KorisnickiNalogId == search.KorisnickiNalogId);

            return result;
        }

       
    }
}