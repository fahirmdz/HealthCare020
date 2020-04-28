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
using System;
using System.Linq;
using System.Threading.Tasks;
using HealthCare020.Services.Helpers;

namespace HealthCare020.Services
{
    public class TokenPosetaService : BaseCRUDService<TokenPosetaDtoLL, TokenPosetaDtoEL, TokenPosetaResourceParameters, TokenPoseta, TokenPosetaUpsertDto, TokenPosetaUpsertDto>
    {
        public TokenPosetaService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor)
        {
        }

        public override IQueryable<TokenPoseta> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.TokeniPoseta
                .Include(x => x.Pacijent)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<TokenPosetaDtoLL> Insert(TokenPosetaUpsertDto dtoForCreation)
        {
            if (!await _dbContext.Pacijenti.AnyAsync(x => x.Id == dtoForCreation.PacijentId))
                throw new NotFoundException($"Pacijent sa ID-em {dtoForCreation.PacijentId} nije pronadjen");

            var existingTokenPoseta =
                await _dbContext.TokeniPoseta.FirstOrDefaultAsync(x => x.PacijentId == dtoForCreation.PacijentId);

            if (existingTokenPoseta != null)
            {
                _dbContext.Remove(existingTokenPoseta);
            }

            var newToken = new TokenPoseta
            {
                PacijentId = dtoForCreation.PacijentId,
                Value = GenerateTokenPoseta()
            };

            await _dbContext.AddAsync(newToken);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TokenPosetaDtoLL>(newToken);
        }

        public override async Task<TokenPosetaDtoLL> Update(int id, TokenPosetaUpsertDto dtoForUpdate)
        {
            var tokenFromDb = await _dbContext.TokeniPoseta.FindAsync(id);

            if (tokenFromDb == null)
                throw new NotFoundException($"Token za posetu sa ID-em {id} nije pronadjen");

            tokenFromDb.Value = GenerateTokenPoseta();

            _dbContext.Update(tokenFromDb);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TokenPosetaDtoLL>(tokenFromDb);
        }

        public override async Task<PagedList<TokenPoseta>> FilterAndPrepare(IQueryable<TokenPoseta> result, TokenPosetaResourceParameters resourceParameters)
        {
            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.ImePacijenta))
                result = result.Where(x =>
                    x.Pacijent.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.ImePacijenta.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.PrezimePacijenta))
                result = result.Where(x =>
                    x.Pacijent.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.PrezimePacijenta.ToLower()));

            return await base.FilterAndPrepare(result, resourceParameters);
        }

        private string GenerateTokenPoseta()
        {
            var rand = new Random();
            string token = string.Empty;

            do
            {
                token = rand.Next(100000, 999999).ToString("D6");
            } while (_dbContext.Set<TokenPoseta>().Any(x => x.Value == token));

            return token;
        }
    }
}