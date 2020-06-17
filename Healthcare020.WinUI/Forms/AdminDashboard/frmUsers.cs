using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.CustomElements;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    public partial class frmUsers : Form
    {
        private static frmUsers _instance;
        private readonly APIService _apiServiceKorisnici;
        private readonly PanelCheckInternetConnection _internetError;

        private IBindingList _korisniciForDgrv;
        private int _currentDgrvPage = 1;

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
            InitializeComponent();
            MainForm.Instance.SetCopyrightPanelColor(Color.FromArgb(240, 240, 240));
            _apiServiceKorisnici = new APIService("korisnici");
            _korisniciForDgrv = new BindingSource();
            this.Text = Properties.Resources.frmUsers;

            //Main data grid view settings
            dgrvKorisnickiNalozi.EnableHeadersVisualStyles = false;
            dgrvKorisnickiNalozi.ReadOnly = false;
            dgrvKorisnickiNalozi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgrvKorisnickiNalozi.BorderStyle = BorderStyle.None;
            dgrvKorisnickiNalozi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgrvKorisnickiNalozi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 190, 190);
            dgrvKorisnickiNalozi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgrvKorisnickiNalozi.AutoGenerateColumns = false;
            dgrvKorisnickiNalozi.RowCount = 8;
            btnPrevPage.Enabled = false;

            //Tool tips
            this.toolTip.SetToolTip(btnPrevPage, "Previous page");
            this.toolTip.SetToolTip(btnNextPage, "Next page");

            if (!ConnectionCheck.CheckForInternetConnection())
            {
                pnlBody.Hide();
                _internetError = new PanelCheckInternetConnection(this);
                _internetError.Show();
                _internetError.BringToFront();
                Controls.Add(_internetError);
                _internetError.SetRetryConnectionEvent(RetryConnection);
            }
        }

        public async void RetryConnection(object sender, EventArgs e)
        {
            if (ConnectionCheck.CheckForInternetConnection())
            {
                _internetError.Hide();
                pnlBody.Show();
                pnlBody.BringToFront();
                await LoadData();
            }
        }

        private async Task LoadData(int pageSize = 8, int pageNumber = 1, string searchParameter = "")
        {
            Application.UseWaitCursor = true;

            var result = await _apiServiceKorisnici
                .Get<KorisnickiNalogDtoLL>(new KorisnickiNalogResourceParameters
                {
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                    Username = string.IsNullOrWhiteSpace(searchParameter) ? null : searchParameter
                });

            _korisniciForDgrv = new BindingList<KorisnickiNalogDtoLL>(result.Data);
            dgrvKorisnickiNalozi.DataSource = _korisniciForDgrv;

            btnNextPage.Enabled = _currentDgrvPage != result.PaginationMetadata.TotalPages;
            btnPrevPage.Enabled = _currentDgrvPage != 1;

            Application.UseWaitCursor = false;
            dgrvKorisnickiNalozi.Cursor = this.Cursor;
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            if (pnlBody.Visible)
                await LoadData();
        }

        private async void btnNextPage_Click_1(object sender, EventArgs e)
        {
            await LoadData(8, ++_currentDgrvPage);
            btnPrevPage.Enabled = true;
        }

        private async void btnPrevPage_Click_1(object sender, EventArgs e)
        {
            await LoadData(8, --_currentDgrvPage);

            if (_currentDgrvPage == 1)
                btnPrevPage.Enabled = false;
            btnNextPage.Enabled = true;
        }

        private async void dgrvKorisnickiNalozi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgrvKorisnickiNalozi.CurrentRow?.DataBoundItem is KorisnickiNalogDtoLL korisnik))
                return;
            //Account lock out
            if (e.ColumnIndex == 3)
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
                        result = await _apiServiceKorisnici.Update<KorisnickiNalogDtoLL>(korisnik.Id, new KorisnickiNalogLockUpsertRequest
                        {
                            Until = until.Value
                        }, "lock");
                    }
                    else
                    {
                        result = await _apiServiceKorisnici.Delete<KorisnickiNalogDtoLL>(korisnik.Id, "lock");
                    }

                    if (result.Succeeded)
                    {
                        korisnik.LockedOut = result.Data.LockedOut;
                        dlgSuccess.ShowDialog();
                    }
                }
            }
        }

        private void dgrvKorisnickiNalozi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgrvKorisnickiNalozi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var isLockedOut =
                    (dgrvKorisnickiNalozi.Rows[e.RowIndex]?.DataBoundItem as KorisnickiNalogDtoLL)?.LockedOut;
                if (isLockedOut.HasValue)
                {
                    e.Value = isLockedOut.Value ? "Otključaj" : "Zaključaj";
                }
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadData(searchParameter: string.IsNullOrWhiteSpace(txtSearch.Text) ? string.Empty : txtSearch.Text);
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            frmStartMenuAdmin.Instance.OpenChildForm(frmNewUser.Instance);
        }
    }
}