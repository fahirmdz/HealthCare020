using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.CustomElements
{
    internal class CircularPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = new GraphicsPath();
            g.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new Region(g);
            base.OnPaint(pe);
        }
    }
}