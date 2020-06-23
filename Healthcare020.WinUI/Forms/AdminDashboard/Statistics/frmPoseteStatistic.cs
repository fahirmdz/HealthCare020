using FontAwesome.Sharp;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using Healthcare020.WinUI.Properties;

namespace Healthcare020.WinUI.Forms.AdminDashboard.Statistics
{
    public partial class frmPoseteStatistic : StatisticChartForm
    {
        private static frmPoseteStatistic _instnace = null;

        public static frmPoseteStatistic Instance
        {
            get
            {
                if (_instnace == null || _instnace.IsDisposed)
                    _instnace = new frmPoseteStatistic();
                return _instnace;
            }
        }

        public frmPoseteStatistic()
        {
            lblChartTitle.Text = Properties.Resources.TitlePoseteStatistic;
            NoDataMessage = Properties.Resources.NoDataPoseteStatisticMessage;
            YAxisTitle = Properties.Resources.StatisticCountYAxisTitle;
            IcnCharForNoData = IconChar.Eye;
            Text = Properties.Resources.frmPoseteStatistic;
            _apiService = new APIService(Routes.ZahtevZaPosetuRoute);
            InitializeComponent();
        }
    }
}