using Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard;
using Healthcare020.WinUI.Forms.RadnikDashboard.RadnikPrijem;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Enums;
using HealthCare020.Core.Request;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;
using Healthcare020.WinUI.Forms.AdminDashboard;

namespace Healthcare020.WinUI.Forms.KorisnickiNalog
{
    public partial class frmLogin : Form
    {
        private static frmLogin _instance;
        private readonly APIService _apiService;

        private frmLogin()
        {
            InitializeComponent();
            txtUsername.Select();
            toolTip.SetToolTip(cbxRememberMe, "Zapamti podatke i automatski me prijavi pri sledećem pokretanju aplikacije");
            _apiService = new APIService(Routes.AccountLockedRoute);
        }

        public static frmLogin Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmLogin();
                }

                return _instance;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            pnlBody.BringToFront();
            txtUsername.Focus();
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            pnlTop.Size = new Size(Width, Height / 2);
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
        }

        public async void Login(string _username = "", string _password = "", bool ExternalLoginCall = false)
        {
            if (ExternalLoginCall)
            {
                txtUsername.Text = _username;
                txtPassword.Text = _password;
            }

            var username = txtUsername.Text;
            var password = txtPassword.Text;

            if (!ValidateInput(setErrors:!ExternalLoginCall))
                return;


            var accountLockedResult =
                await _apiService.Post<bool>(new LoginDto { Username = username, Password = password });
            if (!accountLockedResult.Succeeded)
            {
                if ((int)accountLockedResult.StatusCode == 423)
                {
                    Errors.SetError(txtUsername, Resources.AccountLockedOut);
                    return;
                }
            }

            if (cbxRememberMe.Checked)
            {
                var key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Healthcare020");
                if (key != null)
                {
                    key.SetValue("CurrentUsername", username.Protect());
                    key.SetValue("CurrentPassword", password.Protect());
                    key.Close();
                }
            }

            if (await Auth.AuthenticateWithPassword(username, password))
            {
                Form formToOpen = null;

                switch (Auth.Role)
                {
                    case RoleType.Administrator:
                        formToOpen = frmStartMenuAdministrator.Instance;
                        break;

                    case RoleType.Doktor:
                        formToOpen = frmDoktorMainDashboard.Instance;
                        break;

                    case RoleType.RadnikPrijem:
                        formToOpen = frmRadnikPrijemMainDashboard.Instance;
                        break;

                    case RoleType.MedicinskiTehnicar:
                        break;

                    case RoleType.Pacijent:
                        break;
                }

                if (formToOpen == null)
                    dlgError.ShowDialog("Molimo pokušajte kasnije");

                MainForm.Instance.ReloadUserDropdownMenu();

                formToOpen.OpenAsChildOfControl(Parent);
                Close();
            }
            else
            {
                Errors.SetError(txtPassword, Resources.WrongUsernameOrPasswordMessage);
            }
        }

        private void txtPassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                Login();
            }
        }

        private bool ValidateInput(bool setErrors=true)
        {
            if (!txtUsername.ValidTextInput(Errors, Validation.TextInputType.Mixed,setErrors))
                return false;

            if (!txtPassword.ValidTextInput(Errors, Validation.TextInputType.Mixed,setErrors))
                return false;

            Errors.Clear();
            return true;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            Login();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}