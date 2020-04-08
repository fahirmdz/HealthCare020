namespace HealthCare020.Core.Request
{
    public class GradSearchRequest
    {
        public int? Id { get; set; }
        public string Naziv { get; set; }
        public string DrzavaNaziv { get; set; }
        public int? DrzavaId { get; set; }
    }
}