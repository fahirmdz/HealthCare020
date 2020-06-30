using System.Windows.Forms;
using Flurl.Http.Configuration;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.RadnikPrijem
{
    public partial class frmRadnikPrijemMainDashboard : Form
    {
        private static frmRadnikPrijemMainDashboard _instance = null;
        private readonly APIService _apiService;

        public static frmRadnikPrijemMainDashboard Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmRadnikPrijemMainDashboard();
                return _instance;
            }
        }

        public frmRadnikPrijemMainDashboard()
        {
            _apiService=new APIService(Routes.ZahtevZaPosetuRoute);
            InitializeComponent();
        }

        private void btnPosete_Click(object sender, System.EventArgs e)
        {
            frmRadnikPrijemDataDisplay.InstanceWithData(frmRadnikPrijemPosete.InstanceWithData()).OpenAsChildOfControl(Parent);
        }

        private void btnZahteviZaPosetuNaCekanju_Click(object sender, System.EventArgs e)
        {
            frmRadnikPrijemDataDisplay.InstanceWithData(frmRadnikPrijemPosete.InstanceWithData(NeobradjeniZahteviOnly:true)).OpenAsChildOfControl(Parent);

        }

        private void btnOdobreniZahtevi_Click(object sender, System.EventArgs e)
        {
            frmRadnikPrijemDataDisplay.InstanceWithData(frmRadnikPrijemPosete.InstanceWithData(ObradjeniZahteviOnly:true)).OpenAsChildOfControl(Parent);
        }

        private async void btnAutoSchedulePosete_Click(object sender, System.EventArgs e)
        {
            _apiService.ChangeRoute(Routes.ZahteviZaPosetuAutoSchedulingRoute);
            var schedulingResult = await _apiService.Get<ZahtevZaPregledDtoEL>();
            if(schedulingResult.Succeeded)
                dlgSuccess.ShowDialog();
        }
    }
}