using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    public partial class dlgSuccess : Form
    {
        private static dlgSuccess _instance = null;

        private dlgSuccess()
        {
            InitializeComponent();
            this.Opacity = 50;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
            pnlBody.BackColor = Color.FromArgb(
                245, 245, 245
            );
        }

        public new static void ShowDialog()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new dlgSuccess();
            }

            ((Form) _instance).ShowDialog();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(70, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
        }

        private async void dlgSuccess_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            base.OnLoad(e);
            await Task.Delay(1000);
            Close();
            Dispose();
        }

        private void dlgSuccess_Shown(object sender, EventArgs e)
        {
            pnlBody.PointToScreen(new Point(Width / 2, Height / 2));
        }
    }
}