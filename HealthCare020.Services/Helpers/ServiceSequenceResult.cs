using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace HealthCare020.Services.Helpers
{
    /// <summary>
    /// Includes pagination metedata, data and indicators for previous and next page
    /// </summary>
    public class ServiceSequenceResult
    {
        public PaginationMetadata PaginationMetadata { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public IEnumerable Data { get; set; }
    }
}