using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class UputZaLecenjeUpsertDto
    {
        [StringLength(maximumLength: 250, MinimumLength = 5)]
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        public string OpisStanja { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public LicniPodaciUpsertDto LicniPodaci { get; set; }
    }
}