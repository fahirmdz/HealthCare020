using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System.Linq;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    public sealed partial class frmNewGrad : Form
    {
        private static frmNewGrad _instance;
        private APIService _apiService;
        private GradDtoEL Grad;

        private frmNewGrad(GradDtoEL grad = null)
        {
            InitializeComponent();
            Grad = grad;

            _apiService = new APIService(Routes.DrzaveRoute);
            Text = Grad == null ? Properties.Resources.frmNewGradAdd : Properties.Resources.frmNewGradUpdate;
        }

        public static frmNewGrad Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmNewGrad();
                return _instance;
            }
        }

        public static frmNewGrad InstanceWithData(GradDtoEL grad = null)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmNewGrad(grad);
            else
                _instance.Grad = grad;
            return _instance;
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            frmGradovi.Instance.OpenAsChildOfControl(Parent);
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            if (ValidateInputs())
            {
                _apiService = new APIService(Routes.GradoviRoute);
                if (int.TryParse(cmbDrzave.SelectedValue.ToString(), out int drzavaId))
                {
                    APIServiceResult<GradDtoLL> result;

                    if (Grad == null)
                    {
                        result = await _apiService.Post<GradDtoLL>(new GradUpsertDto
                        { DrzavaId = drzavaId, Naziv = txtNaziv.Text });
                    }
                    else
                    {
                        result = await _apiService.Update<GradDtoLL>(Grad.Id,
                            new GradUpsertDto { Naziv = txtNaziv.Text, DrzavaId = drzavaId });
                    }

                    if (result.Succeeded)
                    {
                        if (Grad == null)
                            await frmPredefinedDataMenu.Instance.LoadPredefinedDataCount(Routes.GradoviRoute);

                        dlgSuccess.ShowDialog();
                        frmGradovi.Instance.OpenAsChildOfControl(Parent);
                        Dispose();
                    }
                }
            }
        }

        private async void frmNewGrad_Load(object sender, System.EventArgs e)
        {
            var result = await _apiService.Get<DrzavaDto>(new DrzavaResourceParameters { PageSize = 100 });
            if (!result.Succeeded)
            {
                dlgError.ShowDialog();
                return;
            }

            var drzave = result.Data;

            cmbDrzave.DataSource = drzave;
            cmbDrzave.ValueMember = nameof(DrzavaDto.Id);
            cmbDrzave.DisplayMember = nameof(DrzavaDto.Naziv);

            if (Grad != null)
            {
                txtNaziv.Text = Grad.Naziv;
                cmbDrzave.SelectedValue = Grad.Drzava.Id;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                Errors.SetError(txtNaziv, Properties.Resources.RequiredField);
                return false;
            }

            if (cmbDrzave.SelectedIndex == -1)
            {
                Errors.SetError(cmbDrzave, Properties.Resources.RequiredField);
                return false;
            }

            if (txtNaziv.Text.Any(char.IsDigit))
            {
                Errors.SetError(txtNaziv, Properties.Resources.InvalidFormat);
                return false;
            }

            Errors.Clear();
            return true;
        }
    }
}