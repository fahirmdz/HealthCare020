using System.Net;

namespace HealthCare020.Core.ServiceModels
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
        }

        public ServiceResult(HttpStatusCode statusCode, string message="")
        {
            if (statusCode != HttpStatusCode.OK)
            {
                Succeeded = false;
                StatusCode = statusCode;
                Message = message;
            }
        }

        public ServiceResult(T data)
        {
            Data = data;
        }

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool Succeeded { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
    }
}