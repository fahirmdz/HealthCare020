using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Drawing;
using System.Windows.Forms;
using Healthcare020.WinUI.Forms.AbstractForms;

namespace Healthcare020.WinUI.Forms.AdministratorDashboard
{
    public partial class frmUsers : DisplayDataForm<KorisnickiNalogDtoLL>
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
            this.Text = Properties.Resources.frmUsers;

            var ID = new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "ID", CellTemplate = new DataGridViewTextBoxCell() };
            ID.CellTemplate = new DataGridViewTextBoxCell();

            var Username = new DataGridViewColumn
            {
                DataPropertyName = "Username",
                HeaderText = "Username",
                Name = "Username",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var LastOnline = new DataGridViewColumn
            {
                DataPropertyName = "LastOnline",
                HeaderText = "Last online",
                Name = "LastOnline",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var DateCreated = new DataGridViewColumn
            {
                DataPropertyName = "DateCreated",
                HeaderText = "Date created",
                Name = "DateCreated",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Zakljucaj = new DataGridViewButtonColumn
            {
                HeaderText = "Zaključavanje",
                Name = "Zaključaj",
                Text = "Zaključaj",
                ToolTipText = "Zaključaj korisnički nalog",
                UseColumnTextForButtonValue = true,
                CellTemplate = new DataGridViewButtonCell{UseColumnTextForButtonValue = true,ToolTipText ="Zaključaj korisnički nalog" },
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Transparent, SelectionBackColor = Color.Transparent },
            };

            base.DgrvColumnsStyle();

            base.AddColumnsToMainDgrv(new[] { ID, Username, LastOnline, DateCreated, Zakljucaj });

            Text = Properties.Resources.frmUsers;
            ResourceParameters = new KorisnickiNalogResourceParameters { PageNumber = 1, PageSize = CurrentRowCount };

            InitializeComponent();
            btnBack.Visible = false;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            base.DisplayDataForm_Load(sender, e);
        }

        protected override async void dgrvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(MainDgrv.CurrentRow?.DataBoundItem is KorisnickiNalogDtoLL korisnik))
                return;

            //Account lock out
            if (e.ColumnIndex == 4)
            {
                Form promptDialog = null;

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
                    APIServiceResult<KorisnickiNalogDtoLL> result = null;

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

        protected override void dgrvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            base.dgrvMain_CellValueChanged(sender, e);
        }

        protected override void dgrvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var isLockedOut =
                    (MainDgrv.Rows[e.RowIndex]?.DataBoundItem as KorisnickiNalogDtoLL)?.LockedOut;
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

            bool ShouldLoad = SearchText != korisnickiNalogResParams.Username;

            if (ShouldLoad)
            {
                korisnickiNalogResParams.Username = SearchText.Trim();
                await base.LoadData();
            }
        }

        protected override void btnNew_Click(object sender, EventArgs e)
        {
            frmNewUser.Instance.OpenAsChildOfControl(Parent);
        }
    }
}