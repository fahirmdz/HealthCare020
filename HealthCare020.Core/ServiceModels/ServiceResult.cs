using System.Net;

namespace HealthCare020.Core.ServiceModels
{
    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult()
        {
        }

        public ServiceResult(HttpStatusCode statusCode, bool succeeded, string message = "") : base(statusCode, succeeded, message)
        {
        }

        public static ServiceResult<T> OK(T data, string message = "") => new ServiceResult<T> { Data = data, Message = message, Succeeded = true, StatusCode = HttpStatusCode.OK };

        public static ServiceResult<T> NoContent(string message = "") => new ServiceResult<T>(HttpStatusCode.NoContent, true, message);

        public ServiceResult(T data):base()
        {
            Data = data;
        }

        public T Data { get; set; }
    }

    public class ServiceResult
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool Succeeded { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public ServiceResult()
        {
        }

        public ServiceResult(HttpStatusCode statusCode, bool succeeded, string message = "")
        {
            Succeeded = succeeded;
            StatusCode = statusCode;
            Message = message;
        }

        public static ServiceResult WithStatusCode(HttpStatusCode statusCode, string message = "") => new ServiceResult { StatusCode = statusCode, Succeeded = (int)statusCode - 200 > 100, Message = message };

        public static ServiceResult BadRequest(string message = "") => new ServiceResult { StatusCode = HttpStatusCode.BadRequest, Succeeded = false, Message = message };

        public static ServiceResult NotFound(string message = "") => new ServiceResult { StatusCode = HttpStatusCode.NotFound, Succeeded = false, Message = message };

        public static ServiceResult Unauthorized(string message = "") => new ServiceResult { StatusCode = HttpStatusCode.Unauthorized, Succeeded = false, Message = message };

        public static ServiceResult Forbidden(string message = "") => new ServiceResult { StatusCode = HttpStatusCode.Forbidden, Succeeded = false, Message = message };
    }
}