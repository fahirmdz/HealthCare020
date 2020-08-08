using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class NaucnaOblastUpsertDto
    {
        [StringLengthWithMessage(3,50)]
        public string Naziv { get; set; }
    }
}