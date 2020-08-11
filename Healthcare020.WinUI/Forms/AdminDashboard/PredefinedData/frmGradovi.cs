using System;
using System.Drawing;
using System.Windows.Forms;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    public partial class frmGradovi : DisplayDataForm<GradDtoEL>
    {
        private static frmGradovi _instance = null;

        public static frmGradovi Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmGradovi();
                return _instance;
            }
        }

        private frmGradovi() : base()
        {

            var ID = new DataGridViewColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                Name = "ID",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Naziv = new DataGridViewColumn { DataPropertyName = "Naziv", HeaderText = "Naziv", Name = "Naziv", CellTemplate = new DataGridViewTextBoxCell() };

            var Drzava = new DataGridViewColumn
            {
                DataPropertyName = "Drzava.Naziv",
                HeaderText = "Država",
                Name = "Država",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Brisi = new DataGridViewButtonColumn
            {
                HeaderText = "Brisanje",
                Name = "Brisanje",
                Text = "Izbriši",
                ToolTipText = "Izbriši grad",
                UseColumnTextForButtonValue = true,
                CellTemplate = new DataGridViewButtonCell { ToolTipText = "Izbriši grad", UseColumnTextForButtonValue = true },
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Transparent, SelectionBackColor = Color.Transparent }
            };

            base.AddColumnsToMainDgrv(new[] { ID, Naziv, Drzava, Brisi });

            _apiService = new APIService(Routes.GradoviRoute);
            Text = Properties.Resources.frmGradovi;
            ResourceParameters = new GradResourceParameters { PageNumber = 1, PageSize = PossibleRowsCount, EagerLoaded = true };

            InitializeComponent();
        }

        private void frmGradovi_Load(object sender, System.EventArgs e)
        {
            DisplayDataForm_Load(sender, e);
            FormForBackButton = frmPredefinedDataMenu.Instance;
        }

        protected override async void dgrvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(MainDgrv.CurrentRow?.DataBoundItem is GradDtoEL grad))
                return;

            //Izbrisi
            if (e.ColumnIndex == 3)
            {
                var promptDialog = dlgPropmpt.ShowDialog();

                if (promptDialog?.DialogResult == DialogResult.OK)
                {
                    var result = await _apiService.Delete<GradDtoLL>(grad.Id);

                    if (result.Succeeded)
                    {
                        dlgSuccess.ShowDialog();
                        _dataForDgrv.Remove(grad);
                        CurrentRowCount--;
                    }
                }
            }
        }

        protected override void dgrvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(MainDgrv.CurrentRow?.DataBoundItem is GradDtoEL grad))
                return;

            if (MainDgrv.Columns[e.ColumnIndex].Name != "Brisanje")
            {
                frmNewGrad.InstanceWithData(grad).OpenAsChildOfControl(Parent);
            }
        }

        protected override void btnNew_Click(object sender, EventArgs e)
        {
            frmNewGrad.Instance.OpenAsChildOfControl(Parent);
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);

            var gradResParams = ResourceParameters as GradResourceParameters;

            if (gradResParams.Naziv != SearchText)
            {
                gradResParams.Naziv = SearchText.Trim();

                await base.LoadData();
            }
        }
    }
}