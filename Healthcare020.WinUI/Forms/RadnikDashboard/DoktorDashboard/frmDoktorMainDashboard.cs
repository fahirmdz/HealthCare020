using System.Windows.Forms;
using HealthCare020.Core.Enums;
using Healthcare020.WinUI.Forms.RadnikDashboard.RadnikPrijem;
using Healthcare020.WinUI.Helpers;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmDoktorMainDashboard : Form
    {
        private static frmDoktorMainDashboard _instance;

        public static frmDoktorMainDashboard Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmDoktorMainDashboard();
                return _instance;
            }
        }

        private frmDoktorMainDashboard()
        {
            InitializeComponent();
            btnPosete.Visible = Auth.Role == RoleType.MedicinskiTehnicar;
        }

        private void btnSviPregledi_Click(object sender, System.EventArgs e)
        {
            frmDoktorDataDisplay.InstanceWithData(frmDoktorPreglediDisplay.InstanceWithData()).OpenAsChildOfControl(Parent);
        }

        private void btnZakazaniPregledi_Click(object sender, System.EventArgs e)
        {
            frmDoktorDataDisplay.InstanceWithData(frmDoktorPreglediDisplay.InstanceWithData(OnlyZakazani:true)).OpenAsChildOfControl(Parent);
        }

        private void btnPreglediNaCekanju_Click(object sender, System.EventArgs e)
        {
            frmDoktorDataDisplay.InstanceWithData(frmDoktorZahteviZaPregledeDisplay.Instance).OpenAsChildOfControl(Parent);
        }

        private void btnLekarskaUverenja_Click(object sender, System.EventArgs e)
        {
            frmDoktorDataDisplay.InstanceWithData(frmLekarskaUverenja.Instance).OpenAsChildOfControl(Parent);
        }

        private void btnUputnice_Click(object sender, System.EventArgs e)
        {
            frmDoktorDataDisplay.InstanceWithData(frmUputnice.InstanceWithData()).OpenAsChildOfControl(Parent);
        }

        private void btnUputniceNamenjene_Click(object sender, System.EventArgs e)
        {
            frmDoktorDataDisplay.InstanceWithData(frmUputnice.InstanceWithData(NamenjenjeTrenutnoLogovanomKorisniku:true)).OpenAsChildOfControl(Parent);
        }

        private void btnPosete_Click(object sender, System.EventArgs e)
        {
            frmRadnikPrijemMainDashboard.Instance.OpenAsChildOfControl(Parent);
        }
    }
}