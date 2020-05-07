using FontAwesome.Sharp;
using Healthcare020.WinUI.Exceptions;
using Healthcare020.WinUI.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.AdminDashboard
{
    public partial class frmStartMenuAdmin : Form
    {
        private static frmStartMenuAdmin _instance;

        //Fields
        private IconButton currentBtn;

        private Panel leftBorderBtn;
        private Form currentChildForm;

        public static frmStartMenuAdmin Instance
        {
            get
            {
                //if (!Auth.IsAuthenticated())
                //    return null;

                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmStartMenuAdmin();
                }

                return _instance;
            }
        }

        private frmStartMenuAdmin()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            
        }

        private void frmStartMenuAdmin_Load(object sender, EventArgs e)
        {
            SetClickEventToCloseUserMenu(Controls);
            SetClickEventToCloseUserMenu(panelMenu.Controls);
            SetClickEventToCloseUserMenu(pnlTop.Controls);
        }

        private void SetClickEventToCloseUserMenu(Control.ControlCollection controls)
        {
            foreach (Control control in Controls)
            {
                control.Click += control_Click;
            }
        }

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(0, 31, 61);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(15, 200, 200);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0, 190, 190);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(73, 96, 117);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var frmUsers = AdminDashboard.frmUsers.Instance;
            if (frmUsers != null)
            {
                OpenChildForm(frmUsers.Instance);
                SetClickEventToCloseUserMenu(frmUsers.Controls);
            }
            else
            {
                MessageBox.Show("Niste prijavljeni na sistem!");
            }
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }

        private void btnPredefinedData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
                currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = RGBColors.color5;
            lblTitleChildForm.Text = "Home";
        }

        private void OpenChildForm(Form childForm)
        {
            if (childForm == currentChildForm)
                return;

            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(childForm);
            pnlBody.Tag = childForm;
            childForm.BringToFront();
            lblTitleChildForm.Text = childForm.Text;
            childForm.Show();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CloseUserDropdownMenu()
        {
            if (pnlUserMenuDropdown.Visible)
                pnlUserMenuDropdown.Hide();
        }

        private void control_Click(object sender, EventArgs e)
        {
            CloseUserDropdownMenu();
        }
    }
}