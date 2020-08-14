using Healthcare020.WinUI.Forms;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    public sealed partial class dlgSuccess : Form
    {
        private static dlgSuccess _instance;

        private dlgSuccess()
        {
            InitializeComponent();
            var mainFormSize = MainForm.Instance.Size;
            Size = new Size(mainFormSize.Width - 14, mainFormSize.Height - 14);
            pnlMain.MinimumSize = Size;

            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            pnlMain.BackColor = Color.FromArgb(80, 0, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        public new static void ShowDialog()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new dlgSuccess();
            }

            ((Form)_instance).ShowDialog();
            _instance.BringToFront();
        }

        private async void dlgSuccess_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
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