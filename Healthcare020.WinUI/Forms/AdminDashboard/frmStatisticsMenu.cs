﻿using System.Linq;
using System.Net;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare020.WinUI.Forms.AdminDashboard.Statistics;
using Healthcare020.WinUI.Helpers;

namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    public partial class frmStatisticsMenu : Form
    {
        private static frmStatisticsMenu _instance = null;
        private readonly APIService _apiService;

        private int PreglediCounter;
        private int ZakazivanjaPregledaCounter;
        private int PoseteCounter;

        public static frmStatisticsMenu Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmStatisticsMenu();

                return _instance;
            }
        }

        private frmStatisticsMenu()
        {
            InitializeComponent();
            Text = Properties.Resources.frmStatisticsMenu;
            _apiService = new APIService();
        }

        private async Task LoadCounts()
        {
            _apiService.ChangeRoute(Routes.PreglediRoute);
            var result = await _apiService.Count();
            if (!result.Succeeded && result.StatusCode == HttpStatusCode.Forbidden)
            {
                Close();
                Dispose();
                return;
            }
            PreglediCounter = result.Data.First();
            _apiService.ChangeRoute(Routes.ZahteviZaPregledRoute);
            ZakazivanjaPregledaCounter = (await _apiService.Count())?.Data.First()  ?? 0;
            _apiService.ChangeRoute(Routes.ZahtevZaPosetuRoute);
            PoseteCounter = (await _apiService.Count())?.Data.First()  ?? 0;
        }

        private async void btnRefresh_Click(object sender, System.EventArgs e)
        {
            await LoadCounts();
        }

        private async void frmStatisticsMenu_Load(object sender, System.EventArgs e)
        {
            await LoadCounts();
            lblPreglediCounter.Text = PreglediCounter.ToString();
            lblPoseteCounter.Text = PoseteCounter.ToString();
            lblZakazivanjaPregledaCounter.Text = ZakazivanjaPregledaCounter.ToString();
        }

        private void btnZakazivanjeStatistic_Click(object sender, System.EventArgs e)
        {
            frmStartMenuAdmin.Instance.OpenChildForm(frmZahteviZaPregledStatistic.Instance);
        }

        private void btnPreglediStatistic_Click(object sender, System.EventArgs e)
        {
            frmStartMenuAdmin.Instance.OpenChildForm(frmPreglediStatistic.Instance);
        }

        private void btnPoseteStatistic_Click(object sender, System.EventArgs e)
        {
            frmStartMenuAdmin.Instance.OpenChildForm(frmPoseteStatistic.Instance);
        }
    }
}