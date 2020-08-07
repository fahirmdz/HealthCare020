using System.Threading.Tasks;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+Routes.FaceRecognitionRecordsRoute)]
    public class FaceRecognitionRecordsController:BaseCRUDController<FaceRecognition,FaceRecognitionDto,FaceRecognitionDto,BaseResourceParameters,FaceRecognitionRecordUpsertDto,FaceRecognitionRecordUpsertDto>
    {
        public FaceRecognitionRecordsController(ICRUDService<FaceRecognition, FaceRecognitionDto, FaceRecognitionDto, BaseResourceParameters, FaceRecognitionRecordUpsertDto, FaceRecognitionRecordUpsertDto> crudService)
            : base(crudService)
        {
        }

        [AllowAnonymous]
        public override async Task<IActionResult> Insert(FaceRecognitionRecordUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }
    }
}