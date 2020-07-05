using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Services;
using TinyIoC;

namespace Healthcare020.Mobile.Helpers
{
    public static class Bootstrap
    {
        internal static TinyIoCContainer GetContainer()
        {
            var container = new TinyIoCContainer();
            container.Register<IAPIService, APIService>();

            return container;
        }

        public static ILocator GetLocator()
        {
            return new Locator(Bootstrap.GetContainer());
        }
    }
}