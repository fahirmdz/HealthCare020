namespace HealthCare020.Core.Models
{
    //EL -> Eager Loaded
    public class PacijentDtoEL : PacijentDto
    {
        public ZdravstvenaKnjizicaDtoEL ZdravstvenaKnjizica { get; set; }
        public KorisnickiNalogDtoLL KorisnickiNalog { get; set; }

        public PacijentDtoEL()
        {

        }

        public PacijentDtoEL(PacijentDtoEL pacijent)
        {
            Id = pacijent.Id;
            ZdravstvenaKnjizica=new ZdravstvenaKnjizicaDtoEL(pacijent.ZdravstvenaKnjizica);
        }
    }
}