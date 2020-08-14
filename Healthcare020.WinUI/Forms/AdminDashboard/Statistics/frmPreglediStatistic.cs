using FontAwesome.Sharp;
using HealthCare020.Core.Constants;
using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.AdminDashboard.Statistics
{
    public sealed partial class frmPreglediStatistic : StatisticChartForm
    {
        private static frmPreglediStatistic _instnace;

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
            Text = Resources.frmPreglediStatistic;
            _apiService = new APIService(Routes.PreglediRoute);
            InitializeComponent();
        }
    }
}