using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmNewUputnica : Form
    {
        private static frmNewUputnica _instance;
        private readonly PacijentDtoEL Pacijent;
        private readonly UputnicaDtoEL Uputnica;
        private readonly APIService _apiService;

        public static frmNewUputnica InstanceWithData(PacijentDtoEL pacijent, bool newInstance = false)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmNewUputnica(pacijent);
            else if (newInstance)
            {
                _instance.Dispose();
                _instance = new frmNewUputnica(pacijent);
            }
            return _instance;
        }

        public static frmNewUputnica InstanceWithData(UputnicaDtoEL uputnica, bool newInstance = false)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmNewUputnica(uputnica);
            else if (newInstance)
            {
                _instance.Dispose();
                _instance = new frmNewUputnica(uputnica);
            }
            return _instance;
        }

        private frmNewUputnica(UputnicaDtoEL uputnica)
        {
            Uputnica = uputnica;
            Pacijent = null;
            InitializeComponent();
            _apiService = new APIService(Routes.UputnicaRoute);

            txtPacijent.Text = Uputnica.Pacijent.ZdravstvenaKnjizica.LicniPodaci.ImePrezime;
            txtRazlog.Text = Uputnica.Razlog;
            txtNapomena.Text = uputnica.Napomena;

            cmbDoktori.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            txtNapomena.ReadOnly = true;
            txtRazlog.ReadOnly = true;
        }

        private frmNewUputnica(PacijentDtoEL pacijent)
        {
            Pacijent = pacijent;
            Uputnica = null;

            _apiService = new APIService(Routes.UputnicaRoute);
            InitializeComponent();
            txtPacijent.Text = Pacijent?.ZdravstvenaKnjizica?.LicniPodaci?.ImePrezime ?? "N/A";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                var upsertDto = new UputnicaUpsertDto
                {
                    DatumVreme = DateTime.Now,
                    Napomena = txtNapomena.Text,
                    PacijentId = Pacijent.Id,
                    Razlog = txtRazlog.Text,
                    UpucenKodDoktoraId = (int)cmbDoktori.SelectedValue
                };

                var result = await _apiService.Post<UputnicaDtoLL>(upsertDto);
                if (result.Succeeded)
                {
                    dlgSuccess.ShowDialog();
                    Close();
                    frmLekarskaUverenja.Instance.OpenAsChildOfControl(Parent);
                    Dispose();
                }
            }
        }

        private async void frmNewUputnica_Load(object sender, EventArgs e)
        {
            _apiService.ChangeRoute(Routes.DoktoriRoute);
            var result = await _apiService.Get<DoktorDtoEL>(new DoktorResourceParameters { EagerLoaded = true });
            if (!result.Succeeded || !result.HasData)
            {
                dlgError.ShowDialog("Greska pri ucitavanju podataka");
                return;
            }

            result.Data = result.Data.Where(x => x.Id != Auth.CurrentLoggedInDoktor.Id).ToList();
            cmbDoktori.DataSource = result.Data.Select(x => new ComboBoxItem($"{x.Radnik.Ime} {x.Radnik.Prezime}", x.Id)).ToList();
            cmbDoktori.ValueMember = nameof(ComboBoxItem.Value);
            cmbDoktori.DisplayMember = nameof(ComboBoxItem.Text);
            cmbDoktori.SelectedValue = Uputnica?.UpucenKodDoktoraId ?? 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            frmLekarskaUverenja.Instance.OpenAsChildOfControl(Parent);
            Dispose();
        }

        private bool ValidateInputs()
        {
            if (!cmbDoktori.ValidComboBoxItemSelected(Errors))
                return false;

            if (!txtRazlog.ValidTextInput(Errors))
                return false;

            Errors.Clear();
            return true;
        }
    }
}