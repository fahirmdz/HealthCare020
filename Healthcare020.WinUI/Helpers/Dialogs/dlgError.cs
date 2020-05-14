using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Dialogs
{
    public partial class dlgError : Form
    {
        private static dlgError _instance = null;

        private dlgError()
        {
            InitializeComponent();
            this.Opacity = 50;
            this.FormBorderStyle = FormBorderStyle.None;
            var mainFormSize = MainForm.Instance.Size;
            this.Size=new Size(mainFormSize.Width-14,mainFormSize.Height-14);
        }

        public new static void ShowDialog()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance=new dlgError();
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
            await Task.Delay(1500);
            Close();
            Dispose();
        }
    }
}