using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using System;
using FontAwesome.Sharp;

namespace Healthcare020.WinUI.Forms.AdminDashboard.Statistics
{
    public partial class frmZahteviZaPregledStatistic : StatisticChartForm
    {
        private static frmZahteviZaPregledStatistic _instnace = null;

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
            lblChartTitle.Text = "Broj kreiranih zahteva za pregled po mesecima";
            YAxisTitle = "Broj zahteva za pregled";
            NoDataPanel.IcnData.IconChar = IconChar.CalendarAlt;
            Text = Properties.Resources.frmZahteviZaPregledStatistic;
            InitializeComponent();
        }

        private void frmZahteviZaPregledStatistic_Load(object sender, EventArgs e)
        {
            base.StatisticChartForm_Load(sender, e);
        }
    }
}