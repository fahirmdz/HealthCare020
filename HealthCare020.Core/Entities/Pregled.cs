using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class Pregled
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ZahtevZaPregled))]
        public int ZahtevZaPregledId { get; set; }

        public ZahtevZaPregled ZahtevZaPregled { get; set; }

        [ForeignKey(nameof(Doktor))]
        public int DoktorId { get; set; }

        public Doktor Doktor { get; set; }

        [ForeignKey(nameof(Pacijent))]
        public int PacijentId { get; set; }

        public Pacijent Pacijent { get; set; }

        public DateTime DatumPregleda { get; set; }
        public uint VrijemePregledaUid { get; set; }

        public bool IsOdradjen { get; set; }
    }
}