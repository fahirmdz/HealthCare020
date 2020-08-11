using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HealthCare020.Services.Extensions
{
    public static class HttpContexntExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }
    }
}