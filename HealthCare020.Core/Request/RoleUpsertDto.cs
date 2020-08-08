using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class RoleUpsertDto
    {
        private string _naziv;
        [RequiredWithMessage]
        [StringLengthWithMessage(3,15)]
        public string Naziv { get=>_naziv; set=>_naziv=value.RemoveWhitespaces(); }
    }
}