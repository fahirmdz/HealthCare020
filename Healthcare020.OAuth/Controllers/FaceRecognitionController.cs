using Healthcare020.OAuth.Validators;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Resources;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Services.Interfaces;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare020.OAuth.Controllers
{
    [Route(Routes.FaceRecognitionRoute)]
    public class FaceRecognitionController : Controller
    {
        private readonly IKorisnikService _korisnikService;
        private readonly IEventService _events;

        public FaceRecognitionController(IKorisnikService korisnikService,
            IEventService events)
        {
            _korisnikService = korisnikService;
            _events = events;
        }

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> LoginWithFaceID([FromForm]TokenEndpointRequestBody model)
        {
            var img = Convert.FromBase64String(model.Image);

            var korisnickiNalog = await _korisnikService.Authenticate(img);
            if (korisnickiNalog == null)
                return BadRequest(SharedResources.UnsuccessfulFaceIdAuthentication);

            //Secret GUID for resource owner password validator (if GUID is not valid, auth will be rejected)
            var secretGuid = new Guid();
            FaceIDSecretsManager.Add(secretGuid);

            var postBody = @"client_id=" + model.ClientId
                                         + "&client_secret=" + model.ClientSecret
                                         + "&grant_type=password&username="
                                         + $"{korisnickiNalog.Username}*{korisnickiNalog.Id}" + $"&password={secretGuid}"
                                         + "&scope=openid offline_access face-recognition";
            var client = new HttpClient();
            HttpResponseMessage response;
            using (var stringContent = new StringContent(postBody, Encoding.UTF8, "application/x-www-form-urlencoded"))
            {
                response = await client.PostAsync($"{Request.Scheme}://{Request.Host.Value}/connect/token", stringContent);
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseJson = await response.Content.ReadAsStringAsync();

                return Ok(responseJson);
            }

            return BadRequest(response.Content.ReadAsStringAsync());
        }
    }
}