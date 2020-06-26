using System;
using MaterialSkin.Controls;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using Healthcare020.WinUI.Properties;

namespace Healthcare020.WinUI.Helpers
{
    public static class Validation
    {
        public enum TextInputType
        {
            Digits, Letters
        }

        public static bool ValidTextInput(this MaterialSingleLineTextField textField, ErrorProvider errors, TextInputType textInputType = TextInputType.Letters)
        {
            if (errors == null)
                return false;

            if (string.IsNullOrWhiteSpace(textField.Text))
            {
                errors.SetError(textField, Properties.Resources.RequiredField);
                return false;
            }

            if (textInputType == TextInputType.Letters ? textField.Text.Any(char.IsDigit) : textField.Text.Any(char.IsLetter))
            {
                errors.SetError(textField, Properties.Resources.InvalidFormat);
                return false;
            }

            return true;
        }

        public static bool ValidComboBoxItemSelected(this ComboBox cmb, ErrorProvider errors)
        {
            if (cmb.SelectedIndex == -1)
            {
                errors.SetError(cmb, Resources.RequiredField);
                return false;
            }

            return true;
        }

        public static bool ValidEmailAddressFormat(this MaterialSingleLineTextField textField, ErrorProvider errors)
        {
            if (errors == null)
                return false;

            try
            {
                var email = new MailAddress(textField.Text);

                return true;
            }
            catch(FormatException)
            {
                errors.SetError(textField,Resources.InvalidFormat);
                return false;
            }
        }
    }
}