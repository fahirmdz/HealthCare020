using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;

namespace HealthCare020.Services.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ZdravstvenoStanje, TwoFieldsDto>()
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Opis))
                .ReverseMap();

            CreateMap<ZdravstvenoStanjeUpsertDto, ZdravstvenoStanje>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<TokenPoseta, TwoFieldsDto>().ReverseMap();
            CreateMap<TokenPosetaUpsertDto, TokenPoseta>().ReverseMap();

            CreateMap<Role, TwoFieldsDto>()
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Naziv))
                .ReverseMap();
            CreateMap<RoleUpsertDto, Role>().ReverseMap();

            CreateMap<Drzava, DrzavaUpsertRequest>().ReverseMap();
            CreateMap<Drzava, DrzavaDto>().ReverseMap();

            CreateMap<Grad, GradDto>().ReverseMap();
            CreateMap<GradUpsertDto, Grad>().ReverseMap();

            CreateMap<KorisnickiNalog, KorisnickiNalogUpsertDto>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<KorisnickiNalog, KorisnickiNalogDto>().ReverseMap();

            CreateMap<LicniPodaci, LicniPodaciDto>().ReverseMap();
            CreateMap<LicniPodaci, LicniPodaciUpsertDto>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<StacionarnoOdeljenje, TwoFieldsDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Naziv));

            CreateMap<StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenje>();

            CreateMap<RoleKorisnickiNalog, RoleKorisnickiNalogDto>();
            CreateMap<KorisnickiNalogRoleUpsertDto, RoleKorisnickiNalog>();

            CreateMap<Radnik, RadnikDto>();
        }
    }
}