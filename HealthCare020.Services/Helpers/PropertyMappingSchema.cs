using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Services.Interfaces;
using HealthCare020.Services.Services;
using System.Collections.Generic;

namespace HealthCare020.Services.Helpers
{
    public static class PropertyMappingSchema
    {
        public static IList<IPropertyMapping> PropertyMappings =>
            new List<IPropertyMapping>()
            {
                {new PropertyMapping<GradDto,Grad>(new Dictionary<string, PropertyMappingValue>()
                    {
                        {nameof(GradDto.Naziv).ToLower(),new PropertyMappingValue(new List<string>(){nameof(Grad.Naziv).ToLower()})},
                        {nameof(GradDto.Id).ToLower(),new PropertyMappingValue(new List<string>(){{nameof(Grad.Id).ToLower()}}) },
                        {nameof(GradDto.DrzavaId).ToLower(),new PropertyMappingValue(new List<string>(){{nameof(Grad.DrzavaId).ToLower()}}) },
                    })
                },
            };
    }
}