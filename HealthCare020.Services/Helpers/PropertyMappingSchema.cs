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
                {new PropertyMapping<TokenPosetaDtoLL,TokenPoseta>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(TokenPosetaDtoLL.Value),new PropertyMappingValue(new List<string>(){nameof(TokenPoseta.Value)})},
                        {nameof(TokenPosetaDtoLL.Id),new PropertyMappingValue(new List<string>(){{nameof(TokenPoseta.Id)}}) },
                        {nameof(TokenPosetaDtoLL.PacijentId),new PropertyMappingValue(new List<string>(){{nameof(TokenPoseta.PacijentId)}}) }
                    })
                },
                {new PropertyMapping<TokenPosetaDtoEL,TokenPoseta>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(TokenPosetaDtoEL.Value),new PropertyMappingValue(new List<string>(){nameof(TokenPoseta.Value)})},
                        {nameof(TokenPosetaDtoEL.Id),new PropertyMappingValue(new List<string>(){{nameof(TokenPoseta.Id)}}) },
                        {nameof(TokenPosetaDtoEL.Pacijent),new PropertyMappingValue(new List<string>(){{nameof(TokenPoseta.Pacijent)}}) }
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
                        {nameof(RadnikPrijemDtoEL.KorisnickiNalog),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.KorisnickiNalog)}})},
                        {nameof(RadnikPrijemDtoEL.LicniPodaci),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.LicniPodaci)}})},
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
                        {nameof(MedicinskiTehnicarDtoEL.KorisnickiNalog),new PropertyMappingValue(new List<string>(){{nameof(MedicinskiTehnicar.Radnik.KorisnickiNalog)}})},
                        {nameof(MedicinskiTehnicarDtoEL.LicniPodaci),new PropertyMappingValue(new List<string>(){{nameof(MedicinskiTehnicar.Radnik.LicniPodaci)}})},
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
                {new PropertyMapping<UputZaLecenjeDtoLL,UputZaLecenje>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(UputZaLecenjeDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(UputZaLecenje.Id)})},
                        {nameof(UputZaLecenjeDtoLL.DoktorId),new PropertyMappingValue(new List<string>(){{nameof(UputZaLecenje.DoktorId)}}) },
                        {nameof(UputZaLecenjeDtoLL.LicniPodaciId),new PropertyMappingValue(new List<string>(){{nameof(UputZaLecenje.LicniPodaciId)}}) },
                        {nameof(UputZaLecenjeDtoLL.DatumVreme),new PropertyMappingValue(new List<string>(){{nameof(UputZaLecenje.DatumVreme)}}) },
                        {nameof(UputZaLecenjeDtoLL.OpisStanja),new PropertyMappingValue(new List<string>(){{nameof(UputZaLecenje.OpisStanja)}}) }
                    })
                },
                {new PropertyMapping<UputZaLecenjeDtoEL,UputZaLecenje>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(UputZaLecenjeDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(UputZaLecenje.Id)})},
                        {nameof(UputZaLecenjeDtoEL.Doktor),new PropertyMappingValue(new List<string>(){{nameof(UputZaLecenje.Doktor)}}) },
                        {nameof(UputZaLecenjeDtoEL.LicniPodaci),new PropertyMappingValue(new List<string>(){{nameof(UputZaLecenje.LicniPodaci)}}) },
                        {nameof(UputZaLecenjeDtoEL.DatumVreme),new PropertyMappingValue(new List<string>(){{nameof(UputZaLecenje.DatumVreme)}}) },
                        {nameof(UputZaLecenjeDtoEL.OpisStanja),new PropertyMappingValue(new List<string>(){{nameof(UputZaLecenje.OpisStanja)}}) }
                    })
                },
                {new PropertyMapping<PacijentDtoLL,Pacijent>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(PacijentDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(Pacijent.Id)})},
                        {nameof(PacijentDtoLL.LicniPodaciId),new PropertyMappingValue(new List<string>(){{nameof(Pacijent.LicniPodaci)}}) }
                    })
                },
                {new PropertyMapping<PacijentDtoEL,Pacijent>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(PacijentDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(Pacijent.Id)})},
                        {nameof(PacijentDtoEL.LicniPodaci),new PropertyMappingValue(new List<string>(){{nameof(Pacijent.LicniPodaci)}}) }
                    })
                },
                {new PropertyMapping<PosetaDtoEL,Poseta>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(PosetaDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(Poseta.Id)})},
                        {nameof(PosetaDtoEL.TokenPoseta),new PropertyMappingValue(new List<string>(){{nameof(Poseta.TokenPoseta)}})},
                        {nameof(PosetaDtoEL.DatumVreme),new PropertyMappingValue(new List<string>(){{nameof(Poseta.DatumVreme)}})}
                    })
                },
                {new PropertyMapping<PosetaDtoLL,Poseta>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(PosetaDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(Poseta.Id)})},
                        {nameof(PosetaDtoLL.TokenPosetaId),new PropertyMappingValue(new List<string>(){{nameof(Poseta.TokenPosetaId)}})},
                        {nameof(PosetaDtoLL.DatumVreme),new PropertyMappingValue(new List<string>(){{nameof(Poseta.DatumVreme)}})}
                    })
                },
                {new PropertyMapping<CustomIzvestajDtoLL,CustomIzvestaj>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(CustomIzvestajDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(CustomIzvestaj.Id)})},
                        {nameof(CustomIzvestajDtoLL.TelesnaTemperatura),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.TelesnaTemperatura)}})},
                        {nameof(CustomIzvestajDtoLL.KrvniPritisakGornji),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.KrvniPritisakGornji)}})},
                        {nameof(CustomIzvestajDtoLL.KrvniPritisakDonji),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.KrvniPritisakDonji)}})},
                        {nameof(CustomIzvestajDtoLL.GlukozaUKrvi),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.GlukozaUKrvi)}})},
                        {nameof(CustomIzvestajDtoLL.DatumVreme),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.DatumVreme)}})},
                        {nameof(CustomIzvestajDtoLL.MedicinskiTehnicarId),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.MedicinskiTehnicarId)}})},
                        {nameof(CustomIzvestajDtoLL.PacijentId),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.PacijentId)}})}
                    })
                },
                {new PropertyMapping<CustomIzvestajDtoEL,CustomIzvestaj>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(CustomIzvestajDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(CustomIzvestaj.Id)})},
                        {nameof(CustomIzvestajDtoEL.TelesnaTemperatura),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.TelesnaTemperatura)}})},
                        {nameof(CustomIzvestajDtoEL.KrvniPritisakGornji),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.KrvniPritisakGornji)}})},
                        {nameof(CustomIzvestajDtoEL.KrvniPritisakDonji),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.KrvniPritisakDonji)}})},
                        {nameof(CustomIzvestajDtoEL.GlukozaUKrvi),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.GlukozaUKrvi)}})},
                        {nameof(CustomIzvestajDtoEL.DatumVreme),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.DatumVreme)}})},
                        {nameof(CustomIzvestajDtoEL.MedicinskiTehnicarImePrezime),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.MedicinskiTehnicar.Radnik.LicniPodaci.Ime)},{nameof(CustomIzvestaj.MedicinskiTehnicar.Radnik.LicniPodaci.Prezime)}})},
                        {nameof(CustomIzvestajDtoEL.PacijentImePrezime),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.Pacijent.LicniPodaci.Ime)},{nameof(CustomIzvestaj.Pacijent.LicniPodaci.Prezime)}})},
                        {nameof(CustomIzvestajDtoEL.PacijentId),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.PacijentId)}})},
                        {nameof(CustomIzvestajDtoEL.MedicinskiTehnicarId),new PropertyMappingValue(new List<string>(){{nameof(CustomIzvestaj.MedicinskiTehnicarId)}})}
                    })
                },
                {new PropertyMapping<DnevniIzvestajDtoLL,DnevniIzvestaj>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(DnevniIzvestajDtoLL.Id),new PropertyMappingValue(new List<string>(){nameof(DnevniIzvestaj.Id)})},
                        {nameof(DnevniIzvestajDtoLL.DatumVreme),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.DatumVreme)}})},
                        {nameof(DnevniIzvestajDtoLL.OpisStanja),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.OpisStanja)}})},
                        {nameof(DnevniIzvestajDtoLL.PacijentId),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.PacijentId)}})},
                        {nameof(DnevniIzvestajDtoLL.DoktorId),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.DoktorId)}})},
                        {nameof(DnevniIzvestajDtoLL.ZdravstvenoStanjeId),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.ZdravstvenoStanjeId)}})},
                    })
                },
                {new PropertyMapping<DnevniIzvestajDtoEL,DnevniIzvestaj>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(DnevniIzvestajDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(DnevniIzvestaj.Id)})},
                        {nameof(DnevniIzvestajDtoEL.DatumVreme),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.DatumVreme)}})},
                        {nameof(DnevniIzvestajDtoEL.OpisStanja),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.OpisStanja)}})},
                        {nameof(DnevniIzvestajDtoEL.Doktor),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.Doktor.Radnik.LicniPodaci.Ime)},{nameof(DnevniIzvestaj.Doktor.Radnik.LicniPodaci.Prezime)}})},
                        {nameof(DnevniIzvestajDtoEL.Pacijent),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.Pacijent.LicniPodaci.Ime)},{nameof(DnevniIzvestaj.Pacijent.LicniPodaci.Prezime)}})},
                        {nameof(DnevniIzvestajDtoEL.PacijentId),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.PacijentId)}})},
                        {nameof(DnevniIzvestajDtoEL.DoktorId),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.DoktorId)}})},
                        {nameof(DnevniIzvestajDtoEL.ZdravstvenoStanje),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.ZdravstvenoStanje.Opis)}})},
                        {nameof(DnevniIzvestajDtoEL.ZdravstvenoStanjeId),new PropertyMappingValue(new List<string>(){{nameof(DnevniIzvestaj.ZdravstvenoStanjeId)}})},
                    })
                }
            };
    }
}