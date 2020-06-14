using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class PacijentUpsertDto
    {
        [Required]
        public int BrojZdravstveneKnjizice { get; set; }

        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string Ime { get; set; }

        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string Prezime { get; set; }

        [StringLength(maximumLength: 12, MinimumLength = 9)]
        public string JMBG { get; set; }

        [Required]
        public KorisnickiNalogUpsertDto KorisnickiNalog { get; set; }
    }
}