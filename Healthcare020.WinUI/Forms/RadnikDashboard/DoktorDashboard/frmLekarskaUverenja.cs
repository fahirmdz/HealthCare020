using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmLekarskaUverenja : DisplayDataForm<LekarskoUverenjeDtoEL>
    {
        private static frmLekarskaUverenja _instance = null;

        public static frmLekarskaUverenja Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmLekarskaUverenja();
                return _instance;
            }
        }

        private frmLekarskaUverenja()
        {
            var ID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(LekarskoUverenjeDtoEL.Id),
                HeaderText = "ID",
                Name = "ID",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Pacijent = new DataGridViewColumn
            {
                HeaderText = "Pacijent",
                Name = "Pacijent",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var DatumVreme = new DataGridViewColumn
            {
                HeaderText = "Datum i vreme pregleda",
                Name = nameof(LekarskoUverenjeDtoEL.Pregled.DatumPregleda),
                CellTemplate = new DataGridViewTextBoxCell(),
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            var ZdravstvenoStanje = new DataGridViewColumn
            {
                HeaderText = "Zdravstveno stanje pacijenta",
                Name = nameof(LekarskoUverenjeDtoEL.ZdravstvenoStanje.Opis),
                CellTemplate = new DataGridViewTextBoxCell()
            };

            base.AddColumnsToMainDgrv(new[] { ID, Pacijent, DatumVreme, ZdravstvenoStanje });

            _apiService = new APIService(Routes.LekarskoUverenjeRoute);
            ResourceParameters = new LekarskoUverenjeResourceParameters() { PageNumber = 1, PageSize = PossibleRowsCount, EagerLoaded = true };

            InitializeComponent();
            btnNew.Visible = false;
        }

        protected override void dgrvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgrvMain.CurrentRow?.DataBoundItem is LekarskoUverenjeDtoEL lekarskoUverenje))
                return;

            dlgForm.ShowDialog(frmNewLekarskoUverenje.InstanceWithData(lekarskoUverenje,true), DialogFormSize.Large,true);
        }

        protected override void dgrvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];

            if (!(row.DataBoundItem is LekarskoUverenjeDtoEL lekarskoUverenje))
                return;

            if (dgrvMain.Columns[e.ColumnIndex].Name == "Pacijent")
            {
                e.Value = lekarskoUverenje.Pregled.Pacijent.ZdravstvenaKnjizica.LicniPodaci.ImePrezime();
            }

            if (dgrvMain.Columns[e.ColumnIndex].Name == nameof(LekarskoUverenjeDtoEL.Pregled.DatumPregleda))
                e.Value = lekarskoUverenje.Pregled?.DatumPregleda.ToString("g") ?? "N/A";

            if (dgrvMain.Columns[e.ColumnIndex].Name == nameof(LekarskoUverenjeDtoEL.ZdravstvenoStanje.Opis))
                e.Value = lekarskoUverenje.ZdravstvenoStanje.Opis;
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);

            var lekarskoUverenjeResParams = ResourceParameters as LekarskoUverenjeResourceParameters;
            if (lekarskoUverenjeResParams == null)
                return;

            var ShouldLoad = SearchText != lekarskoUverenjeResParams.PacijentIme;

            if (ShouldLoad)
            {
                lekarskoUverenjeResParams.PacijentIme = SearchText;
                lekarskoUverenjeResParams.PacijentPrezime = SearchText;
                await base.LoadData();
            }
        }
    }
}