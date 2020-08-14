using AutoMapper;
using HealthCare020.Core.Mappers;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Services;
using Mapper = AutoMapper.Mapper;

namespace Healthcare020.Mobile.Helpers
{
    public static class Bootstrap
    {
        internal static TinyIoCContainer GetContainer()
        {
            var container = new TinyIoCContainer();
            container.Register<IAPIService, APIService>();

            container.Register<IMapper, Mapper>(new Mapper(new MapperConfiguration(MapperConfig.MapperConfiguration())));
            return container;
        }

        public static ILocator GetLocator()
        {
            return new Locator(GetContainer());
        }
    }
}