using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare020.WinUI.Forms.AdminDashboard;

namespace Healthcare020.WinUI.Helpers
{
    public static class FormExtensions
    {
        /// <summary>
        /// Open form as child of passed control
        /// </summary>
        /// <param name="form">Form child</param>
        /// <param name="parentControl">Parent control</param>
        public static void OpenAsChildOfControl(this Form form, Control parentControl)
        {
            if (form == null || parentControl == null || form.IsDisposed)
                return;

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            foreach (var control in parentControl.Controls.OfType<Form>())
            {
                if (form != control)
                {
                    control.Close();
                    parentControl.Controls.Remove(control);
                }
            }

            parentControl.Controls.Add(form);
            form.Parent = parentControl;
            form.Show();
        }

        public static void ShowDialogWithBlurryBackground(this Form dialog)
        {
            var panel = new Panel();
            dialog.TopLevel = false;
            panel.Controls.Add(dialog);
            panel.Tag = dialog;
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.FromArgb(25, Color.Black);
            panel.BringToFront();
            frmStartMenuAdministrator.Instance.Controls.Add(panel);

            panel.Show();
        }

        public static async Task CloseAfterDelay(this Form form, int millisecondsDelay)
        {
            await Task.Delay(millisecondsDelay);
            form.Close();
        }
    }
}