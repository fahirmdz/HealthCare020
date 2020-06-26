using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard
{
    public partial class frmMainDashboard : Form
    {
        private static frmMainDashboard _instance = null;

        public static frmMainDashboard Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmMainDashboard();
                return _instance;
            }
        }

        private frmMainDashboard()
        {
            InitializeComponent();
        }

        private void btnUserMenu_Click(object sender, System.EventArgs e)
        {
            if (pnlUserMenuDropdown.Visible)
                pnlUserMenuDropdown.Hide();
            else
                pnlUserMenuDropdown.Show();
        }

        public void ShowInMainPanel(Form form)
        {
            if (form == null)
                return;

            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            pnlMain.Controls.Add(form);
            form.Show();
        }
    }
}