using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class TokenPosetaUpsertRequest
    {
        [StringLength(maximumLength: 9, MinimumLength = 5)]
        [DataType(DataType.Text)]
        public string Value { get; set; }
    }
}