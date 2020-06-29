using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmPregledZakazivanje : Form
    {
        private static frmPregledZakazivanje _instance = null;
        private ZahtevZaPregledDtoEL ZahtevZaPregled;

        private readonly APIService _apiService;

        private frmPregledZakazivanje(ZahtevZaPregledDtoEL zahtevZaPregled)
        {
            ZahtevZaPregled = zahtevZaPregled;
            _apiService = new APIService(Routes.PreglediRoute);
            InitializeComponent();
        }

        public static frmPregledZakazivanje InstanceWithData(ZahtevZaPregledDtoEL zahtevZaPregled)
        {
            if (zahtevZaPregled == null)
                return null;
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmPregledZakazivanje(zahtevZaPregled);
            return _instance;
        }

        private void frmZahtevZaPregled_Load(object sender, System.EventArgs e)
        {
            txtZahtevZaPregled.Text = ZahtevZaPregled.Id.ToString();
            datePregled.MinDate = DateTime.Now;
            timePregled.MinDate = DateTime.Now;
            txtDoktor.Text = ZahtevZaPregled.Doktor;
            txtPacijent.Text = ZahtevZaPregled.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci?.ImePrezime() ?? "N/A";
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            if(ValidateInputs())
            {
                var datumVremePregleda = new DateTime(datePregled.Value.Year, datePregled.Value.Month,
                    datePregled.Value.Day, timePregled.Value.Hour, timePregled.Value.Minute, 0);

                var result = await _apiService.Post<PregledDtoLL>(new PregledUpsertDto
                {
                    DatumPregleda = datumVremePregleda,
                    PacijentId = ZahtevZaPregled.Pacijent.Id,
                    ZahtevZaPregledId = ZahtevZaPregled.Id
                });

                if (result.Succeeded)
                {
                    dlgForm.SetShouldDisposeOnChildClose(true);
                    Close();
                    dlgSuccess.ShowDialog();
                    Dispose();
                }
            }
        }

        private bool ValidateInputs()
        {
            if (datePregled.Value.Date < DateTime.Now.Date)
            {
                Errors.SetError(datePregled, Resources.InvalidDateMustBeInFuture);
                return false;
            }

            if (datePregled.Value.Date == DateTime.Now.Date 
                && (timePregled.Value.Hour < DateTime.Now.Hour 
                    || (timePregled.Value.Hour < DateTime.Now.Hour && timePregled.Value.Minute < DateTime.Now.Minute)))

            {
                Errors.SetError(timePregled, Resources.InvalidTimeMustBeInFuture);
                return false;
            }

            Errors.Clear();
            return true;
        }
    }
}