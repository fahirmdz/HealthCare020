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
    public sealed partial class frmRoles : DisplayDataForm<TwoFieldsDto>
    {
        private static frmRoles _instance;

        public static frmRoles Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmRoles();
                return _instance;
            }
        }

        private frmRoles()
        {
            var ID = new DataGridViewColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                Name = "ID",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Naziv = new DataGridViewColumn { DataPropertyName = "Naziv", HeaderText = "Naziv", Name = "Naziv", CellTemplate = new DataGridViewTextBoxCell() };

            var Brisi = new DataGridViewButtonColumn
            {
                HeaderText = Resources.DeleteVerb,
                Name = Resources.DeleteVerb,
                Text = Resources.DeleteIt,
                ToolTipText = "Izbriši role",
                UseColumnTextForButtonValue = true,
                CellTemplate = new DataGridViewButtonCell { ToolTipText = "Izbriši role", UseColumnTextForButtonValue = true },
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Transparent, SelectionBackColor = Color.Transparent }
            };
            AddColumnsToMainDgrv(new[] { ID, Naziv, Brisi });
            _apiService = new APIService(Routes.RolesRoute);
            Text = Resources.frmRoles;
            ResourceParameters = new TwoFieldsResourceParameters();

            InitializeComponent();
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);

            var rolesResParams = ResourceParameters as TwoFieldsResourceParameters;

            if (SearchText != (rolesResParams?.Naziv ?? string.Empty))
            {
                if (rolesResParams != null)
                    rolesResParams.Naziv = SearchText;
                await LoadData();
            }
        }

        protected override async void dgrvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MainDgrv.CurrentRow?.DataBoundItem is TwoFieldsDto role)
            {
                if (MainDgrv.Columns[e.ColumnIndex].Name == "Brisanje")
                {
                    var prompt = dlgPropmpt.ShowDialog();

                    if (prompt.DialogResult == DialogResult.OK)
                    {
                        var result = await _apiService.Delete<TwoFieldsDto>(role.Id);

                        if (result.Succeeded)
                        {
                            dlgSuccess.ShowDialog();
                            _dataForDgrv.Remove(role);
                            CurrentRowCount--;
                        }
                    }
                }
            }
        }

        protected override void btnNew_Click(object sender, EventArgs e)
        {
            frmNewRole.ShowDialog();
        }

        protected override void dgrvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MainDgrv.CurrentRow?.DataBoundItem is TwoFieldsDto role)
            {
                frmNewRole.ShowDialogWithData(role);
            }
        }

        public new async void RefreshData() => await LoadData();

        private void frmRoles_Load(object sender, EventArgs e)
        {
            DisplayDataForm_Load(sender, e);
            FormForBackButton = frmPredefinedDataMenu.Instance;
        }
    }
}