namespace HealthCare020.Services.Configuration
{
    public class ServicesConfiguration
    {
        public SMSGatewayConf SMSGatewayConfiguration { get; set; }
        public TelegramBotConf TelegramBot { get; set; }

        public class SMSGatewayConf
        {
            public string SignatureSecret { get; set; }
            public string APIKey { get; set; }
            public string APISecret { get; set; }
        }

        public class TelegramBotConf
        {
            public string Token { get; set; }
            public string ChatId { get; set; }
        }
    }
}