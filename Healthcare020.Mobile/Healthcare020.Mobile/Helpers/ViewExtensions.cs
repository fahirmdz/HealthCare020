using System.Threading.Tasks;
using Xamarin.Forms;

namespace Healthcare020.Mobile.Helpers
{
    public static class ViewExtensions
    {
        public static async Task ScaleEffect(this View view,double scale)
        {
            await view.ScaleTo(scale, 150);
            await view.ScaleTo(1, 150);
        }
    }
}