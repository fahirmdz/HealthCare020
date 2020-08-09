using HealthCare020.Core.ValidationAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class LicniPodaciUpsertDto
    {
        [RequiredWithMessage]
        [StringLengthWithMessage(2, 15)]
        public string Ime { get; set; }

        [RequiredWithMessage]
        [StringLengthWithMessage(2, 15)]
        public string Prezime { get; set; }

        [RequiredWithMessage]
        [StringLengthWithMessage(3, 30)]
        public string Adresa { get; set; }

        [RequiredWithMessage]
        [StringLengthWithMessage(9, 12)]
        public string JMBG { get; set; }

        [RequiredWithMessage]
        [DefaultValue("M")]
        [GenderAbbr]
        public char Pol { get; set; }

        [EmailAddress]
        [RequiredWithMessage]
        public string EmailAddress { get; set; }

        [RequiredWithMessage]
        [DataType(DataType.PhoneNumber)]
        public string BrojTelefona { get; set; }

        [RequiredWithMessage]
        public int GradId { get; set; }

        [RequiredWithMessage]
        public byte[] ProfilePicture { get; set; }
    }
}