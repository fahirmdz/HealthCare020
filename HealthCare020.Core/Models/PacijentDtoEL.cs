namespace HealthCare020.Core.Models
{
    //EL -> Eager Loaded
    public class PacijentDtoEL : PacijentDto
    {
        public LicniPodaciDto LicniPodaci { get; set; }

        public TokenPosetaDto TokenPoseta { get; set; }
    }
}