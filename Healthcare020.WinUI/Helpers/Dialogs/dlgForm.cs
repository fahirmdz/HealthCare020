using Healthcare020.WinUI.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    public enum DialogFormSize
    {
        Small = 5,
        Medium = 8,
        Large = 10
    };

    public partial class dlgForm : Form
    {
        public static bool ShouldDisposeOnChildClose;

        public bool ShouldDisposeOnOutsideClick;
        public bool DisabledCloseOnOutsideClick;
        private static dlgForm _instance = null;
        private Size BodyPanelSize;
        private Form Child;

        private dlgForm(Form child, DialogFormSize bodyPanelSize = DialogFormSize.Medium, bool ShouldDisposeOnOutsideClick = true, bool DisabledCloseOnOutsideClick=false)
        {
            this.ShouldDisposeOnOutsideClick = ShouldDisposeOnOutsideClick;
            this.DisabledCloseOnOutsideClick = DisabledCloseOnOutsideClick;

            ShouldDisposeOnChildClose = true;
            var sizeMultiplier = (int)bodyPanelSize;

            BodyPanelSize = new Size(sizeMultiplier * 100, (int)((double)sizeMultiplier / 2) * 100);
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            var mainFormSize = MainForm.Instance.Size;
            this.Size = new Size(mainFormSize.Width - 14, mainFormSize.Height - 14);
            pnlMain.MinimumSize = Size;
            pnlBody.Size = BodyPanelSize;
            pnlBody.CenterToClient(this);
            txtLeftTitle.CenterToClient(pnlSide);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = Color.Empty;
            pnlMain.BackColor = Color.FromArgb(170, 0, 0, 0);
            Child = child;
            Child.OpenAsChildOfControl(pnlBody);
            //Left focus from left side title (because it is RichTextBox)
            txtLeftTitle.Enter += (s, e) => { txtLeftTitle.Parent.Focus(); };
            this.KeyPreview = true;
        }

        public static void ShowDialog(Form child, DialogFormSize bodyPanelSize = DialogFormSize.Medium, bool NewInstance = false)
        {
            try
            {
                if (_instance == null || _instance.IsDisposed || (_instance != null && _instance.Visible) ||
                    NewInstance)
                    _instance = new dlgForm(child, bodyPanelSize);

                ((Form) _instance).ShowDialog();
            }
            catch (Exception ex)
            {
                //ignore;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Child.Close();
        }

        private void child_Closed(object sender, EventArgs e)
        {
            if (ShouldDisposeOnChildClose)
            {
                Child.Dispose();
                Close();
                Dispose();
            }
        }

        private void dlgForm_Load(object sender, EventArgs e)
        {
            txtLeftTitle.HideCaret();
            this.Dock = DockStyle.Fill;
            ShouldDisposeOnChildClose = true;
        }

        private void dlgForm_Shown(object sender, EventArgs e)
        {
            pnlBody.PointToClient(new Point(Width / 2, Height / 2));
        }

        private void pnlBody_ControlAdded(object sender, ControlEventArgs e)
        {
            Child = pnlBody.Controls.OfType<Form>().First();
            Child.Closed += child_Closed;
        }

        private void pnlBody_ControlRemoved(object sender, ControlEventArgs e)
        {
        }

        private void pnlMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.DisabledCloseOnOutsideClick)
                return;

            Close();
            if (ShouldDisposeOnOutsideClick)
            {
                //Trigger event child_Closed (above)
                Child.Close();
            }
        }

        private void txtLeftTitle_SelectionChanged(object sender, EventArgs e)
        {
            txtLeftTitle.DeselectAll();
        }

        /// <summary>
        /// Set flag to indicate that form should close after child closing
        /// </summary>
        /// <param name="should">Flag value true or false</param>
        public static void SetShouldDisposeOnChildClose(bool should) => ShouldDisposeOnChildClose = should;

        private void dlgForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
                Child.Close();
            }
        }
    }
}