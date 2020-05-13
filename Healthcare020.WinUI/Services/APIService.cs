using System;
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
        private string BaseUrl;

        public APIService(string route)
        {
            try
            {
                request = Auth.GetAuthorizedApiRequest(route);
                BaseUrl = request.Url;
            }
            catch (UnauthorizedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RevertToBaseRequest(object resourceParameters=null)
        {
            if (resourceParameters != null)
            {
                request.Url.RemoveQueryParams(resourceParameters.GetType().GetProperties().Select(x => x.Name));
            }

            request.Url = BaseUrl;
        }

        public async Task<APIServiceResult<List<T>>> Get<T>(object resourceParameters = null)
        {
            var response = await request.SetQueryParams(resourceParameters).GetAsync();
            RevertToBaseRequest(resourceParameters);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new APIServiceResult<List<T>>(response.StatusCode);
            }

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
            request.Url.AppendPathSegment(id);

            try
            {
                var response = await request.PutJsonAsync(dtoForUpdate);
                RevertToBaseRequest();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new APIServiceResult<T>(response.StatusCode);
                }
                var headers = response.Headers;

                var result = await response.Content.ReadAsAsync<T>();
                return new APIServiceResult<T>(result);
            }
            catch (Exception ex)
            {
                return APIServiceResult<T>.BadRequest;
            }
        }

        public async Task<APIServiceResult<T>> PartiallyUpdate<T>(int id, object patchDocument)
        {
            request.Url.AppendPathSegment(id);

            HttpContent content = new CapturedJsonContent(JsonConvert.SerializeObject(patchDocument));

            var response = await request.PatchJsonAsync(content);
            RevertToBaseRequest();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new APIServiceResult<T>(response.StatusCode);
            }

            var result = await response.Content.ReadAsAsync<T>();

            return new APIServiceResult<T>(result);
        }

        public async Task<APIServiceResult<T>> Delete<T>(int id)
        {
            request.Url.AppendPathSegment(id);

            var response = await request.DeleteAsync();
            RevertToBaseRequest();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new APIServiceResult<T>(response.StatusCode);
            }

            return APIServiceResult<T>.OK;
        }
    }
}