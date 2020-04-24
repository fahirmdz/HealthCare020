using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class NaucnaOblastUpsertDto
    {
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string Naziv { get; set; }
    }
}