using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Healthcare020.Mobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public string LoadingMessage { get; set; } = string.Empty;

        protected bool EnabledLoadingSpinner = false;
        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (EnabledLoadingSpinner)
                {
                    if (value)
                        UserDialogs.Instance.ShowLoading(LoadingMessage);
                    else
                        UserDialogs.Instance.HideLoading();
                }
                SetProperty(ref isBusy, value);
            }
        }

        private string title = string.Empty;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;

            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}