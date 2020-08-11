using System;
using System.Drawing;
using System.Linq;
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
    public partial class frmDrzave : DisplayDataForm<DrzavaDto>
    {
        private static frmDrzave _instance;

        public static frmDrzave Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmDrzave();

                return _instance;
            }
        }

        private frmDrzave() : base()
        {
            var ID = new DataGridViewTextBoxColumn { DataPropertyName = nameof(DrzavaDto.Id), HeaderText = "ID", Name = "ID", CellTemplate = new DataGridViewTextBoxCell() };

            var Naziv = new DataGridViewColumn { DataPropertyName = nameof(DrzavaDto.Naziv), HeaderText = "Naziv", Name = "Naziv", CellTemplate = new DataGridViewTextBoxCell() };

            var PozivniBroj = new DataGridViewColumn
            {
                DataPropertyName = nameof(DrzavaDto.PozivniBroj),
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
                CellTemplate = new DataGridViewButtonCell { ToolTipText = "Izbriši državu", UseColumnTextForButtonValue = true },
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Transparent, SelectionBackColor = Color.Transparent }
            };

            base.AddColumnsToMainDgrv(new[] { ID, Naziv, PozivniBroj, Brisi });

            _apiService = new APIService(Routes.DrzaveRoute);
            Text = Properties.Resources.frmDrzave;
            ResourceParameters = new DrzavaResourceParameters { PageNumber = 1, PageSize = PossibleRowsCount };

            InitializeComponent();
        }

        private  void frmDrzave_Load(object sender, EventArgs e)
        {
            DisplayDataForm_Load(sender, e);
            FormForBackButton = frmPredefinedDataMenu.Instance;
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);

            var drzavaResParams = ResourceParameters as DrzavaResourceParameters;

            bool isPozivni = SearchText.Any(char.IsDigit), ShouldLoad = (isPozivni && SearchText != drzavaResParams.PozivniBroj) || (!isPozivni && SearchText != drzavaResParams.Naziv);

            drzavaResParams.Naziv = isPozivni ? string.Empty : SearchText.Trim();
            drzavaResParams.PozivniBroj = isPozivni ? SearchText.Trim() : string.Empty;

            if (ShouldLoad)
                await base.LoadData();
        }

        protected override void btnNew_Click(object sender, EventArgs e)
        {
            frmNewDrzava.Instance.OpenAsChildOfControl(Parent);
        }

        protected override async void dgrvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(MainDgrv.CurrentRow?.DataBoundItem is DrzavaDto drzava))
                return;

            if (e.ColumnIndex == 3)
            {
                var prompDialog = dlgPropmpt.ShowDialog();

                if (prompDialog?.DialogResult == DialogResult.OK)
                {
                    var result = await _apiService.Delete<DrzavaDto>(drzava.Id);

                    if (result.Succeeded)
                    {
                        _dataForDgrv.Remove(drzava);
                        CurrentRowCount--;
                        dlgSuccess.ShowDialog();
                    }
                }
            }
        }

        protected override void dgrvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(MainDgrv.CurrentRow?.DataBoundItem is DrzavaDto drzava))
                return;

            if (MainDgrv.Columns[e.ColumnIndex].Name != "Izbriši")
            {
                frmNewDrzava.InstanceWithData(drzava).OpenAsChildOfControl(Parent);
            }
        }
    }
}