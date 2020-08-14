using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class PacijentNaLecenjuUpsertDto
    {
        [RequiredWithMessage()]
        public LicniPodaciUpsertDto LicniPodaci { get; set; }

        [RequiredWithMessage]
        public int StacionarnoOdeljenjeId { get; set; }

        [RequiredWithMessage]
        public int BrojSobe { get; set; }
    }
}