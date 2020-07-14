namespace HealthCare020.Core.Models
{
    public class PacijentNaLecenjuDtoEL:PacijentNaLecenjuDto
    {
        public string ImePrezime { get; set; }
        public TwoFieldsDto StacionarnoOdeljenje { get; set; }
    }
}