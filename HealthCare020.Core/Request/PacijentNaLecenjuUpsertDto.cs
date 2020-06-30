using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class PacijentNaLecenjuUpsertDto
    {
        [Required(ErrorMessage = "Licni podaci su obavezni za kreiranje novogo pacijenta na lecenju.")]
        public LicniPodaciUpsertDto LicniPodaci { get; set; }

        [Required]
        public int StacionarnoOdeljenjeId { get; set; }

        [Required]
        public int BrojSobe { get; set; }
    }
}