using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class ZdravstvenaKnjizicaUpsertDto
    {
        [RequiredWithMessage]
        public LicniPodaciUpsertDto LicniPodaci { get; set; }

        [RequiredWithMessage]
        public int DoktorId { get; set; }
    }
}