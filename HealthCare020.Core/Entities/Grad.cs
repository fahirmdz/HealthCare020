using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class Grad
    {
        public int Id { get; set; }

        [StringLength(maximumLength:20,MinimumLength = 2)]
        public string Naziv { get; set; }

        [ForeignKey(nameof(Drzava))]
        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
    }
}