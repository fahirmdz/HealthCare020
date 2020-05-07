using System.Net.Http.Headers;
using HealthCare020.Core.ResponseModels;

namespace Healthcare020.WinUI.Models
{
    public class APIServiceResult<T>
    {
        public T Data { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
        public bool Success { get; set; } = true;
    }
}