using System;
using System.Windows.Forms;
using Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData;

namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    public partial class frmPredefinedDataMenu : Form
    {
        public Control ParentControl { get;set; }

        private static frmPredefinedDataMenu _instance;

        public static frmPredefinedDataMenu Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmPredefinedDataMenu();

                return _instance;
            }
        }

        public frmPredefinedDataMenu()
        {
            InitializeComponent();
            Text = Properties.Resources.frmPredefinedData;
        }

        private void frmPredefinedDataMenu_Load(object sender, EventArgs e)
        {
            frmStartMenuAdmin.Instance.SetClickEventToCloseUserMenu(Controls);
            frmStartMenuAdmin.Instance.SetClickEventToCloseUserMenu(pnlMain.Controls);
        }

        private void btnDrzave_Click(object sender, EventArgs e)
        {
            frmStartMenuAdmin.Instance.OpenChildForm(frmDrzave.Intance);
        }
    }
}