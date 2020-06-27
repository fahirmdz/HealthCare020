using FontAwesome.Sharp;
using Healthcare020.WinUI.Forms.KorisnickiNalog;
using HealthCare020.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Healthcare020.WinUI.Forms.RadnikDashboard;

namespace Healthcare020.WinUI.Helpers.CustomElements
{
    public class UserMenuDropdownPanel : Panel
    {
        private bool _closeOnAnyActionOutside;
        private UserMenuButton _toggler;

        public UserMenuDropdownPanel()
        {
            _toggler = new UserMenuButton();
            this.Name = "pnlUserMenuDropdown";
            this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.BackColor = Color.FromArgb(0, 190, 190);
            this.BorderStyle = BorderStyle.None;

            var buttons = new List<IconButton>();

            if (Auth.Role != RoleType.Administrator)
            {
                //Dashboard button
                var dashboard = new IconButton { Name="btnDashboard", Text="Dashboard", IconChar = IconChar.TachometerAlt};
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
                btn.Size = new Size(this.Width, this.Height / 3);
                btn.Font = new Font("Calibri", 11.25f, FontStyle.Bold);
            }

            this.Controls.AddRange(buttons.ToArray());
            this.Hide();

            
        }

        [DefaultValue(false)]
        public bool CloseOnAnyActionOutside
        {
            get => _closeOnAnyActionOutside;
            set
            {
                _closeOnAnyActionOutside = value;
            }
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

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Auth.Logout();
            this.Hide();
        }

        protected override void OnResize(EventArgs eventargs)
        {
            var buttonCount = Auth.Role == RoleType.Administrator ? 1 : 3;
            foreach (var btn in Controls.OfType<IconButton>())
            {
                btn.Size = new Size(this.Width, this.Height / buttonCount);
            }
        }

        protected void profileButton_OnClick(object sender, EventArgs e)
        {
            frmUserProfile.Instance.OpenAsChildOfControl(Parent);
            this.Hide();
        }

        protected void dashboardButton_OnClick(object sender, EventArgs e)
        {
            frmMainDashboard.Instance.OpenAsChildOfControl(Parent);
            this.Hide();
        }

        protected void toggler_OnClick(object sender, EventArgs e)
        {
            if (this.Visible)
                this.Hide();
            else
            {
                this.Show();
                this.BringToFront();
            }
        }

        
    }
}