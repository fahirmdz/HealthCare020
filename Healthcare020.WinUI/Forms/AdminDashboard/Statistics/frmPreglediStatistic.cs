using FontAwesome.Sharp;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Properties;

namespace Healthcare020.WinUI.Forms.AdministratorDashboard.Statistics
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
            lblChartTitle.Text = Resources.TitlePreglediStatistic;
            NoDataMessage = Resources.NoDataPreglediObavljeniStatisticMessage;
            YAxisTitle = "Broj obavljenih pregleda";
            IcnCharForNoData = IconChar.Stethoscope;
            Text = Properties.Resources.frmPreglediStatistic;
            _apiService = new APIService(Routes.PreglediRoute);
            InitializeComponent();
        }
    }
}