using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.AdminDashboard
{
    public partial class frmUsers : Form
    {
        private static frmUsers _instance;
        private APIService<KorisnickiNalogResourceParameters> _apiService;

        public static frmUsers Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance=new frmUsers();
                }

                return _instance;
            }
        }
        private frmUsers()
        {
            InitializeComponent();
            _apiService=new APIService<KorisnickiNalogResourceParameters>("korisnici");
            dgrvKorisnickiNalozi.EnableHeadersVisualStyles = false;
            dgrvKorisnickiNalozi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgrvKorisnickiNalozi.BorderStyle = BorderStyle.None;
            dgrvKorisnickiNalozi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgrvKorisnickiNalozi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 190, 190);
            dgrvKorisnickiNalozi.ColumnHeadersDefaultCellStyle.ForeColor=Color.White;
            dgrvKorisnickiNalozi.AutoGenerateColumns = false;
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            var korisnici = await _apiService
                .Get<KorisnickiNalogDtoEL>(new KorisnickiNalogResourceParameters
                {
                    EagerLoaded = true
                });

            dgrvKorisnickiNalozi.DataSource = korisnici;
        }
    }
}
