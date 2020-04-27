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

            CreateMap<NaucnaOblast, TwoFieldsDto>()
                .ForMember(x => x.Naziv, opt => opt.MapFrom(x => x.Naziv))
                .ReverseMap();
            CreateMap<NaucnaOblastUpsertDto, NaucnaOblast>().ReverseMap();

            CreateMap<Drzava, DrzavaUpsertRequest>().ReverseMap();
            CreateMap<Drzava, DrzavaDto>().ReverseMap();

            CreateMap<Grad, GradDtoLL>().ReverseMap();
            CreateMap<Grad, GradDtoEL>();

            CreateMap<KorisnickiNalog, KorisnickiNalogUpsertDto>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<KorisnickiNalog, KorisnickiNalogDtoLL>()
                .ForMember(dest => dest.DateCreated,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                .ForMember(dest => dest.LastOnline,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                .ForMember(dest => dest.Roles,
                    opt => opt.MapFrom(x => x.RolesKorisnickiNalog.Select(z => z.RoleId)));

            CreateMap<KorisnickiNalog, KorisnickiNalogDtoEL>()
                .ForMember(dest => dest.DateCreated,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                .ForMember(dest => dest.LastOnline,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                 .ForMember(dest => dest.Roles,
                    opt => opt.MapFrom(x => x.RolesKorisnickiNalog.Select(z => z.Role)));

            CreateMap<LicniPodaci, LicniPodaciDto>();
            CreateMap<LicniPodaci, LicniPodaciUpsertDto>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<StacionarnoOdeljenje, TwoFieldsDto>()
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(x => x.Naziv));

            CreateMap<StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenje>();

            //Radnik
            CreateMap<Radnik, RadnikPrijemDtoLL>()
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore());
            CreateMap<Radnik, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore());
            CreateMap<Radnik, RadnikDtoEL>();


            //RadnikPrijem
            CreateMap<RadnikPrijem, RadnikPrijemDtoLL>();
            CreateMap<RadnikPrijem, RadnikPrijemDtoEL>();
            CreateMap<RadnikPrijemUpsertDto, Radnik>().ReverseMap();

            CreateMap<LicniPodaci, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<KorisnickiNalog, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<StacionarnoOdeljenje, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.Naziv))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            //RadnikPrijem
            CreateMap<RadnikPrijem, RadnikPrijemDtoLL>()
                .ForMember(dest => dest.KorisnickiNalogId,
                    opt => opt.MapFrom(x => x.Radnik.KorisnickiNalogId))
                .ForMember(dest => dest.LicniPodaciId,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaciId))
                .ForMember(dest => dest.StacionarnoOdeljenjeId,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenjeId));

            CreateMap<RadnikPrijem, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenje))
                .ForMember(dest => dest.LicniPodaci,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaci))
                .ForMember(dest => dest.KorisnickiNalog,
                    opt => opt.MapFrom(x => x.Radnik.KorisnickiNalog));
                
            CreateMap<RadnikPrijemUpsertDto, Radnik>().ReverseMap();



            //MedicinskiTehnicar
            CreateMap<MedicinskiTehnicar, MedicinskiTehnicarDtoLL>()
                .ForMember(dest => dest.KorisnickiNalogId,
                    opt => opt.MapFrom(x => x.Radnik.KorisnickiNalogId))
                .ForMember(dest => dest.LicniPodaciId,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaciId))
                .ForMember(dest => dest.StacionarnoOdeljenjeId,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenjeId));

            CreateMap<MedicinskiTehnicar, MedicinskiTehnicarDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenje))
                .ForMember(dest => dest.LicniPodaci,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaci))
                .ForMember(dest => dest.KorisnickiNalog,
                    opt => opt.MapFrom(x => x.Radnik.KorisnickiNalog));
                
            CreateMap<MedicinskiTehnicarUpsertDto, Radnik>().ReverseMap();


            //Doktor
            CreateMap<Doktor, DoktorDtoLL>();

            CreateMap<Doktor, DoktorDtoEL>()
                .ForMember(dest => dest.NaucnaOblast,
                    opt => opt.MapFrom(x => x.NaucnaOblast))
                .ForMember(dest => dest.Radnik,
                    opt => opt.MapFrom(x => x.Radnik));

            CreateMap<DoktorUpsertDto, Doktor>().ReverseMap();
            CreateMap<DoktorUpsertDto, Radnik>().ReverseMap();


            //UputZaLecenje
            CreateMap<UputZaLecenje, UputZaLecenjeDtoLL>();

            CreateMap<UputZaLecenje, UputZaLecenjeDtoEL>()
                .ForMember(dest => dest.Doktor,
                    opt => opt.MapFrom(x =>"dr. "+ x.Doktor.ImePrezime))
                .ForMember(dest => dest.LicniPodaci,
                    opt => opt.MapFrom(x => x.LicniPodaci));
            CreateMap<UputZaLecenjeUpsertDto, UputZaLecenje>()
                .ForMember(dest=>dest.LicniPodaci,opt=>opt.Ignore())
                .ReverseMap();


            //Pacijent
            CreateMap<Pacijent, PacijentDtoLL>();

            CreateMap<Pacijent, PacijentDtoEL>()
                .ForMember(dest => dest.LicniPodaci,
                    opt => opt.MapFrom(x => x.LicniPodaci))
                .ForMember(dest => dest.TokenPoseta,
                    opt => opt.MapFrom(x => x.TokenPoseta));

        }
    }
}