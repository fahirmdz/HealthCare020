using Healthcare020.WinUI.Forms;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    public partial class dlgError : Form
    {
        private static dlgError _instance = null;

        private dlgError(string message = "")
        {
            InitializeComponent();
            lblError.Text = string.IsNullOrWhiteSpace(message)?"Greška":message;
            this.FormBorderStyle = FormBorderStyle.None;
            var mainFormSize = MainForm.Instance.Size;
            this.Size = new Size(mainFormSize.Width - 14, mainFormSize.Height - 14);
            pnlMain.MinimumSize = Size;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor,true);
            this.BackColor=Color.Transparent;
            this.TransparencyKey=Color.Transparent;
            pnlMain.BackColor = Color.FromArgb(125, 0, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        public static void ShowDialog(string message = "")
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new dlgError(message);
            }

            ((Form) _instance).Visible = false;
            ((Form)_instance).ShowDialog();
        }

        private void dlgError_Shown(object sender, EventArgs e)
        {
            pnlBody.PointToScreen(new Point(Width / 2, Height / 2));
        }

        private async void dlgError_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            await Task.Delay(1200);
            Close();
            Dispose();
        }
    }
}