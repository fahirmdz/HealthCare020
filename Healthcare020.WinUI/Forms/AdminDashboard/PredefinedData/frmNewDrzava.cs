using System.Linq;
using System.Windows.Forms;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    public partial class frmNewDrzava : Form
    {
        private static frmNewDrzava _instance;
        private readonly APIService _apiService;
        private DrzavaDto Drzava;

        public static frmNewDrzava Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmNewDrzava();
                return _instance;
            }
        }

        public static frmNewDrzava InstanceWithData(DrzavaDto drzava)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmNewDrzava(drzava);
            else
                _instance.Drzava = drzava;
            return _instance;
        }

        private frmNewDrzava(DrzavaDto drzava = null)
        {
            Drzava = drzava;
            InitializeComponent();
            this.Text = Drzava != null ? Properties.Resources.frmNewDrzavaUpdate : Properties.Resources.frmNewDrzavaAdd;
            _apiService = new APIService(Routes.DrzaveRoute);
        }

        private void frmNewDrzava_Load(object sender, System.EventArgs e)
        {
            if (Drzava != null)
            {
                txtNaziv.Text = Drzava.Naziv;
                txtPozivniBroj.Text = Drzava.PozivniBroj;
            }
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            frmDrzave.Instance.OpenAsChildOfControl(Parent);
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            if (ValidateInput())
            {
                APIServiceResult<DrzavaDto> result;
                if (Drzava == null)
                {
                    result = await _apiService.Post<DrzavaDto>(new DrzavaUpsertRequest
                    {
                        Naziv = txtNaziv.Text,
                        PozivniBroj = txtPozivniBroj.Text
                    });
                }
                else
                {
                    result = await _apiService.Update<DrzavaDto>(Drzava.Id,
                        new DrzavaUpsertRequest { Naziv = txtNaziv.Text, PozivniBroj = txtPozivniBroj.Text });
                }

                if (result.Succeeded)
                {
                    if (Drzava == null)
                        await frmPredefinedDataMenu.Instance.LoadPredefinedDataCount(Routes.DrzaveRoute);

                    dlgSuccess.ShowDialog();
                    frmDrzave.Instance.OpenAsChildOfControl(Parent);
                    Dispose();
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
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

            if (txtPozivniBroj.Text.Any(char.IsLetter))
            {
                Errors.SetError(txtPozivniBroj, Properties.Resources.InvalidFormat);
                return false;
            }

            return true;
        }
    }
}