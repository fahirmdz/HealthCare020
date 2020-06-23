using FontAwesome.Sharp;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;

namespace Healthcare020.WinUI.Forms.AdminDashboard.Statistics
{
    public partial class frmPreglediStatistic : StatisticChartForm
    {
        private static frmPreglediStatistic _instnace = null;

        public static frmPreglediStatistic Instance
        {
            get
            {
                if (_instnace == null || _instnace.IsDisposed)
                    _instnace = new frmPreglediStatistic();
                return _instnace;
            }
        }

        public frmPreglediStatistic()
        {
            lblChartTitle.Text = "Prikaz broja obavljenih pregleda po mesecima";
            NoDataMessage = "Nema obavljenih pregleda za odabrane mesece";
            YAxisTitle = "Broj obavljenih pregleda";
            NoDataPanel.IcnData.IconChar = IconChar.Stethoscope;
            Text = Properties.Resources.frmPreglediStatistic;
            _apiService = new APIService(Routes.PreglediRoute);
            InitializeComponent();
        }
    }
}