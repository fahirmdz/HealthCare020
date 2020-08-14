using Healthcare020.WinUI.Forms.AbstractForms;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    public sealed partial class frmSecurity : DisplayDataForm<Person>
    {
        private static frmSecurity _instance;

        public static frmSecurity Instance
        {
            get
            {
                if (!Auth.IsAuthenticated())
                    return null;
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmSecurity();
                }

                return _instance;
            }
        }

        private frmSecurity()
        {
            pnlSearch.Visible = btnNew.Visible = false;

            _apiService = new APIService(Routes.FaceRecognitionPersonGroupPersonsRoute);
            _dataForDgrv = new BindingSource();
            Text = Resources.frmSecurityTitle;

            var Id = new DataGridViewColumn
            {
                DataPropertyName = "PersonId",
                HeaderText = "ID",
                Name = "ID",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Username = new DataGridViewColumn
            {
                DataPropertyName = "Name",
                HeaderText = Resources.Username,
                Name = "Username",
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var Brisanje = new DataGridViewButtonColumn
            {
                HeaderText = Resources.DeleteVerb,
                Name = Resources.DeleteIt,
                Text = Resources.DeleteIt,
                ToolTipText = Resources.DeletePersonFromGroup,
                UseColumnTextForButtonValue = true,
                CellTemplate = new DataGridViewButtonCell { UseColumnTextForButtonValue = true, ToolTipText = Resources.DeletePersonFromGroup },
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Transparent, SelectionBackColor = Color.Transparent },
            };

            DgrvColumnsStyle();
            AddColumnsToMainDgrv(new[] { Id, Username, Brisanje });

            InitializeComponent();
            btnBack.Visible = false;
        }

        protected override async void dgrvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(MainDgrv.CurrentRow?.DataBoundItem is Person person))
                return;

            //Delete person from group
            if (e.ColumnIndex == 2)
            {
                var promptDialog = dlgPropmpt.ShowDialog();

                if (promptDialog?.DialogResult == DialogResult.OK)
                {
                    var result = await _apiService.Delete<Person>(person.PersonId);

                    if (result.Succeeded)
                    {
                        _dataForDgrv.Remove(person);
                        dlgSuccess.ShowDialog();
                    }
                }
            }
        }

        protected override void btnNew_Click(object sender, EventArgs e)
        {
            frmNewUser.Instance.OpenAsChildOfControl(Parent);
        }
    }
}