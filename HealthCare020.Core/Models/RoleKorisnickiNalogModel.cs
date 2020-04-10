namespace HealthCare020.Core.Models
{
    public class RoleKorisnickiNalogModel
    {
        public int Id { get; set; }
        public KorisnickiNalogModel KorisnickiNalog { get; set; }
        public TwoFields Role { get; set; }
    }
}