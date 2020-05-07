using FontAwesome.Sharp;
using Healthcare020.WinUI.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Healthcare020.WinUI.CustomElements
{
    public class UserMenuDropdownPanel : Panel
    {
        private UserMenuButton _toggler;

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

        private bool _closeOnAnyActionOutside;
        [DefaultValue(false)]
        public bool CloseOnAnyActionOutside
        {
            get => _closeOnAnyActionOutside;
            set
            {
                _closeOnAnyActionOutside = value;
            }
        }

        public UserMenuDropdownPanel()
        {
            _toggler = new UserMenuButton();
            this.Name = "pnlUserMenuDropdown";
            this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.BackColor = Color.FromArgb(0, 190, 190);
            this.BorderStyle = BorderStyle.None;

            //Profile button
            var profileButton = new IconButton();
            profileButton.Name = "btnProfile";
            profileButton.Text = "Profile";
            profileButton.IconChar = IconChar.IdCard;

            var settingsButton = new IconButton();
            settingsButton.Name = "btnSettings";
            settingsButton.Text = "Settings";
            settingsButton.IconChar = IconChar.Cog;

            var logoutButton = new IconButton();
            logoutButton.Name = "btnLogout";
            logoutButton.Text = "Logout";
            logoutButton.IconChar = IconChar.SignOutAlt;
            logoutButton.Click += profileButton_OnClick;

            var buttons = new IconButton[] { logoutButton, settingsButton, profileButton };

            foreach (var btn in buttons)
            {
                btn.BackColor = Color.FromArgb(0, 190, 190);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Dock = DockStyle.Top;
                btn.IconColor = Color.FromArgb(20, 70, 125);
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.ForeColor = Color.FromArgb(244, 238, 237);
                btn.IconSize = 26;
                btn.FlatAppearance.BorderSize = 0;
                btn.Size = new Size(this.Width, this.Height / 3);
                btn.Font = new Font("Calibri", 11.25f, FontStyle.Bold);
            }

            this.Controls.AddRange(buttons);
            this.Hide();
        }
        

        protected override void OnResize(EventArgs eventargs)
        {
            foreach (var btn in Controls.OfType<IconButton>())
            {
                btn.Size=new Size(this.Width,this.Height/3);
            }
        }

        protected void profileButton_OnClick(object sender, EventArgs e)
        {
            Auth.Logout();
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

        protected void HideUserMenuDropdown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}