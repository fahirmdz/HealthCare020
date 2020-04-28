namespace HealthCare020.Core.ResourceParameters
{
    public class TokenPosetaResourceParameters:BaseResourceParameters
    {
        public bool EagerLoaded { get; set; } = false;
        public string ImePacijenta { get; set; }
        public string PrezimePacijenta { get; set; }
    }
}