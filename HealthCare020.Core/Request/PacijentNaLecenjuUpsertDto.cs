using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class PacijentNaLecenjuUpsertDto
    {
        [Required(ErrorMessage = "Licni podaci su obavezni za kreiranje novogo pacijenta na lecenju.")]
        public LicniPodaciUpsertDto LicniPodaci { get; set; }
        public int StacionarnoOdeljenjeId { get; set; }
    }
}