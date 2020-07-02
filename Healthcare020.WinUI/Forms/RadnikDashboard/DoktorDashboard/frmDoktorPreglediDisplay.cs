using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using System;
using System.Windows.Forms;
using PregledResourceParameters = HealthCare020.Core.ResourceParameters.PregledResourceParameters;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmDoktorPreglediDisplay : DisplayDataForm<PregledDtoEL>
    {
        private static frmDoktorPreglediDisplay _instance = null;
        private int OpenedPregledId;
        private bool OnlyZakazani;

        public static frmDoktorPreglediDisplay InstanceWithData(bool OnlyZakazani = false)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmDoktorPreglediDisplay(OnlyZakazani);
            return _instance;
        }

        private frmDoktorPreglediDisplay(bool OnlyZakazani = false)
        {
            this.OnlyZakazani = OnlyZakazani;
            this.Text = OnlyZakazani ? Resources.frmDoktorZakazaniPregledi : Resources.frmDoktorPregledi;

            var ID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(PregledDtoEL.Id),
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
                DataPropertyName = nameof(PregledDtoEL.DatumPregleda),
                HeaderText = "Datum i vreme",
                Name = nameof(PregledDtoEL.DatumPregleda),
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var IsOdradjen = new DataGridViewColumn
            {
                DataPropertyName = nameof(PregledDtoEL.IsOdradjen),
                HeaderText = "Odrađen",
                Name = "Odrađen",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            base.AddColumnsToMainDgrv(new[] { ID, Pacijent, DatumVreme, IsOdradjen });

            _apiService = new APIService(Routes.PreglediRoute);
            ResourceParameters = new PregledResourceParameters() { PageNumber = 1, PageSize = PossibleRowsCount, EagerLoaded = true, OnlyZakazani = OnlyZakazani };

            InitializeComponent();
            btnNew.Visible = false;
            btnBack.Visible = false;
        }

        protected override void dgrvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];

            var pregled = row.DataBoundItem as PregledDtoEL;

            if (pregled == null)
                return;

            if (dgrvMain.Columns[e.ColumnIndex].Name == "Pacijent")
            {
                e.Value = pregled.Pacijent.ZdravstvenaKnjizica.LicniPodaci.ImePrezime();
            }

            if (dgrvMain.Columns[e.ColumnIndex].Name == "Odrađen")
            {
                e.Value = pregled.IsOdradjen ? "DA" : "NE";
            }

            if (dgrvMain.Columns[e.ColumnIndex].Name == nameof(PregledDtoEL.DatumPregleda))
                e.Value = pregled.DatumPregleda.ToString("g");
        }

        protected override void dgrvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgrvMain.CurrentRow?.DataBoundItem is PregledDtoEL pregled))
                return;

            //Proverava se da li je korisnik kliknuo na novi red i pritom zeli pokrenuti drugi pregled
            //Ukoliko je korisnik kliknuo na novi pregled, podaci koji su unijeti za prethodno pokrenuti pregled se brisu (dispose se frmNewLekarskoUverenje instanca)
            var newInstance = false;
            if (OpenedPregledId != pregled.Id)
            {
                OpenedPregledId = pregled.Id;
                newInstance = true;
            }
            if (!pregled.IsOdradjen)
                dlgForm.ShowDialog(frmNewLekarskoUverenje.InstanceWithData(pregled,newInstance), DialogFormSize.Large,newInstance);
            else
                dlgForm.ShowDialog(frmPregledOverview.InstanceWithData(pregled,newInstance),NewInstance:newInstance);
        }

        private void frmDoktorPreglediDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);

            var preglediResParams = ResourceParameters as PregledResourceParameters;
            if (preglediResParams == null)
                return;

            var ShouldLoad = SearchText != preglediResParams.PacijentIme;

            if (ShouldLoad)
            {
                preglediResParams.PacijentIme = SearchText;
                preglediResParams.PacijentPrezime = SearchText;
                await base.LoadData();
            }
        }
    }
}