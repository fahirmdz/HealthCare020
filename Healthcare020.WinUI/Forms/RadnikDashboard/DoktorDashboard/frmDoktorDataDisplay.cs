using Healthcare020.WinUI.Helpers;
using System;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmDoktorDataDisplay : Form
    {
        private static frmDoktorDataDisplay _instance;
        private readonly Form DataForm;

        /// <summary>
        /// Get instance of form
        /// </summary>
        /// <param name="dataForm">Display data form</param>
        public static frmDoktorDataDisplay InstanceWithData(Form dataForm)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmDoktorDataDisplay(dataForm);
            return _instance;
        }

        private frmDoktorDataDisplay(Form dataForm)
        {
            DataForm = dataForm;
            InitializeComponent();
            lblTitle.Text = DataForm.Text;
        }

        private void frmDoktorPregledi_Load(object sender, EventArgs e)
        {
            DataForm.OpenAsChildOfControl(pnlData);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmDoktorMainDashboard.Instance.OpenAsChildOfControl(Parent);
        }
    }
}