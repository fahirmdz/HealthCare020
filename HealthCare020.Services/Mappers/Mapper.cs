using System.Collections.Generic;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System.Globalization;
using System.Linq;

namespace HealthCare020.Services.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ZdravstvenoStanje, TwoFieldsDto>()
                .ForMember(x => x.Naziv, opt => opt.MapFrom(x => x.Opis))
                .ReverseMap();

            CreateMap<ZdravstvenoStanjeUpsertDto, ZdravstvenoStanje>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<TokenPoseta, TokenPosetaDto>().ReverseMap();
            CreateMap<TokenPosetaUpsertDto, TokenPoseta>().ReverseMap();

            CreateMap<Role, TwoFieldsDto>()
                .ForMember(x => x.Naziv, opt => opt.MapFrom(x => x.Naziv))
                .ReverseMap();
            CreateMap<RoleUpsertDto, Role>().ReverseMap();

            CreateMap<Drzava, DrzavaUpsertRequest>().ReverseMap();
            CreateMap<Drzava, DrzavaDto>().ReverseMap();

            CreateMap<Grad, GradDto>().ReverseMap();
            CreateMap<GradUpsertDto, Grad>().ReverseMap();
            CreateMap<Grad, GradDtoEagerLoaded>()
                .ForMember(dest => dest.Drzava,
                    opt => opt.MapFrom(x => x.Drzava.Naziv));

            CreateMap<KorisnickiNalog, KorisnickiNalogUpsertDto>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<KorisnickiNalog, KorisnickiNalogDtoLazyLoaded>()
                .ForMember(dest => dest.DateCreated,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                .ForMember(dest => dest.LastOnline,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                .ForMember(dest => dest.Roles,
                    opt => opt.MapFrom(x => x.RolesKorisnickiNalog.Select(z => z.RoleId)));

            CreateMap<KorisnickiNalog, KorisnickiNalogDtoEagerLoaded>()
                .ForMember(dest => dest.DateCreated,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                .ForMember(dest => dest.LastOnline,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                 .ForMember(dest => dest.Roles,
                    opt => opt.MapFrom(x => x.RolesKorisnickiNalog.Select(z=>z.Role)));
               

            CreateMap<LicniPodaci, LicniPodaciDto>().ReverseMap();
            CreateMap<LicniPodaci, LicniPodaciUpsertDto>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<StacionarnoOdeljenje, TwoFieldsDto>()
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(x => x.Naziv));

            CreateMap<StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenje>();

            //Radnik
            CreateMap<Radnik, RadnikPrijemDto>()
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore());
            CreateMap<Radnik, RadnikPrijemDtoEagerLoaded>()
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore());

            //RadnikPrijem
            CreateMap<RadnikPrijem, RadnikPrijemDto>();
            CreateMap<RadnikPrijem, RadnikPrijemDtoEagerLoaded>()
                .ForMember(dest => dest.ImePrezime,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaci.Ime + " " + x.Radnik.LicniPodaci.Prezime));
            CreateMap<RadnikPrijemUpsertDto, Radnik>();

            CreateMap<LicniPodaci, RadnikPrijemDtoEagerLoaded>()
                .ForMember(dest => dest.Grad,
                    opt => opt.MapFrom(x => x.Grad.Naziv))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<KorisnickiNalog, RadnikPrijemDtoEagerLoaded>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<StacionarnoOdeljenje, RadnikPrijemDtoEagerLoaded>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.Naziv))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}