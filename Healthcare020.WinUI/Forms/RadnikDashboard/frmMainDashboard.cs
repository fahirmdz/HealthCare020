using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard
{
    public partial class frmMainDashboard : Form
    {
        private static frmMainDashboard _instance = null;

        public static frmMainDashboard Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmMainDashboard();
                return _instance;
            }
        }

        private frmMainDashboard()
        {
            InitializeComponent();
        }
    }
}