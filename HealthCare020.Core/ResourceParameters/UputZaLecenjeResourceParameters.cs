using System.Net.Cache;

namespace HealthCare020.Core.ResourceParameters
{
    public class UputZaLecenjeResourceParameters:BaseResourceParameters
    {
        public string ImePacijenta { get; set; }
        public string PrezimePacijenta { get; set; }
        public string ImeDoktora { get; set; }

        public bool EagerLoaded { get; set; } = false;

    }
}