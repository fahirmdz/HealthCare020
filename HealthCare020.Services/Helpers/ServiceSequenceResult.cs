using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace HealthCare020.Services.Helpers
{
    public class ServiceSequenceResult
    {
        public PaginationMetadata PaginationMetadata { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public IEnumerable<ExpandoObject> Data { get; set; }
    }
}