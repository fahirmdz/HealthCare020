using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers
{
    public static class StyleExtensions
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );


        public static IntPtr CreateRoundRect(this Form form,int nWidthElipse,int nHeightElipse)
        {
            return CreateRoundRectRgn(0, 0, form.Width, form.Height, nWidthElipse, nHeightElipse);
        }

        public static IntPtr CreateRoundRect(this TextBox textBox,int nWidthElipse,int nHeightElipse)
        {
            return CreateRoundRectRgn(0, 0, textBox.Width, textBox.Height, nWidthElipse, nHeightElipse);
        }
    }
}