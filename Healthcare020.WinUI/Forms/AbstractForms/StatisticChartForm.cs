using FontAwesome.Sharp;
using Healthcare020.WinUI.Helpers.CustomElements;
using Healthcare020.WinUI.Services;
using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare020.WinUI.Properties;
using Brushes = System.Windows.Media.Brushes;

namespace Healthcare020.WinUI.Forms.AbstractForms
{
    public enum ChartType
    {
        Line,
        Pie
    };

    public partial class StatisticChartForm : Form
    {
        protected int MonthsCount;
        protected APIService _apiService;

        protected ChartType ChartType;
        protected string YAxisTitle;
        protected readonly List<string> Months;
        protected List<int> MonthlyCounts;
        protected string NoDataMessage;

        protected NoDataPanel NoDataPanel;
        protected IconChar IcnCharForNoData;

        public StatisticChartForm()
        {
            InitializeComponent();
            btnThreeMonths.Enabled = false;
            Text = Resources.frmZahteviZaPregledStatistic;
            MonthsCount = 3;
            Months = new List<string> { "Januar", "Februar", "Mart", "April", "Maj", "Jun", "Jul", "Avgust", "Septembar", "Oktobar", "Novembar", "Decembar" };

            ChartType = ChartType.Pie;
            chartLine.AxisX.Add(new Axis { Title = "Mesec" });
            chartPieMain.AxisX.Add(new Axis { Title = "Mesec" });
            chartLine.AxisX.Add(new Axis { Title = YAxisTitle });
            chartPieMain.AxisX.Add(new Axis { Title = YAxisTitle });
            chartLine.Hide();
        }

        protected async Task ChangeChartType()
        {
            if (ChartType == ChartType.Pie)
            {
                ChartType = ChartType.Line;
                btnChartTypeChange.IconChar = IconChar.ChartPie;
                btnChartTypeChange.Text = Resources.PieChart;
            }
            else
            {
                ChartType = ChartType.Pie;
                btnChartTypeChange.IconChar = IconChar.ChartLine;
                btnChartTypeChange.Text = Resources.LineChart;
            }

            UpdateChart((await _apiService.Count(MonthsCount))?.Data ?? new List<int> { 0, 0, 0 });
        }

        protected void ButtonActivatorAndMonthsCountChange(int monthsCount)
        {
            var disabledForeColor = Color.FromArgb(227, 227, 227);
            var white = Color.FromArgb(255, 255, 255);

            switch (monthsCount)
            {
                case 3:
                    MonthsCount = monthsCount;
                    btnThreeMonths.Enabled = false;
                    btnThreeMonths.ForeColor = disabledForeColor;
                    btnSixMonths.Enabled = true;
                    btnSixMonths.ForeColor = white;
                    btnTwelveMonths.Enabled = true;
                    btnTwelveMonths.ForeColor = white;
                    break;

                case 6:
                    MonthsCount = monthsCount;
                    btnSixMonths.Enabled = false;
                    btnSixMonths.ForeColor = disabledForeColor;
                    btnThreeMonths.Enabled = true;
                    btnThreeMonths.ForeColor = white;
                    btnTwelveMonths.Enabled = true;
                    btnTwelveMonths.ForeColor = white;
                    break;

                case 12:
                    MonthsCount = monthsCount;
                    btnTwelveMonths.Enabled = false;
                    btnTwelveMonths.ForeColor = disabledForeColor;
                    btnThreeMonths.Enabled = true;
                    btnThreeMonths.ForeColor = white;
                    btnSixMonths.Enabled = true;
                    btnSixMonths.ForeColor = white;
                    break;
            }
        }

        protected (string Month, int Year) GetMonthFromNumberToTakeAway(int monthsToTakeAway)
        {
            var monthIndex = DateTime.Now.Month - monthsToTakeAway;
            var year = DateTime.Now.Year;
            if (monthIndex < 1)
            {
                monthIndex += 12;
                year--;
            }

            return (Months[monthIndex - 1], year);
        }

        protected void UpdateChart(List<int> MonthlyData)
        {
            if (MonthlyData.All(x => x == 0))
            {
                pnlMain.Hide();
                NoDataPanel.Show();
                return;
            }

            NoDataPanel.Hide();
            pnlMain.Show();

            var series = new SeriesCollection();
            var months = new List<string>();

            for (int i = 0; i < MonthlyData.Count; i++)
            {
                var monthYear = GetMonthFromNumberToTakeAway(MonthlyData.Count - i);
                if (ChartType == ChartType.Line)
                    months.Add($"{monthYear.Month} - {monthYear.Year}");

                if (ChartType == ChartType.Pie)
                {
                    ISeriesView serie = new PieSeries
                    {
                        Title = $"{monthYear.Month} - {monthYear.Year}",
                        Values = new ChartValues<int> { MonthlyData[i] },
                        DataLabels = true
                    };

                    series.Add(serie);
                }
            }

            if (ChartType == ChartType.Pie)
            {
                chartPieMain.Series.Clear();
                chartPieMain.Series = series;
                chartPieMain.Show();
                chartLine.Hide();
            }
            else
            {
                series.Add(new LineSeries
                {
                    Title = YAxisTitle,
                    Values = MonthlyData.AsChartValues(),
                    DataLabels = true,
                    Stroke = Brushes.MediumPurple
                });
                chartLine.AxisX.First().Labels = months;
                chartLine.Show();
                chartPieMain.Hide();
                chartLine.Series.Clear();
                chartLine.Series = series;
            }
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
            NoDataPanel = new NoDataPanel(NoDataMessage)
            {
                IcnData =
                {
                    IconChar = IcnCharForNoData
                }
            };
            NoDataPanel.Left = (pnlMain.ClientSize.Width - NoDataPanel.Width) / 2;
            NoDataPanel.Top = pnlMain.ClientSize.Height / 2 - 60;
            Controls.Add(NoDataPanel);
            NoDataPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            NoDataPanel.Hide();

            MonthlyCounts = (await _apiService.Count(3))?.Data ?? new List<int> { 0, 0, 0 };

            UpdateChart(MonthlyCounts);
            chartPieMain.LegendLocation = LegendLocation.Bottom;
            chartLine.LegendLocation = LegendLocation.Bottom;
        }

        protected async void btnChartTypeChange_Click(object sender, EventArgs e)
        {
            await ChangeChartType();
        }
    }
}