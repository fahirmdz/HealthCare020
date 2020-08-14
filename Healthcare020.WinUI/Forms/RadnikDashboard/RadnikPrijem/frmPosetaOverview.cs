using System;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.RadnikPrijem
{
    public partial class frmPosetaOverview : Form
    {
        private static frmPosetaOverview _instance;
        private readonly ZahtevZaPosetuDtoEL ZahtevZaPosetu;

        private readonly APIService _apiService;

        private frmPosetaOverview(ZahtevZaPosetuDtoEL zahtevZaPosetu)
        {
            ZahtevZaPosetu = zahtevZaPosetu;
            _apiService = new APIService(Routes.ZahtevZaPosetuRoute);
            InitializeComponent();
            dateZakazaniDatum.Enabled = timeZakazanoVreme.Enabled = false;
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

        private void frmPosetaOverview_Load(object sender, EventArgs e)
        {
            txtPacijent.Text = ZahtevZaPosetu.PacijentNaLecenju.ImePrezime;
            txtDatumZahteva.Text = ZahtevZaPosetu.DatumVremeKreiranja.ToString("g");
            txtBrojTelefonaPosetioca.Text = ZahtevZaPosetu.BrojTelefonaPosetioca;
            txtIsObradjen.Text = ZahtevZaPosetu.IsObradjen ? "DA" : "NE";

            if (ZahtevZaPosetu.IsObradjen)
            {
                if (ZahtevZaPosetu.ZakazanoDatumVreme != null)
                {
                    dateZakazaniDatum.Value = ZahtevZaPosetu.ZakazanoDatumVreme.Value;
                    timeZakazanoVreme.Value = ZahtevZaPosetu.ZakazanoDatumVreme.Value;
                }
            }
            else
            {
                dateZakazaniDatum.MinDate=DateTime.Now;
                timeZakazanoVreme.MinDate=DateTime.Now;
            }

        }
    }
}