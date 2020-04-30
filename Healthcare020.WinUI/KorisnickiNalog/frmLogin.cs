using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.StartMenu;
using System;
using System.Windows.Forms;

namespace Healthcare020.WinUI.KorisnickiNalog
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Login()
        {
            if (!ValidateInput())
            {
                return;
            }

            var username = txtUsername.Text;
            var password = txtPassword.Text;

            Auth.AuthenticateWithPassword(username, password);

            var startMenu = new frmStartMenu { MdiParent = MdiParent };
            startMenu.Show();
            Close();
        }

        private void btnLogin_MouseClick(object sender, MouseEventArgs e)
        {
            Login();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                err.SetError(txtUsername, "Obavezno polje");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                err.SetError(txtPassword, "Obavezno polje");
                return false;
            }

            return true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                Login();
            }
        }
    }
}