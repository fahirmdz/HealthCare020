using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class GradUpsertDto
    {
        private string _naziv;
        [RequiredWithMessage]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Naziv mora sadrzati izmedju 2 i 20 karaktera")]
        public string Naziv { get=>_naziv; set=>_naziv=value.RemoveWhitespaces(); }

        public int DrzavaId { get; set; }
    }
}