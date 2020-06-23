using Healthcare020.WinUI.Services;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms
{
    public partial class StatisticChartForm : Form
    {
        protected int MonthsCount;
        protected APIService _apiService;

        protected readonly List<string> Months;
        protected List<int> MonthlyCounts;

        protected StatisticChartForm()
        {
            InitializeComponent();
            btnThreeMonths.Enabled = false;
            Text = Properties.Resources.frmZahteviZaPregledStatistic;
            MonthsCount = 3;
            Months = new List<string> { "Januar", "Februar", "Mart", "April", "Maj", "Jun", "Jul", "Avgust", "Septembar", "Oktobar", "Novembar", "Decembar" };

        }

        protected void ButtonActivatorAndMonthsCountChange(int MonthsCount)
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

        protected string GetMonthFromNumberToTakeAway(int monthsToTakeAway)
        {
            var monthIndex = DateTime.Now.Month - monthsToTakeAway;
            monthIndex = monthIndex < 1 ? 12 + monthIndex : monthIndex;

            return Months[monthIndex - 1];
        }

        protected void UpdateChart(List<int> MonthlyData)
        {
            var series = new SeriesCollection();
            for (int i = 0; i < MonthlyData.Count; i++)
            {
                series.Add(new PieSeries
                {
                    Title = GetMonthFromNumberToTakeAway(i + 1),
                    Values = new ChartValues<int> { MonthlyData[i] },
                    DataLabels = true
                });
            }
            chartPieMain.Series.Clear();
            chartPieMain.Series = series;
        }

        protected async void btnThreeMonths_Click(object sender, EventArgs e)
        {
            ButtonActivatorAndMonthsCountChange(3);
            UpdateChart((await _apiService.Count(3))?.Data ?? new List<int> { 0, 0, 0 });
        }

        protected async void btnSixMonths_Click(object sender, EventArgs e)
        {
            ButtonActivatorAndMonthsCountChange(6);
            UpdateChart((await _apiService.Count(6))?.Data ?? new List<int> { 0, 0, 0 });
        }

        protected async void btnTwelveMonths_Click(object sender, EventArgs e)
        {
            ButtonActivatorAndMonthsCountChange(12);
            MonthlyCounts = (await _apiService.Count(12))?.Data ?? new List<int> { 0, 0, 0 };
            UpdateChart(MonthlyCounts);
        }

        protected async void StatisticChartForm_Load(object sender, EventArgs e)
        {
            MonthlyCounts = (await _apiService.Count(3))?.Data ?? new List<int> { 0, 0, 0 };

            UpdateChart(MonthlyCounts);
            chartPieMain.LegendLocation = LegendLocation.Bottom;
        }
    }
}