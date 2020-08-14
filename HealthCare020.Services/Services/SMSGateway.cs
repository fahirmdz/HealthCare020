using HealthCare020.Services.Configuration;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Nexmo.Api;

namespace HealthCare020.Services.Services
{
    public class SMSGateway : ISMSGateway
    {
        private string APIKey { get; }
        private string APISecret { get; }

        public SMSGateway(IOptions<ServicesConfiguration> options, IWebHostEnvironment env)
        {
            ServicesConfiguration.SMSGatewayConf conf;
            if (env.IsDevelopment())
            {
                conf = options.Value.SMSGatewayConfiguration;
                APIKey = conf.APIKey;
                APISecret = conf.APISecret;
            }
            else
            {
                conf = options.Value.SMSGatewayConfiguration;
                APIKey = conf.APIKey;
                APISecret = conf.APISecret;

                //    AccountSid= Environment.GetEnvironmentVariable("AZURE_Twilio_AccountSid");
                //    AuthToken = Environment.GetEnvironmentVariable("AZURE_Twilio_AuthToken");
                //    VerificationServiceSid = Environment.GetEnvironmentVariable("AZURE_Twilio_VerificationServiceSid");
                //}
            }
        }

        public void Send(string recipientNumber, string message)
        {
            var number = recipientNumber[0] == '0' ? recipientNumber.Replace("0", "387") : recipientNumber;
            number = number[0] == '6' ? $"387{number}" : number;

            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = APIKey,
                ApiSecret = APISecret
            });
            client.SMS.Send(request: new SMS.SMSRequest
            {
                @from = "Healthcare",
                to = number,
                text = message
            });
        }
    }
}