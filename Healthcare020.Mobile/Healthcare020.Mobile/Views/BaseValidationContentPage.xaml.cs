using Healthcare020.Mobile.ViewModels;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseValidationContentPage : ContentPage
    {
        /// <summary>
        /// Base validation view model (need to set on start)
        /// </summary>
        protected BaseValidationViewModel BaseValidationVM;

        /// <summary>
        /// StackLayout element that represents input form body
        /// </summary>
        protected StackLayout FormBody;

        public BaseValidationContentPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hide validation message for input caller (it is recommended to set the FormBody element on Page initialization)
        /// </summary>
        protected virtual void HideErrorLabel(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            if (FormBody == null)
            {
                FormBody = this.FindByName<StackLayout>("FormBody");
                if (FormBody == null || entry == null)
                    return;
            }

            var labelToHide = FormBody.FindByName<Label>($"{entry.ClassId}Validation");
            if (labelToHide != null)
            {
                labelToHide.Text = string.Empty;
                labelToHide.IsVisible = false;
            }
        }

        /// <summary>
        /// Validate model properties/inputs and set error if model is invalid.
        /// In order to successfully set a validation message, it is necessary that there is a label in the form body with ClientId = {EntryName}Validation,
        /// e.g. for entry Name validation label is NameValidation.
        /// </summary>
        /// <returns>True if model is valid, false if not</returns>
        protected virtual bool ValidateModel()
        {
            if (BaseValidationVM == null)
                return true;

            if (BaseValidationVM.Errors.Any())
            {
                foreach (var error in BaseValidationVM.Errors)
                {
                    var validationLabel = this.FindByName<Label>($"{error.Key}Validation");
                    if (validationLabel != null)
                    {
                        validationLabel.Text = error.Value;
                        validationLabel.IsVisible = true;
                    }
                }
                return false;
            }

            return true;
        }

        protected void SetErrorsClearOnTextChanged()
        {
            if (FormBody == null)
                return;
            foreach (var entry in FormBody.Children.OfType<Entry>())
            {
                entry.TextChanged += HideErrorLabel;
            }
        }

        protected void SetFormBodyElement()
        {
            FormBody = this.FindByName<StackLayout>("FormBody");
        }
    }
}