namespace HealthCare020.Core.Models
{
    //EL -> Eager Loaded
    public class PacijentDtoEL : PacijentDto
    {
        public ZdravstvenaKnjizicaDtoEL ZdravstvenaKnjizica { get; set; }

        public PacijentDtoEL()
        {
            
        }

        public PacijentDtoEL(PacijentDtoEL pacijent)
        {
            Id = pacijent.Id;
            Username = pacijent.Username;
            KorisnickiNalogId = pacijent.KorisnickiNalogId;
            ZdravstvenaKnjizica=new ZdravstvenaKnjizicaDtoEL(pacijent.ZdravstvenaKnjizica);
        }
    }
}