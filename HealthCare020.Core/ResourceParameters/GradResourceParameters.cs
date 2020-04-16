namespace HealthCare020.Core.ResourceParameters
{
    public class GradResourceParameters:BaseResourceParameters
    {
        public int? Id { get; set; }
        public string Naziv { get; set; }
        public string DrzavaNaziv { get; set; }
        public int? DrzavaId { get; set; }
    }
}