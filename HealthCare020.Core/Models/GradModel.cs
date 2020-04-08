namespace HealthCare020.Core.Models
{
    public class GradModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DrzavaModel Drzava { get; set; }
    }
}