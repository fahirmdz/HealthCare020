﻿using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mapper = HealthCare020.Services.Mappers.Mapper;

namespace HealthCare020.Services.Helpers
{
    public static class AutoMapperExtensions
    {
        public static TDestination Map<TSource, TDestination>(this TDestination destination,[FromServices]IMapper mapper, TSource source)
        {
            return mapper.Map(source, destination);
        }
    }
}