using System;
using HealthCare020.Core.Models;
using System.Windows.Forms;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Request;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Services;

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
            _apiService=new APIService(Routes.PreglediRoute);
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
            datePregled.MinDate=DateTime.Now;
            timePregled.MinDate=DateTime.Now;
            txtDoktor.Text = ZahtevZaPregled.Doktor;
            txtPacijent.Text = ZahtevZaPregled.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci?.ImePrezime()??"N/A";
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            var datumVremePregleda = new DateTime(datePregled.Value.Year, datePregled.Value.Month,
                datePregled.Value.Day, timePregled.Value.Hour, timePregled.Value.Minute,0);

            var result = await _apiService.Post<PregledDtoLL>(new PregledUpsertDto
            {
                DatumPregleda = datumVremePregleda,
                PacijentId = ZahtevZaPregled.Pacijent.Id,
                ZahtevZaPregledId = ZahtevZaPregled.Id
            });

            if (result.Succeeded)
            {
                Close();
                Dispose();
                Parent.Dispose();
                dlgSuccess.ShowDialog();
            }
        }
    }
}