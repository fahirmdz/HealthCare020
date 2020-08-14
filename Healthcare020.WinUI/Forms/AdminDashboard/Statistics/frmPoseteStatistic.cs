using FontAwesome.Sharp;
using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;

namespace Healthcare020.WinUI.Forms.AdminDashboard.Statistics
{
    public sealed partial class frmPoseteStatistic : StatisticChartForm
    {
        private static frmPoseteStatistic _instnace;

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
            lblChartTitle.Text = Resources.TitlePoseteStatistic;
            NoDataMessage = Resources.NoDataPoseteStatisticMessage;
            YAxisTitle = Resources.StatisticCountYAxisTitle;
            IcnCharForNoData = IconChar.Eye;
            Text = Resources.frmPoseteStatistic;
            _apiService = new APIService(Routes.ZahtevZaPosetuRoute);
            InitializeComponent();
        }
    }
}