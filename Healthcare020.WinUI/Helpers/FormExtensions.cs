using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers
{
    public static class FormExtensions
    {
        /// <summary>
        /// Show new MDI child form and close current active child (need to set Mdi parent before call this method)
        /// </summary>
        public static void ShowAsNextMdiChild(this Form form, Panel panel)
        {
            form.Left = 0;
            form.Top = 0;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            panel.Tag = form;
            form.AutoScroll = false;
            form.BringToFront();
            form.Show();

        }
    }
}