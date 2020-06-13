using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class PacijentUpsertDto
    {
        [Required]
        public int ZdravstvenaKnjizicaId { get; set; }

        [Required]
        public int KorisnickiNalogId { get; set; }

    }
}