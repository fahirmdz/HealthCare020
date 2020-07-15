using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface ISMSGateway
    {
        void Send(string recipientNumber, string text);

        Task<bool> SendVerificationCodeSms(string recipientNumber);

        Task<bool> VerifyVerificationCodeSms(string phoneNumber, string verificationCode);
        void DeleteVerifiedcode(string code);
    }
}