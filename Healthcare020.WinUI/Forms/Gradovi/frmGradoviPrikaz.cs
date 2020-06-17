using System;
using System.Windows.Forms;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.Gradovi
{
    public partial class frmGradoviPrikaz : Form
    {
        private readonly APIService _apiService;

        public frmGradoviPrikaz()
        {
            _apiService = new APIService("gradovi");
            InitializeComponent();
        }

        private async void frmGradoviPrikaz_Load(object sender, EventArgs e)
        {
            var data = await _apiService.Get<GradDtoLL>(new GradResourceParameters{Naziv = ""});

            dgrvGradoviPrikaz.DataSource = data;
        }
    }
}