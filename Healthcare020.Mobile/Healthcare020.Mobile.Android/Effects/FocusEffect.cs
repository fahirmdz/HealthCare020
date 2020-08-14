using System;
using HealthCare020.Core.Resources;
using Healthcare020.Mobile.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(FocusEffect), nameof(FocusEffect))]
namespace Healthcare020.Mobile.Droid.Effects
{
    public class FocusEffect : PlatformEffect
    {
        private float scaleX;
        private float scaleY;


        protected override void OnAttached()
        {
            try
            {
                scaleX = Control.ScaleX;
                scaleY = Control.ScaleY;
            }
            catch (Exception ex)
            {
                Console.WriteLine(SharedResources.FocusEffect_OnAttached_Cannot_set_property_on_attached_control__Error__, ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (Control.ScaleY-scaleY>1)
                    {
                        Control.ScaleY = scaleY;
                        Control.ScaleX = scaleX;
                    }
                    else
                    {
                        Control.ScaleY = scaleY + 5;
                        Control.ScaleX = scaleX + 5;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(SharedResources.FocusEffect_OnAttached_Cannot_set_property_on_attached_control__Error__, ex.Message);
            }
        }
    }
}