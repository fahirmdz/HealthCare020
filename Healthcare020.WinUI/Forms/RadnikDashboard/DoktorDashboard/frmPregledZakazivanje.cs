using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmPregledZakazivanje : Form
    {
        private static frmPregledZakazivanje _instance;
        private readonly ZahtevZaPregledDtoEL ZahtevZaPregled;

        private readonly APIService _apiService;
        private DateTime RecommendedDateTime;

        private frmPregledZakazivanje(ZahtevZaPregledDtoEL zahtevZaPregled)
        {
            ZahtevZaPregled = zahtevZaPregled;
            _apiService = new APIService(Routes.PreglediRoute);
            InitializeComponent();
            toolTip.SetToolTip(icnRecommendedTime, Resources.RecommendedTimeForPregledMessage);
        }

        public static frmPregledZakazivanje InstanceWithData(ZahtevZaPregledDtoEL zahtevZaPregled)
        {
            if (zahtevZaPregled == null)
                return null;
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmPregledZakazivanje(zahtevZaPregled);
            return _instance;
        }

        private async void frmZahtevZaPregled_Load(object sender, EventArgs e)
        {
            if (ZahtevZaPregled != null)
            {
                _apiService.ChangeRoute(Routes.RecommendPregledTimeRoute);
                var result = await _apiService.GetAsSingle<DateTime>(
                    queryStringCollection: new Dictionary<string, string>
                    {
                        {
                            "godiste",
                            ZahtevZaPregled?.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci?.DatumRodjenja.Year.ToString()
                        }
                    });
                if (result.Succeeded && result.HasData)
                {
                    RecommendedDateTime = result.Data;
                    timePregled.Value = RecommendedDateTime;
                    datePregled.MinDate = DateTime.Now.AddDays(DateTime.Now.Hour < 9 ? 0 : 1);
                }
                else
                {
                    var currentHours = DateTime.Now.Hour;
                    var hoursToAdd = currentHours > 17 ? 31 - currentHours : currentHours < 9 ? 9 - currentHours : 0;
                    timePregled.MinDate = DateTime.Now.AddHours(hoursToAdd);
                    datePregled.MinDate = DateTime.Now.AddDays(hoursToAdd > 9 ? 1 : 0);
                }

                txtZahtevZaPregled.Text = ZahtevZaPregled.Id.ToString();
                txtDoktor.Text = ZahtevZaPregled.Doktor;
                txtPacijent.Text = ZahtevZaPregled.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci?.ImePrezime ?? "N/A";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
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
                    Dispose();
                    await frmDoktorZahteviZaPregledeDisplay.Instance.ReloadData();
                    frmDoktorZahteviZaPregledeDisplay.Instance.ShowSuccess();
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