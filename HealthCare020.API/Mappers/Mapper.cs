using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;

namespace HealthCare020.API.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<ZdravstvenoStanje, TwoFields>().ReverseMap();
        }
    }
}