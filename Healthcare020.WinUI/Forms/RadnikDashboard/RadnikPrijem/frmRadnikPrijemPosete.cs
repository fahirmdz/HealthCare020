using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.RadnikPrijem
{
    public sealed partial class frmRadnikPrijemPosete : DisplayDataForm<ZahtevZaPosetuDtoEL>
    {
        private static frmRadnikPrijemPosete _instance;

        public static frmRadnikPrijemPosete InstanceWithData(bool NeobradjeniZahteviOnly = false, bool ObradjeniZahteviOnly = false) //if false then Kreirane
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmRadnikPrijemPosete(NeobradjeniZahteviOnly, ObradjeniZahteviOnly);
            return _instance;
        }

        private frmRadnikPrijemPosete(bool NeobradjeniZahteviOnly = false, bool ObradjeniZahteviOnly = false)
        {
            if (NeobradjeniZahteviOnly)
                Text = Resources.frmRadnikPrijemPoseteNeobradjeniZahtevi;
            else if (ObradjeniZahteviOnly)
                Text = Resources.frmRadnikPrijemPoseteObradjeniZahteviOnly;
            else
                Text = Resources.frmRadnikPrijemPoseteSviZahtevi;

            var ID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(ZahtevZaPosetuDtoEL.Id),
                HeaderText = "ID",
                Name = "ID",
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 5
            };

            var Pacijent = new DataGridViewColumn
            {
                HeaderText = "Pacijent",
                Name = "Pacijent",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var ZakazanoDatumVreme = new DataGridViewColumn
            {
                DataPropertyName = nameof(ZahtevZaPosetuDtoEL.ZakazanoDatumVreme),
                HeaderText = "Zakazano vreme posete",
                Name = nameof(ZahtevZaPosetuDtoEL.ZakazanoDatumVreme),
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var brojTelefona = new DataGridViewColumn
            {
                DataPropertyName = nameof(ZahtevZaPosetuDtoEL.BrojTelefonaPosetioca),
                HeaderText = "Broj telefona posetioca",
                Name = nameof(ZahtevZaPosetuDtoEL.BrojTelefonaPosetioca),
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var columnsToAdd = new List<DataGridViewColumn> { ID, Pacijent, brojTelefona };

            if (!NeobradjeniZahteviOnly)
                columnsToAdd.Add(ZakazanoDatumVreme);

            AddColumnsToMainDgrv(columnsToAdd.ToArray());

            _apiService = new APIService(Routes.ZahtevZaPosetuRoute);
            ResourceParameters = new ZahtevZaPosetuResourceParameters()
            {
                PageNumber = 1,
                PageSize = PossibleRowsCount,
                EagerLoaded = true,
                NeobradjeneOnly = NeobradjeniZahteviOnly,
                ObradjeneOnly = ObradjeniZahteviOnly
            };

            InitializeComponent();
            btnNew.Visible = false;
            btnBack.Visible = false;
        }

        protected override void dgrvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];

            if (!(row.DataBoundItem is ZahtevZaPosetuDtoEL zahtevZaPosetu))
                return;

            if (dgrvMain.Columns[e.ColumnIndex].Name == "Pacijent")
                e.Value = zahtevZaPosetu.PacijentNaLecenju.ImePrezime;

            if (dgrvMain.Columns[e.ColumnIndex].Name == nameof(ZahtevZaPosetuDtoEL.ZakazanoDatumVreme))
                e.Value = zahtevZaPosetu.ZakazanoDatumVreme.HasValue ? zahtevZaPosetu.ZakazanoDatumVreme.Value.ToString("g") : "ODBIJEN";
        }

        protected override void dgrvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgrvMain.CurrentRow?.DataBoundItem is ZahtevZaPosetuDtoEL zahtevZaPosetu))
                return;
            dlgForm.ShowDialog(frmPosetaOverview.InstanceWithData(zahtevZaPosetu, newInstance: true),
                NewInstance: true);
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);

            if (!(ResourceParameters is ZahtevZaPosetuResourceParameters zahtevZaPosetuiResParams))
                return;

            var ShouldLoad = SearchText != zahtevZaPosetuiResParams.PacijentIme;

            if (ShouldLoad)
            {
                zahtevZaPosetuiResParams.PacijentIme = SearchText;
                zahtevZaPosetuiResParams.PacijentPrezime = SearchText;
                await LoadData();
            }
        }
    }
}