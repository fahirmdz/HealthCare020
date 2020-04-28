namespace HealthCare020.Core.ResourceParameters
{
    public class PosetaResourceParameters:BaseResourceParameters
    {
        public bool EagerLoaded { get; set; } = false;
        public string ImePacijenta { get; set; }
        public string TokenPoseta { get; set; }
    }
}