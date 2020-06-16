using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Extensions;

namespace HealthCare020.Core.Request
{
    public class DrzavaUpsertRequest
    {
        private string _naziv;
        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [StringLength(maximumLength: 30, MinimumLength = 2,ErrorMessage = "Naziv mora sadrzati izmedju 3 i 20 karaktera")]
        [DataType(DataType.Text)]
        public string Naziv { get=>_naziv; set=>_naziv=value.RemoveWhitespaces(); }

        private string _pozivniBroj;
        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [StringLength(maximumLength: 5, MinimumLength = 2,ErrorMessage = "Pozivni broj mora sadrzati izmedju 2 i 4 cifre")]
        public string PozivniBroj { get=>_pozivniBroj; set=>_pozivniBroj=value.RemoveWhitespaces(); }
    }
}