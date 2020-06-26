using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Healthcare020.WinUI.Helpers.CustomElements
{
    public class UserMenuButton : IconPictureBox
    {
        public UserMenuButton()
        {
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Cursor = Cursors.Hand;
            this.Name = "btnUserMenu";
            this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.IconColor = Color.FromArgb(53, 68, 82);
            this.IconSize = 41;
            this.IconChar = IconChar.UserCircle;
        }
    }
}