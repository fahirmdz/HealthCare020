using Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    public partial class frmPredefinedDataMenu : Form
    {
        private static frmPredefinedDataMenu _instance;
        private APIService _apiService;

        private frmPredefinedDataMenu()
        {
            InitializeComponent();
            _apiService = new APIService(Routes.DrzaveRoute);
            lblDrzaveCounter.Text = DrzavaCount.ToString();
            lblGradoviCounter.Text = GradoviCount.ToString();
            lblRolesCounter.Text = RolesCount.ToString();
            lblZdravstvenaStanjaCounter.Text = ZdravstvenaStanjaCount.ToString();
            lblNaucneOblastiCounter.Text = NaucneOblastiCount.ToString();

            Text = Properties.Resources.frmPredefinedData;
        }

        public static frmPredefinedDataMenu Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmPredefinedDataMenu();

                return _instance;
            }
        }

        

        //PREDEFINED DATA COUNTS
        public int DrzavaCount { get; set; }
        public int GradoviCount { get; set; }
        public int NaucneOblastiCount { get; set; }
        public int RolesCount { get; set; }
        public int ZdravstvenaStanjaCount { get; set; }

        public async Task LoadPredefinedDataCount(string route)
        {
            switch (route)
            {
                case Routes.DrzaveRoute:
                    _apiService = new APIService(Routes.DrzaveRoute);
                    DrzavaCount = (await _apiService.Count())?.Data.First() ?? 0;
                    lblDrzaveCounter.Text = DrzavaCount.ToString();
                    break;

                case Routes.GradoviRoute:
                    _apiService.ChangeRoute(Routes.GradoviRoute);
                    GradoviCount = (await _apiService.Count())?.Data.First() ?? 0;
                    lblGradoviCounter.Text = GradoviCount.ToString();
                    break;

                case Routes.ZdravstvenaStanjaRoute:
                    _apiService.ChangeRoute(Routes.ZdravstvenaStanjaRoute);
                    ZdravstvenaStanjaCount = (await _apiService.Count())?.Data.First() ?? 0;
                    lblZdravstvenaStanjaCounter.Text = ZdravstvenaStanjaCount.ToString();
                    break;

                case Routes.NaucneOblastiRoute:
                    _apiService.ChangeRoute(Routes.NaucneOblastiRoute);
                    NaucneOblastiCount = (await _apiService.Count())?.Data.First() ?? 0;
                    lblNaucneOblastiCounter.Text = NaucneOblastiCount.ToString();
                
                    break;

                case Routes.RolesRoute:
                    _apiService.ChangeRoute(Routes.RolesRoute);
                    RolesCount = (await _apiService.Count())?.Data.First() ?? 0;
                    lblRolesCounter.Text = RolesCount.ToString();
                    break;

                default:
                    return;
            }
        }

        private async Task LoadPredefinedDataCounts()
        {
            _apiService = new APIService(Routes.DrzaveRoute);
            DrzavaCount = (await _apiService.Count())?.Data.First() ?? 0;
            _apiService.ChangeRoute(Routes.GradoviRoute);
            GradoviCount = (await _apiService.Count())?.Data.First() ?? 0;
            _apiService.ChangeRoute(Routes.ZdravstvenaStanjaRoute);
            ZdravstvenaStanjaCount = (await _apiService.Count())?.Data.First() ?? 0;
            _apiService.ChangeRoute(Routes.NaucneOblastiRoute);
            NaucneOblastiCount = (await _apiService.Count())?.Data.First() ?? 0;
            _apiService.ChangeRoute(Routes.RolesRoute);
            RolesCount = (await _apiService.Count())?.Data.First() ?? 0;
        }

        private void btnDrzave_Click(object sender, EventArgs e)
        {
            frmDrzave.Instance.OpenAsChildOfControl(Parent);
        }

        private void btnGradovi_Click(object sender, EventArgs e)
        {
            frmGradovi.Instance.OpenAsChildOfControl(Parent);
        }

        private void btnNaucneOblasti_Click(object sender, EventArgs e)
        {
            frmNaucneOblasti.Instance.OpenAsChildOfControl(Parent);
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            frmRoles.Instance.OpenAsChildOfControl(Parent);
        }

        private void btnZdravstvenaStanja_Click(object sender, EventArgs e)
        {
            frmZdravstvenaStanja.Instance.OpenAsChildOfControl(Parent);
        }

        private async void frmPredefinedDataMenu_Load(object sender, EventArgs e)
        {
            await LoadPredefinedDataCounts();
            lblDrzaveCounter.Text = DrzavaCount.ToString();
            lblGradoviCounter.Text = GradoviCount.ToString();
            lblNaucneOblastiCounter.Text = NaucneOblastiCount.ToString();
            lblRolesCounter.Text = RolesCount.ToString();
            lblZdravstvenaStanjaCounter.Text = ZdravstvenaStanjaCount.ToString();
        }
    }
}