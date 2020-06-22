using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdminDashboard.Statistics
{
    public partial class frmZahteviZaPregledeStatistic : Form
    {
        private static frmZahteviZaPregledeStatistic _instance = null;
        private int MonthsCount;
        private APIService _apiService;

        private readonly List<string> Months;
        private List<int> ZahteviZaPregledCountsPoMesecima;

        public static frmZahteviZaPregledeStatistic Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmZahteviZaPregledeStatistic();

                return _instance;
            }
        }

        private frmZahteviZaPregledeStatistic()
        {
            InitializeComponent();
            Text = Properties.Resources.frmZahteviZaPregledStatistic;
            MonthsCount = 3;
            btnThreeMonths.Enabled = false;
            _apiService = new APIService(Routes.ZahteviZaPregledRoute);
            Months = new List<string> { "Januar", "Februar", "Mart", "April", "Maj", "Jun", "Jul", "Avgust", "Septembar", "Oktobar", "Novembar", "Decembar" };
        }

        private void ButtonActivatorAndMonthsCountChange(int MonthsCount)
        {
            var disabledForeColor = Color.FromArgb(227, 227, 227);
            var white = Color.FromArgb(255, 255, 255);

            switch (MonthsCount)
            {
                case 3:
                    MonthsCount = 3;
                    btnThreeMonths.Enabled = false;
                    btnThreeMonths.ForeColor = disabledForeColor;
                    btnSixMonths.Enabled = true;
                    btnSixMonths.ForeColor = white;
                    btnTwelveMonths.Enabled = true;
                    btnTwelveMonths.ForeColor = white;
                    break;

                case 6:
                    MonthsCount = 6;
                    btnSixMonths.Enabled = false;
                    btnSixMonths.ForeColor = disabledForeColor;
                    btnThreeMonths.Enabled = true;
                    btnThreeMonths.ForeColor = white;
                    btnTwelveMonths.Enabled = true;
                    btnTwelveMonths.ForeColor = white;
                    break;

                case 12:
                    MonthsCount = 12;
                    btnTwelveMonths.Enabled = false;
                    btnTwelveMonths.ForeColor = disabledForeColor;
                    btnThreeMonths.Enabled = true;
                    btnThreeMonths.ForeColor = white;
                    btnSixMonths.Enabled = true;
                    btnSixMonths.ForeColor = white;
                    break;
            }
        }

        private string GetMonthFromNumberToTakeAway(int monthsToTakeAway)
        {
            var monthIndex = DateTime.Now.Month - monthsToTakeAway;
            monthIndex = monthIndex < 1 ? 12+monthIndex : monthIndex;

            return Months[monthIndex-1];
        }

        private void UpdateChart(List<int> MonthlyData)
        {
            var series = new SeriesCollection();
            for (int i=0;i<MonthlyData.Count;i++)
            {
                series.Add(new PieSeries
                {
                    Title=GetMonthFromNumberToTakeAway(i+1),
                    Values = new ChartValues<int>{MonthlyData[i]},
                    DataLabels = true
                });
            }
            chartZahteviZaPreglede.Series.Clear();
            chartZahteviZaPreglede.Series = series;
        }

        private async void frmZahteviZaPregledeStatistic_Load(object sender, EventArgs e)
        {
            ZahteviZaPregledCountsPoMesecima = (await _apiService.Count(3))?.Data ?? new List<int> { 0, 0, 0 };
           
            UpdateChart(ZahteviZaPregledCountsPoMesecima);
            chartZahteviZaPreglede.LegendLocation = LegendLocation.Bottom;
        }

        private async void btnThreeMonths_Click(object sender, EventArgs e)
        {
            ButtonActivatorAndMonthsCountChange(3);
            UpdateChart((await _apiService.Count(3))?.Data ?? new List<int> {0, 0, 0});
        }

        private async void btnSixMonths_Click(object sender, EventArgs e)
        {
            ButtonActivatorAndMonthsCountChange(6);
            UpdateChart((await _apiService.Count(6))?.Data ?? new List<int> {0, 0, 0});
        }

        private async void btnTwelveMonths_Click(object sender, EventArgs e)
        {
            ButtonActivatorAndMonthsCountChange(12);
            ZahteviZaPregledCountsPoMesecima = (await _apiService.Count(12))?.Data ?? new List<int> {0, 0, 0};
            UpdateChart(ZahteviZaPregledCountsPoMesecima);
        }
    }
}