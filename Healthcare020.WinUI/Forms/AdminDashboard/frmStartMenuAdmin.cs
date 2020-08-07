using FontAwesome.Sharp;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.CustomElements;
using Healthcare020.WinUI.Helpers.Dialogs;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdministratorDashboard
{
    public partial class frmStartMenuAdministrator : Form
    {
        private static frmStartMenuAdministrator _instance;

        //Fields
        private IconButton currentBtn;

        private Form currentChildForm;
        private Panel leftBorderBtn;

        private frmStartMenuAdministrator()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
        }

        public static frmStartMenuAdministrator Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmStartMenuAdministrator();
                }

                return _instance;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            currentChildForm?.Dispose();
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            foreach (var form in pnlBody.Controls.OfType<Form>())
            {
                form.Dispose();
                form.Close();
            }
            btnStatistics.PerformClick();
            Reset();
        }

        private void btnPredefinedData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            var frmPredefinedData = frmPredefinedDataMenu.Instance;
            if (frmPredefinedData != null)
            {
                frmPredefinedData.OpenAsChildOfControl(pnlBody);
            }
            else
            {
                dlgError.ShowDialog(Properties.Resources.NotLoggedIn);
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            var frmStatisticsMenu = AdministratorDashboard.frmStatisticsMenu.Instance;
            if (frmStatisticsMenu != null)
            {
                frmStatisticsMenu.OpenAsChildOfControl(pnlBody);
            }
            else
            {
                dlgError.ShowDialog(Properties.Resources.NotLoggedIn);
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var frmUsers = AdministratorDashboard.frmUsers.Instance;
            if (frmUsers != null)
            {
                frmUsers.OpenAsChildOfControl(pnlBody);
            }
            else
            {
                MessageBox.Show(Properties.Resources.NotLoggedIn);
            }
        }

        private void userMenuDropdown_MouseClick(object sender, EventArgs e)
        {
            if (pnlUserMenuDropdown.Visible)
                pnlUserMenuDropdown.Hide();
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0, 190, 190);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(73, 96, 117);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void frmStartMenuAdministrator_Load(object sender, EventArgs e)
        {
            if (!Auth.IsAuthenticated())
            {
                Close();
                Dispose();
            }

            //Set event to close user drop down menu on click
            this.SetMouseClickEventToChildControls(userMenuDropdown_MouseClick, true, x => !(x is UserMenuButton) && !(x is UserMenuDropdownPanel));
            btnStatistics.PerformClick();
        }

        private void pnlBody_ControlAdded(object sender, ControlEventArgs e)
        {
            currentChildForm = pnlBody.Controls.OfType<Form>().First();
            if (currentChildForm == null)
                return;

            lblTitleChildForm.Text = currentChildForm.Text;

            //Set event to close user drop down menu on click
            currentChildForm.SetMouseClickEventToChildControls(userMenuDropdown_MouseClick, true);
        }

        private void Reset()
        {
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = RGBColors.color5;
            lblTitleChildForm.Text = "Home";
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(0, 31, 61);
        }

        private void iconCurrentChildForm_Click(object sender, EventArgs e)
        {
            btnStatistics.PerformClick();
        }
    }
}