using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class LekarskoUverenjeUpsertDto
    {
        public int PregledId { get; set; }

        public int ZdravstvenoStanjeId { get; set; }

        [StringLength(255, ErrorMessage = "Maximum length of OpisStanja is 255 characters", MinimumLength = 5)]
        public string OpisStanja { get; set; }
    }
}