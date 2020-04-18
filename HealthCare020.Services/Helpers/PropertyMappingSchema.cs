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
                {new PropertyMapping<GradDto,Grad>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(GradDto.Naziv),new PropertyMappingValue(new List<string>(){nameof(Grad.Naziv)})},
                        {nameof(GradDto.Id),new PropertyMappingValue(new List<string>(){{nameof(Grad.Id)}}) },
                        {nameof(GradDto.DrzavaId),new PropertyMappingValue(new List<string>(){{nameof(Grad.DrzavaId)}}) },
                    })
                },
                {new PropertyMapping<DrzavaDto,Drzava>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(DrzavaDto.Naziv),new PropertyMappingValue(new List<string>(){nameof(Drzava.Naziv)})},
                        {nameof(DrzavaDto.Id),new PropertyMappingValue(new List<string>(){{nameof(Drzava.Id)}}) },
                        {nameof(DrzavaDto.PozivniBroj),new PropertyMappingValue(new List<string>(){{nameof(Drzava.PozivniBroj)}}) },
                    })
                },
                {new PropertyMapping<TokenPosetaDto,TokenPoseta>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(TokenPosetaDto.Value),new PropertyMappingValue(new List<string>(){nameof(TokenPoseta.Value)})},
                        {nameof(TokenPosetaDto.Id),new PropertyMappingValue(new List<string>(){{nameof(TokenPoseta.Id)}}) }
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
                {new PropertyMapping<RadnikPrijemDto,RadnikPrijem>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(RadnikPrijemDto.Id),new PropertyMappingValue(new List<string>(){nameof(RadnikPrijem.Id)})},
                        {nameof(RadnikPrijemDto.LicniPodaciId),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.LicniPodaciId)}})},
                        {nameof(RadnikPrijemDto.StacionarnoOdeljenjeId),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.StacionarnoOdeljenjeId)}})},
                        {nameof(RadnikPrijemDto.KorisnickiNalogId),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.KorisnickiNalogId)}})},
                    })
                },
                {new PropertyMapping<RadnikPrijemDtoEagerLoaded,RadnikPrijem>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(RadnikPrijemDtoEagerLoaded.Id),new PropertyMappingValue(new List<string>(){nameof(RadnikPrijem.Id)})},
                        {nameof(RadnikPrijemDtoEagerLoaded.KorisnickiNalogId),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.KorisnickiNalogId)}})},
                        {nameof(RadnikPrijemDtoEagerLoaded.Username),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.KorisnickiNalog.Username)}})},
                        {nameof(RadnikPrijemDtoEagerLoaded.LicniPodaciId),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.LicniPodaciId)}})},
                        {nameof(RadnikPrijemDtoEagerLoaded.ImePrezime),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.LicniPodaci.Ime)},{nameof(Radnik.LicniPodaci.Prezime)}})},
                        {nameof(RadnikPrijemDtoEagerLoaded.JMBG),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.LicniPodaci.JMBG)}})},
                        {nameof(RadnikPrijemDtoEagerLoaded.Adresa),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.LicniPodaci.Adresa)}})},
                        {nameof(RadnikPrijemDtoEagerLoaded.Pol),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.LicniPodaci.Pol)}})},
                        {nameof(RadnikPrijemDtoEagerLoaded.BrojTelefona),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.LicniPodaci.BrojTelefona)}})},
                        {nameof(RadnikPrijemDtoEagerLoaded.Grad),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.LicniPodaci.Grad.Naziv)}})},
                        {nameof(RadnikPrijemDtoEagerLoaded.StacionarnoOdeljenjeId),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.StacionarnoOdeljenjeId)}})},
                        {nameof(RadnikPrijemDtoEagerLoaded.StacionarnoOdeljenje),new PropertyMappingValue(new List<string>(){{nameof(RadnikPrijem.Radnik.StacionarnoOdeljenje.Naziv)}})},
                    })
                },
                {new PropertyMapping<GradDtoEagerLoaded,Grad>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(GradDtoEagerLoaded.Naziv),new PropertyMappingValue(new List<string>(){nameof(Grad.Naziv)})},
                        {nameof(GradDtoEagerLoaded.Id),new PropertyMappingValue(new List<string>(){{nameof(Grad.Id)}}) },
                        {nameof(GradDtoEagerLoaded.DrzavaId),new PropertyMappingValue(new List<string>(){{nameof(Grad.DrzavaId)}}) },
                        {nameof(GradDtoEagerLoaded.Drzava),new PropertyMappingValue(new List<string>(){{nameof(Grad.Drzava.Naziv)}}) },
                    })
                },
            };
    }
}