using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Dialogs
{
    public partial class dlgPropmpt : Form
    {
        private static dlgPropmpt _instance = null;

        private dlgPropmpt()
        {
            InitializeComponent();
            this.Opacity = 50;
            this.FormBorderStyle = FormBorderStyle.None;
            pnlBody.BackColor = Color.FromArgb(
                245, 245, 245
            );
        }

        public new static dlgPropmpt ShowDialog()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new dlgPropmpt();
            }

            ShowDialog();
            _instance.BringToFront();

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
            this.CenterToParent();
            this.BringToFront();
        }

        private void dlgPropmpt_Shown(object sender, System.EventArgs e)
        {
            pnlBody.PointToScreen(new Point(Width / 2, Height / 2));
        }

        private async void btnYes_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}