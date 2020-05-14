using HealthCare020.Core.ResponseModels;
using System.Net;

namespace Healthcare020.WinUI.Models
{
    public class APIServiceResult<T>
    {
        public APIServiceResult()
        {
        }

        public APIServiceResult(HttpStatusCode statusCode)
        {
            if (StatusCode != HttpStatusCode.OK)
            {
                Succeeded = false;
            }
            StatusCode = statusCode;
        }

        public APIServiceResult(T data)
        {
            Data = data;
        }

        public static APIServiceResult<T> BadRequest => new APIServiceResult<T>(HttpStatusCode.BadRequest);
        public static APIServiceResult<T> Unauthorized => new APIServiceResult<T>(HttpStatusCode.Unauthorized);
        public static APIServiceResult<T> Forbidden => new APIServiceResult<T>(HttpStatusCode.Forbidden);
        public static APIServiceResult<T> NotFound => new APIServiceResult<T>(HttpStatusCode.NotFound);
        public static APIServiceResult<T> OK => new APIServiceResult<T>(HttpStatusCode.OK);


        public T Data { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
        public bool Succeeded { get; set; } = true;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}