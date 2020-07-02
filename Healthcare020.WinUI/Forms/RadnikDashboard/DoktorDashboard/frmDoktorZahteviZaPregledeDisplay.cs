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
    public partial class frmDoktorZahteviZaPregledeDisplay : DisplayDataForm<ZahtevZaPregledDtoEL>
    {
        private static frmDoktorZahteviZaPregledeDisplay _instance = null;

        private frmDoktorZahteviZaPregledeDisplay()
        {
            var ID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(ZahtevZaPregledDtoEL.Id),
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
                DataPropertyName = nameof(ZahtevZaPregledDtoEL.DatumVreme),
                HeaderText = "Datum i vreme",
                Name = "Datum i vreme",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var IsObradjen = new DataGridViewColumn
            {
                DataPropertyName = nameof(ZahtevZaPregledDtoEL.IsObradjen),
                HeaderText = "Obrađen",
                Name = nameof(ZahtevZaPregledDtoEL.IsObradjen),
                CellTemplate = new DataGridViewTextBoxCell()
            };

            base.AddColumnsToMainDgrv(new[] { ID, Pacijent, IsObradjen, DatumVreme });

            _apiService = new APIService(Routes.ZahteviZaPregledRoute);
            ResourceParameters = new ZahtevZaPregledResourceParameters() { PageNumber = 1, PageSize = PossibleRowsCount, EagerLoaded = true };

            InitializeComponent();

            btnNew.Visible = false;
            btnBack.Visible = false;
        }

        public static frmDoktorZahteviZaPregledeDisplay Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmDoktorZahteviZaPregledeDisplay();
                return _instance;
            }
        }

        protected override void dgrvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgrvMain.CurrentRow?.DataBoundItem is ZahtevZaPregledDtoEL zahtevZaPregled))
                return;

            dlgForm.ShowDialog(frmZahtevZaPregled.InstanceWithData(zahtevZaPregled));
        }

        protected override void dgrvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];

            var pregled = row.DataBoundItem as ZahtevZaPregledDtoEL;

            if (pregled == null)
                return;

            if (dgrvMain.Columns[e.ColumnIndex].Name == "Pacijent")
            {
                e.Value = pregled.Pacijent.ZdravstvenaKnjizica.LicniPodaci.ImePrezime();
            }

            if (dgrvMain.Columns[e.ColumnIndex].Name == nameof(ZahtevZaPregledDtoEL.IsObradjen))
            {
                e.Value = pregled.IsObradjen ? "DA" : "NE";
            }
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);
            var zahteviZaPregledResParams = ResourceParameters as ZahtevZaPregledResourceParameters;
            if (zahteviZaPregledResParams == null)
                return;

            var ShouldLoad = SearchText != zahteviZaPregledResParams.PacijentIme;

            if (ShouldLoad)
            {
                zahteviZaPregledResParams.PacijentIme = SearchText;
                zahteviZaPregledResParams.PacijentPrezime = SearchText;
                await base.LoadData();
            }
        }
    }
}