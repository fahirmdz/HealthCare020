namespace HealthCare020.Core.Models
{
    public class CustomIzvestajDtoEL : CustomIzvestajDto
    {
        public int MedicinskiTehnicarId { get; set; }
        public string MedicinskiTehnicarImePrezime { get; set; }

        public int PacijentId { get; set; }
        public string PacijentImePrezime { get; set; }

    }
}