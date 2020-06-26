using Healthcare020.WinUI.Forms.AdminDashboard;
using Healthcare020.WinUI.Forms.KorisnickiNalog;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.CustomElements;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms
{
    public partial class MainForm : Form
    {
        private static MainForm _instance;
        private Form currentChild;

        public static MainForm Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new MainForm();
                }

                return _instance;
            }
        }

        private MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Healthcare020_Icon;
            Text = string.Empty;
            ControlBox = false;
            DoubleBuffered = true;
            KeyPreview = true;
            currentChild = null;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            //Region = Region.FromHrgn(this.CreateRoundRect(20, 20));

            if (currentChild == null)
            {
                await Auth.AuthenticateWithPassword("test", "testtest");
                frmStartMenuAdmin.Instance.OpenAsChildOfControl(panelDesktop);
            }

            picClose.BringToFront();
            picMaximize.BringToFront();
            picClose.BringToFront();
            picClose.SizeMode = PictureBoxSizeMode.CenterImage;
            picClose.SizeMode = PictureBoxSizeMode.CenterImage;
            picMaximize.SizeMode = PictureBoxSizeMode.CenterImage;

            //Set event to close user dropdown menu on every click
            pnlTop.SetMouseClickEventToChildControls(userMenuDropdown_MouseClick, true,
                x => !(x is UserMenuButton));
        }

        //===== Draggable form =====

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelMainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            //mouseDown = true;
            //mouseX = Cursor.Position.X - this.Left;
            //mouseY = Cursor.Position.Y - this.Top;
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {
        }

        private void picClose_MouseHover(object sender, EventArgs e)
        {
            picClose.BackColor = Color.FromArgb(0, 170, 180);
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.BackColor = Color.FromArgb(0, 190, 190);
        }

        private void picMaximize_MouseHover(object sender, EventArgs e)
        {
            picMaximize.BackColor = Color.FromArgb(0, 170, 180);
        }

        private void picMaximize_MouseLeave(object sender, EventArgs e)
        {
            picMaximize.BackColor = Color.FromArgb(0, 190, 190);
        }

        private void picMinimize_MouseHover(object sender, EventArgs e)
        {
            picMinimize.BackColor = Color.FromArgb(0, 170, 180);
        }

        private void picMinimize_MouseLeave(object sender, EventArgs e)
        {
            picMinimize.BackColor = Color.FromArgb(0, 190, 190);
        }

        private void picClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public Panel GetMainPanel()
        {
            return panelDesktop;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
        }

        public void SetLoginAsChildForm()
        {
            var loginForm = frmLogin.Instance;
            currentChild.Dispose();
            loginForm.OpenAsChildOfControl(panelDesktop);
        }

        private void panelDesktop_ControlAdded(object sender, ControlEventArgs e)
        {
            currentChild = panelDesktop.Controls.OfType<Form>().First();

            //Set event to close user dropdown menu on every click
            currentChild.SetMouseClickEventToChildControls(userMenuDropdown_MouseClick, true,
                x => !(x is UserMenuDropdownPanel) && !(x is UserMenuButton),
                nestingCounter: currentChild is frmStartMenuAdmin ? 3 : 2);

            if (currentChild is frmLogin || currentChild is frmStartMenuAdmin)
            {
                pnlTop.Hide();
            }
            else
            {
                pnlTop.Show();
            }
        }

        protected void userMenuDropdown_MouseClick(object sender, EventArgs e)
        {
            if (userMenuDropdown.Visible)
                userMenuDropdown.Hide();
        }
    }
}