using Healthcare020.WinUI.Services;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.AdminDashboard
{
    public partial class frmUsers : Form
    {
        private static frmUsers _instance;
        private APIService<KorisnickiNalogResourceParameters> _apiService;
        private int _currentDgrvPage = 1;

        public static frmUsers Instance
        {
            get
            {
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
            _apiService = new APIService<KorisnickiNalogResourceParameters>("korisnici");
            dgrvKorisnickiNalozi.EnableHeadersVisualStyles = false;
            dgrvKorisnickiNalozi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgrvKorisnickiNalozi.BorderStyle = BorderStyle.None;
            dgrvKorisnickiNalozi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgrvKorisnickiNalozi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 190, 190);
            dgrvKorisnickiNalozi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgrvKorisnickiNalozi.AutoGenerateColumns = false;
            dgrvKorisnickiNalozi.RowCount = 8;
            btnPrevPage.Enabled = false;
            this.toolTip.SetToolTip(btnPrevPage, "Previous page");
            this.toolTip.SetToolTip(btnNextPage, "Next page");
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            var result = await _apiService
                .Get<KorisnickiNalogDtoLL>(new KorisnickiNalogResourceParameters { PageSize = 8 });

            dgrvKorisnickiNalozi.DataSource = result.Data;

            if (result.PaginationMetadata.CurrentPage == result.PaginationMetadata.TotalPages)
                btnNextPage.Enabled = false;
        }

        private async void btnNextPage_Click_1(object sender, EventArgs e)
        {
            var result = await _apiService
                .Get<KorisnickiNalogDtoLL>(new KorisnickiNalogResourceParameters { PageSize = 8, PageNumber = ++_currentDgrvPage });

            dgrvKorisnickiNalozi.DataSource = result.Data;
            btnPrevPage.Enabled = true;
            if (result.PaginationMetadata.CurrentPage == result.PaginationMetadata.TotalPages)
                btnNextPage.Enabled = false;
        }

        private async void btnPrevPage_Click_1(object sender, EventArgs e)
        {
            var result = await _apiService
                    .Get<KorisnickiNalogDtoLL>(new KorisnickiNalogResourceParameters { PageSize = 8, PageNumber = --_currentDgrvPage });

            dgrvKorisnickiNalozi.DataSource = result.Data;
            if (_currentDgrvPage == 1)
                btnPrevPage.Enabled = false;
            btnNextPage.Enabled = true;
        }
    }
}