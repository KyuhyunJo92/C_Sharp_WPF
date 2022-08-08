using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Person_WPF_CS.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public ICommand OKCmd { get; protected set; }
        public ICommand CancelCmd { get; protected set; }
        
        public event RequestCloseEventHandler RequestClose;
        protected void ExecuteClose(bool isOK)
        {
            RequestClose?.Invoke(isOK);
        }

        //PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
