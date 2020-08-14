using HealthCare020.API.Constants;
using HealthCare020.API.Properties;
using HealthCare020.Core.Constants;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    [Authorize(AuthorizationPolicies.AdministratorPolicy)]
    [Route("api/" + Routes.FaceRecognitionRoute)]
    [ApiController]
    public class FaceRecognitionController : ControllerBase
    {
        private readonly IFaceRecognitionService _faceRecognitionService;

        public FaceRecognitionController(IFaceRecognitionService faceRecognitionService)
        {
            _faceRecognitionService = faceRecognitionService;
        }

        [HttpPost("person-group")]
        public async Task<IActionResult> CreatePersonGroup()
        {
            if (await _faceRecognitionService.CreatePersonGroup(Resources.FaceAPI_PersonGroupId,
                Resources.FaceAPI_PersonGroupName))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("person-group")]
        public async Task<IActionResult> DeletePersonGroup()
        {
            try
            {
                await _faceRecognitionService.DeletePersonGroup(Resources.FaceAPI_PersonGroupId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("person-group/persons")]
        public async Task<IActionResult> PersonGroupPersonsList([FromQuery] BaseResourceParameters resourceParameters)
        {
            var lastReturnedPersonId = string.Empty;
            if (HttpContext.Session.GetString("LastReturnedPersonId") is { } personId)
            {
                lastReturnedPersonId = personId;
            }

            if (HttpContext.Session.GetInt32("LastPersonsPageNumber") is { } lastPageNumber)
            {
                if (resourceParameters?.PageNumber <= lastPageNumber)
                    lastReturnedPersonId = string.Empty;
            }
            var persons = await _faceRecognitionService.GetPersonGroupPersonsList(Resources.FaceAPI_PersonGroupId,
                resourceParameters?.PageSize ?? 6, lastReturnedPersonId);

            if (persons.Any())
            {
                HttpContext.Session.SetString("LastReturnedPersonId", persons.Last().PersonId.ToString());
                HttpContext.Session.SetInt32("LastPersonsPageNumber", resourceParameters?.PageNumber ?? 1);
            }
            return Ok(persons);
        }

        [HttpDelete("person-group/persons/{Id}")]
        public async Task<IActionResult> DeletePersonFromPersonGroup(string Id)
        {
            if (Guid.TryParse(Id, out Guid paresedGuid))
            {
                await _faceRecognitionService.DeletePersonFromGroup(paresedGuid, Resources.FaceAPI_PersonGroupId);
                return Ok();
            }

            return BadRequest("Unable to parse person ID");
        }

        [HttpPost("person-group/persons/{personId}/face")]
        public async Task<IActionResult> AddFaceToPerson(string personId, [FromBody] string encodedByteContent)
        {
            if (Guid.TryParse(personId, out Guid parsedGuid))
            {
                byte[] image;
                try
                {
                    image = Convert.FromBase64String(encodedByteContent);
                }
                catch (Exception ex)

                {
                    return BadRequest("Unable to parse content");
                }

                var face = await _faceRecognitionService.AddFaceToPerson(Resources.FaceAPI_PersonGroupId, parsedGuid,
                    new MemoryStream(image));
                if (face != null)
                    return Ok();

                return BadRequest();
            }
            return BadRequest("Unable to parse content");
        }
    }
}