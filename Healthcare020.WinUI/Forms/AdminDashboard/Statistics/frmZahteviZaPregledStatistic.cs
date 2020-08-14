using System;
using FontAwesome.Sharp;
using HealthCare020.Core.Constants;
using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.AdminDashboard.Statistics
{
    public sealed partial class frmZahteviZaPregledStatistic : StatisticChartForm
    {
        private static frmZahteviZaPregledStatistic _instnace;

        public static frmZahteviZaPregledStatistic Instance
        {
            get
            {
                if (_instnace == null || _instnace.IsDisposed)
                    _instnace = new frmZahteviZaPregledStatistic();
                return _instnace;
            }
        }

        private frmZahteviZaPregledStatistic()
        {
            _apiService = new APIService(Routes.ZahteviZaPregledRoute);
            lblChartTitle.Text = Resources.TitleZahteviZaPregledeStatistic;
            YAxisTitle = "Broj zahteva za pregled";
            IcnCharForNoData = IconChar.CalendarAlt;
            NoDataMessage = Resources.NoDataZahteviZaPregledStatisticMessage;
            Text = Resources.frmZahteviZaPregledStatistic;
            InitializeComponent();
        }

        private void frmZahteviZaPregledStatistic_Load(object sender, EventArgs e)
        {
            StatisticChartForm_Load(sender, e);
        }
    }
}