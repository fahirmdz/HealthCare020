using Flurl.Http;
using Healthcare020.WinUI.Exceptions;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Properties;
using HealthCare020.Core.ResponseModels;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using DateTime = System.DateTime;

namespace Healthcare020.WinUI.Services
{
    public class APIService
    {
        private readonly string BaseUrl;
        private readonly IFlurlRequest request;
        private static readonly Logger logger = LogManager.GetLogger(Settings.Default.Healthcare020_Logger);

        /// <summary>
        /// Create new API service with specific route
        /// </summary>
        /// <param name="route">Specific route </param>
        public APIService(string route = "")
        {
            try
            {
#if DEBUG
                var httpClientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain,
                        errors) => true
                };
#endif

                var httpClient = new HttpClient(httpClientHandler)
                {
                    BaseAddress = new Uri(Settings.Default.ApiUrl)
                };

                var _flurlClient = new FlurlClient(httpClient);
                request = _flurlClient.Request(route);
                BaseUrl = request.Url;

                request = request.GetAuthorizedApiRequest().AllowAnyHttpStatus();
                BaseUrl = request.Url;
            }
            catch (UnauthorizedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeRoute(string route)
        {
            request.Url = Settings.Default.ApiUrl;
            request.AppendPathSegment(route);
        }

        public async Task<APIServiceResult<List<int>>> Count(int MonthsCount = 0)
        {
            try
            {
                if (!request.Url.Path.Contains("count"))
                    request.Url.AppendPathSegment("count");

                var response = await request.SetQueryParam("MonthsCount", MonthsCount).GetAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Resources.AccessDenied);

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var msg = string.Empty;
                        if (response.Content != null)
                        {
                            msg = await response.Content.ReadAsStringAsync();
                        }
                        dlgError.ShowDialog(msg);
                    }

                    return APIServiceResult<List<int>>.WithStatusCode(response.StatusCode);
                }

                var str = await response.Content.ReadAsStringAsync();
                return APIServiceResult<List<int>>.OK(await response.Content.ReadAsAsync<List<int>>());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                dlgError.ShowDialog(Resources.TemporarilyUnvailable);
                return APIServiceResult<List<int>>.Exception();
            }
        }

        /// <summary>
        /// DELETE request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="id">Unique identifier of entity that will be partially updated</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        public async Task<APIServiceResult<T>> Delete<T>(object id, string pathToAppend = "")
        {
            try
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
                        dlgError.ShowDialog(Resources.AccessDenied);

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                        dlgError.ShowDialog(await response.Content?.ReadAsStringAsync() ?? string.Empty);

                    return APIServiceResult<T>.WithStatusCode(response.StatusCode);
                }

                var result = await response.Content?.ReadAsAsync<T>();

                return result != null ? APIServiceResult<T>.OK(result) : APIServiceResult<T>.NoContent();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                dlgError.ShowDialog(Resources.TemporarilyUnvailable);
                return APIServiceResult<T>.Exception();
            }
        }

        /// <summary>
        /// GET request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="resourceParameters">Resource parameters that will be sent as query string params</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        /// <param name="queryStringCollection"></param>
        /// <returns></returns>
        public async Task<APIServiceResult<List<T>>> Get<T>(object resourceParameters = null, string pathToAppend = "", Dictionary<string, string> queryStringCollection = null)
        {
            try
            {
                if (queryStringCollection != null)
                {
                    foreach (var queryString in queryStringCollection)
                    {
                        request.Url.QueryParams.Add(queryString.Key, queryString.Value);
                    }
                }

                if (!string.IsNullOrWhiteSpace(pathToAppend))
                {
                    request.Url.AppendPathSegment(pathToAppend);
                }

                var response = await request.SetQueryParams(resourceParameters).GetAsync();
                RevertToBaseRequest(resourceParameters);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Resources.AccessDenied);

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var msg = string.Empty;
                        if (response.Content != null)
                        {
                            msg = await response.Content.ReadAsStringAsync();
                        }
                        dlgError.ShowDialog(msg);
                    }

                    return APIServiceResult<List<T>>.WithStatusCode(response.StatusCode);
                }

                var headers = response.Headers;

                var result = await response.Content.ReadAsAsync<List<T>>();

                if (response.StatusCode == HttpStatusCode.OK && result == null)
                {
                    return APIServiceResult<List<T>>.OK();
                }

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
                    HasData = result != null
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                dlgError.ShowDialog(Resources.TemporarilyUnvailable);
                return APIServiceResult<List<T>>.Exception();
            }
        }

        public async Task<APIServiceResult<T>> GetAsSingle<T>(string pathToAppend = "", Dictionary<string, string> queryStringCollection = null)
        {
            try
            {
                if (queryStringCollection != null)
                {
                    foreach (var queryString in queryStringCollection)
                    {
                        request.Url.QueryParams.Add(queryString.Key, queryString.Value);
                    }
                }

                if (!string.IsNullOrWhiteSpace(pathToAppend))
                {
                    request.Url.AppendPathSegment(pathToAppend);
                }

                var response = await request.GetAsync();
                RevertToBaseRequest();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Resources.AccessDenied);

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var msg = string.Empty;
                        if (response.Content != null)
                        {
                            msg = await response.Content.ReadAsStringAsync();
                        }
                        dlgError.ShowDialog(msg);
                    }

                    return APIServiceResult<T>.WithStatusCode(response.StatusCode);
                }

                object result;

                if (typeof(T) == typeof(DateTime))
                {
                    var textPlain = await response.Content.ReadAsStringAsync();
                    var dateTimeResult =
                        DateTime.Parse(textPlain, CultureInfo.InvariantCulture); ;
                    result = dateTimeResult;
                }
                else
                {
                    result = await response.Content.ReadAsAsync<T>();
                }

                if (response.StatusCode == HttpStatusCode.OK && result == null)
                {
                    return APIServiceResult<T>.OK();
                }

                return new APIServiceResult<T>
                {
                    Data = (T)result,
                    HasData = result != null
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                dlgError.ShowDialog(Resources.TemporarilyUnvailable);
                return APIServiceResult<T>.Exception();
            }
        }

        public async Task<APIServiceResult<T>> GetById<T>(int id, string pathToAppend = "", bool eagerLoaded = false)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(pathToAppend))
                {
                    request.Url.AppendPathSegment(pathToAppend);
                }

                if (eagerLoaded)
                {
                    request.SetQueryParam("eagerLoaded", "true");
                }

                request.Url.AppendPathSegment(id.ToString());
                var response = await request.GetAsync();

                RevertToBaseRequest();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Resources.AccessDenied);

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var msg = string.Empty;
                        if (response.Content != null)
                        {
                            msg = await response.Content.ReadAsStringAsync();
                        }
                        dlgError.ShowDialog(msg);
                    }

                    return APIServiceResult<T>.WithStatusCode(response.StatusCode);
                }

                var result = await response.Content.ReadAsAsync<T>();

                return APIServiceResult<T>.OK(result);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                dlgError.ShowDialog(Resources.TemporarilyUnvailable);
                return APIServiceResult<T>.Exception();
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
            try
            {
                request.Url.AppendPathSegment(id);
                if (!string.IsNullOrWhiteSpace(pathToAppend))
                {
                    request.Url.AppendPathSegment(pathToAppend);
                }
                var response = await request.PatchJsonAsync(patchDocument);
                RevertToBaseRequest();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Resources.AccessDenied);

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var msg = string.Empty;
                        if (response.Content != null)
                        {
                            msg = await response.Content.ReadAsStringAsync();
                        }
                        dlgError.ShowDialog(msg);
                    }

                    return APIServiceResult<T>.WithStatusCode(response.StatusCode);
                }

                var result = await response.Content.ReadAsAsync<T>();

                return APIServiceResult<T>.OK(result);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                dlgError.ShowDialog(Resources.TemporarilyUnvailable);
                return APIServiceResult<T>.Exception();
            }
        }

        /// <summary>
        /// POST request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="dtoForCreation">Data Transfer Object for creating new entity</param>
        /// <param name="ReturnData"></param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        public async Task<APIServiceResult<T>> Post<T>(object dtoForCreation, bool ReturnData = false, string pathToAppend = "")
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(pathToAppend))
                {
                    request.Url.AppendPathSegment(pathToAppend);
                }

                var response = await request.PostJsonAsync(dtoForCreation);
                RevertToBaseRequest();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Resources.AccessDenied);
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        if (response.Content != null)
                            dlgError.ShowDialog(await response.Content?.ReadAsStringAsync() ?? string.Empty);
                    }
                    else if ((int)response.StatusCode == 422)
                    {
                        var msg = Resources.InvalidInputData;

                        if (response.Content != null)
                            msg = await response.Content.ReadAsStringAsync();
                        dlgError.ShowDialog(msg);
                    }

                    return APIServiceResult<T>.WithStatusCode(response.StatusCode);
                }

                if (ReturnData)
                {
                    var result = await response.Content.ReadAsAsync<T>();
                    return APIServiceResult<T>.OK(result);
                }
                return APIServiceResult<T>.OK();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                dlgError.ShowDialog(Resources.TemporarilyUnvailable);
                return APIServiceResult<T>.Exception();
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
            try
            {
                request.Url.AppendPathSegment(id);
                if (!string.IsNullOrWhiteSpace(pathToAppend))
                {
                    request.Url.AppendPathSegment(pathToAppend);
                }

                var response = await request.PutJsonAsync(dtoForUpdate);
                RevertToBaseRequest();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        dlgError.ShowDialog(Resources.AccessDenied);
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var msg = string.Empty;
                        if (response.Content != null)
                        {
                            msg = await response.Content.ReadAsStringAsync();
                        }
                        dlgError.ShowDialog(msg);
                    }
                    else if ((int)response.StatusCode == 422)
                    {
                        var msg = Resources.InvalidInputData;

                        if (response.Content != null)
                            msg = await response.Content.ReadAsStringAsync();
                        dlgError.ShowDialog(msg);
                    }

                    return APIServiceResult<T>.WithStatusCode(response.StatusCode);
                }
                var headers = response.Headers;

                var result = await response.Content.ReadAsAsync<T>();
                return APIServiceResult<T>.OK(result);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                dlgError.ShowDialog(Resources.TemporarilyUnvailable);
                return APIServiceResult<T>.Exception();
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