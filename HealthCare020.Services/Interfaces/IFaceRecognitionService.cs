using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IFaceRecognitionService
    {
        Task<IList<Person>> GetPersonGroupPersonsList(string personGroupId, int pageSize = 6, string startPersonId = "");

        Task<bool> CreatePersonGroup(string personGroupId, string groupName);

        Task<Person> CreatePersonInGroup(string personGroupId, string name);

        Task<PersistedFace> AddFaceToPerson(string personGroupId, Guid personId, Stream stream);

        Task<Guid?> IdentifyFace(Stream stream, string personGroupId);

        Task DeletePersonGroup(string personGroupId);

        Task<DetectedFace> DetectFace(Stream stream);

        Task<Person> GetPerson(Guid personId, string personGroupId);

        Task DeleteFacesFromPerson(string personGroupId, Guid personId);

        Task DeletePersonFromGroup(Guid personId, string personGroupId);
    }
}