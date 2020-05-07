using System;
using Flurl;
using Flurl.Http;
using Flurl.Http.Content;
using Healthcare020.WinUI.Exceptions;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Models;
using HealthCare020.Core.ResponseModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Services
{
    public class APIService
    {
        private IFlurlRequest request;

        public APIService(string route)
        {
            try
            {
                request = Auth.GetAuthorizedApiRequest(route);
            }
            catch (UnauthorizedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<APIServiceResult<List<T>>> Get<T>(object resourceParameters = null)
        {
            var response = await request.SetQueryParams(resourceParameters).GetAsync();
            var headers = response.Headers;

            var result = await response.Content.ReadAsAsync<List<T>>();
            var xpaginationHeader = headers.FirstOrDefault(x => x.Key == "X-Pagination").Value?.FirstOrDefault();

            PaginationMetadata paginationMetadata = null;

            if (!string.IsNullOrWhiteSpace(xpaginationHeader))
                paginationMetadata = JsonConvert.DeserializeObject<PaginationMetadata>(xpaginationHeader);
            {
            }

            return new APIServiceResult<List<T>>
            {
                PaginationMetadata = paginationMetadata ?? new PaginationMetadata(),
                Data = result
            };
        }

        public async Task<APIServiceResult<T>> Update<T>(int id, object dtoForUpdate)
        {
            var tempReq = request;
            tempReq.Url.AppendPathSegment(id);

            try
            {
                var response = await tempReq.PutJsonAsync(dtoForUpdate);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new APIServiceResult<T> { Success = false };
                }
                var headers = response.Headers;

                var result = await response.Content.ReadAsAsync<T>();
                return new APIServiceResult<T>
                {
                    Data = result
                };
            }
            catch (Exception ex)
            {

            }
            
            return new APIServiceResult<T>{Success = false};
            
        }

        public async Task<APIServiceResult<T>> PartiallyUpdate<T>(object patchDocument)
        {
            request.Headers.Add("Content-Type", "application/json-patch+json");

            HttpContent content = new CapturedJsonContent(JsonConvert.SerializeObject(patchDocument));

            var response = await request.PatchAsync(content);
            var headers = response.Headers;

            var result = await response.Content.ReadAsAsync<T>();

            return new APIServiceResult<T>
            {
                Data = result
            };
        }
    }
}