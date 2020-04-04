using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Entities
{
    public class StacionarnoOdeljenje
    {
        public int Id { get; set; }

        [StringLength(maximumLength:40,MinimumLength = 4)]
        public string Naziv { get; set; }
        
    }
}