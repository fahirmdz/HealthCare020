using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class PacijentNaLecenju
    {
        public int Id { get; set; }

        [ForeignKey(nameof(LicniPodaci))]
        public int LicniPodaciId { get; set; }
        public LicniPodaci LicniPodaci { get; set; }

        [ForeignKey(nameof(StacionarnoOdeljenje))]
        public int StacionarnoOdeljenjeId { get; set; }
        public StacionarnoOdeljenje StacionarnoOdeljenje { get; set; }

        [Required]
        public int BrojSobe { get; set; }
    }
}