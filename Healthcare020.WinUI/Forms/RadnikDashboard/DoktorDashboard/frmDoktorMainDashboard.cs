﻿using System.Windows.Forms;
using Healthcare020.WinUI.Helpers;

namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    public partial class frmDoktorMainDashboard : Form
    {
        private static frmDoktorMainDashboard _instance = null;

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
    }
}