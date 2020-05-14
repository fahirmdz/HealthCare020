using Healthcare020.WinUI.Dialogs;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Healthcare020.WinUI.AdminDashboard
{
    public partial class frmNewUser : Form
    {
        private static frmNewUser _instance = null;
        private readonly APIService _korisniciAPIService;

        private frmNewUser()
        {
            InitializeComponent();
            _korisniciAPIService = new APIService("korisnici");

            this.Text = Properties.Resources.frmNewUser;
            foreach (var control in Controls.OfType<MaterialSingleLineTextField>())
            {
                errors.SetIconPadding(control,10);
            }
            foreach (var control in Controls.OfType<ComboBox>())
            {
                errors.SetIconPadding(control,10);
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

                var result = await _korisniciAPIService.Post<KorisnickiNalogDtoLL>(newUser);

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

            if (cmbImePrezimeStacOd.SelectedIndex == -1)
            {
                errors.SetError(cmbImePrezimeStacOd, Properties.Resources.RequiredField);
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
        }
    }
}