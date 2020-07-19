using System.Threading.Tasks;
using Xamarin.Forms;

namespace Healthcare020.Mobile.Helpers
{
    public static class PageExtensions
    {
        public static async Task PopToRootParentNavigationPage(this Page page)
        {
            if (page.Parent is NavigationPage navPage)
            {
                await navPage.PopToRootAsync();
            }
        }

        public static async Task PopToRootAsNavigationPage(this Page page)
        {
            if (page is NavigationPage navPage)
            {
                await navPage.PopToRootAsync();
            }
        }

        public static async Task PopToRootCurrentTabAsNavigationPage(this Page page)
        {
            if (page is TabbedPage tabbedPage)
            {
                if (tabbedPage.CurrentPage is NavigationPage navPage)
                {
                    await navPage.PopToRootAsync();
                }
            }
        }
    }
}