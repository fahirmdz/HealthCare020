namespace HealthCare020.Services.Interfaces
{
    public interface ISMSGateway
    {
        void Send(string recipientNumber, string text);
    }
}