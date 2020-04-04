using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Entities
{
    public class ZdravstvenoStanje
    {
        public int Id { get; set; }

        [StringLength(maximumLength:15,MinimumLength = 3)]
        public string Opis { get; set; }
    }
}