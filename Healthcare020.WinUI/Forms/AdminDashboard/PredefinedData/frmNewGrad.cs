using System.Linq;
using System.Windows.Forms;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    public partial class frmNewGrad : Form
    {
        private static frmNewGrad _instance = null;
        private  APIService _apiService;

        public static frmNewGrad Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmNewGrad();
                return _instance;
            }
        }

        private frmNewGrad()
        {
            InitializeComponent();
            _apiService=new APIService(Routes.DrzaveRoute);
            Text = Properties.Resources.frmNewGrad;
        }

        private async void frmNewGrad_Load(object sender, System.EventArgs e)
        {
            var result = await _apiService.Get<DrzavaDto>(new DrzavaResourceParameters{PageSize = 100});
            if (!result.Succeeded)
            {
                dlgError.ShowDialog();
                return;
            }

            var drzave = result.Data;

            cmbDrzave.DataSource = drzave;
            cmbDrzave.ValueMember = nameof(DrzavaDto.Id);
            cmbDrzave.DisplayMember = nameof(DrzavaDto.Naziv);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                Errors.SetError(txtNaziv,Properties.Resources.RequiredField);
                return false;
            }

            if (cmbDrzave.SelectedIndex == -1)
            {
                Errors.SetError(cmbDrzave,Properties.Resources.RequiredField);
                return false;
            }

            if (txtNaziv.Text.Any(char.IsDigit))
            {
                Errors.SetError(txtNaziv,Properties.Resources.InvalidFormat);
                return false;
            }

            Errors.Clear();
            return true;
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            if (ValidateInputs())
            {
                _apiService=new APIService(Routes.GradoviRoute);
                if(int.TryParse(cmbDrzave.SelectedValue.ToString(),out int drzavaId))
                {
                    var result = await _apiService.Post<GradDtoLL>(new GradUpsertDto
                        {DrzavaId = drzavaId, Naziv = txtNaziv.Text});

                    if (result.Succeeded)
                    {
                        dlgSuccess.ShowDialog();
                        frmStartMenuAdmin.Instance.OpenChildForm(frmGradovi.Instance);
                    }
                }
            }
        }
    }
}