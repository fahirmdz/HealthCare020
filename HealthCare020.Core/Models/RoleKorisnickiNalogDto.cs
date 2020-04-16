namespace HealthCare020.Core.Models
{
    public class RoleKorisnickiNalogDto
    {
        public int Id { get; set; }
        public KorisnickiNalogDto KorisnickiNalog { get; set; }
        public TwoFieldsDto Role { get; set; }
    }
}