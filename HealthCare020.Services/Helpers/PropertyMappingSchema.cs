using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Services.Interfaces;
using HealthCare020.Services.Services;
using System;
using System.Collections.Generic;

namespace HealthCare020.Services.Helpers
{
    public static class PropertyMappingSchema
    {
        public static IList<IPropertyMapping> PropertyMappings =>
            new List<IPropertyMapping>()
            {
                {new PropertyMapping<GradDtoLL,Grad>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(GradDtoLL.Naziv),new PropertyMappingValue(new List<string>(){nameof(Grad.Naziv)})},
                        {nameof(GradDtoLL.Id),new PropertyMappingValue(new List<string>(){{nameof(Grad.Id)}}) },
                        {nameof(GradDtoLL.DrzavaId),new PropertyMappingValue(new List<string>(){{nameof(Grad.DrzavaId)}}) },
                    })
                },
                {new PropertyMapping<DrzavaDto,Drzava>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(DrzavaDto.Naziv),new PropertyMappingValue(new List<string>(){nameof(Drzava.Naziv)})},
                        {nameof(DrzavaDto.Id),new PropertyMappingValue(new List<string>(){{nameof(Drzava.Id)}}) },
                        {nameof(DrzavaDto.PozivniBroj),new PropertyMappingValue(new List<string>(){{nameof(Drzava.PozivniBroj)}}) },
                    })
                },
                {new PropertyMapping<ZdravstvenoStanjeDto,ZdravstvenoStanje>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(ZdravstvenoStanjeDto.Opis),new PropertyMappingValue(new List<string>(){nameof(ZdravstvenoStanje.Opis)})},
                        {nameof(ZdravstvenoStanjeDto.Id),new PropertyMappingValue(new List<string>(){{nameof(ZdravstvenoStanje.Id)}}) }
                    })
                },
                {new PropertyMapping<TwoFieldsDto,StacionarnoOdeljenje>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(TwoFieldsDto.Naziv),new PropertyMappingValue(new List<string>(){nameof(StacionarnoOdeljenje.Naziv)})},
                        {nameof(TwoFieldsDto.Id),new PropertyMappingValue(new List<string>(){{nameof(StacionarnoOdeljenje.Id)}}) }
                    })
                },
                {new PropertyMapping<TwoFieldsDto,Role>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(TwoFieldsDto.Naziv),new PropertyMappingValue(new List<string>(){nameof(Role.Naziv)})},
                        {nameof(TwoFieldsDto.Id),new PropertyMappingValue(new List<string>(){{nameof(Role.Id)}}) }
                    })
                },
                {new PropertyMapping<TwoFieldsDto,NaucnaOblast>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(TwoFieldsDto.Naziv),new PropertyMappingValue(new List<string>(){nameof(NaucnaOblast.Naziv)})},
                        {nameof(TwoFieldsDto.Id),new PropertyMappingValue(new List<string>(){{nameof(NaucnaOblast.Id)}}) }
                    })
                },
                {new PropertyMapping<RadnikPrijemDtoLL,RadnikPrijem>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(RadnikPrijemDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(RadnikPrijem.Id)})},
                        {nameof(RadnikPrijemDtoLL.LicniPodaciId),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.LicniPodaciId)}})},
                        {nameof(RadnikPrijemDtoLL.StacionarnoOdeljenjeId),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.StacionarnoOdeljenjeId)}})},
                        {nameof(RadnikPrijemDtoLL.KorisnickiNalogId),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.KorisnickiNalogId)}})},
                    })
                },
                {new PropertyMapping<RadnikPrijemDtoEL,RadnikPrijem>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(RadnikPrijemDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(RadnikPrijem.Id)})},
                        {nameof(RadnikPrijemDtoEL.StacionarnoOdeljenje),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.StacionarnoOdeljenje)}})},
                    })
                },
                {new PropertyMapping<MedicinskiTehnicarDtoLL,MedicinskiTehnicar>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(MedicinskiTehnicarDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(MedicinskiTehnicar.Id)})},
                        {nameof(MedicinskiTehnicarDtoLL.LicniPodaciId),new PropertyMappingValue(new List<string>(){{nameof(MedicinskiTehnicar.Radnik.LicniPodaciId)}})},
                        {nameof(MedicinskiTehnicarDtoLL.StacionarnoOdeljenjeId),new PropertyMappingValue(new List<string>(){{nameof(MedicinskiTehnicar.Radnik.StacionarnoOdeljenjeId)}})},
                        {nameof(MedicinskiTehnicarDtoLL.KorisnickiNalogId),new PropertyMappingValue(new List<string>(){{nameof(MedicinskiTehnicar.Radnik.KorisnickiNalogId)}})},
                    })
                },
                {new PropertyMapping<MedicinskiTehnicarDtoEL,MedicinskiTehnicar>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(MedicinskiTehnicarDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(MedicinskiTehnicar.Id)})},
                        {nameof(MedicinskiTehnicarDtoEL.StacionarnoOdeljenje),new PropertyMappingValue(new List<string>(){{nameof(MedicinskiTehnicar.Radnik.StacionarnoOdeljenje)}})},
                    })
                },
                {new PropertyMapping<DoktorDtoLL,Doktor>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(DoktorDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(Doktor.Id)})},
                        {nameof(DoktorDtoLL.RadnikId),new PropertyMappingValue(new List<string>(){{nameof(Doktor.RadnikId)}})},
                    })
                },
                {new PropertyMapping<DoktorDtoEL,Doktor>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(DoktorDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(Doktor.Id)})},
                        {nameof(DoktorDtoEL.NaucnaOblast),new PropertyMappingValue(new List<string>(){nameof(Doktor.NaucnaOblast)})},
                        {nameof(DoktorDtoEL.Radnik),new PropertyMappingValue(new List<string>(){nameof(Doktor.Radnik)})},
                    })
                },
                {new PropertyMapping<GradDtoEL,Grad>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(GradDtoEL.Naziv),new PropertyMappingValue(new List<string>(){nameof(Grad.Naziv)})},
                        {nameof(GradDtoEL.Id),new PropertyMappingValue(new List<string>(){{nameof(Grad.Id)}}) },
                        {nameof(GradDtoEL.Drzava),new PropertyMappingValue(new List<string>(){{nameof(Grad.Drzava)}}) },
                    })
                },
                {new PropertyMapping<KorisnickiNalogDtoLL,KorisnickiNalog>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(KorisnickiNalogDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(KorisnickiNalog.Id)})},
                        {nameof(KorisnickiNalogDtoLL.Username),new PropertyMappingValue(new List<string>(){{nameof(KorisnickiNalog.Username)}}) },
                        {nameof(KorisnickiNalogDtoLL.LastOnline),new PropertyMappingValue(new List<string>(){{nameof(KorisnickiNalog.LastOnline)}}) },
                        {nameof(KorisnickiNalogDtoLL.DateCreated),new PropertyMappingValue(new List<string>(){{nameof(KorisnickiNalog.DateCreated)}}) },
                        {nameof(KorisnickiNalogDtoLL.Roles),new PropertyMappingValue(new List<string>(){{nameof(KorisnickiNalog.RolesKorisnickiNalog)}}) },
                    })
                },
                {new PropertyMapping<KorisnickiNalogDtoEL,KorisnickiNalog>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(KorisnickiNalogDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(KorisnickiNalog.Id)})},
                        {nameof(KorisnickiNalogDtoEL.Username),new PropertyMappingValue(new List<string>(){{nameof(KorisnickiNalog.Username)}}) },
                        {nameof(KorisnickiNalogDtoEL.LastOnline),new PropertyMappingValue(new List<string>(){{nameof(KorisnickiNalog.LastOnline)}}) },
                        {nameof(KorisnickiNalogDtoEL.DateCreated),new PropertyMappingValue(new List<string>(){{nameof(KorisnickiNalog.DateCreated)}}) },
                        {nameof(KorisnickiNalogDtoEL.Roles),new PropertyMappingValue(new List<string>(){{nameof(KorisnickiNalog.RolesKorisnickiNalog)}}) }
                    })
                },
                {new PropertyMapping<PacijentDtoLL,Pacijent>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(PacijentDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(Pacijent.Id)})},
                        {nameof(PacijentDtoLL.ZdravstvenaKnjizicaId),new PropertyMappingValue(new List<string>(){nameof(Pacijent.ZdravstvenaKnjizicaId)})},
                        {nameof(PacijentDtoLL.KorisnickiNalogId),new PropertyMappingValue(new List<string>(){nameof(Pacijent.KorisnickiNalogId)})}
                    })
                },
                {new PropertyMapping<PacijentDtoEL,Pacijent>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(PacijentDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(Pacijent.Id)})},
                        {nameof(PacijentDtoEL.ZdravstvenaKnjizica),new PropertyMappingValue(new List<string>(){nameof(Pacijent.ZdravstvenaKnjizica)})},
                    })
                },
                {new PropertyMapping<ZahtevZaPosetuDtoLL,ZahtevZaPosetu>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(ZahtevZaPosetuDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPosetu.Id)})},
                        {nameof(ZahtevZaPosetuDtoLL.PacijentNaLecenjuId),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPosetu.PacijentNaLecenjuId)})},

                        {nameof(ZahtevZaPosetuDtoLL.BrojTelefonaPosetioca),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPosetu.BrojTelefonaPosetioca)})}
                    })
                },
                {new PropertyMapping<ZahtevZaPosetuDtoEL,ZahtevZaPosetu>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(ZahtevZaPosetuDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPosetu.Id)})},
                        {nameof(ZahtevZaPosetuDtoEL.PacijentNaLecenju),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPosetu.PacijentNaLecenju)})},
                        {nameof(ZahtevZaPosetuDtoEL.BrojTelefonaPosetioca),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPosetu.BrojTelefonaPosetioca)})},
                    })
                },
                {new PropertyMapping<PacijentNaLecenjuDtoLL,PacijentNaLecenju>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(PacijentNaLecenjuDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(PacijentNaLecenju.Id)})},
                        {nameof(PacijentNaLecenjuDtoLL.StacionarnoOdeljenjeId),new PropertyMappingValue(new List<string>(){nameof(PacijentNaLecenju.StacionarnoOdeljenjeId)})}
                    })
                },
                {new PropertyMapping<PacijentNaLecenjuDtoEL,PacijentNaLecenju>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(PacijentNaLecenjuDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(PacijentNaLecenju.Id)})},
                        {nameof(PacijentNaLecenjuDtoEL.StacionarnoOdeljenje),new PropertyMappingValue(new List<string>(){nameof(PacijentNaLecenju.StacionarnoOdeljenje)})}
                    })
                },
                {new PropertyMapping<ZdravstvenaKnjizicaDtoLL,ZdravstvenaKnjizica>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(ZdravstvenaKnjizicaDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(ZdravstvenaKnjizica.Id)})},
                        {nameof(ZdravstvenaKnjizicaDtoLL.LicniPodaciId),new PropertyMappingValue(new List<string>(){nameof(ZdravstvenaKnjizica.LicniPodaciId)})},
                        {nameof(ZdravstvenaKnjizicaDtoLL.DoktorId),new PropertyMappingValue(new List<string>(){nameof(ZdravstvenaKnjizica.DoktorId)})}
                    })
                },
                {new PropertyMapping<ZdravstvenaKnjizicaDtoEL,ZdravstvenaKnjizica>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(ZdravstvenaKnjizicaDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(ZdravstvenaKnjizica.Id)})},
                        {nameof(ZdravstvenaKnjizicaDtoEL.LicniPodaci),new PropertyMappingValue(new List<string>(){nameof(ZdravstvenaKnjizica.LicniPodaci)})},
                        {nameof(ZdravstvenaKnjizicaDtoEL.Doktor),new PropertyMappingValue(new List<string>(){nameof(ZdravstvenaKnjizica.Doktor)})},
                        {nameof(ZdravstvenaKnjizicaDtoEL.DoktorId),new PropertyMappingValue(new List<string>(){nameof(ZdravstvenaKnjizica.DoktorId)})}
                    })
                },
                {new PropertyMapping<ZahtevZaPregledDtoLL,ZahtevZaPregled>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(ZahtevZaPregledDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPregled.Id)})},
                        {nameof(ZahtevZaPregledDtoLL.PacijentId),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPregled.PacijentId)})},
                        {nameof(ZahtevZaPregledDtoLL.DoktorId),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPregled.DoktorId)})},
                        {nameof(ZahtevZaPregledDtoLL.UputnicaId),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPregled.UputnicaId)})},
                        {nameof(ZahtevZaPregledDtoLL.Napomena),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPregled.Napomena)})}
                    })
                },
                {new PropertyMapping<ZahtevZaPregledDtoEL,ZahtevZaPregled>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(ZahtevZaPregledDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPregled.Id)})},
                        {nameof(ZahtevZaPregledDtoEL.Pacijent),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPregled.Pacijent)})},
                        {nameof(ZahtevZaPregledDtoEL.Doktor),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPregled.Doktor)})},
                        {nameof(ZahtevZaPregledDtoEL.Uputnica),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPregled.Uputnica)})},
                        {nameof(ZahtevZaPregledDtoEL.Napomena),new PropertyMappingValue(new List<string>(){nameof(ZahtevZaPregled.Napomena)})}
                    })
                },
                {new PropertyMapping<UputnicaDtoLL,Uputnica>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(UputnicaDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(Uputnica.Id)})},
                        {nameof(UputnicaDtoLL.PacijentId),new PropertyMappingValue(new List<string>(){nameof(Uputnica.PacijentId)})},
                        {nameof(UputnicaDtoLL.UputioDoktorId),new PropertyMappingValue(new List<string>(){nameof(Uputnica.UputioDoktorId)})},
                        {nameof(UputnicaDtoLL.UpucenKodDoktoraId),new PropertyMappingValue(new List<string>(){nameof(Uputnica.UpucenKodDoktoraId)})},
                        {nameof(UputnicaDtoLL.Napomena),new PropertyMappingValue(new List<string>(){nameof(Uputnica.Napomena)})},
                        {nameof(UputnicaDtoLL.Razlog),new PropertyMappingValue(new List<string>(){nameof(Uputnica.Razlog)})},
                        {nameof(UputnicaDtoLL.DatumVreme),new PropertyMappingValue(new List<string>(){nameof(Uputnica.DatumVreme)})}
                    })
                },
                {new PropertyMapping<UputnicaDtoEL,Uputnica>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(UputnicaDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(Uputnica.Id)})},
                        {nameof(UputnicaDtoEL.Pacijent),new PropertyMappingValue(new List<string>(){nameof(Uputnica.Pacijent)})},
                        {nameof(UputnicaDtoEL.UputioDoktor),new PropertyMappingValue(new List<string>(){nameof(Uputnica.UputioDoktor)})},
                        {nameof(UputnicaDtoEL.UpucenKodDoktora),new PropertyMappingValue(new List<string>(){nameof(Uputnica.UpucenKodDoktora)})},
                        {nameof(UputnicaDtoEL.Napomena),new PropertyMappingValue(new List<string>(){nameof(Uputnica.Napomena)})},
                        {nameof(UputnicaDtoEL.Razlog),new PropertyMappingValue(new List<string>(){nameof(Uputnica.Razlog)})},
                        {nameof(UputnicaDtoEL.DatumVreme),new PropertyMappingValue(new List<string>(){nameof(Uputnica.DatumVreme)})}
                    })
                },
                {new PropertyMapping<PregledDtoLL,Pregled>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(PregledDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(Pregled.Id)})},
                        {nameof(PregledDtoLL.PacijentId),new PropertyMappingValue(new List<string>(){nameof(Pregled.PacijentId)})},
                        {nameof(PregledDtoLL.DoktorId),new PropertyMappingValue(new List<string>(){nameof(Pregled.DoktorId)})},
                        {nameof(PregledDtoLL.ZahtevZaPregledId),new PropertyMappingValue(new List<string>(){nameof(Pregled.ZahtevZaPregledId)})},
                        {nameof(PregledDtoLL.DatumPregleda),new PropertyMappingValue(new List<string>(){nameof(Pregled.DatumPregleda)})},
                        {nameof(PregledDtoLL.IsOdradjen),new PropertyMappingValue(new List<string>(){nameof(Pregled.IsOdradjen)})}
                    })
                },
                {new PropertyMapping<PregledDtoEL,Pregled>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(PregledDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(Pregled.Id)})},
                        {nameof(PregledDtoEL.Pacijent),new PropertyMappingValue(new List<string>(){nameof(Pregled.Pacijent)})},
                        {nameof(PregledDtoEL.Doktor),new PropertyMappingValue(new List<string>(){nameof(Pregled.Doktor)})},
                        {nameof(PregledDtoEL.DatumPregleda),new PropertyMappingValue(new List<string>(){nameof(Pregled.DatumPregleda)})},
                        {nameof(PregledDtoEL.IsOdradjen),new PropertyMappingValue(new List<string>(){nameof(Pregled.IsOdradjen)})}
                    })
                },
                {new PropertyMapping<LekarskoUverenjeDtoLL,LekarskoUverenje>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(LekarskoUverenjeDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(LekarskoUverenje.Id)})},
                        {nameof(LekarskoUverenjeDtoLL.PregledId),new PropertyMappingValue(new List<string>(){nameof(LekarskoUverenje.PregledId)})},
                        {nameof(LekarskoUverenjeDtoLL.ZdravstvenoStanjeId),new PropertyMappingValue(new List<string>(){nameof(LekarskoUverenje.ZdravstvenoStanjeId)})},
                        {nameof(LekarskoUverenjeDtoLL.OpisStanja),new PropertyMappingValue(new List<string>(){nameof(LekarskoUverenje.OpisStanja)})}
                    })
                },
                {new PropertyMapping<LekarskoUverenjeDtoEL,LekarskoUverenje>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(LekarskoUverenjeDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(LekarskoUverenje.Id)})},
                        {nameof(LekarskoUverenjeDtoEL.Pregled),new PropertyMappingValue(new List<string>(){nameof(LekarskoUverenje.Pregled)})},
                        {nameof(LekarskoUverenjeDtoEL.ZdravstvenoStanje),new PropertyMappingValue(new List<string>(){nameof(LekarskoUverenje.ZdravstvenoStanje)})},
                        {nameof(LekarskoUverenjeDtoEL.OpisStanja),new PropertyMappingValue(new List<string>(){nameof(LekarskoUverenje.OpisStanja)})}
                    })
                },
            };
    }
}