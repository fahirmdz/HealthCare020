using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class ZdravstvenaKnjizicaUpsertDto
    {
        [Required]
        public LicniPodaciUpsertDto LicniPodaci { get; set; }

        [Required]
        public int DoktorId { get; set; }
    }
}