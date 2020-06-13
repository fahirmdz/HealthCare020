namespace HealthCare020.Core.ResourceParameters
{
    public class LekarskoUverenjeResourceParameters : BaseResourceParameters
    {
        public int? PregledId { get; set; }

        public int? ZdravstvenoStanjeId { get; set; }

        public string OpisStanja { get; set; }
        public bool EagerLoaded { get; set; } = false;
    }
}