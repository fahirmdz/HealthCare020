using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    public partial class frmDrzave : DisplayDataForm<DrzavaDto>
    {
        public Control ParentControl { get; set; }
        private static frmDrzave _instance;

        public static frmDrzave Intance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmDrzave();

                return _instance;
            }
        }

        public frmDrzave() : base()
        {
            var ID = new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "ID", CellTemplate = new DataGridViewTextBoxCell() };
            ID.CellTemplate = new DataGridViewTextBoxCell();

            var Naziv = new DataGridViewColumn { DataPropertyName = "Naziv", HeaderText = "Naziv", Name = "Naziv", CellTemplate = new DataGridViewTextBoxCell() };

            var PozivniBroj = new DataGridViewColumn
            {
                DataPropertyName = "PozivniBroj",
                HeaderText = "Pozivni broj",
                Name = "PozivniBroj",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Brisi = new DataGridViewButtonColumn
            {
                HeaderText = "Brisanje",
                Name = "Izbriši",
                Text = "Izbriši",
                ToolTipText = "Izbriši državu",
                UseColumnTextForButtonValue = true,
                CellTemplate = new DataGridViewButtonCell(),
                DefaultCellStyle = new DataGridViewCellStyle{BackColor = Color.Transparent,SelectionBackColor = Color.Transparent}
            };

            base.DgrvColumnsStyle();

            base.AddColumnsToMainDgrv(new[] { ID, Naziv, PozivniBroj, Brisi });

            _apiService = new APIService(Routes.DrzaveRoute);
            Text = Properties.Resources.frmDrzave;
            ResourceParameters = new DrzavaResourceParameters { PageNumber = 1, PageSize = CurrentRowCount };

            InitializeComponent();
        }

        private async void frmDrzave_Load(object sender, EventArgs e)
        {
            DisplayDataForm_Load(sender, e);
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);

            var drzavaResParams = ResourceParameters as DrzavaResourceParameters;

            bool isPozivni = SearchText.Any(char.IsDigit),ShouldLoad = (isPozivni && SearchText!=drzavaResParams.PozivniBroj) || (!isPozivni && SearchText!=drzavaResParams.Naziv);

            drzavaResParams.Naziv = isPozivni ? string.Empty : SearchText.Trim();
            drzavaResParams.PozivniBroj = isPozivni ? SearchText.Trim() : string.Empty;

            if (ShouldLoad)
                await base.LoadData();
        }
    }
}