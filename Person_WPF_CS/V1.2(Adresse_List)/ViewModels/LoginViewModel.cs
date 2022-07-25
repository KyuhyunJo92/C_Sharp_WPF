using Person_WPF_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace Person_WPF_CS.ViewModels 
{
    public delegate void RequestCloseEventHandler(bool isOK);
    public class LoginViewModel : INotifyPropertyChanged
    {
        LoginModel LM;
        public LoginViewModel()
        {
            OKCmd = new RelayCommand(x => ExecuteOKCmd());
            CancelCmd = new RelayCommand(x => ExecuteClose(false));
            LM = new LoginModel();
        }
        //Properties
        public string ID { get;  set; }
        public string PW { get; set; }

        public Person p;

        private string _loginErrorMessage;
        public string LoginErrorMessage
        {
            get { return _loginErrorMessage; }
            set { _loginErrorMessage = value; OnPropertyChanged("LoginErrorMessage"); }
        }
        
        public ICommand OKCmd { get; private set; }
        public ICommand CancelCmd { get; private set; }

        public event RequestCloseEventHandler RequestClose;

        private void ExecuteClose(bool isOK)
        {
            RequestClose?.Invoke(isOK);
        }

        private void ExecuteOKCmd()
        {
            bool? IsCorrectID_PW = LM.AreIDandPWCorrect(ID, PW);
            //wenn id und PW sind richtig, fenster zu
            //'' falsch, fenter offen bleiben. nicht tun etwas
            if (IsCorrectID_PW == true) { ExecuteClose(true); }
            else { LoginErrorMessage = "ID oder PW ist(sind) Falsch."; }
            /*else { LoginErrorMessage = "ID oder PW ist(sind) Falsch."; }*///lbl loginwindow ->kommentar 'falsch PW'
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //private
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

