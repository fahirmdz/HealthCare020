using System;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using System.Windows.Forms;
using HealthCare020.Core.Request;
using Healthcare020.WinUI.Helpers.Dialogs;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.RadnikPrijem
{
    public partial class frmPosetaOverview : Form
    {
        private static frmPosetaOverview _instance = null;
        private ZahtevZaPosetuDtoEL ZahtevZaPosetu;

        private readonly APIService _apiService;

        private frmPosetaOverview(ZahtevZaPosetuDtoEL zahtevZaPosetu)
        {
            ZahtevZaPosetu = zahtevZaPosetu;
            _apiService = new APIService(Routes.ZahtevZaPosetuRoute);
            InitializeComponent();
        }

        public static frmPosetaOverview InstanceWithData(ZahtevZaPosetuDtoEL zahtevZaPosetu, bool newInstance = false)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmPosetaOverview(zahtevZaPosetu);
            else if (newInstance)
            {
                _instance.Dispose();
                _instance = new frmPosetaOverview(zahtevZaPosetu);
            }
            return _instance;
        }

        private void frmPosetaOverview_Load(object sender, System.EventArgs e)
        {
            txtPacijent.Text = ZahtevZaPosetu.PacijentNaLecenju.LicniPodaci.ImePrezime;
            txtDatumZahteva.Text = ZahtevZaPosetu.DatumVremeKreiranja.ToString("g");
            txtBrojTelefonaPosetioca.Text = ZahtevZaPosetu.BrojTelefonaPosetioca;
            txtIsObradjen.Text = ZahtevZaPosetu.IsObradjen ? "DA" : "NE";
         
            if (ZahtevZaPosetu.IsObradjen)
            {
                dateZakazaniDatum.Value = ZahtevZaPosetu.ZakazanoDatumVreme.Value;
                timeZakazanoVreme.Value = ZahtevZaPosetu.ZakazanoDatumVreme.Value;
            }
            else
            {
                dateZakazaniDatum.MinDate=DateTime.Now;
                timeZakazanoVreme.MinDate=DateTime.Now;
            }
            
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var dateTimeForUpdating=new DateTime(dateZakazaniDatum.Value.Year,dateZakazaniDatum.Value.Month,dateZakazaniDatum.Value.Day,timeZakazanoVreme.Value.Hour,timeZakazanoVreme.Value.Minute,0);


            var result = await _apiService.PartiallyUpdate<ZahtevZaPosetuDtoLL>(ZahtevZaPosetu.Id, new[]{new JsonPatchDto("replace","/ZakazanoDatumVreme", dateTimeForUpdating)});

            ZahtevZaPosetu.ZakazanoDatumVreme = dateTimeForUpdating;

            if(result.Succeeded)
                dlgSuccess.ShowDialog();
        }
    }
}