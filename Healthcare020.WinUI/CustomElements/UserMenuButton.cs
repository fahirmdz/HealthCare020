using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.CustomElements
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
            this.ForeColor = Color.FromArgb(20, 70, 125);
            this.IconColor = Color.FromArgb(20, 70, 125);
            this.IconSize = 41;
            this.IconChar = IconChar.UserCircle;
        }
    }
}