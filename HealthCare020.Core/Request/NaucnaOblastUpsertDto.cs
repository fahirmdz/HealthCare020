using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class NaucnaOblastUpsertDto
    {
        [MaxLength(50)]
        [MinLength(3)]
        public string Naziv { get; set; }
    }
}