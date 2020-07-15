using HealthCare020.Services.Configuration;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare020.Services.Services
{
    public class SMSGateway : ISMSGateway
    {
        private readonly ServicesConfiguration.SMSGatewayConf _conf;
        private string SignatureSecret { get; set; }
        private string APIKey { get; set; }
        private string APISecret { get; set; }

        private List<string> VerifiedCodes;

        public SMSGateway(IOptions<ServicesConfiguration> options, IWebHostEnvironment env)
        {
            VerifiedCodes = new List<string>();

            if (env.IsDevelopment())
            {
                _conf = options.Value.SMSGatewayConfiguration;
                APIKey = _conf.APIKey;
                APISecret = _conf.APISecret;
                SignatureSecret = _conf.SignatureSecret;
            }
            else
            {
                _conf = options.Value.SMSGatewayConfiguration;
                APIKey = _conf.APIKey;
                APISecret = _conf.APISecret;
                SignatureSecret = _conf.SignatureSecret;

                //    AccountSid= Environment.GetEnvironmentVariable("AZURE_Twilio_AccountSid");
                //    AuthToken = Environment.GetEnvironmentVariable("AZURE_Twilio_AuthToken");
                //    VerificationServiceSid = Environment.GetEnvironmentVariable("AZURE_Twilio_VerificationServiceSid");
                //}
            }
        }

        public void Send(string recipientNumber, string message)
        {
            try
            {
                var number = recipientNumber[0] == '0' ? recipientNumber.Replace("0", "387") : recipientNumber;
                number = number[0] == '6' ? $"387{number}" : number;

                var client = new Client(creds: new Nexmo.Api.Request.Credentials
                {
                    ApiKey = APIKey,
                    ApiSecret = APISecret
                });
                var results = client.SMS.Send(request: new SMS.SMSRequest
                {
                    from = "Healthcare",
                    to = number,
                    text = message
                });
            }
            catch (Exception ex)
            {
                //ignore
            }
        }

        public async Task<bool> SendVerificationCodeSms(string recipientNumber)
        {
            //TwilioClient.Init(AccountSid, AuthToken);
            //recipientNumber = recipientNumber.Replace("0", "+387");

            //var verification = await VerificationResource.CreateAsync(
            //    to: recipientNumber,
            //    channel: "sms",
            //    pathServiceSid: VerificationServiceSid
            //);

            //return verification.Status == "pending";

            return true;
        }

        public async Task<bool> VerifyVerificationCodeSms(string phoneNumber, string verificationCode)
        {
            //if (VerifiedCodes.Contains(verificationCode))
            //    return true;

            //TwilioClient.Init(AccountSid, AuthToken);
            //phoneNumber = phoneNumber.Replace("0", "+387");

            //var verification = await VerificationCheckResource.CreateAsync(
            //    to: phoneNumber,
            //    code: verificationCode,
            //    pathServiceSid: VerificationServiceSid
            //);

            //if (verification.Status == "approved")
            //{
            //    VerifiedCodes.Add(verificationCode);
            //    return true;
            //}

            //return false;
            return true;
        }

        public void DeleteVerifiedcode(string code)
        {
            VerifiedCodes.Remove(code);
        }
    }
}