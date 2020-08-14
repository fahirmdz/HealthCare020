using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.CustomElements
{
    public sealed class UserMenuButton : IconPictureBox
    {
        public UserMenuButton()
        {
            BackColor = Color.Transparent;
            SizeMode = PictureBoxSizeMode.CenterImage;
            Cursor = Cursors.Hand;
            Name = "btnUserMenu";
            Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            IconColor = Color.FromArgb(53, 68, 82);
            IconSize = 41;
            IconChar = IconChar.UserCircle;
        }
    }
}