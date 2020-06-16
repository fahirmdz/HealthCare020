using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class LekarskoUverenjeUpsertDto
    {
        [Required]
        public int PregledId { get; set; }

        [Required]
        public int ZdravstvenoStanjeId { get; set; }

        [StringLength(255, ErrorMessage = "Maximum length of OpisStanja is 255 characters", MinimumLength = 5)]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Morate unijeti opis stanja.")]
        public string OpisStanja { get; set; }
    }
}