using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class DrzavaUpsertRequest
    {
        [Required(ErrorMessage = "Obavezno polje")]
        [StringLength(maximumLength: 30, MinimumLength = 2,ErrorMessage = "Naziv mora sadrzati izmedju 3 i 20 karaktera")]
        [DataType(DataType.Text)]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [StringLength(maximumLength: 5, MinimumLength = 2,ErrorMessage = "Pozivni broj mora sadrzati izmedju 2 i 4 cifre")]
        public string PozivniBroj { get; set; }
    }
}