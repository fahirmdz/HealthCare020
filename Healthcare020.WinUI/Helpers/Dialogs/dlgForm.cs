﻿using Healthcare020.WinUI.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    public enum DialogFormSize
    {
        Small=5,
        Medium=8,
        Large=10
    };
    public partial class dlgForm : Form
    {
        private static dlgForm _instance = null;
        private Form Child;
        private Size BodyPanelSize;

        private dlgForm(Form child, DialogFormSize bodyPanelSize=DialogFormSize.Medium)
        {
            var sizeMultiplier = (int) bodyPanelSize;

            BodyPanelSize=new Size(sizeMultiplier*100,(int)((double)sizeMultiplier/2)*100);
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            var mainFormSize = MainForm.Instance.Size;
            this.Size = new Size(mainFormSize.Width - 14, mainFormSize.Height - 14);
            pnlMain.MinimumSize = Size;
            pnlBody.Size = BodyPanelSize;
            pnlBody.CenterToClient(this);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor,true);
            this.BackColor=Color.Transparent;
            this.TransparencyKey=Color.Empty;
            pnlMain.BackColor = Color.FromArgb(170, 0, 0, 0);
            Child = child;
            Child.OpenAsChildOfControl(pnlBody);
            //Left focus from left side title (because it is RichTextBox)
            txtLeftTitle.Enter += (s, e) => { txtLeftTitle.Parent.Focus(); };
        }

        public static void ShowDialog(Form child,DialogFormSize bodyPanelSize=DialogFormSize.Medium, bool NewInstance=false)
        {
            if (_instance == null || _instance.IsDisposed || (_instance!=null && _instance.Visible) || NewInstance)
                _instance = new dlgForm(child,bodyPanelSize);
           
            ((Form)_instance).ShowDialog();
        }

        protected override void OnPaintBackground(PaintEventArgs e) { }
        private void dlgForm_Load(object sender, EventArgs e)
        {
            txtLeftTitle.HideCaret();
            this.Dock = DockStyle.Fill;
        }

        private void dlgForm_Shown(object sender, EventArgs e)
        {
            pnlBody.PointToClient(new Point(Width / 2, Height / 2));
        }

        private void pnlMain_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
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

        private void pnlBody_ControlAdded(object sender, ControlEventArgs e)
        {
            Child = pnlBody.Controls.OfType<Form>().First();
        }

        private void pnlBody_ControlRemoved(object sender, ControlEventArgs e)
        {
        }
    }
}