using Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using System;
using System.Windows.Forms;
using Healthcare020.WinUI.Helpers;

namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    public partial class frmPredefinedDataMenu : Form
    {
        public Control ParentControl { get; set; }
        private APIService _apiService;

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

        private frmPredefinedDataMenu()
        {
            InitializeComponent();
            _apiService = new APIService(Routes.DrzaveRoute);
            lblDrzaveCounter.Text = frmStartMenuAdmin.Instance.DrzavaCount.ToString();
            lblGradoviCounter.Text = frmStartMenuAdmin.Instance.GradoviCount.ToString();
            lblRolesCounter.Text = frmStartMenuAdmin.Instance.RolesCount.ToString();
            lblZdravstvenaStanjaCounter.Text = frmStartMenuAdmin.Instance.ZdravstvenaStanjaCount.ToString();
            lblNaucneOblastiCounter.Text = frmStartMenuAdmin.Instance.NaucneOblastiCount.ToString();

            Text = Properties.Resources.frmPredefinedData;
        }

        private void frmPredefinedDataMenu_Load(object sender, EventArgs e)
        {
            frmStartMenuAdmin.Instance.SetClickEventToCloseUserMenu(Controls);
            frmStartMenuAdmin.Instance.SetClickEventToCloseUserMenu(pnlMain.Controls);
        }

        private void btnDrzave_Click(object sender, EventArgs e)
        {
            frmDrzave.Instance.OpenAsChildOfControl(Parent);
        }

        private void btnZdravstvenaStanja_Click(object sender, EventArgs e)
        {
            frmZdravstvenaStanja.Instance.OpenAsChildOfControl(Parent);
        }

        private void btnGradovi_Click(object sender, EventArgs e)
        {
            frmGradovi.Instance.OpenAsChildOfControl(Parent);
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            frmRoles.Instance.OpenAsChildOfControl(Parent);
        }

        private void btnNaucneOblasti_Click(object sender, EventArgs e)
        {
            frmNaucneOblasti.Instance.OpenAsChildOfControl(Parent);
        }
    }
}