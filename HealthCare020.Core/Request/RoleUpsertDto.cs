using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Extensions;

namespace HealthCare020.Core.Request
{
    public class RoleUpsertDto
    {
        private string _naziv;
        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [StringLength(maximumLength:15,MinimumLength = 3,ErrorMessage = "Naziv role mora sadrzati izmedju 3 i 15 slova")]
        public string Naziv { get=>_naziv; set=>_naziv=value.RemoveWhitespaces(); }
    }
}