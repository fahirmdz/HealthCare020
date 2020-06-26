using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Enums;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Services;
using MaterialSkin.Controls;

namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    public partial class frmNewUser : Form
    {
        private static frmNewUser _instance = null;
        private readonly APIService _apiService;

        private frmNewUser()
        {
            InitializeComponent();
            _apiService = new APIService(Routes.KorisniciRoute);

            TopLevel = false;
            Text = Properties.Resources.frmNewUser;
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
            frmUsers.Instance.OpenAsChildOfControl(Parent);
        }
        

        private void frmNewUser_Load(object sender, EventArgs e)
        {
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputValues())
            {
                string roleTypeChecked=string.Empty;
                if (rbtnAdmin.Checked) roleTypeChecked = RoleType.Administrator.ToDescriptionString();
                if (rbtnDoktor.Checked) roleTypeChecked = RoleType.Doktor.ToDescriptionString();
                if (rbtnRadnikPrijem.Checked) roleTypeChecked = RoleType.RadnikPrijem.ToDescriptionString();
                if (rbtnMedTehnicar.Checked) roleTypeChecked = RoleType.MedicinskiTehnicar.ToDescriptionString();

                var newUser = new KorisnickiNalogUpsertDto
                {
                    Username=txtUsername.Text,
                    Password = txtPassword.Text,
                    ConfirmPassword = txtConfirmPassword.Text,
                    RoleType = roleTypeChecked
                };

                var result = await _apiService.Post<KorisnickiNalogDtoLL>(newUser);

                if (result.Succeeded)
                {
                    dlgSuccess.ShowDialog();
                    frmUsers.Instance.OpenAsChildOfControl(Parent);
                }
            }
        }

        private bool ValidateInputValues()
        {
            if (string.IsNullOrWhiteSpace(txtImePrezime.Text))
            {
                errors.SetError(txtImePrezime, Properties.Resources.RequiredField);
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

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errors.SetError(txtConfirmPassword, Properties.Resources.DifferentPasswords);
                return false;
            }

            errors.Clear();
            return true;
        }

#pragma warning disable 1998

        private async void cmbVrstaRadnika_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void frmNewUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            errors.Clear();
        }



#pragma warning restore 1998

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