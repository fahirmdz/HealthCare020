﻿using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    public sealed partial class frmNaucneOblasti : DisplayDataForm<TwoFieldsDto>
    {
        private static frmNaucneOblasti _instance;

        public static frmNaucneOblasti Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmNaucneOblasti();
                return _instance;
            }
        }

        private frmNaucneOblasti()
        {
            Text = Resources.frmNaucneOblasti;

            var ID = new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                Name = "ID",
                DataPropertyName = "Id",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Naziv = new DataGridViewTextBoxColumn
            {
                HeaderText = Resources.Name,
                Name = "Naziv",
                DataPropertyName = "Naziv",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Brisi = new DataGridViewButtonColumn
            {
                HeaderText = Resources.DeleteVerb,
                Name = "Brisanje",
                Text = Resources.DeleteIt,
                ToolTipText = Resources.DeleteIt,
                UseColumnTextForButtonValue = true,
                CellTemplate = new DataGridViewButtonCell { ToolTipText = Resources.DeleteIt, UseColumnTextForButtonValue = true },
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Transparent, SelectionBackColor = Color.Transparent }
            };

            AddColumnsToMainDgrv(new DataGridViewColumn[] { ID, Naziv, Brisi });
            ResourceParameters = new TwoFieldsResourceParameters();
            _apiService = new APIService(Routes.NaucneOblastiRoute);
            InitializeComponent();
        }

        protected override async void dgrvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MainDgrv.CurrentRow?.DataBoundItem is TwoFieldsDto naucnaOblast)
            {
                if (MainDgrv.Columns[e.ColumnIndex].Name == "Brisanje")
                {
                    var prompt = dlgPropmpt.ShowDialog();

                    if (prompt.DialogResult == DialogResult.OK)
                    {
                        var result = await _apiService.Delete<TwoFieldsDto>(naucnaOblast.Id);

                        if (result.Succeeded)
                        {
                            dlgSuccess.ShowDialog();
                            _dataForDgrv.Remove(naucnaOblast);
                            CurrentRowCount--;
                        }
                    }
                }
            }
        }

        protected override void dgrvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MainDgrv.CurrentRow?.DataBoundItem is TwoFieldsDto naucnaOblast)
            {
                if (MainDgrv.Columns[e.ColumnIndex].Name != "Brisanje")
                {
                    frmNewNaucnaOblast.ShowDialogWithData(naucnaOblast);
                }
            }
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);

            var twoFieldsResParams = ResourceParameters as TwoFieldsResourceParameters;

            if (SearchText != twoFieldsResParams?.Naziv)
            {
                if (twoFieldsResParams != null)
                    twoFieldsResParams.Naziv = SearchText;
                await LoadData();
            }
        }

        protected override void btnNew_Click(object sender, EventArgs e)
        {
            frmNewNaucnaOblast.ShowDialog();
        }

        private void frmNaucneOblasti_Load(object sender, EventArgs e)
        {
            DisplayDataForm_Load(sender, e);
            FormForBackButton = frmPredefinedDataMenu.Instance;
        }
    }
}