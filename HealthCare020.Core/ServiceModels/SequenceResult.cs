using System.Collections;
using HealthCare020.Core.ResponseModels;

namespace HealthCare020.Core.ServiceModels
{
    /// <summary>
    /// Includes pagination metedata, data and indicators for previous and next page
    /// </summary>
    public class SequenceResult
    {
        public PaginationMetadata PaginationMetadata { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public IEnumerable Data { get; set; }
    }
}