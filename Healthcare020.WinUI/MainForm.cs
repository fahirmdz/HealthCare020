using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.KorisnickiNalog;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Healthcare020.WinUI
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
            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Region = Region.FromHrgn(this.CreateRoundRect(20, 20));

            var loginForm = frmLogin.Instance;
            currentChild = loginForm;
            loginForm.ShowAsNextMdiChild(panelDesktop);

            picClose.BringToFront();
            picMaximize.BringToFront();
            picClose.BringToFront();
            picClose.SizeMode = PictureBoxSizeMode.CenterImage;
            picClose.SizeMode = PictureBoxSizeMode.CenterImage;
            picMaximize.SizeMode = PictureBoxSizeMode.CenterImage;
            lblCopyright.BringToFront();
        }

        //===== Draggable form =====

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

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

        //Helper  methods
        public void SetCopyrightPanelColor(Color color)
        {
            pnlCopyright.BackColor = color;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
        }
    }
}