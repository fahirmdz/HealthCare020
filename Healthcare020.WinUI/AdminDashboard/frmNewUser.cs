using Healthcare020.WinUI.Dialogs;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.AdminDashboard
{
    public partial class frmNewUser : Form
    {
        private static frmNewUser _instance = null;
        private readonly APIService _apiService;

        private frmNewUser()
        {
            InitializeComponent();
            _apiService = new APIService();

            this.Text = Properties.Resources.frmNewUser;
            foreach (var control in Controls.OfType<MaterialSingleLineTextField>())
            {
                errors.SetIconPadding(control, 10);
            }
            foreach (var control in Controls.OfType<ComboBox>())
            {
                errors.SetIconPadding(control, 10);
            }
        }

        public static frmNewUser Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmNewUser();
                }

                return _instance;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmStartMenuAdmin.Instance.OpenChildForm(frmUsers.Instance);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputValues())
            {
                var newUser = new KorisnickiNalogUpsertDto
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    ConfirmPassword = txtConfirmPassword.Text
                };

                var result = await _apiService.Post<KorisnickiNalogDtoLL>(newUser);

                if (result.Succeeded)
                {
                    dlgSuccess.ShowDialog();
                    frmStartMenuAdmin.Instance.OpenChildForm(frmUsers.Instance);
                }
                else
                {
                    dlgError.ShowDialog();
                }
            }
        }

        private bool ValidateInputValues()
        {
            if (cmbVrstaRadnika.SelectedIndex == -1)
            {
                errors.SetError(cmbVrstaRadnika, Properties.Resources.RequiredField);
                return false;
            }

            if (cmbImePrezime.SelectedIndex == -1)
            {
                errors.SetError(cmbImePrezime, Properties.Resources.RequiredField);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errors.SetError(txtUsername, Properties.Resources.RequiredField);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errors.SetError(txtPassword, Properties.Resources.RequiredField);
                return false;
            }

            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                errors.SetError(txtConfirmPassword, Properties.Resources.DifferentPasswords);
                return false;
            }

            return true;
        }

        private void frmNewUser_Load(object sender, EventArgs e)
        {
            var typesOfUsers = new List<string>
            {
                "Doktor", "Medicinski tehnicar", "Radnik na prijemu"
            };

            cmbVrstaRadnika.DataSource = typesOfUsers;
        }

        private async void cmbVrstaRadnika_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVrstaRadnika.SelectedIndex == -1)
                return;

            List<RadnikDtoEL> radnici;

            //switch (cmbVrstaRadnika.SelectedIndex)+
            //{
            //    case 0:
            //        {
            //            _apiService.AddRoute(Routes.DoktoriRoute);

            //            break;
            //        }
            //    case 1:
            //        {
            //            _apiService.AddRoute(Routes.MedicinskiTehnicariRoute);
            //            radnici = await GetRadnici<List<MedicinskiTehnicarDtoEL>>() as List<RadnikDtoEL>;
            //            break;
            //        }
            //    case 2:
            //        {
            //            _apiService.AddRoute(Routes.RadniciPrijemRoute);
            //            radnici = await GetRadnici<List<RadnikPrijemDtoEL>>() as List<RadnikDtoEL>;
            //            break;
            //        }
            //}

            //var listForCmbImePrezime = radnici.Select(x => new
            //{
            //    Id = x.
            //})
        }

        //private async Task<bool> SetCmbImePrezime<T>()
        //{
        //    var result = await _apiService.Get<List<T>>();
        //    if (!result.Succeeded)
        //        return false;

        //    var radnici = result.Data;

        //    c
        //}
    }
}