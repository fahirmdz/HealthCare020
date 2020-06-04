using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class LekarskoUverenje
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Pregled))]
        public int PregledId { get; set; }
        public Pregled Pregled { get; set; }

        [ForeignKey(nameof(ZdravstvenoStanje))]
        public int ZdravstvenoStanjeId { get; set; }
        public ZdravstvenoStanje ZdravstvenoStanje { get; set; }

        [StringLength(255,ErrorMessage = "Maximum length of OpisStanja is 255 characters",MinimumLength = 5)]
        public string OpisStanja { get; set; }
    }
}