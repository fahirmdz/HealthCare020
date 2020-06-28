using HealthCare020.Core.Models;
using System.Windows.Forms;
using HealthCare020.Core.Constants;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmZahtevZaPregled : Form
    {
        private static frmZahtevZaPregled _instance = null;
        private ZahtevZaPregledDtoEL ZahtevZaPregled;

        private readonly APIService _apiService;

        private frmZahtevZaPregled(ZahtevZaPregledDtoEL zahtevZaPregled)
        {
            ZahtevZaPregled = zahtevZaPregled;
            _apiService=new APIService(Routes.ZahteviZaPregledRoute);
            InitializeComponent();
            btnZakazi.Visible = !ZahtevZaPregled.IsObradjen;
        }

        public static frmZahtevZaPregled InstanceWithData(ZahtevZaPregledDtoEL zahtevZaPregled)
        {
            if (zahtevZaPregled == null)
                return null;
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmZahtevZaPregled(zahtevZaPregled);
            return _instance;
        }
        private void frmZahtevZaPregled_Load(object sender, System.EventArgs e)
        {
            txtDatumZahteva.Text = ZahtevZaPregled.DatumVreme.ToString("g");
            txtDoktor.Text = ZahtevZaPregled.Doktor;
            txtPacijent.Text = ZahtevZaPregled.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci?.ImePrezime()??"N/A";
            txtNapomena.Text = ZahtevZaPregled.Napomena;
            txtNapomena.ReadOnly = true;
            txtIsObradjen.Text = ZahtevZaPregled.IsObradjen ? "DA" : "NE";
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            frmPregledZakazivanje.InstanceWithData(ZahtevZaPregled).OpenAsChildOfControl(Parent);
        }
    }
}