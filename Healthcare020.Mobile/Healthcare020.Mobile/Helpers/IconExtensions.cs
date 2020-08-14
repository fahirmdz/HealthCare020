using Xamarin.Forms;

namespace Healthcare020.Mobile.Helpers
{
    public static class IconExtensions
    {
        /// <summary>
        /// Get Font Awesome icon based on glyph string
        /// </summary>
        /// <param name="glyph"></param>
        /// <param name="size"></param>
        /// <returns>FontImageSource object of icon</returns>
        public static FontImageSource GetIcon(this string glyph, int size = 30)
        {
            var FontAwesomeRegular = Application.Current.Resources["FontAwesomeRegular"] as OnPlatform<string>;

            return new FontImageSource
            {
                FontFamily = FontAwesomeRegular,
                Glyph = glyph,
                Color = Color.WhiteSmoke,
                Size = size
            };
        }
    }
}