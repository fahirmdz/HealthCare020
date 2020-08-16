using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    public sealed partial class frmUsers : DisplayDataForm<KorisnickiNalogDtoLL>
    {
        private static frmUsers _instance;

        public static frmUsers Instance
        {
            get
            {
                if (!Auth.IsAuthenticated())
                    return null;
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmUsers();
                }

                return _instance;
            }
        }

        private frmUsers()
        {
            _apiService = new APIService(Routes.KorisniciRoute);
            _dataForDgrv = new BindingSource();
            Text = Resources.frmUsers;

            var ID = new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "ID", CellTemplate = new DataGridViewTextBoxCell() };
            ID.CellTemplate = new DataGridViewTextBoxCell();

            var Username = new DataGridViewColumn
            {
                DataPropertyName = "Username",
                HeaderText = Resources.Username,
                Name = "Username",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var LastOnline = new DataGridViewColumn
            {
                DataPropertyName = "LastOnline",
                HeaderText = Resources.LastOnline,
                Name = "LastOnline",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var DateCreated = new DataGridViewColumn
            {
                DataPropertyName = "DateCreated",
                HeaderText = Resources.DateCreated,
                Name = "DateCreated",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Zakljucaj = new DataGridViewButtonColumn
            {
                HeaderText = Resources.LockVerb,
                Name = "Zaključaj",
                Text = "Zaključaj",
                ToolTipText = Resources.LockAccount,
                UseColumnTextForButtonValue = true,
                CellTemplate = new DataGridViewButtonCell { UseColumnTextForButtonValue = true, ToolTipText = Resources.LockAccount },
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Transparent, SelectionBackColor = Color.Transparent },
            };

            DgrvColumnsStyle();

            AddColumnsToMainDgrv(new[] { ID, Username, LastOnline, DateCreated, Zakljucaj });

            Text = Resources.frmUsers;
            ResourceParameters = new KorisnickiNalogResourceParameters();

            InitializeComponent();
            btnBack.Visible = false;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DisplayDataForm_Load(sender, e);
        }

        protected override async void dgrvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(MainDgrv.CurrentRow?.DataBoundItem is KorisnickiNalogDtoLL korisnik))
                return;

            //Account lock out
            if (e.ColumnIndex == 4)
            {
                Form promptDialog;

                if (korisnik.LockedOut)
                {
                    promptDialog = dlgPropmpt.ShowDialog();
                }
                else
                {
                    promptDialog = dlgAccountLock.ShowDialog();
                }

                DateTime? until = null;
                bool isForLockout = promptDialog is dlgAccountLock;

                if (isForLockout)
                {
                    until = DateTime.Now.AddHours(((dlgAccountLock)promptDialog).NumberOfHours);
                }

                if (promptDialog?.DialogResult == DialogResult.OK)
                {
                    APIServiceResult<KorisnickiNalogDtoLL> result;

                    if (isForLockout)
                    {
                        result = await _apiService.Update<KorisnickiNalogDtoLL>(korisnik.Id, new KorisnickiNalogLockUpsertRequest
                        {
                            Until = until.Value
                        }, "lock");
                    }
                    else
                    {
                        result = await _apiService.Delete<KorisnickiNalogDtoLL>(korisnik.Id, "lock");
                    }

                    if (result.Succeeded)
                    {
                        korisnik.LockedOut = result.Data.LockedOut;
                        dlgSuccess.ShowDialog();
                    }
                }
            }
        }

        protected override void dgrvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var isLockedOut =
                    (MainDgrv.Rows[e.RowIndex].DataBoundItem as KorisnickiNalogDtoLL)?.LockedOut;
                if (isLockedOut.HasValue)
                {
                    e.Value = isLockedOut.Value ? "Otključaj" : "Zaključaj";
                }
            }
        }

        protected override async void txtSearch_Leave(object sender, EventArgs e)
        {
            base.txtSearch_Leave(sender, e);

            var korisnickiNalogResParams = ResourceParameters as KorisnickiNalogResourceParameters;

            bool ShouldLoad = korisnickiNalogResParams != null && SearchText != korisnickiNalogResParams.Username;

            if (ShouldLoad)
            {
                korisnickiNalogResParams.Username = SearchText.Trim();
                await LoadData();
            }
        }

        protected override void btnNew_Click(object sender, EventArgs e)
        {
            frmNewUser.Instance.OpenAsChildOfControl(Parent);
        }
    }
}