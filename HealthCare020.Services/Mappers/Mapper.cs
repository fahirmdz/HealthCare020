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
            #region ZdravstvenoStanje

            CreateMap<ZdravstvenoStanje, ZdravstvenoStanjeDto>();

            CreateMap<ZdravstvenoStanjeUpsertDto, ZdravstvenoStanje>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();

            #endregion ZdravstvenoStanje

            #region Role

            CreateMap<Role, TwoFieldsDto>()
                .ForMember(x => x.Naziv, opt => opt.MapFrom(x => x.Naziv))
                .ReverseMap();
            CreateMap<RoleUpsertDto, Role>().ReverseMap();

            #endregion Role

            #region NaucnaOblast

            CreateMap<NaucnaOblast, TwoFieldsDto>()
                .ForMember(x => x.Naziv, opt => opt.MapFrom(x => x.Naziv))
                .ReverseMap();
            CreateMap<NaucnaOblastUpsertDto, NaucnaOblast>().ReverseMap();

            #endregion NaucnaOblast

            #region Drzava

            CreateMap<Drzava, DrzavaUpsertRequest>().ReverseMap();
            CreateMap<Drzava, DrzavaDto>().ReverseMap();

            #endregion Drzava

            #region Grad

            CreateMap<Grad, GradDtoLL>().ReverseMap();
            CreateMap<Grad, GradDtoEL>();
            CreateMap<GradUpsertDto, Grad>();

            #endregion Grad

            #region KorisnickiNalog

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

            #endregion KorisnickiNalog

            #region LicniPodaci

            CreateMap<LicniPodaci, LicniPodaciDto>();
            CreateMap<LicniPodaci, LicniPodaciUpsertDto>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            #endregion LicniPodaci

            #region StacionarnoOdeljenje

            CreateMap<StacionarnoOdeljenje, TwoFieldsDto>()
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(x => x.Naziv));

            CreateMap<StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenje>();

            #endregion StacionarnoOdeljenje

            #region Radnik

            CreateMap<Radnik, RadnikPrijemDtoLL>()
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore());
            CreateMap<Radnik, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore());
            CreateMap<Radnik, RadnikDtoEL>()
                .ForMember(dest => dest.Ime,
                    opt => opt.MapFrom(x => x.LicniPodaci.Ime))
                .ForMember(dest => dest.Prezime,
                    opt => opt.MapFrom(x => x.LicniPodaci.Prezime));

            #endregion Radnik

            #region RadnikPrijem

            CreateMap<RadnikPrijemUpsertDto, Radnik>().ReverseMap();

            CreateMap<LicniPodaci, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<KorisnickiNalog, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<StacionarnoOdeljenje, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.Naziv))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<RadnikPrijem, RadnikPrijemDtoLL>()
                .ForMember(dest => dest.KorisnickiNalogId,
                    opt => opt.MapFrom(x => x.Radnik.KorisnickiNalogId))
                .ForMember(dest => dest.LicniPodaciId,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaciId))
                .ForMember(dest => dest.StacionarnoOdeljenjeId,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenjeId));

            CreateMap<RadnikPrijem, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenje));

            CreateMap<RadnikPrijemUpsertDto, Radnik>().ReverseMap();

            #endregion RadnikPrijem

            #region MedicinskiTehnicar

            CreateMap<MedicinskiTehnicar, MedicinskiTehnicarDtoLL>()
                .ForMember(dest => dest.KorisnickiNalogId,
                    opt => opt.MapFrom(x => x.Radnik.KorisnickiNalogId))
                .ForMember(dest => dest.LicniPodaciId,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaciId))
                .ForMember(dest => dest.StacionarnoOdeljenjeId,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenjeId));

            CreateMap<MedicinskiTehnicar, MedicinskiTehnicarDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenje));

            CreateMap<MedicinskiTehnicarUpsertDto, Radnik>().ReverseMap();

            #endregion MedicinskiTehnicar

            #region Doktor

            CreateMap<Doktor, DoktorDtoLL>();

            CreateMap<Doktor, DoktorDtoEL>()
                .ForMember(dest => dest.NaucnaOblast,
                    opt => opt.MapFrom(x => x.NaucnaOblast))
                .ForMember(dest => dest.Radnik,
                    opt => opt.MapFrom(x => x.Radnik));

            CreateMap<DoktorUpsertDto, Doktor>()
                .ForMember(dest => dest.Radnik, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<DoktorUpsertDto, Radnik>().ReverseMap();

            #endregion Doktor

            #region Pacijent

            CreateMap<Pacijent, PacijentDtoLL>()
                .ForMember(dest => dest.Username,
                    opt => opt.MapFrom(x => x.KorisnickiNalog.Username));
            CreateMap<Pacijent, PacijentDtoEL>()
                .ForMember(dest => dest.ZdravstvenaKnjizica,
                    opt => opt.MapFrom(x => x.ZdravstvenaKnjizica))
                .ForMember(dest => dest.Username,
                    opt => opt.MapFrom(x => x.KorisnickiNalog.Username));
            CreateMap<PacijentUpsertDto, Pacijent>();

            #endregion Pacijent

            #region ZahtevZaPregled

            CreateMap<ZahtevZaPregled, ZahtevZaPregledDtoLL>();
            CreateMap<ZahtevZaPregled, ZahtevZaPregledDtoEL>()
                .ForMember(dest => dest.Doktor,
                    opt => opt.MapFrom(x => x.Doktor.Radnik.LicniPodaci.ImePrezime()))
                .ForMember(dest => dest.Pacijent,
                    opt => opt.MapFrom(x => x.Pacijent))
                .ForMember(dest => dest.Uputnica,
                    opt => opt.MapFrom(x => x.Uputnica));

            #endregion ZahtevZaPregled

            #region Pregled

            CreateMap<Pregled, PregledDtoLL>();
            CreateMap<Pregled, PregledDtoEL>()
                .ForMember(dest => dest.Doktor,
                    opt => opt.MapFrom(x => x.Doktor.Radnik.LicniPodaci.ImePrezime()))
                .ForMember(dest => dest.Pacijent,
                    opt => opt.MapFrom(x => x.Pacijent));

            #endregion Pregled

            #region ZdravstvenaKnjizica

            CreateMap<ZdravstvenaKnjizica, ZdravstvenaKnjizicaDtoLL>();
            CreateMap<ZdravstvenaKnjizica, ZdravstvenaKnjizicaDtoEL>()
                .ForMember(dest => dest.Doktor,
                    opt => opt.MapFrom(x => x.Doktor.Radnik.LicniPodaci.ImePrezime()))
                .ForMember(dest => dest.LicniPodaci,
                    opt => opt.MapFrom(x => x.LicniPodaci));

            #endregion ZdravstvenaKnjizica

            #region Uputnica

            CreateMap<Uputnica, UputnicaDtoLL>();
            CreateMap<Uputnica, UputnicaDtoEL>()
                .ForMember(dest => dest.Pacijent,
                    opt => opt.MapFrom(x => x.Pacijent))
                .ForMember(dest => dest.UpucenKodDoktora,
                    opt => opt.MapFrom(x => x.UpucenKodDoktora.Radnik.LicniPodaci.ImePrezime()))
                .ForMember(dest => dest.UputioDoktor,
                    opt => opt.MapFrom(x => x.UputioDoktor.Radnik.LicniPodaci.ImePrezime()));
            CreateMap<UputnicaUpsertDto, Uputnica>();

            #endregion Uputnica

            #region LekarskoUverenje

            CreateMap<LekarskoUverenje, LekarskoUverenjeDtoLL>();
            CreateMap<LekarskoUverenje, LekarskoUverenjeDtoEL>()
                .ForMember(dest => dest.Pregled,
                    opt => opt.MapFrom(x => x.Pregled))
                .ForMember(dest => dest.ZdravstvenoStanje,
                    opt => opt.MapFrom(x => x.ZdravstvenoStanje));
            CreateMap<LekarskoUverenjeUpsertDto, LekarskoUverenje>();

            #endregion LekarskoUverenje

            #region Poseta

            CreateMap<ZahtevZaPosetu, ZahtevZaPosetuDtoLL>();
            CreateMap<ZahtevZaPosetu, ZahtevZaPosetuDtoEL>()
                .ForMember(dest => dest.PacijentNaLecenju,
                    opt => opt.MapFrom(x => x.PacijentNaLecenju));
            CreateMap<ZahtevZaPosetuUpsertDto, ZahtevZaPosetu>();

            #endregion Poseta

            #region PacijentNaLecenju

            CreateMap<PacijentNaLecenju, PacijentNaLecenjuDtoLL>();
            CreateMap<PacijentNaLecenju, PacijentNaLecenjuDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.StacionarnoOdeljenje))
                .ForMember(dest => dest.LicniPodaci,
                    opt => opt.MapFrom(x => x.LicniPodaci));
            CreateMap<PacijentNaLecenjuUpsertDto, PacijentNaLecenju>();

            #endregion PacijentNaLecenju
        }
    }
}