using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.StartMenu;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Healthcare020.WinUI.KorisnickiNalog
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        private void Login()
        {
            if (!ValidateInput())
            {
                return;
            }

            var username = txtUsername.Text;
            var password = txtPassword.Text;

            if (Auth.AuthenticateWithPassword(username, password))
            {
                var startMenu = new frmStartMenu { MdiParent = MdiParent };
                startMenu.Show();
                Close();
            }
            else
            {
                err.SetError(txtPassword,"Netačan username ili password");
            }
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

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                Login();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MdiParent.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {

        }
    }
}