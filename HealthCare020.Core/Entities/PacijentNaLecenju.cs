using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class PacijentNaLecenju
    {
        public int Id { get; set; }

        [ForeignKey(nameof(StacionarnoOdeljenje))]
        public int StacionarnoOdeljenjeId { get; set; }
        public StacionarnoOdeljenje StacionarnoOdeljenje { get; set; }
    }
}