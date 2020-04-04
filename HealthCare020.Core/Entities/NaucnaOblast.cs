using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Entities
{
    public class NaucnaOblast
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string Naziv { get; set; }
    }
}