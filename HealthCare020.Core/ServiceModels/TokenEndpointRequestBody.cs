using Newtonsoft.Json;

namespace HealthCare020.Core.ServiceModels
{
    public class TokenEndpointRequestBody
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public string Scope { get; set; }
        public string Image { get; set; }
    }
}