using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class DnevniIzvestajUpsertDto
    {
        [StringLength(maximumLength: 250, MinimumLength = 5)]
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        public string OpisStanja { get; set; }

        public int ZdravstvenoStanjeId { get; set; }

        public int PacijentId { get; set; }
    }
}