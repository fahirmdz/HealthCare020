namespace HealthCare020.Core.Models
{
    //LL -> Lazy Loaded
    public  class GradDtoLL:GradDto
    {
        public int DrzavaId { get; set; }

        public GradDtoLL()
        {
        }

        public GradDtoLL(GradDtoLL grad)
        {
            Id = grad.Id;
            Naziv = grad.Naziv;
            DrzavaId = grad.DrzavaId;
        }
    }
}