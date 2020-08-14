using System;
using System.Windows.Forms;
using Healthcare020.WinUI.Helpers;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.RadnikPrijem
{
    public partial class frmRadnikPrijemDataDisplay : Form
    {
        private static frmRadnikPrijemDataDisplay _instance;
        private readonly Form DataForm;

        /// <summary>
        /// Get instance of form
        /// </summary>
        /// <param name="dataForm">Display data form</param>
        public static frmRadnikPrijemDataDisplay InstanceWithData(Form dataForm)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmRadnikPrijemDataDisplay(dataForm);
            return _instance;
        }

        private frmRadnikPrijemDataDisplay(Form dataForm)
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
            frmRadnikPrijemMainDashboard.Instance.OpenAsChildOfControl(Parent);
        }
    }
}