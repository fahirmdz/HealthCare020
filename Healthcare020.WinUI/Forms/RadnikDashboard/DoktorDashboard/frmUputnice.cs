using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public sealed partial class frmUputnice : DisplayDataForm<UputnicaDtoEL>
    {
        private static frmUputnice _instance;

        public static frmUputnice InstanceWithData(bool NamenjenjeTrenutnoLogovanomKorisniku = false) //if false then Kreirane
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmUputnice(NamenjenjeTrenutnoLogovanomKorisniku);
            return _instance;
        }

        private frmUputnice(bool NamenjenjeTrenutnoLogovanomKorisniku = false)
        {
            Text = NamenjenjeTrenutnoLogovanomKorisniku ? Resources.frmUpuceneUputnice : Resources.frmKreiraneUputnice;

            var ID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(UputnicaDtoEL.Id),
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

            var upucenKodDoktora = new DataGridViewColumn
            {
                DataPropertyName = nameof(UputnicaDtoEL.UpucenKodDoktora),
                HeaderText = "Upućen kod doktora",
                Name = nameof(UputnicaDtoEL.UpucenKodDoktora),
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var DatumVreme = new DataGridViewColumn
            {
                DataPropertyName = nameof(UputnicaDtoEL.DatumVreme),
                HeaderText = "Datum i vreme",
                Name = nameof(UputnicaDtoEL.DatumVreme),
                CellTemplate = new DataGridViewTextBoxCell()
            };

            AddColumnsToMainDgrv(new[] { ID, Pacijent, upucenKodDoktora, DatumVreme });

            _apiService = new APIService(Routes.UputnicaRoute);
            ResourceParameters = new UputnicaResourceParameters { PageNumber = 1, PageSize = PossibleRowsCount, EagerLoaded = true, UpuceneUputnice = NamenjenjeTrenutnoLogovanomKorisniku };

            InitializeComponent();
            btnNew.Visible = false;
            btnBack.Visible = false;
        }

        protected override void dgrvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];

            var uputnica = row.DataBoundItem as UputnicaDtoEL;

            if (uputnica == null)
                return;

            if (dgrvMain.Columns[e.ColumnIndex].Name == "Pacijent")
            {
                e.Value = uputnica.Pacijent.ZdravstvenaKnjizica.LicniPodaci.ImePrezime;
            }
        }

        protected override void dgrvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgrvMain.CurrentRow?.DataBoundItem is UputnicaDtoEL uputnica))
                return;

            dlgForm.ShowDialog(frmNewUputnica.InstanceWithData(uputnica, newInstance: true), DialogFormSize.Large, NewInstance: true);
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);

            var uputnicaiResParams = ResourceParameters as UputnicaResourceParameters;
            if (uputnicaiResParams == null)
                return;

            var ShouldLoad = SearchText != uputnicaiResParams.PacijentImePrezime;

            if (ShouldLoad)
            {
                uputnicaiResParams.PacijentImePrezime = SearchText;
                await base.LoadData();
            }
        }
    }
}