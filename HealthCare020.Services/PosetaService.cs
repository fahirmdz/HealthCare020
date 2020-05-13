using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class PosetaService : BaseCRUDService<PosetaDtoLL, PosetaDtoEL, PosetaResourceParameters, Poseta, PosetaUpsertDto, PosetaUpsertDto>
    {
        public PosetaService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor)
        {
        }

        public override IQueryable<Poseta> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Posete
                .Include(x => x.TokenPoseta)
                .ThenInclude(x => x.Pacijent)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult<PosetaDtoLL>> Insert(PosetaUpsertDto dtoForCreation)
        {
            var tokenPosetaFromDb = await _dbContext.TokeniPoseta
                .FirstOrDefaultAsync(x => x.Value == dtoForCreation.TokenPoseta);

            if (tokenPosetaFromDb == null)
                return new ServiceResult<PosetaDtoLL>(HttpStatusCode.NotFound, $"Token sa vrijednoscu {dtoForCreation.TokenPoseta} nije pronadjen.");

            if (tokenPosetaFromDb.BrojPreostalihPoseta == 0)
                return new ServiceResult<PosetaDtoLL>(HttpStatusCode.BadRequest, $"Token za posetu {dtoForCreation.TokenPoseta} je dostigao maximalan broj poseta.");

            tokenPosetaFromDb.BrojPreostalihPoseta -= 1;
            _dbContext.Update(tokenPosetaFromDb);
            var newEntity = new Poseta
            {
                DatumVreme = DateTime.Now,
                TokenPosetaId = tokenPosetaFromDb.Id
            };

            await _dbContext.AddAsync(newEntity);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult<PosetaDtoLL>(_mapper.Map<PosetaDtoLL>(newEntity));
        }

        public override async Task<ServiceResult<PosetaDtoLL>> Update(int id, PosetaUpsertDto dtoForUpdate)
        {
            var posetaFromDb = await _dbContext.Posete.FindAsync(id);

            if (posetaFromDb == null)
                return new ServiceResult<PosetaDtoLL>(HttpStatusCode.NotFound, $"Poseta sa ID-em {id} nije pronadjena.");

            var tokenPosetaFromDb = await _dbContext.TokeniPoseta
                .FirstOrDefaultAsync(x => x.Value == dtoForUpdate.TokenPoseta);

            if (tokenPosetaFromDb == null)
                return new ServiceResult<PosetaDtoLL>(HttpStatusCode.NotFound, $"Token sa vrijednoscu {dtoForUpdate.TokenPoseta} nije pronadjen.");

            if (tokenPosetaFromDb.BrojPreostalihPoseta == 0)
                return new ServiceResult<PosetaDtoLL>(HttpStatusCode.BadRequest, $"Token za posetu {dtoForUpdate.TokenPoseta} je dostigao maximalan broj poseta.");

            await Task.Run(() =>
            {
                posetaFromDb.TokenPosetaId = tokenPosetaFromDb.Id;
                _dbContext.Update(posetaFromDb);
                _dbContext.SaveChanges();
            });

            return new ServiceResult<PosetaDtoLL>(_mapper.Map<PosetaDtoLL>(posetaFromDb));
        }

        public override async Task<PagedList<Poseta>> FilterAndPrepare(IQueryable<Poseta> result, PosetaResourceParameters resourceParameters)
        {
            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.ImePacijenta))
                result = result.Where(x =>
                    x.TokenPoseta.Pacijent.LicniPodaci.Ime.ToLower()
                        .StartsWith(resourceParameters.ImePacijenta.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.TokenPoseta))
                result = result.Where(x => x.TokenPoseta.Value.StartsWith(resourceParameters.TokenPoseta));

            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}