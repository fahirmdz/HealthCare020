using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare020.WinUI.Forms;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    public partial class dlgSuccess : Form
    {
        private static dlgSuccess _instance = null;

        private dlgSuccess()
        {
            InitializeComponent();
            this.Opacity = 50;
            var mainFormSize = MainForm.Instance.Size;
            this.Size=new Size(mainFormSize.Width-14,mainFormSize.Height-14);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public new static void ShowDialog()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new dlgSuccess();
            }

            ((Form) _instance).ShowDialog();
            _instance.BringToFront();
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
            this.Dock = DockStyle.Fill;
            await Task.Delay(1200);
            Close();
            Dispose();
        }

        private void dlgSuccess_Shown(object sender, EventArgs e)
        {
            pnlBody.PointToScreen(new Point(Width / 2, Height / 2));
        }
    }
}