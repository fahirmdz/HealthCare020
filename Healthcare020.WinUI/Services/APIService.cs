using Flurl.Http;
using Flurl.Http.Content;
using Healthcare020.WinUI.Exceptions;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Models;
using HealthCare020.Core.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare020.WinUI.Helpers.Dialogs;

namespace Healthcare020.WinUI.Services
{
    public class APIService
    {
        private IFlurlRequest request;
        private string BaseUrl;

        /// <summary>
        /// Create new API service with specific route
        /// </summary>
        /// <param name="route">Specific route </param>
        public APIService(string route="")
        {
            try
            {
                request = Auth.GetAuthorizedApiRequest(route).AllowAnyHttpStatus();
                BaseUrl = request.Url;
            }
            catch (UnauthorizedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RevertToBaseRequest(object resourceParameters = null)
        {
            if (resourceParameters != null)
            {
                request.Url.RemoveQueryParams(resourceParameters.GetType().GetProperties().Select(x => x.Name));
            }

            request.Url = BaseUrl;
        }

        /// <summary>
        /// Add route to the base request for the API. The route will be removed after the first request.
        /// </summary>
        public void AddRoute(string route)
        {
            request.Url.AppendPathSegments(route);
        }

        /// <summary>
        /// GET request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="resourceParameters">Resource parameters that will be sent as query string params</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        /// <returns></returns>
        public async Task<APIServiceResult<List<T>>> Get<T>(object resourceParameters = null, string pathToAppend = "")
        {
            if (!string.IsNullOrWhiteSpace(pathToAppend))
            {
                request.Url.AppendPathSegment(pathToAppend);
            }

            var response = await request.SetQueryParams(resourceParameters).GetAsync();
            RevertToBaseRequest(resourceParameters);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if(response.StatusCode==HttpStatusCode.Forbidden)
                    dlgError.ShowDialog(Properties.Resources.AccessDenied);

                return APIServiceResult<List<T>>.WithStatusCode(response.StatusCode);
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

        /// <summary>
        /// POST request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="dtoForCreation">Data Transfer Object for creating new entity</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        public async Task<APIServiceResult<T>> Post<T>(object dtoForCreation, string pathToAppend = "")
        {
            if (!string.IsNullOrWhiteSpace(pathToAppend))
            {
                request.Url.AppendPathSegment(pathToAppend);
            }

            HttpResponseMessage response=null;
            try
            {
                 response = await request.PostJsonAsync(dtoForCreation);
                RevertToBaseRequest();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if(response.StatusCode==HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Properties.Resources.AccessDenied);

                    return APIServiceResult<T>.WithStatusCode(response.StatusCode);
                }
                var headers = response.Headers;

                var result = await response.Content.ReadAsAsync<T>();
                return  APIServiceResult<T>.OK(result);
            }
            catch (Exception ex)
            {
                return APIServiceResult<T>.WithStatusCode(response?.StatusCode??HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// UPDATE request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="id">Unique identifier of entity that will be updated</param>
        /// <param name="dtoForUpdate">Data Transfer Object for updating entity</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        public async Task<APIServiceResult<T>> Update<T>(int id, object dtoForUpdate, string pathToAppend = "")
        {
            request.Url.AppendPathSegment(id);
            if (!string.IsNullOrWhiteSpace(pathToAppend))
            {
                request.Url.AppendPathSegment(pathToAppend);
            }
            HttpResponseMessage response=null;

            try
            {
                 response = await request.PutJsonAsync(dtoForUpdate);
                RevertToBaseRequest();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if(response.StatusCode==HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Properties.Resources.AccessDenied);

                    return APIServiceResult<T>.WithStatusCode(response.StatusCode);
                }
                var headers = response.Headers;

                var result = await response.Content.ReadAsAsync<T>();
                return APIServiceResult<T>.OK(result);
            }
            catch (Exception ex)
            {
                dlgError.ShowDialog();
                return APIServiceResult<T>.WithStatusCode(response?.StatusCode??HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// PATCH request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="id">Unique identifier of entity that will be partially updated</param>
        /// <param name="patchDocument">JSON patch document for updating entity</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        public async Task<APIServiceResult<T>> PartiallyUpdate<T>(int id, object patchDocument, string pathToAppend = "")
        {
            request.Url.AppendPathSegment(id);
            if (!string.IsNullOrWhiteSpace(pathToAppend))
            {
                request.Url.AppendPathSegment(pathToAppend);
            }
            HttpContent content = new CapturedJsonContent(JsonConvert.SerializeObject(patchDocument));

            var response = await request.PatchJsonAsync(content);
            RevertToBaseRequest();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if(response.StatusCode==HttpStatusCode.Forbidden)
                    dlgError.ShowDialog(Properties.Resources.AccessDenied);

                return APIServiceResult<T>.WithStatusCode(response.StatusCode);
            }

            var result = await response.Content.ReadAsAsync<T>();

            return APIServiceResult<T>.OK(result);
        }

        /// <summary>
        /// DELETE request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="id">Unique identifier of entity that will be partially updated</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        public async Task<APIServiceResult<T>> Delete<T>(int id, string pathToAppend = "")
        {
            request.Url.AppendPathSegment(id);
            if (!string.IsNullOrWhiteSpace(pathToAppend))
            {
                request.Url.AppendPathSegment(pathToAppend);
            }

            var response = await request.DeleteAsync();
            RevertToBaseRequest();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if(response.StatusCode==HttpStatusCode.Forbidden)
                    dlgError.ShowDialog(Properties.Resources.AccessDenied);

                return APIServiceResult<T>.WithStatusCode(response.StatusCode);
            }

            var result = await response.Content?.ReadAsAsync<T>();

            return result != null ? APIServiceResult<T>.OK(result) : APIServiceResult<T>.NoContent();
        }
    }
}