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
    class LoginViewModel : ViewModelBase
    {
        PersonModels PM;
        LoginModel LM;
        public LoginViewModel()
        {
            PM = new PersonModels();
            OKCmd = new RelayCommand(x => ExecuteOK());
            CancelCmd = new RelayCommand(x => ExecuteClose(false));
            LM = new LoginModel();
        }
        //Properties
        public string ID { get; set; }
        public string PW { get; set; }

        public Person CurrentPerson { get; private set; }

        private string _loginErrorMessage;
        public string LoginErrorMessage
        {
            get { return _loginErrorMessage; }
            set { _loginErrorMessage = value; OnPropertyChanged("LoginErrorMessage"); }
        }



        private void ExecuteOK()
        {
            bool? IsCorrectID_PW = LM.AreIDandPWCorrect(ID, PW);
            //wenn id und PW sind richtig, fenster zu
            //'' falsch, fenter offen bleiben. nicht tun etwas
            if (IsCorrectID_PW == true)
            {
                CurrentPerson = PM.getPersonFromDB(ID);
                ExecuteClose(true);
            }
            else { LoginErrorMessage = "ID oder PW ist(sind) Falsch."; }
            /*else { LoginErrorMessage = "ID oder PW ist(sind) Falsch."; }*///lbl loginwindow ->kommentar 'falsch PW'
        }
    }
}

