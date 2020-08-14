using Healthcare020.WinUI.Forms;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    public sealed partial class dlgPropmpt : Form
    {
        private static dlgPropmpt _instance;

        private dlgPropmpt()
        {
            InitializeComponent();
            var mainFormSize = MainForm.Instance.Size;
            Size = new Size(mainFormSize.Width - 16, mainFormSize.Height - 14);
            pnlMain.MinimumSize = Size;
            FormBorderStyle = FormBorderStyle.None;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            TransparencyKey = Color.Transparent;
            pnlMain.BackColor = Color.FromArgb(125, 0, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        public new static dlgPropmpt ShowDialog()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new dlgPropmpt();
            }

            ((Form)_instance).ShowDialog();
            return _instance;
        }

        private void dlgPropmpt_Load(object sender, System.EventArgs e)
        {
            Dock = DockStyle.Fill;
        }

        private void dlgPropmpt_Shown(object sender, System.EventArgs e)
        {
            pnlBody.PointToScreen(new Point(Width / 2, Height / 2));
        }

#pragma warning disable 1998

        private async void btnYes_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void pnlMain_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
            Dispose();
        }

#pragma warning restore 1998
    }
}