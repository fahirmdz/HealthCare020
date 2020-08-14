using Healthcare020.WinUI.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    public sealed partial class dlgAccountLock : Form
    {
        private static dlgAccountLock _instance;
        public int NumberOfHours = 2;

        private dlgAccountLock()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            var mainFormSize = MainForm.Instance.Size;
            Size = new Size(mainFormSize.Width - 14, mainFormSize.Height - 14);
            pnlMain.MinimumSize = Size;

            cmbBrojSati.Items.Add("2");
            cmbBrojSati.Items.Add("6");
            cmbBrojSati.Items.Add("18");

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            pnlMain.BackColor = Color.FromArgb(80, 0, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        public new static dlgAccountLock ShowDialog()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new dlgAccountLock();
            }

            ((Form)_instance).ShowDialog();
            _instance.BringToFront();

            return _instance;
        }

        private void dlgAccountLock_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            CenterToParent();
            BringToFront();
        }

        private void dlgAccountLock_Shown(object sender, EventArgs e)
        {
            dlgPrompt.PointToScreen(new Point(Width / 2, Height / 2));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnLockOk_Click(object sender, EventArgs e)
        {
            if (cmbBrojSati.SelectedIndex == -1)
            {
                DialogResult = DialogResult.No;
                return;
            }

            DialogResult = DialogResult.OK;
            NumberOfHours = int.Parse(cmbBrojSati.SelectedItem.ToString());
        }

        private void pnlMain_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
            Dispose();
        }
    }
}