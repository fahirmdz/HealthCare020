using Healthcare020.WinUI.Forms;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    public partial class dlgForm : Form
    {
        private static dlgForm _instance = null;
        private Form Child;

        private dlgForm(Form child)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            var mainFormSize = MainForm.Instance.Size;
            this.Size = new Size(mainFormSize.Width - 14, mainFormSize.Height - 14);
            pnlMain.MinimumSize = Size;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor,true);
            this.BackColor=Color.Transparent;
            this.TransparencyKey=Color.Empty;
            pnlMain.BackColor = Color.FromArgb(170, 0, 0, 0);
            Child = child;
            Child.Dock = DockStyle.Fill;
            Child.TopLevel = false;
            pnlBody.Controls.Add(Child);

            //Left focus from left side title (because it is RichTextBox)
            txtLeftTitle.Enter += (s, e) => { txtLeftTitle.Parent.Focus(); };
        }

        public static void ShowDialog(Form child)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new dlgForm(child);
            }
            ((Form)_instance).ShowDialog();
        }

        protected override void OnPaintBackground(PaintEventArgs e) { }
        private void dlgForm_Load(object sender, EventArgs e)
        {
            txtLeftTitle.HideCaret();
            this.Dock = DockStyle.Fill;
            Child.Show();
            Child.BringToFront();
        }

        private void dlgForm_Shown(object sender, EventArgs e)
        {
            pnlBody.PointToScreen(new Point(Width / 2, Height / 2));
        }

        private void pnlMain_MouseClick(object sender, MouseEventArgs e)
        {
            Child.Close();
            Child.Dispose();
            Close();
            Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Child.Close();
            Child.Dispose();
            Close();
            Dispose();
        }

        private void txtLeftTitle_SelectionChanged(object sender, EventArgs e)
        {
            txtLeftTitle.DeselectAll();
        }
    }
}