using System.Drawing;
using System.Windows.Forms;
using Healthcare020.WinUI.Forms;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    public partial class dlgPropmpt : Form
    {
        private static dlgPropmpt _instance = null;

        private dlgPropmpt()
        {
            InitializeComponent();
            this.Opacity = 50;
            var mainFormSize = MainForm.Instance.Size;
            this.Size = new Size(mainFormSize.Width - 14, mainFormSize.Height - 14);
            this.FormBorderStyle = FormBorderStyle.None;
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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(70, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
        }

        private void dlgPropmpt_Load(object sender, System.EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void dlgPropmpt_Shown(object sender, System.EventArgs e)
        {
            pnlBody.PointToScreen(new Point(Width / 2, Height / 2));
        }

#pragma warning disable 1998

        private async void btnYes_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

#pragma warning restore 1998
    }
}