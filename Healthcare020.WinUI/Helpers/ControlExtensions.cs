using System;
using System.Linq;
using System.Windows.Forms;

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
    }
}