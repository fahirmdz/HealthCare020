using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HealthCare020.Services.Helpers;

namespace HealthCare020.Services
{
    public class ZahtevZaPregledService : BaseCRUDService<ZahtevZaPregledDtoLL, ZahtevZaPregledDtoEL, ZahtevZaPregledResourceParameters, ZahtevZaPregled, ZahtevZaPregledUpsertDto, ZahtevZaPregledUpsertDto>
    {
        public ZahtevZaPregledService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor) : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor)
        {
        }

        public override IQueryable<ZahtevZaPregled> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Set<ZahtevZaPregled>()
                .Include(x => x.Pacijent)
                .ThenInclude(x => x.ZdravstvenaKnjizica)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .Include(x => x.Doktor)
                .ThenInclude(x => x.Radnik)
                .ThenInclude(x => x.LicniPodaci)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult> Insert(ZahtevZaPregledUpsertDto dtoForCreation)
        {
            if (!await _dbContext.ZahteviZaPregled.AnyAsync(x => x.DoktorId == dtoForCreation.DoktorId))
                return ServiceResult.NotFound($"Doktor sa ID-em {dtoForCreation.DoktorId} nije pronadjen.");

            if (!await _dbContext.ZahteviZaPregled.AnyAsync(x => x.PacijentId == dtoForCreation.PacijentId))
                return ServiceResult.NotFound($"Pacijent sa ID-em {dtoForCreation.DoktorId} nije pronadjen.");

            if (dtoForCreation.UputnicaId.HasValue && !await _dbContext.ZahteviZaPregled.AnyAsync(x => x.UputnicaId == dtoForCreation.UputnicaId))
                return ServiceResult.NotFound($"Uputnica sa ID-em {dtoForCreation.DoktorId} nije pronadjena.");

            var entity = new ZahtevZaPregled
            {
                DoktorId = dtoForCreation.DoktorId,
                PacijentId = dtoForCreation.PacijentId,
                UputnicaId = dtoForCreation.UputnicaId,
                Napomena = dtoForCreation.Napomena
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return ServiceResult<ZahtevZaPregledDtoLL>.OK(_mapper.Map<ZahtevZaPregledDtoLL>(entity));
        }

        public override async Task<ServiceResult> Update(int id, ZahtevZaPregledUpsertDto dtoForUpdate)
        {
            var zahtevFromDb = await _dbContext.ZahteviZaPregled.FindAsync(id);

            if (zahtevFromDb == null)
                return new ServiceResult<ZahtevZaPregledDtoLL>();

            if (!await _dbContext.ZahteviZaPregled.AnyAsync(x => x.DoktorId == dtoForUpdate.DoktorId))
                return ServiceResult.NotFound($"Doktor sa ID-em {dtoForUpdate.DoktorId} nije pronadjen.");

            if (!await _dbContext.ZahteviZaPregled.AnyAsync(x => x.PacijentId == dtoForUpdate.PacijentId))
                return ServiceResult.NotFound($"Pacijent sa ID-em {dtoForUpdate.DoktorId} nije pronadjen.");

            if (dtoForUpdate.UputnicaId.HasValue &&
                !await _dbContext.ZahteviZaPregled.AnyAsync(x => x.UputnicaId == dtoForUpdate.UputnicaId))
                return ServiceResult.NotFound($"Uputnica sa ID-em {dtoForUpdate.DoktorId} nije pronadjena.");

            _mapper.Map(dtoForUpdate, zahtevFromDb);

            await Task.Run(() =>
            {
                _dbContext.ZahteviZaPregled.Update(zahtevFromDb);
            });
            await _dbContext.SaveChangesAsync();

            return ServiceResult<ZahtevZaPregledDtoLL>.OK(_mapper.Map<ZahtevZaPregledDtoLL>(zahtevFromDb));
        }
    }
}