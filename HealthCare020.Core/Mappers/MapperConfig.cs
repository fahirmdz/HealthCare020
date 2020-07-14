using System.Globalization;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;

namespace HealthCare020.Core.Mappers
{
    public class MapperConfig
    {
        public static MapperConfigurationExpression MapperConfiguration()
        {
             #region ZdravstvenoStanje
            var mapperConfigExp = new MapperConfigurationExpression();

            mapperConfigExp.CreateMap<ZdravstvenoStanje, ZdravstvenoStanjeDto>();

            mapperConfigExp.CreateMap<ZdravstvenoStanjeUpsertDto, ZdravstvenoStanje>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();

            #endregion ZdravstvenoStanje

            #region Role

            mapperConfigExp.CreateMap<Role, TwoFieldsDto>()
                .ForMember(x => x.Naziv, opt => opt.MapFrom(x => x.Naziv))
                .ReverseMap();
            mapperConfigExp.CreateMap<RoleUpsertDto, Role>().ReverseMap();

            #endregion Role

            #region NaucnaOblast

            mapperConfigExp.CreateMap<NaucnaOblast, TwoFieldsDto>()
                .ForMember(x => x.Naziv, opt => opt.MapFrom(x => x.Naziv))
                .ReverseMap();
            mapperConfigExp.CreateMap<NaucnaOblastUpsertDto, NaucnaOblast>().ReverseMap();

            #endregion NaucnaOblast

            #region Drzava

            mapperConfigExp.CreateMap<Drzava, DrzavaUpsertRequest>().ReverseMap();
            mapperConfigExp.CreateMap<Drzava, DrzavaDto>().ReverseMap();

            #endregion Drzava

            #region Grad

            mapperConfigExp.CreateMap<Grad, GradDtoLL>().ReverseMap();
            mapperConfigExp.CreateMap<Grad, GradDtoEL>();
            mapperConfigExp.CreateMap<GradUpsertDto, Grad>();

            #endregion Grad

            #region KorisnickiNalog

            mapperConfigExp.CreateMap<KorisnickiNalog, KorisnickiNalogUpsertDto>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());

            mapperConfigExp.CreateMap<KorisnickiNalog, KorisnickiNalogDtoLL>()
                .ForMember(dest => dest.DateCreated,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                .ForMember(dest => dest.LastOnline,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                .ForMember(dest => dest.Roles,
                    opt => opt.MapFrom(x => x.RolesKorisnickiNalog.Select(z => z.RoleId)));

            mapperConfigExp.CreateMap<KorisnickiNalog, KorisnickiNalogDtoEL>()
                .ForMember(dest => dest.DateCreated,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                .ForMember(dest => dest.LastOnline,
                    opt => opt.MapFrom(x => x.DateCreated.ToString("d", new CultureInfo("de-DE"))))
                .ForMember(dest => dest.Roles,
                    opt => opt.MapFrom(x => x.RolesKorisnickiNalog.Select(z => z.Role)));

            #endregion KorisnickiNalog

            #region LicniPodaci

            mapperConfigExp.CreateMap<LicniPodaci, LicniPodaciDto>()
                .DisableCtorValidation()
                .ForMember(dest=>dest.Grad,
                    opt=>opt.MapFrom(x=>x.Grad));
            mapperConfigExp.CreateMap<LicniPodaci, LicniPodaciUpsertDto>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            mapperConfigExp.CreateMap<LicniPodaciDto,LicniPodaciUpsertDto>().DisableCtorValidation();

            #endregion LicniPodaci

            #region StacionarnoOdeljenje

            mapperConfigExp.CreateMap<StacionarnoOdeljenje, TwoFieldsDto>()
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(x => x.Naziv));

            mapperConfigExp.CreateMap<StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenje>();

            #endregion StacionarnoOdeljenje

            #region Radnik

            mapperConfigExp.CreateMap<Radnik, RadnikPrijemDtoLL>()
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore());
            mapperConfigExp.CreateMap<Radnik, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore());
            mapperConfigExp.CreateMap<Radnik, RadnikDtoEL>()
                .ForMember(dest => dest.Ime,
                    opt => opt.MapFrom(x => x.LicniPodaci.Ime))
                .ForMember(dest => dest.Prezime,
                    opt => opt.MapFrom(x => x.LicniPodaci.Prezime));

            #endregion Radnik

            #region RadnikPrijem

            mapperConfigExp.CreateMap<RadnikPrijemUpsertDto, Radnik>().ReverseMap();

            mapperConfigExp.CreateMap<LicniPodaci, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            mapperConfigExp.CreateMap<KorisnickiNalog, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            mapperConfigExp.CreateMap<StacionarnoOdeljenje, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.Naziv))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            mapperConfigExp.CreateMap<RadnikPrijem, RadnikPrijemDtoLL>()
                .ForMember(dest => dest.KorisnickiNalogId,
                    opt => opt.MapFrom(x => x.Radnik.KorisnickiNalogId))
                .ForMember(dest => dest.LicniPodaciId,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaciId))
                .ForMember(dest => dest.StacionarnoOdeljenjeId,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenjeId));

            mapperConfigExp.CreateMap<RadnikPrijem, RadnikPrijemDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenje))
                .ForMember(dest => dest.LicniPodaciId,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaciId))
                .ForMember(dest => dest.Ime,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaci.Ime))
                .ForMember(dest => dest.Prezime,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaci.Prezime));

            mapperConfigExp.CreateMap<RadnikPrijemUpsertDto, Radnik>().ReverseMap();

            #endregion RadnikPrijem

            #region MedicinskiTehnicar

            mapperConfigExp.CreateMap<MedicinskiTehnicar, MedicinskiTehnicarDtoLL>()
                .ForMember(dest => dest.KorisnickiNalogId,
                    opt => opt.MapFrom(x => x.Radnik.KorisnickiNalogId))
                .ForMember(dest => dest.LicniPodaciId,
                    opt => opt.MapFrom(x => x.Radnik.LicniPodaciId))
                .ForMember(dest => dest.StacionarnoOdeljenjeId,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenjeId));

            mapperConfigExp.CreateMap<MedicinskiTehnicar, MedicinskiTehnicarDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.Radnik.StacionarnoOdeljenje));

            mapperConfigExp.CreateMap<MedicinskiTehnicarUpsertDto, Radnik>().ReverseMap();

            #endregion MedicinskiTehnicar

            #region Doktor

            mapperConfigExp.CreateMap<Doktor, DoktorDtoLL>();

            mapperConfigExp.CreateMap<Doktor, DoktorDtoEL>()
                .ForMember(dest => dest.NaucnaOblast,
                    opt => opt.MapFrom(x => x.NaucnaOblast))
                .ForMember(dest => dest.Radnik,
                    opt => opt.MapFrom(x => x.Radnik));

            mapperConfigExp.CreateMap<DoktorUpsertDto, Doktor>()
                .ForMember(dest => dest.Radnik, opt => opt.Ignore())
                .ReverseMap();
            mapperConfigExp.CreateMap<DoktorUpsertDto, Radnik>().ReverseMap();

            #endregion Doktor

            #region Pacijent

            mapperConfigExp.CreateMap<Pacijent, PacijentDtoLL>()
                .ForMember(dest => dest.Username,
                    opt => opt.MapFrom(x => x.KorisnickiNalog.Username));
            mapperConfigExp.CreateMap<Pacijent, PacijentDtoEL>()
                .DisableCtorValidation()
                .ForMember(dest => dest.ZdravstvenaKnjizica,
                    opt => opt.MapFrom(x => x.ZdravstvenaKnjizica))
                .ForMember(dest => dest.Username,
                    opt => opt.MapFrom(x => x.KorisnickiNalog.Username));
            mapperConfigExp.CreateMap<PacijentUpsertDto, Pacijent>();

            #endregion Pacijent

            #region ZahtevZaPregled

            mapperConfigExp.CreateMap<ZahtevZaPregled, ZahtevZaPregledDtoLL>();
            mapperConfigExp.CreateMap<ZahtevZaPregled, ZahtevZaPregledDtoEL>()
                .DisableCtorValidation()
                .ForMember(dest => dest.Doktor,
                    opt => opt.MapFrom(x => x.Doktor.Radnik.LicniPodaci.ImePrezime()))
                .ForMember(dest => dest.Pacijent,
                    opt => opt.MapFrom(x => x.Pacijent))
                .ForMember(dest => dest.Uputnica,
                    opt => opt.MapFrom(x => x.Uputnica));

            #endregion ZahtevZaPregled

            #region Pregled

            mapperConfigExp.CreateMap<Pregled, PregledDtoLL>();
            mapperConfigExp.CreateMap<Pregled, PregledDtoEL>()
                .ForMember(dest => dest.Doktor,
                    opt => opt.MapFrom(x => x.Doktor.Radnik.LicniPodaci.ImePrezime()))
                .ForMember(dest => dest.Pacijent,
                    opt => opt.MapFrom(x => x.Pacijent));

            #endregion Pregled

            #region ZdravstvenaKnjizica

            mapperConfigExp.CreateMap<ZdravstvenaKnjizica, ZdravstvenaKnjizicaDtoLL>();
            mapperConfigExp.CreateMap<ZdravstvenaKnjizica, ZdravstvenaKnjizicaDtoEL>()
                .DisableCtorValidation()
                .ForMember(dest => dest.Doktor,
                    opt => opt.MapFrom(x => x.Doktor.Radnik.LicniPodaci.ImePrezime()))
                .ForMember(dest => dest.LicniPodaci,
                    opt => opt.MapFrom(x => x.LicniPodaci));

            #endregion ZdravstvenaKnjizica

            #region Uputnica

            mapperConfigExp.CreateMap<Uputnica, UputnicaDtoLL>();
            mapperConfigExp.CreateMap<Uputnica, UputnicaDtoEL>()
                .ForMember(dest => dest.Pacijent,
                    opt => opt.MapFrom(x => x.Pacijent))
                .ForMember(dest => dest.UpucenKodDoktora,
                    opt => opt.MapFrom(x => x.UpucenKodDoktora.Radnik.LicniPodaci.ImePrezime()))
                .ForMember(dest => dest.UputioDoktor,
                    opt => opt.MapFrom(x => x.UputioDoktor.Radnik.LicniPodaci.ImePrezime()));
            mapperConfigExp.CreateMap<UputnicaUpsertDto, Uputnica>();

            #endregion Uputnica

            #region LekarskoUverenje

            mapperConfigExp.CreateMap<LekarskoUverenje, LekarskoUverenjeDtoLL>();
            mapperConfigExp.CreateMap<LekarskoUverenje, LekarskoUverenjeDtoEL>()
                .ForMember(dest => dest.Pregled,
                    opt => opt.MapFrom(x => x.Pregled))
                .ForMember(dest => dest.ZdravstvenoStanje,
                    opt => opt.MapFrom(x => x.ZdravstvenoStanje));
            mapperConfigExp.CreateMap<LekarskoUverenjeUpsertDto, LekarskoUverenje>();

            #endregion LekarskoUverenje

            #region Poseta

            mapperConfigExp.CreateMap<ZahtevZaPosetu, ZahtevZaPosetuDtoLL>();
            mapperConfigExp.CreateMap<ZahtevZaPosetu, ZahtevZaPosetuDtoEL>()
                .ForMember(dest => dest.PacijentNaLecenju,
                    opt => opt.MapFrom(x => x.PacijentNaLecenju));
            mapperConfigExp.CreateMap<ZahtevZaPosetuUpsertDto, ZahtevZaPosetu>();

            #endregion Poseta

            #region PacijentNaLecenju

            mapperConfigExp.CreateMap<PacijentNaLecenju, PacijentNaLecenjuDtoLL>();
            mapperConfigExp.CreateMap<PacijentNaLecenju, PacijentNaLecenjuDtoEL>()
                .ForMember(dest => dest.StacionarnoOdeljenje,
                    opt => opt.MapFrom(x => x.StacionarnoOdeljenje))
                .ForMember(dest => dest.ImePrezime,
                    opt => opt.MapFrom(x => x.LicniPodaci.ImePrezime()));
            mapperConfigExp.CreateMap<PacijentNaLecenjuUpsertDto, PacijentNaLecenju>();

            #endregion PacijentNaLecenju

            mapperConfigExp.CreateMap<ZahtevZaPosetuPatchDto, ZahtevZaPosetu>()
                .ForMember(dest => dest.Id, x => x.Ignore());
            mapperConfigExp.CreateMap<ZahtevZaPosetu,ZahtevZaPosetuPatchDto>();

            return mapperConfigExp;
        }
    }
}