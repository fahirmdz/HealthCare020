using Xamarin.Forms;

namespace Healthcare020.Mobile.Controls
{
    /// <summary>
    /// Custom picker with bindable flag value in ClassId that indicates that indicates picker is ready or not for opening
    /// </summary>
    public class CustomPicker : Picker
    {
        public static string PickerIsReady = "Ready";
        public static string PickerIsNotReady = "NotReady";

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(ClassId))
            {
                if (ClassId == PickerIsReady)
                    Focus();
            }
        }
    }
}