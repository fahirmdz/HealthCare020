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

            CreateMap<ZdravstvenoStanje, TwoFields>()
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Opis))
                .ReverseMap();

            CreateMap<ZdravstvenoStanjeUpsertRequest, ZdravstvenoStanje>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<TokenPoseta, TwoFields>().ReverseMap();
        }
    }
}