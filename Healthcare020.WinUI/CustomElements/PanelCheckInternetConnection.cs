using System;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.CustomElements
{
    public partial class PanelCheckInternetConnection : UserControl
    {
        public PanelCheckInternetConnection(Form parent)
        {
            InitializeComponent();
            Parent = parent;
            Size = new Size(parent.Width, parent.Height);
            MainForm.Instance.SetCopyrightPanelColor(Color.FromArgb(255, 255, 255));
        }

        private void PanelCheckInternetConnection_Load(object sender, EventArgs e)
        {
        }


        public void SetRetryConnectionEvent(EventHandler e)
        {
            btnRetryConnection.Click += e;
        }
    }
}