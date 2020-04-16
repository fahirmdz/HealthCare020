using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.ResourceParameters
{
    public class ZdravstvenoStanjeResourceParameters:BaseResourceParameters
    {
        [MaxLength(150)]
        public string Opis { get; set; }
    }
}