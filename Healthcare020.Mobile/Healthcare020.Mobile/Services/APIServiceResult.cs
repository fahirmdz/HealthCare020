using System.Net;
using HealthCare020.Core.ResponseModels;

namespace Healthcare020.Mobile.Services
{
    public class APIServiceResult<T>
    {
        public APIServiceResult()
        {
        }

        public APIServiceResult(HttpStatusCode statusCode, bool succeeded, string message = "")
        {
            Succeeded = succeeded;
            StatusCode = statusCode;
            Message = message;
        }

        public T Data { get; set; }
        public bool HasData { get; set; }
        public string Message { get; set; } = string.Empty;
        public PaginationMetadata PaginationMetadata { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool Succeeded { get; set; } = true;

        public static APIServiceResult<T> BadRequest(string message = "") => new APIServiceResult<T> { StatusCode = HttpStatusCode.BadRequest, Succeeded = false, Message = message };

        public static APIServiceResult<T> Exception(string message = "") => new APIServiceResult<T> { StatusCode = HttpStatusCode.InternalServerError, Succeeded = false, HasData = false };

        public static APIServiceResult<T> Forbidden(string message = "") => new APIServiceResult<T> { StatusCode = HttpStatusCode.Forbidden, Succeeded = false, Message = message };

        public static APIServiceResult<T> NoContent(string message = "") => new APIServiceResult<T>(HttpStatusCode.NoContent, true, message);

        public static APIServiceResult<T> NotFound(string message = "") => new APIServiceResult<T> { StatusCode = HttpStatusCode.NotFound, Succeeded = false, Message = message };

        public static APIServiceResult<T> OK(T data, string message = "") => new APIServiceResult<T> { Data = data, Message = message, Succeeded = true, StatusCode = HttpStatusCode.OK, HasData = data != null };

        public static APIServiceResult<T> OK() => new APIServiceResult<T> { Succeeded = true, StatusCode = HttpStatusCode.OK, HasData = true };

        public static APIServiceResult<T> Unauthorized(string message = "") => new APIServiceResult<T> { StatusCode = HttpStatusCode.Unauthorized, Succeeded = false, Message = message };

        public static APIServiceResult<T> WithStatusCode(HttpStatusCode statusCode, string message = "") => new APIServiceResult<T> { StatusCode = statusCode, Succeeded = (int)statusCode - 200 < 100, Message = message };
    }
}