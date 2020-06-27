using HealthCare020.Core.Models;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmZahtevZaPregled : Form
    {
        private static frmZahtevZaPregled _instance = null;
        private ZahtevZaPregledDtoEL ZahtevZaPregled;

        public static frmZahtevZaPregled InstanceWithData(ZahtevZaPregledDtoEL zahtevZaPregled)
        {
            if (zahtevZaPregled == null)
                return null;
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmZahtevZaPregled(zahtevZaPregled);
            return _instance;
        }

        private frmZahtevZaPregled(ZahtevZaPregledDtoEL zahtevZaPregled)
        {
            ZahtevZaPregled = zahtevZaPregled;
            InitializeComponent();
        }

        private void frmZahtevZaPregled_Load(object sender, System.EventArgs e)
        {
            txtDatumZahteva.Text = ZahtevZaPregled.DatumVreme.ToString("g");
            txtDoktor.Text = ZahtevZaPregled.Doktor;
            txtPacijent.Text = ZahtevZaPregled.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci?.ImePrezime()??"N/A";
            txtNapomena.Text = ZahtevZaPregled.Napomena;
            txtNapomena.ReadOnly = true;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Parent.Dispose();
            Dispose();
        }
    }
}