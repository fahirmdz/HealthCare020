using System.Threading.Tasks;
using Healthcare020.Mobile.Services;

namespace Healthcare020.Mobile.Interfaces
{
    public interface IFaceRecognitionService
    {
        Task<bool> CreatePersounGroup(string personGroupId,string groupName);

        Task<bool> AddPersonToGruop(string username, byte[] picture);

        Task<Person> IdentifyFace(byte[] facePicture);

        Task<bool> DeletePersonGroup(string personGroupId);
    }
}