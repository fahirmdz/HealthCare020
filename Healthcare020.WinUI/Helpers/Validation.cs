using MaterialSkin.Controls;
using System.Linq;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers
{
    public static class Validation
    {
        public static bool ValidTextInput(this MaterialSingleLineTextField textField, ErrorProvider errors)
        {
            if (string.IsNullOrWhiteSpace(textField.Text))
            {
                errors.SetError(textField, Properties.Resources.RequiredField);
                return false;
            }

            if (textField.Text.Any(char.IsDigit))
            {
                errors.SetError(textField, Properties.Resources.InvalidFormat);
                return false;
            }

            errors.Clear();
            return true;
        }
    }
}