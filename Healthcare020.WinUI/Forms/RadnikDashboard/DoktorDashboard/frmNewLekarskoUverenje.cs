using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using System;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmNewLekarskoUverenje : Form
    {
        private static frmNewLekarskoUverenje _instance = null;
        private PregledDtoEL Pregled;
        private readonly APIService _apiService;

        public static frmNewLekarskoUverenje InstanceWithData(PregledDtoEL pregled,bool newInstance=false)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmNewLekarskoUverenje(pregled);
            else if (newInstance)
            {
                _instance.Dispose();
                _instance=new frmNewLekarskoUverenje(pregled);
            }
            return _instance;
        }

        private frmNewLekarskoUverenje(PregledDtoEL pregled)
        {
            Pregled = pregled;
            _apiService = new APIService(Routes.ZdravstvenaStanjaRoute);
            InitializeComponent();
            txtPacijent.Text = Pregled.Pacijent.ZdravstvenaKnjizica.LicniPodaci.ImePrezime();
            txtDoktor.Text = Pregled.Doktor;
            txtOpisStanja.ResetText();
            toolTip.SetToolTip(btnPdf, "Generisanje PDF dokumenta na osnovu podataka iz forme");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
                PDFService.GeneratePDFDocument(Pregled,
                    (cmbZdravstvenoStanje.SelectedItem as ZdravstvenoStanjeDto)?.Opis ?? string.Empty,
                    txtOpisStanja.Text);
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
            cmbZdravstvenoStanje.SelectedIndex = 0;
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
    }
}