using System.Net;

namespace HealthCare020.Core.ServiceModels
{

    public class ServiceResult
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool Succeeded { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public bool HasData { get; set; } = false;
        public object Data { get; set; }


        public ServiceResult()
        {
        }

        public ServiceResult(HttpStatusCode statusCode, bool succeeded, string message = "")
        {
            Succeeded = succeeded;
            StatusCode = statusCode;
            Message = message;
            HasData = Data != null;
        }

        public static ServiceResult OK(object data=null, string message = "") => new ServiceResult
        {
            Data = data,
            Message = message, 
            Succeeded = true, 
            StatusCode = HttpStatusCode.OK,
            HasData = data!=null
        };

        public static ServiceResult NoContent(string message = "") => new ServiceResult(HttpStatusCode.NoContent, true, message);

        public ServiceResult(object data):base()
        {
            Data = data;
        }

        public static ServiceResult WithStatusCode(HttpStatusCode statusCode, string message = "") => new ServiceResult { StatusCode = statusCode, Succeeded = (int)statusCode - 200 < 100, Message = message };

        public static ServiceResult BadRequest(string message = "") => new ServiceResult { StatusCode = HttpStatusCode.BadRequest, Succeeded = false, Message = message };

        public static ServiceResult NotFound(string message = "") => new ServiceResult { StatusCode = HttpStatusCode.NotFound, Succeeded = false, Message = message };
        
        public static ServiceResult Unauthorized(string message = "") => new ServiceResult { StatusCode = HttpStatusCode.Unauthorized, Succeeded = false, Message = message };

        public static ServiceResult Forbidden(string message = "") => new ServiceResult { StatusCode = HttpStatusCode.Forbidden, Succeeded = false, Message = message };
    }
}