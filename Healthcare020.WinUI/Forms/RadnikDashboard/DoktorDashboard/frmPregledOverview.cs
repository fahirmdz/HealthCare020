using HealthCare020.Core.Models;
using System;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmPregledOverview : Form
    {
        private static frmPregledOverview _instance = null;
        private PregledDtoEL Pregled;

        private frmPregledOverview(PregledDtoEL pregled)
        {
            Pregled = pregled;
            InitializeComponent();
            txtDoktor.Text = Pregled.Doktor;
            txtDatumVreme.Text = Pregled.DatumPregleda.ToString("g");
            txtPacijent.Text = Pregled.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci?.ImePrezime ?? "N/A";
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

        private void frmPregledOverview_Load(object sender, EventArgs e)
        {
        }
    }
}