using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare020.WinUI.Forms.AdminDashboard;

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


        public static void ShowDialogWithBlurryBackground(this Form dialog)
        {
            var panel = new Panel();
            dialog.TopLevel = false;
            panel.Controls.Add(dialog);
            panel.Tag = dialog;
            panel.Dock = DockStyle.Fill;
            panel.BackColor=Color.FromArgb(25,Color.Black);
            panel.BringToFront();
            frmStartMenuAdmin.Instance.Controls.Add(panel);

            panel.Show();
        }

        public static async Task CloseAfterDelay(this Form form, int millisecondsDelay )
        {
            await Task.Delay( millisecondsDelay );
            form.Close();
        }
    }
}