using System.Collections;

namespace HealthCare020.Services.Helpers
{
    public class ServiceSequenceResult
    {
        public PaginationMetadata PaginationMetadata { get; set; }
        public IEnumerable Data { get; set; }
    }
}