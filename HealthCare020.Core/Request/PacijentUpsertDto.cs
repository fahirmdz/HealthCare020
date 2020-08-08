using HealthCare020.Core.Extensions;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class PacijentUpsertDto
    {
        [RequiredWithMessage]
        public int BrojZdravstveneKnjizice { get; set; }

        private string _ime;

        [StringLengthWithMessage(2, 15)]
        public string Ime { get => _ime; set => _ime = value.RemoveWhitespaces(); }

        private string _prezime;

        [StringLengthWithMessage(2, 15)]
        public string Prezime { get => _prezime; set => _prezime = value.RemoveWhitespaces(); }

        private string _jmbg;

        [StringLengthWithMessage(9, 12)]
        public string JMBG { get => _jmbg; set => _jmbg = value.RemoveWhitespaces(); }

        [RequiredWithMessage]
        public byte[] ProfilePicture { get; set; }

        [RequiredWithMessage]
        public KorisnickiNalogUpsertDto KorisnickiNalog { get; set; }
    }
}