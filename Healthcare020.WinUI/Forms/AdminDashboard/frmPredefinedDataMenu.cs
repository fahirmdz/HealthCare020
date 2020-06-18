using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    public partial class frmPredefinedDataMenu : Form
    {
        private static frmPredefinedDataMenu _instance;

        public static frmPredefinedDataMenu Instance
        {
            get
            {
                if(_instance==null || _instance.IsDisposed)
                    _instance=new frmPredefinedDataMenu();

                return _instance;
            }
        }

        public frmPredefinedDataMenu()
        {
            InitializeComponent();
            Text = Properties.Resources.frmPredefinedData;

        }

        private void frmPredefinedDataMenu_Load(object sender, EventArgs e)
        {
            frmStartMenuAdmin.Instance.SetClickEventToCloseUserMenu(Controls);
            frmStartMenuAdmin.Instance.SetClickEventToCloseUserMenu(pnlMain.Controls);
        }
    }
}
