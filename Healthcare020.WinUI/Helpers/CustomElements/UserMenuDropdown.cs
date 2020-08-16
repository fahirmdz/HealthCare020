using FontAwesome.Sharp;
using Healthcare020.WinUI.Forms.AdminDashboard;
using Healthcare020.WinUI.Forms.KorisnickiNalog;
using Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard;
using Healthcare020.WinUI.Forms.RadnikDashboard.RadnikPrijem;
using HealthCare020.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.CustomElements
{
    public sealed class UserMenuDropdownPanel : Panel
    {
        private UserMenuButton _toggler;

        public UserMenuDropdownPanel()
        {
            Name = "pnlUserMenuDropdown";
            Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            BackColor = Color.FromArgb(0, 190, 190);
            BorderStyle = BorderStyle.None;

            ArrangeButtons();

            Hide();
        }

        public void ArrangeButtons()
        {
            var buttonsFromControls = Controls.OfType<IconButton>();
            foreach (var btn in buttonsFromControls)
            {
                Controls.Remove(btn);
            }

            var buttons = new List<IconButton>();

            if (Auth.Role != RoleType.Administrator)
            {
                //Dashboard button
                var dashboard = new IconButton { Name = "btnDashboard", Text = "Dashboard", IconChar = IconChar.TachometerAlt };
                dashboard.Click += dashboardButton_OnClick;

                buttons.Add(dashboard);

                //Profile button
                var profileButton = new IconButton { Name = "btnProfile", Text = "Profile", IconChar = IconChar.IdCard };
                profileButton.Click += profileButton_OnClick;

                buttons.Add(profileButton);
            }

            //Logout button
            var logoutButton = new IconButton { Name = "btnLogout", Text = "Logout", IconChar = IconChar.SignOutAlt };
            logoutButton.Click += logoutButton_OnClick;

            buttons.Add(logoutButton);
            buttons.Reverse();

            foreach (var btn in buttons)
            {
                btn.BackColor = Color.FromArgb(0, 190, 190);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Dock = DockStyle.Top;
                btn.IconColor = Color.FromArgb(53, 68, 82);
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.ForeColor = Color.FromArgb(244, 238, 237);
                btn.IconSize = 36;
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.BorderSize = 0;
                btn.Size = new Size(Width, Height / 3);
                btn.Font = new Font("Calibri", 11.25f, FontStyle.Bold);
            }

            Controls.AddRange(controls: buttons.ToArray());
        }

        [Description("Icon button which toggles this dropdown list")]
        public UserMenuButton Toggler
        {
            get => _toggler;
            set
            {
                _toggler = value;
                _toggler.Click += toggler_OnClick;
            }
        }

        private void logoutButton_OnClick(object sender, EventArgs e)
        {
            Auth.Logout();
            Hide();
        }

        protected override void OnResize(EventArgs eventargs)
        {
            var buttonCount = Auth.Role == RoleType.Administrator ? 1 : 3;
            foreach (var btn in Controls.OfType<IconButton>())
            {
                btn.Size = new Size(Width, Height / buttonCount);
            }
        }

        private void profileButton_OnClick(object sender, EventArgs e)
        {
            frmUserProfile.Instance.OpenAsChildOfControl(Parent);
            Hide();
        }

        private void dashboardButton_OnClick(object sender, EventArgs e)
        {
            switch (Auth.Role)
            {
                case RoleType.Administrator:
                    frmStartMenuAdministrator.Instance.OpenAsChildOfControl(Parent);
                    break;

                case RoleType.Doktor:
                    frmDoktorMainDashboard.Instance.OpenAsChildOfControl(Parent);
                    break;
                case RoleType.MedicinskiTehnicar:
                    frmDoktorMainDashboard.Instance.OpenAsChildOfControl(Parent);
                    break;
                case RoleType.RadnikPrijem:
                    frmRadnikPrijemMainDashboard.Instance.OpenAsChildOfControl(Parent);
                    break;
            }

            Hide();
        }

        private void toggler_OnClick(object sender, EventArgs e)
        {
            if (Visible)
                Hide();
            else
            {
                Show();
                BringToFront();
            }
        }
    }
}