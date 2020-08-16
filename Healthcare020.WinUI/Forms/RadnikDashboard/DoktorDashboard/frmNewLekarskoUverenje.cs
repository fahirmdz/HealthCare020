using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System;
using System.Windows.Forms;
using HealthCare020.Core.Enums;
using dlgForm = Healthcare020.WinUI.Helpers.Dialogs.dlgForm;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmNewLekarskoUverenje : Form
    {
        private static frmNewLekarskoUverenje _instance;
        private readonly PregledDtoEL Pregled;
        private readonly LekarskoUverenjeDtoEL LekarskoUverenje;
        private readonly APIService _apiService;

        public static frmNewLekarskoUverenje InstanceWithData(PregledDtoEL pregled, bool newInstance = false)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmNewLekarskoUverenje(pregled);
            else if (newInstance)
            {
                _instance.Dispose();
                _instance = new frmNewLekarskoUverenje(pregled);
            }
            return _instance;
        }

        public static frmNewLekarskoUverenje InstanceWithData(LekarskoUverenjeDtoEL lekarskoUverenje, bool newInstance = false)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmNewLekarskoUverenje(lekarskoUverenje);
            else if (newInstance)
            {
                _instance.Dispose();
                _instance = new frmNewLekarskoUverenje(lekarskoUverenje);
            }
            return _instance;
        }

        private frmNewLekarskoUverenje(LekarskoUverenjeDtoEL lekarskoUverenje)
        {
            LekarskoUverenje = lekarskoUverenje;
            Pregled = null;
            InitializeComponent();

            _apiService = new APIService(Routes.ZdravstvenaStanjaRoute);
            txtPacijent.Text = LekarskoUverenje.Pregled.Pacijent.ZdravstvenaKnjizica.LicniPodaci.ImePrezime;
            txtDoktor.Text = LekarskoUverenje.Pregled.Doktor;
            txtOpisStanja.Text = LekarskoUverenje.OpisStanja;
            toolTip.SetToolTip(btnPdf, "Generisanje PDF dokumenta na osnovu podataka iz forme");

            btnSave.Visible = false;
            txtOpisStanja.ReadOnly = true;
            cmbZdravstvenoStanje.Enabled = false;

            var isMedicinskiTehnicar = Auth.Role == RoleType.MedicinskiTehnicar;
            btnPdf.Visible = !isMedicinskiTehnicar;
            btnSave.Visible = !isMedicinskiTehnicar;
            btnUputnica.Visible = !isMedicinskiTehnicar;
        }

        private frmNewLekarskoUverenje(PregledDtoEL pregled)
        {
            Pregled = pregled;
            LekarskoUverenje = null;

            _apiService = new APIService(Routes.ZdravstvenaStanjaRoute);
            InitializeComponent();
            txtPacijent.Text = Pregled.Pacijent.ZdravstvenaKnjizica.LicniPodaci.ImePrezime;
            txtDoktor.Text = Pregled.Doktor;
            txtOpisStanja.ResetText();
            toolTip.SetToolTip(btnPdf, "Generisanje PDF dokumenta na osnovu podataka iz forme");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                _apiService.ChangeRoute(Routes.LekarskoUverenjeRoute);
                var upsertDto = new LekarskoUverenjeUpsertDto
                {
                    OpisStanja = txtOpisStanja.Text,
                    PregledId = Pregled.Id,
                    ZdravstvenoStanjeId = (int)cmbZdravstvenoStanje.SelectedValue
                };

                var result = await _apiService.Post<LekarskoUverenjeDtoLL>(upsertDto);
                if (result.Succeeded)
                {
                    dlgSuccess.ShowDialog();
                    Close();
                }
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (LekarskoUverenje != null || ValidateInputs())
            {
                if (LekarskoUverenje != null)
                    PDFService.GeneratePDFDocument(Pregled ?? LekarskoUverenje.Pregled,
                        (cmbZdravstvenoStanje.SelectedItem as ZdravstvenoStanjeDto)?.Opis ?? string.Empty,
                        txtOpisStanja.Text);
            }
        }

        private async void frmNewLekarskoUverenje_Load(object sender, EventArgs e)
        {
            var result = await _apiService.Get<ZdravstvenoStanjeDto>();
            if (!result.Succeeded || !result.HasData)
            {
                dlgError.ShowDialog("Problem sa ucitavanjem zdravstvenih stanja");
                return;
            }

            cmbZdravstvenoStanje.DataSource = result.Data;
            cmbZdravstvenoStanje.ValueMember = nameof(ZdravstvenoStanjeDto.Id);
            cmbZdravstvenoStanje.DisplayMember = nameof(ZdravstvenoStanjeDto.Opis);
            cmbZdravstvenoStanje.SelectedValue = LekarskoUverenje?.ZdravstvenoStanje?.Id??0;
        }

        private bool ValidateInputs()
        {
            if (cmbZdravstvenoStanje.SelectedIndex == -1)
            {
                Errors.SetError(cmbZdravstvenoStanje, Resources.RequiredField);
                return false;
            }

            if (!txtOpisStanja.ValidTextInput(Errors, Validation.TextInputType.Mixed))
                return false;

            Errors.Clear();
            return true;
        }

        private void btnUputnica_Click(object sender, EventArgs e)
        {
            dlgForm.SetShouldDisposeOnChildClose(false);
            dlgForm.ShowDialog(frmNewUputnica.InstanceWithData(Pregled?.Pacijent ?? LekarskoUverenje.Pregled.Pacijent), DialogFormSize.Large, NewInstance: true);
        }
    }
}