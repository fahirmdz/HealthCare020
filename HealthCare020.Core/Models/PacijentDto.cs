namespace HealthCare020.Core.Models
{
    public abstract class PacijentDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int KorisnickiNalogId { get; set; }
    }
}