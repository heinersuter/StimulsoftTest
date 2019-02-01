using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StimulsoftTest
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetValue<T>(ref T field, T value, Action action = null)
        {
            if (!Equals(field, value))
            {
                field = value;
                RaisePropertyChanged();
                action?.Invoke();
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
