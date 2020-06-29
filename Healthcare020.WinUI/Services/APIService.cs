using Flurl.Http;
using Flurl.Http.Content;
using Healthcare020.WinUI.Exceptions;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
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
using Healthcare020.WinUI.Properties;

namespace Healthcare020.WinUI.Services
{
    public class APIService
    {
        private string BaseUrl;
        private IFlurlRequest request;

        /// <summary>
        /// Create new API service with specific route
        /// </summary>
        /// <param name="route">Specific route </param>
        public APIService(string route = "")
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

        /// <summary>
        /// Add route to the base request for the API. The route will be removed after the first request.
        /// </summary>
        public void AddRoute(string route)
        {
            request.Url.AppendPathSegments(route);
        }

        public void ChangeRoute(string route)
        {
            request.Url = Properties.Settings.Default.ApiUrl;
            request.AppendPathSegment(route);
        }

        public async Task<APIServiceResult<List<int>>> Count(int MonthsCount = 0)
        {
            if (!request.Url.Path.Contains("count"))
                request.Url.AppendPathSegment("count");

            var response = await request.SetQueryParam("MonthsCount", MonthsCount).GetAsync();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode == HttpStatusCode.Forbidden)
                    dlgError.ShowDialog(Properties.Resources.AccessDenied);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                    dlgError.ShowDialog(await response.Content?.ReadAsStringAsync() ?? string.Empty);

                return APIServiceResult<List<int>>.WithStatusCode(response.StatusCode);
            }

            return APIServiceResult<List<int>>.OK(await response.Content.ReadAsAsync<List<int>>());
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
                if (response.StatusCode == HttpStatusCode.Forbidden)
                    dlgError.ShowDialog(Properties.Resources.AccessDenied);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                    dlgError.ShowDialog(await response.Content?.ReadAsStringAsync() ?? string.Empty);

                return APIServiceResult<T>.WithStatusCode(response.StatusCode);
            }

            var result = await response.Content?.ReadAsAsync<T>();

            return result != null ? APIServiceResult<T>.OK(result) : APIServiceResult<T>.NoContent();
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
                if (response.StatusCode == HttpStatusCode.Forbidden)
                    dlgError.ShowDialog(Properties.Resources.AccessDenied);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                    dlgError.ShowDialog(await response.Content?.ReadAsStringAsync() ?? string.Empty);

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
                Data = result,
                HasData = result!=null
            };
        }

        public async Task<APIServiceResult<T>> GetById<T>(int id, string pathToAppend = "", bool eagerLoaded = false)
        {
            if (!string.IsNullOrWhiteSpace(pathToAppend))
            {
                request.Url.AppendPathSegment(pathToAppend);
            }

            if (eagerLoaded)
            {
                request.SetQueryParam("eagerLoaded", "true");
            }

            HttpResponseMessage response = null;

            request.Url.AppendPathSegment(id.ToString());
            response = await request.GetAsync();

            RevertToBaseRequest();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode == HttpStatusCode.Forbidden)
                    dlgError.ShowDialog(Properties.Resources.AccessDenied);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                    dlgError.ShowDialog(await response.Content?.ReadAsStringAsync() ?? string.Empty);

                return APIServiceResult<T>.WithStatusCode(response.StatusCode);
            }

            var result = await response.Content.ReadAsAsync<T>();

            return APIServiceResult<T>.OK(result);
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
                if (response.StatusCode == HttpStatusCode.Forbidden)
                    dlgError.ShowDialog(Properties.Resources.AccessDenied);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                    dlgError.ShowDialog(await response.Content?.ReadAsStringAsync() ?? string.Empty);

                return APIServiceResult<T>.WithStatusCode(response.StatusCode);
            }

            var result = await response.Content.ReadAsAsync<T>();

            return APIServiceResult<T>.OK(result);
        }

        /// <summary>
        /// POST request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="dtoForCreation">Data Transfer Object for creating new entity</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        public async Task<APIServiceResult<T>> Post<T>(object dtoForCreation, bool ReturnData=false, string pathToAppend = "")
        {
            if (!string.IsNullOrWhiteSpace(pathToAppend))
            {
                request.Url.AppendPathSegment(pathToAppend);
            }

            HttpResponseMessage response = null;
            try
            {
                response = await request.PostJsonAsync(dtoForCreation);
                RevertToBaseRequest();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Properties.Resources.AccessDenied);
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                        dlgError.ShowDialog(await response.Content?.ReadAsStringAsync() ?? string.Empty);
                    else if((int)response.StatusCode==422)
                        dlgError.ShowDialog(Resources.InvalidInputData);

                    return APIServiceResult<T>.WithStatusCode(response.StatusCode);
                }
                var headers = response.Headers;

                if(ReturnData)
                {
                    var result = await response.Content.ReadAsAsync<T>();
                    return APIServiceResult<T>.OK(result);
                }
                return APIServiceResult<T>.OK();
            }
            catch (Exception)
            {
                return APIServiceResult<T>.WithStatusCode(response?.StatusCode ?? HttpStatusCode.InternalServerError);
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
            HttpResponseMessage response = null;

            try
            {
                response = await request.PutJsonAsync(dtoForUpdate);
                RevertToBaseRequest();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Properties.Resources.AccessDenied);
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                        dlgError.ShowDialog(await response.Content?.ReadAsStringAsync() ?? string.Empty);
                    else if ((int)response.StatusCode == 422)
                        dlgError.ShowDialog(Resources.InvalidInputData);

                    return APIServiceResult<T>.WithStatusCode(response.StatusCode);
                }
                var headers = response.Headers;

                var result = await response.Content.ReadAsAsync<T>();
                return APIServiceResult<T>.OK(result);
            }
            catch (Exception ex)
            {
                dlgError.ShowDialog();
                return APIServiceResult<T>.WithStatusCode(response?.StatusCode ?? HttpStatusCode.InternalServerError);
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
    }
}