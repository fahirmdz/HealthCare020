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
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class ZdravstvenoStanjeService : BaseCRUDService<ZdravstvenoStanjeDto, ZdravstvenoStanjeDto, ZdravstvenoStanjeResourceParameters, ZdravstvenoStanje, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto>
    {
        public ZdravstvenoStanjeService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
        }

        public override async Task<ServiceResult> Delete(int id)
        {
            var entityFromDb = await _dbContext.ZdravstvenaStanja.FindAsync(id);
            if (entityFromDb == null)
                return ServiceResult.NotFound($"Zdravstveno stanje sa ID-em {id} nije pronadjeno");

            if (await _dbContext.LekarskaUverenja.AnyAsync(x => x.ZdravstvenoStanjeId == id))
                return ServiceResult.BadRequest($"Ne mozete brisati zdravstveno stanje, sve dok ima lekarskih uverenja na kojima je referencirano");

            await Task.Run(() =>
            {
                _dbContext.Remove(entityFromDb);
            });

            await _dbContext.SaveChangesAsync();

            return ServiceResult.NoContent();
        }

        public override async Task<PagedList<ZdravstvenoStanje>> FilterAndPrepare(IQueryable<ZdravstvenoStanje> result, ZdravstvenoStanjeResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (resourceParameters != null)
            {
                if (!string.IsNullOrWhiteSpace(resourceParameters.Opis))
                    result = result.Where(x => x.Opis.ToLower().Contains(resourceParameters.Opis.ToLower()));
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}