using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.KorisnickiNalog;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Healthcare020.WinUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(this.CreateRoundRect(15, 15));
        }

        private int mouseX = 0, mouseY = 0;
        private bool mouseDown;

      
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            frmLogin child = new frmLogin();
            child.MdiParent = this;
            child.Left = 0;
            child.Top = 0;
            var parentSize = ClientRectangle.Size;
            parentSize.Height -= 4;
            parentSize.Width -= 4;
            child.Size = parentSize;
            child.AutoScroll = false;
            AutoScroll = false;
            child.Show();

            picClose.BringToFront();
            picMaximize.BringToFront();
            picMinimize.BringToFront();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //===== Draggable form =====
        private void panelMainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void panelMainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panelMainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }
    }
}