using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;

namespace HealthCare020.API.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<ZdravstvenoStanje, TwoFields>()
                .ForMember(x=>x.Value,opt=>opt.MapFrom(x=>x.Opis))
                .ReverseMap();

            CreateMap<ZdravstvenoStanje, ZdravstvenoStanjeUpsertRequest>().ReverseMap();
        }
    }
}