using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class ZahtevZaPregledUpsertDto
    {
        [Required]
        public int DoktorId { get; set; }

        public int? UputnicaId { get; set; }

        [StringLength(255, ErrorMessage = "Maximum length is 255 characters", MinimumLength = 5)]
        [Required]
        public string Napomena { get; set; }
    }
}