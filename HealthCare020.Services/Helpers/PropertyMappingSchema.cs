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
                {new PropertyMapping<RadnikDtoLazyLoaded,Radnik>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(RadnikDtoLazyLoaded.Id),new PropertyMappingValue(new List<string>(){nameof(Radnik.Id)})},
                        {nameof(RadnikDtoLazyLoaded.LicniPodaciId),new PropertyMappingValue(new List<string>(){{nameof(Radnik.LicniPodaciId)}})},
                        {nameof(RadnikDtoLazyLoaded.StacionarnoOdeljenjeId),new PropertyMappingValue(new List<string>(){{nameof(Radnik.StacionarnoOdeljenjeId)}})},
                        {nameof(RadnikDtoLazyLoaded.KorisnickiNalogId),new PropertyMappingValue(new List<string>(){{nameof(Radnik.KorisnickiNalogId)}})},
                    })
                },
                {new PropertyMapping<RadnikDtoEagerLoaded,Radnik>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(RadnikDtoEagerLoaded.Id),new PropertyMappingValue(new List<string>(){nameof(Radnik.Id)})},
                        {nameof(RadnikDtoEagerLoaded.KorisnickiNalogId),new PropertyMappingValue(new List<string>(){{nameof(Radnik.KorisnickiNalogId)}})},
                        {nameof(RadnikDtoEagerLoaded.Username),new PropertyMappingValue(new List<string>(){{nameof(Radnik.KorisnickiNalog.Username)}})},
                        {nameof(RadnikDtoEagerLoaded.LicniPodaciId),new PropertyMappingValue(new List<string>(){{nameof(Radnik.LicniPodaciId)}})},
                        {nameof(RadnikDtoEagerLoaded.ImePrezime),new PropertyMappingValue(new List<string>(){{nameof(Radnik.LicniPodaci.Ime)},{nameof(Radnik.LicniPodaci.Prezime)}})},
                        {nameof(RadnikDtoEagerLoaded.JMBG),new PropertyMappingValue(new List<string>(){{nameof(Radnik.LicniPodaci.JMBG)}})},
                        {nameof(RadnikDtoEagerLoaded.Adresa),new PropertyMappingValue(new List<string>(){{nameof(Radnik.LicniPodaci.Adresa)}})},
                        {nameof(RadnikDtoEagerLoaded.Pol),new PropertyMappingValue(new List<string>(){{nameof(Radnik.LicniPodaci.Pol)}})},
                        {nameof(RadnikDtoEagerLoaded.BrojTelefona),new PropertyMappingValue(new List<string>(){{nameof(Radnik.LicniPodaci.BrojTelefona)}})},
                        {nameof(RadnikDtoEagerLoaded.Grad),new PropertyMappingValue(new List<string>(){{nameof(Radnik.LicniPodaci.Grad.Naziv)}})},
                        {nameof(RadnikDtoEagerLoaded.StacionarnoOdeljenjeId),new PropertyMappingValue(new List<string>(){{nameof(Radnik.StacionarnoOdeljenjeId)}})},
                        {nameof(RadnikDtoEagerLoaded.StacionarnoOdeljenje),new PropertyMappingValue(new List<string>(){{nameof(Radnik.StacionarnoOdeljenje.Naziv)}})},
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