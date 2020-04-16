using System;
using System.Collections.Generic;

namespace HealthCare020.Services.Interfaces
{
    public class PropertyMappingValue
    {
        public IEnumerable<string> DestionationProperties { get; set; }
        public bool Revert { get; set; }

        public PropertyMappingValue(IEnumerable<string> destinationProperties, bool revert = false)
        {
            Revert = revert;
            DestionationProperties = destinationProperties ?? throw new ArgumentNullException(nameof(destinationProperties));
        }
    }
}