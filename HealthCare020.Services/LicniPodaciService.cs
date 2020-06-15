using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Enums;
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

namespace HealthCare020.Services
{
    public class LicniPodaciService : BaseCRUDService<LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaci, LicniPodaciUpsertDto, LicniPodaciUpsertDto>
    {
        public LicniPodaciService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
        }

        public override async Task<ServiceResult> GetById(int id, bool EagerLoaded)
        {
            if (await _authService.CurrentUserIsInRoleAsync(RoleType.Pacijent))
            {
                var user = await _authService.LoggedInUser();
                if (!await _dbContext.Pacijenti
                        .Include(x => x.ZdravstvenaKnjizica)
                        .AnyAsync(x => x.KorisnickiNalogId == user.Id && x.ZdravstvenaKnjizica.LicniPodaciId == id))
                {
                    return ServiceResult.Forbidden($"Nemate permisije za pristup licnim podacima drugih pacijenata.");
                }
            }

            return await base.GetById(id, EagerLoaded);
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

        public override async Task<ServiceResult> Insert(LicniPodaciUpsertDto request)
        {
            if (!await _dbContext.Gradovi.AnyAsync(x => x.Id == request.GradId))
                return ServiceResult.NotFound($"Grad sa ID-em {request.GradId} nije pronadjen");

            var entity = _mapper.Map<LicniPodaci>(request);

            await _dbContext.LicniPodaci.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            entity.Grad = await _dbContext.Gradovi.Include(x => x.Drzava).FirstOrDefaultAsync(x => x.Id == entity.GradId);
            return new ServiceResult<LicniPodaciDto>(_mapper.Map<LicniPodaciDto>(entity));
        }

        public override async Task<ServiceResult> Update(int id, LicniPodaciUpsertDto request)
        {
            var entity = await _dbContext.LicniPodaci.FindAsync(id);
            if (entity == null)
                return ServiceResult.NotFound("Licni podaci nisu pronadjeni");

            if (!_dbContext.Gradovi.Any(x => x.Id == request.GradId))
            {
                return ServiceResult.NotFound($"Grad sa ID-em {request.GradId} nije pronadjen");
            }
            await Task.Run(() =>
            {
                _mapper.Map(request, entity);

                _dbContext.LicniPodaci.Update(entity);
            });

            await _dbContext.SaveChangesAsync();

            return new ServiceResult<LicniPodaciDto>(_mapper.Map<LicniPodaciDto>(entity));
        }
    }
}