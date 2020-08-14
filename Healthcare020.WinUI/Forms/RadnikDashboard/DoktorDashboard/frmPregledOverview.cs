using HealthCare020.Core.Models;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmPregledOverview : Form
    {
        private static frmPregledOverview _instance;

        private frmPregledOverview(PregledDtoEL pregled)
        {
            var _pregled = pregled;
            InitializeComponent();
            txtDoktor.Text = _pregled.Doktor;
            txtDatumVreme.Text = _pregled.DatumPregleda.ToString("g");
            txtPacijent.Text = _pregled.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci?.ImePrezime ?? "N/A";
        }

        public static frmPregledOverview InstanceWithData(PregledDtoEL pregled, bool newInstance = false)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmPregledOverview(pregled);
            else if (newInstance)
            {
                _instance.Dispose();
                _instance = new frmPregledOverview(pregled);
            }
            return _instance;
        }
    }
}