﻿using HealthCare020.Core.Entities;
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
                        {nameof(DoktorDtoLL.LicniPodaciId),new PropertyMappingValue(new List<string>(){{nameof(Doktor.Radnik.LicniPodaciId)}})},
                        {nameof(DoktorDtoLL.StacionarnoOdeljenjeId),new PropertyMappingValue(new List<string>(){{nameof(Doktor.Radnik.StacionarnoOdeljenjeId)}})},
                        {nameof(DoktorDtoLL.KorisnickiNalogId),new PropertyMappingValue(new List<string>(){{nameof(Doktor.Radnik.KorisnickiNalogId)}})},
                    })
                },
                {new PropertyMapping<DoktorDtoEL,Doktor>(new Dictionary<string, PropertyMappingValue>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {nameof(DoktorDtoEL.Id),new PropertyMappingValue(new List<string>(){nameof(Doktor.Id)})},
                        {nameof(DoktorDtoEL.KorisnickiNalog),new PropertyMappingValue(new List<string>(){{nameof(Doktor.Radnik.KorisnickiNalog)}})},
                        {nameof(DoktorDtoEL.LicniPodaci),new PropertyMappingValue(new List<string>(){{nameof(Doktor.Radnik.LicniPodaci)}})},
                        {nameof(DoktorDtoEL.StacionarnoOdeljenje),new PropertyMappingValue(new List<string>(){{nameof(Doktor.Radnik.StacionarnoOdeljenje)}})},
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
                        {nameof(KorisnickiNalogDtoEL.Roles),new PropertyMappingValue(new List<string>(){{nameof(KorisnickiNalog.RolesKorisnickiNalog)}}) },
                    })
                },
            };
    }
}