using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Interfaces;
using HealthCare020.Services.Security;
using HealthCare020.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class FaceRegonitionRecordService : BaseCRUDService<FaceRecognitionDto, FaceRecognitionDto, BaseResourceParameters, FaceRecognition, FaceRecognitionRecordUpsertDto, FaceRecognitionRecordUpsertDto>
    {
        public FaceRegonitionRecordService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService)
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
        }

        public override async Task<ServiceResult> Insert(FaceRecognitionRecordUpsertDto dtoForCreation)
        {
            if (await Validate(dtoForCreation) is { } validationResult && !validationResult.Succedded)
                return ServiceResult.NotFound(validationResult.message);
            try
            {
                var record = new FaceRecognition
                {
                    KorisnickiNalogId = dtoForCreation.KorisnickiNalogId,
                    DateTime = DateTime.Now
                };

                await _dbContext.AddAsync(record);
                await _dbContext.SaveChangesAsync();

                return ServiceResult.OK(_mapper.Map<FaceRecognitionDto>(record));
            }
            catch (Exception ex)
            {
                return ServiceResult.BadRequest();
            }
        }

        public override async Task<ServiceResult> Update(int id, FaceRecognitionRecordUpsertDto dtoForUpdate)
        {
            if (await Validate(dtoForUpdate) is { } validationResult && !validationResult.Succedded)
                return ServiceResult.NotFound(validationResult.message);

            try
            {
                var recordFromDb = await _dbContext.FaceRecognitions.FindAsync(id);
                if (recordFromDb == null)
                    return ServiceResult.NotFound();

                recordFromDb.KorisnickiNalogId = dtoForUpdate.KorisnickiNalogId;
                recordFromDb.DateTime = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                return ServiceResult.OK(_mapper.Map<FaceRecognitionDto>(recordFromDb));
            }
            catch (Exception ex)
            {
                return ServiceResult.BadRequest();
            }
        }

        private async Task<(bool Succedded, string message)> Validate(FaceRecognitionRecordUpsertDto dto)
        {
            //API consumers need to send RSA encrypted secret for this service
            if (dto.Key.Decrypt(SecurityResources.RSAPrivateKey) != SecurityResources.ServiceIdentificationSecret)
                return (false, "Wrong key");
            if (!await _dbContext.KorisnickiNalozi.AnyAsync(x => x.Id == dto.KorisnickiNalogId))
                return (false, $"Korisnicki nalog sa ID-em {dto.KorisnickiNalogId} nije pronadjen");

            return (true, string.Empty);
        }
    }
}