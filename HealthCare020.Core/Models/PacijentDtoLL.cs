namespace HealthCare020.Core.Models
{
    public class PacijentDtoLL : PacijentDto
    {
        public int ZdravstvenaKnjizicaId { get; set; }
        public string Username { get; set; }
        public int KorisnickiNalogId { get; set; }
    }
}