using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Healthcare020.WinUI.Helpers.CustomElements
{
    public partial class NoDataPanel : UserControl
    {
        public IconPictureBox IcnData;

        public NoDataPanel(string MainText = "")
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(MainText))
                lblMessage.Text = MainText;
        }

        private void NoDataPanel_SizeChanged(object sender, System.EventArgs e)
        {
            pnlMain.PointToClient(new Point(this.Size.Width / 2, this.Size.Height / 2));
        }
    }
}