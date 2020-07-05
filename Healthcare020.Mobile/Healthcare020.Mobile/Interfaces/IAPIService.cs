using System.Collections.Generic;
using System.Threading.Tasks;
using Healthcare020.Mobile.Services;

namespace Healthcare020.Mobile.Interfaces
{
    public interface IAPIService
    {
        /// <summary>
        /// Add route to the base request for the API. The route will be removed after the first request.
        /// </summary>
        void AddRoute(string route);

        void ChangeRoute(string route);
        Task<APIServiceResult<List<int>>> Count(int MonthsCount = 0);

        /// <summary>
        /// DELETE request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="id">Unique identifier of entity that will be partially updated</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        Task<APIServiceResult<T>> Delete<T>(int id, string pathToAppend = "");

        /// <summary>
        /// GET request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="resourceParameters">Resource parameters that will be sent as query string params</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        /// <returns></returns>
        Task<APIServiceResult<List<T>>> Get<T>(object resourceParameters = null, string pathToAppend = "");

        Task<APIServiceResult<T>> GetById<T>(int id, string pathToAppend = "", bool eagerLoaded = false);

        /// <summary>
        /// PATCH request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="id">Unique identifier of entity that will be partially updated</param>
        /// <param name="patchDocument">JSON patch document for updating entity</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        Task<APIServiceResult<T>> PartiallyUpdate<T>(int id, object patchDocument,
            string pathToAppend = "");

        /// <summary>
        /// POST request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="dtoForCreation">Data Transfer Object for creating new entity</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        Task<APIServiceResult<T>> Post<T>(object dtoForCreation, bool ReturnData = false,
            string pathToAppend = "");

        /// <summary>
        /// UPDATE request to the API
        /// </summary>
        /// <typeparam name="T">Type of return data</typeparam>
        /// <param name="id">Unique identifier of entity that will be updated</param>
        /// <param name="dtoForUpdate">Data Transfer Object for updating entity</param>
        /// <param name="pathToAppend">Additional path to append on base url (e.g. "lock" custom operation as "/users/1/lock")</param>
        Task<APIServiceResult<T>> Update<T>(int id, object dtoForUpdate, string pathToAppend = "");

        void RevertToBaseRequest(object resourceParameters = null);
    }
}