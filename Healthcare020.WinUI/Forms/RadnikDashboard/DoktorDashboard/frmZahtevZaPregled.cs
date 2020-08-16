using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using HealthCare020.Core.Enums;
using HealthCare020.Core.Models;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmZahtevZaPregled : Form
    {
        private static frmZahtevZaPregled _instance;
        private readonly ZahtevZaPregledDtoEL ZahtevZaPregled;

        private frmZahtevZaPregled(ZahtevZaPregledDtoEL zahtevZaPregled)
        {
            ZahtevZaPregled = zahtevZaPregled;
            InitializeComponent();
            btnZakazi.Visible = !ZahtevZaPregled.IsObradjen && Auth.Role != RoleType.MedicinskiTehnicar;
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
            txtPacijent.Text = ZahtevZaPregled.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci?.ImePrezime ?? "N/A";
            txtNapomena.Text = ZahtevZaPregled.Napomena;
            txtNapomena.ReadOnly = true;
            txtIsObradjen.Text = ZahtevZaPregled.IsObradjen ? "DA" : "NE";
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            dlgForm.SetShouldDisposeOnChildClose(false);
            frmPregledZakazivanje.InstanceWithData(ZahtevZaPregled).OpenAsChildOfControl(Parent);
            dlgForm.SetShouldDisposeOnChildClose(true);
        }
    }
}