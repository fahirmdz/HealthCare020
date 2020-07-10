using Android.Content;
using Android.Support.Design.Widget;
using Android.Views;
using Healthcare020.Mobile.Droid.Renderers;
using Healthcare020.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(PacijentDasbhboardTabbedPage), typeof(MyTabPageRender))]

namespace Healthcare020.Mobile.Droid.Renderers
{
    public class MyTabPageRender : TabbedPageRenderer, BottomNavigationView.IOnNavigationItemReselectedListener
    {
        public MyTabPageRender(Context context) : base(context)
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null && e.NewElement != null)
            {
                for (int i = 0; i <= this.ViewGroup.ChildCount - 1; i++)
                {
                    var childView = this.ViewGroup.GetChildAt(i);
                    if (childView is ViewGroup viewGroup)
                    {
                        for (int j = 0; j <= viewGroup.ChildCount - 1; j++)
                        {
                            var childRelativeLayoutView = viewGroup.GetChildAt(j);
                            if (childRelativeLayoutView is BottomNavigationView bottomNavigationView)
                            {
                                bottomNavigationView.SetOnNavigationItemReselectedListener(this);
                            }
                        }
                    }
                }
            }
        }

        async void BottomNavigationView.IOnNavigationItemReselectedListener.OnNavigationItemReselected(IMenuItem item)
        {
            if (Element.CurrentPage is NavigationPage navPage)
            {
                await navPage.PopToRootAsync(true);
            }
        }
    }
}