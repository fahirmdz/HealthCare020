using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using HealthCare020.Core.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Healthcare020.Mobile.Services
{
    internal enum HttpRequestType
    {
        PUT, POST, GET, DELETE
    }

    #region Models

    public class Person
    {
        public string PersonId { get; set; }
        public List<string> PersistedFaceIds { get; set; }
        public string Name { get; set; }
    }

    public class Face
    {
        public string FaceId { get; set; }
    }

    public class PersonCandidate
    {
        public string PersonId { get; set; }
        public float Confidence { get; set; }
    }

    public class FaceIdentificationResult
    {
        public string FaceId { get; set; }
        public List<PersonCandidate> Candidates { get; set; }
    }

    #endregion Models

    public class FaceRecognitionService : IFaceRecognitionService
    {
        private readonly IAPIService _apiService;

        public FaceRecognitionService()
        {
            _apiService = new APIService(Routes.PacijentiRoute);
        }

        public async Task<bool> CreatePersounGroup(string personGroupId, string groupName)
        {
            var requestBody = new
            {
                Name = groupName,
                RecognitionModel = "recognition_02"
            };
            var uri = $"https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/{personGroupId}?";

            try
            {
                var response = await MakeRequest(JsonConvert.SerializeObject(requestBody), uri, HttpRequestType.PUT);
                return response?.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Person> CreatePersonInGroup(string name)
        {
            var uri = $"https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/{AppResources.FaceAPI_PersonGroupId}/persons?";

            var requestBody = new
            {
                Name = name
            };
            try
            {
                var response = await MakeRequest(JsonConvert.SerializeObject(requestBody), uri, HttpRequestType.POST);
                if (response.StatusCode != HttpStatusCode.OK)
                    return null;

                return await response.Content.ReadAsAsync<Person>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AddFaceToPerson(string personId, byte[] picture)
        {
            var uri =
                $"https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/{AppResources.FaceAPI_PersonGroupId}/persons/{personId}/persistedFaces?";

            try
            {
                var response = await MakeRequest(string.Empty, uri, HttpRequestType.POST, byteBody: picture,
                    contentType: "application/octet-stream");

                await TrainModel(AppResources.FaceAPI_PersonGroupId);

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task TrainModel(string personGroupId)
        {
            var uri = $"https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/{personGroupId}/train?";

            var response = await MakeRequest(string.Empty, uri, HttpRequestType.POST);
        }

        public async Task<bool> AddPersonToGruop(string username, byte[] picture)
        {
            try
            {
                var person = await CreatePersonInGroup(username);
                if (person == null)
                    return false;

                return await AddFaceToPerson(person.PersonId, picture);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Person> IdentifyFace(byte[] facePicture)
        {
            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/identify?";
            var face = await DetectFace(facePicture);
            if (face == null)
                return null;

            var requestBody = new
            {
                PersonGroupId = AppResources.FaceAPI_PersonGroupId,
                FaceIds = new[] { face.FaceId },
                MaxNumOfCandidatesReturned = 1,
                ConfidenceThreshold = 0.5
            };

            try
            {
                var response = await MakeRequest(JsonConvert.SerializeObject(requestBody), uri, HttpRequestType.POST);
                var str = await response.Content.ReadAsStringAsync();
                var results = await response.Content.ReadAsAsync<List<FaceIdentificationResult>>();

                if (results.Any())
                {
                    var result = results.First();
                    var personWithHighestConfidence =
                        result.Candidates.FirstOrDefault(x => x.Confidence == result.Candidates.Max(c => c.Confidence));

                    var person = await GetPerson(personWithHighestConfidence.PersonId);

                    if (person != null)
                        return person;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Face> DetectFace(byte[] facePicture)
        {
            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&recognitionModel=recognition_02&";
            try
            {
                var response = await MakeRequest(string.Empty, uri, HttpRequestType.POST, byteBody: facePicture, contentType: "application/octet-stream");
                if (response.StatusCode != HttpStatusCode.OK)
                    return null;

                var face = await response.Content.ReadAsAsync<List<Face>>();
                return face?[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Person> GetPerson(string personId)
        {
            var uri = $"https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/{AppResources.FaceAPI_PersonGroupId}/persons/{personId}?";

            var response = await MakeRequest(string.Empty, uri, HttpRequestType.GET);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            Person result = null;

            try
            {
                return await response.Content.ReadAsAsync<Person>();
            }
            catch (Exception ex)
            {
                //ignore;
            }

            try
            {
                return (await response.Content.ReadAsAsync<List<Person>>())?.First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeletePersonGroup(string personGroupId)
        {
            var uri = $"https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/{personGroupId}?";
            var response = await MakeRequest(string.Empty, uri, HttpRequestType.DELETE);
            return response.StatusCode == HttpStatusCode.OK;
        }

        private async Task<HttpResponseMessage> MakeRequest(string body, string url, HttpRequestType requestType, string contentType = "application/json", byte[] byteBody = null)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppResources.AzureFaceAPI_Key);

            var uri = url + queryString;

            HttpResponseMessage response;

            byte[] byteData = byteBody ?? Encoding.UTF8.GetBytes(body);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                switch (requestType)
                {
                    case HttpRequestType.PUT:
                        return await client.PutAsync(uri, content);

                    case HttpRequestType.POST:
                        return await client.PostAsync(uri, content);

                    case HttpRequestType.GET:
                        return await client.GetAsync(uri);

                    case HttpRequestType.DELETE:
                        return await client.DeleteAsync(uri);

                    default:
                        return null;
                }
            }
        }
    }
}