using System.Linq;
using System.Windows.Forms;

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
    }
}