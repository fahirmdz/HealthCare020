namespace HealthCare020.Core.ResourceParameters
{
    public class GradResourceParameters:BaseResourceParameters
    {
        public bool EagerLoaded { get; set; } = false;
        public string Naziv { get; set; }
        public string DrzavaNaziv { get; set; }
        public int? DrzavaId { get; set; }
    }
}