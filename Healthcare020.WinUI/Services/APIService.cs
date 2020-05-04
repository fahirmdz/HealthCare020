using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using HealthCare020.Core.ResponseModels;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Models;
using Newtonsoft.Json;

namespace Healthcare020.WinUI.Services
{
    public class APIService<TResourceParameters>
    {
        private IFlurlRequest request;

        public APIService(string route)
        {
            request = Auth.GetAuthorizedApiRequest(route);
        }


        public async Task<APIServiceResult<List<T>>> Get<T>(object resourceParameters=null)
        {
            var response =  await request.SetQueryParams(resourceParameters).GetAsync();
            var headers = response.Headers;

            var result = await response.Content.ReadAsAsync<List<T>>();
            var xpaginationHeader = headers.FirstOrDefault(x => x.Key == "X-Pagination").Value?.FirstOrDefault();

            PaginationMetadata paginationMetadata = null;

            if (!string.IsNullOrWhiteSpace(xpaginationHeader))
            {
               paginationMetadata = JsonConvert.DeserializeObject<PaginationMetadata>(xpaginationHeader);
            }

            return new APIServiceResult<List<T>>
            {
                PaginationMetadata = paginationMetadata??new PaginationMetadata(),
                Data = result
            };
        }
    }
}