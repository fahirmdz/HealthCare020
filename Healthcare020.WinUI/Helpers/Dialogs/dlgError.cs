using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Dialogs
{
    public partial class dlgError : Form
    {
        public dlgError()
        {
            InitializeComponent();
            InitializeComponent();
            this.Opacity = 50;
            this.FormBorderStyle = FormBorderStyle.None;
            pnlBody.BackColor = Color.FromArgb(
                245, 245, 245
            );
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(70, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
        }

        private void dlgError_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.CenterToParent();
            this.BringToFront();
        }

        private void dlgError_Shown(object sender, EventArgs e)
        {
            pnlBody.PointToScreen(new Point(Width / 2, Height / 2));
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await Task.Delay(1000);
            Close();
        }
    }
}