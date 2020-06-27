using Healthcare020.WinUI.Helpers;
using System;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmDoktorPregledi : Form
    {
        private static frmDoktorPregledi _instance = null;
        private Form DataForm;

        /// <summary>
        /// Get instance of form
        /// </summary>
        /// <param name="dataForm">Display data form</param>
        public static frmDoktorPregledi InstanceWithData(Form dataForm)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmDoktorPregledi(dataForm);
            return _instance;
        }

        private frmDoktorPregledi(Form dataForm)
        {
            DataForm = dataForm;
            InitializeComponent();
        }

        private void frmDoktorPregledi_Load(object sender, EventArgs e)
        {
            DataForm.OpenAsChildOfControl(pnlData);
        }
    }
}