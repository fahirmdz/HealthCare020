using System;
using System.Drawing;
using System.Windows.Forms;
using Healthcare020.WinUI.Forms.AdminDashboard;
using Healthcare020.WinUI.Helpers;

namespace Healthcare020.WinUI.Forms.KorisnickiNalog
{
    public partial class frmLogin : Form
    {

        private static frmLogin _instance;

        public static frmLogin Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance=new frmLogin();
                }

                return _instance;
            }
        }
        private frmLogin()
        {
            InitializeComponent();
            txtUsername.Select();  
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            pnlBody.BringToFront();
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
                var startMenu = frmStartMenuAdmin.Instance;
                startMenu.ShowAsNextMdiChild(MainForm.Instance.GetMainPanel());
            }
            else
            {
                err.SetError(txtPassword, "Netačan username ili password");
            }
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtPassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                Login();
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            pnlTop.Size=new Size(Width,this.Height/2);
        }
    }
}