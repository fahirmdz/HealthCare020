using System.Linq;
using System.Windows.Forms;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    public partial class frmNewDrzava : Form
    {
        private static frmNewDrzava _instance;
        private readonly APIService _apiService;

        public static frmNewDrzava Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmNewDrzava();
                return _instance;
            }
        }

        private frmNewDrzava()
        {
            InitializeComponent();
            this.Text = Properties.Resources.frmNewDrzava;
            _apiService=new APIService(Routes.DrzaveRoute);

        }

        private void frmNewDrzava_Load(object sender, System.EventArgs e)
        {

        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            frmStartMenuAdmin.Instance.OpenChildForm(frmDrzave.Intance);
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            if (ValidateInput())
            {
                var result = await _apiService.Post<DrzavaDto>(new DrzavaUpsertRequest
                {
                    Naziv = txtNaziv.Text,
                    PozivniBroj = txtPozivniBroj.Text
                });

                if (result.Succeeded)
                {
                    dlgSuccess.ShowDialog();
                    frmStartMenuAdmin.Instance.OpenChildForm(frmDrzave.Intance);
                }
            }
        }


        private bool ValidateInput()
        {
            if(string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                Errors.SetError(txtNaziv, Properties.Resources.RequiredField);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPozivniBroj.Text))
            {
                Errors.SetError(txtNaziv, Properties.Resources.RequiredField);
                return false;
            }

            if (txtNaziv.Text.Any(char.IsDigit))
            {
                Errors.SetError(txtNaziv, Properties.Resources.InvalidFormat);
                return false;
            }

            if(txtPozivniBroj.Text.Any(char.IsLetter))
            {
                Errors.SetError(txtPozivniBroj, Properties.Resources.InvalidFormat);
                return false;
            }

            return true;
        }
    }
}