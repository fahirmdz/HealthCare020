using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Healthcare020.WinUI.Helpers
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Set event to all childs of this control and optional to nested childs
        /// </summary>
        /// <param name="eventToAttach">Mouse click event handler</param>
        /// <param name="SetToNestedChilds">Boolean indicates to add event to nested childs</param>
        /// <param name="condition">Optional condition for every child/nested child control</param>
        /// <param name="nestingCounter">How much nesting in every child control. Max is 3</param>
        public static void SetMouseClickEventToChildControls(this Control c, MouseEventHandler toAttach , bool SetToNestedChilds = false,
            Func<Control, bool> condition = null, int nestingCounter=2)
        {
            c.MouseClick += toAttach;
            foreach (var control in c.Controls.OfType<Control>())
            {
                if (condition != null && !condition.Invoke(control))
                    continue;

                control.MouseClick += toAttach;

                foreach (var nestedControl in control.Controls.OfType<Control>())
                {
                    if (condition != null && !condition.Invoke(nestedControl))
                        continue;

                    nestedControl.MouseClick += toAttach;
                    if (nestingCounter == 3)
                    {
                        foreach (var nestedOfNestedControl in nestedControl.Controls.OfType<Control>())
                        {
                            if (condition != null && !condition.Invoke(nestedOfNestedControl))
                                continue;
                            nestedOfNestedControl.MouseClick += toAttach;
                        }
                    }
                }
            }
        }


        public static void ResetTextboxes(this Control.ControlCollection controls)
        {
            foreach (var control in controls.OfType<MaterialSingleLineTextField>())
            {
                control.Text = string.Empty;
            }
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public static void HideCaret(this Control control)
        {
            HideCaret(control.Handle);
        }


        public static void CenterToClient(this Control control, Control client)
        {
            control.Location = new Point(client.ClientSize.Width / 2 - control.Size.Width / 2,
                client.ClientSize.Height / 2 - control.Size.Height / 2);
        }
    }
}