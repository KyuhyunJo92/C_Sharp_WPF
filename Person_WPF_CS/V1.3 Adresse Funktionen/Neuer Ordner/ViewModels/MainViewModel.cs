using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Person_WPF_CS.Models;

namespace Person_WPF_CS.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        private Models.GreetingBuilder _loginBegruessenBuilder;
        private RegisterMessageBuilder _registerBegrussenBuilder;

        public MainViewModel()
        {
            _registerBegrussenBuilder = new RegisterMessageBuilder();
            _loginBegruessenBuilder = new GreetingBuilder();
            LoginCmd = new RelayCommand(x => CallLoginFunction());
            LogoutCmd = new RelayCommand(x => CallLogoutFunction());
            RegisterCmd = new RelayCommand(x => CallRegisterFunction());
            MeinKontoCmd = new RelayCommand(x => CallMeinKontoFunction());
        }
        
        
        /*Command Properties*/
        public ICommand LoginCmd { get; private set; }
        public ICommand LogoutCmd { get; private set; }
        public ICommand RegisterCmd { get; private set; }
        public ICommand MeinKontoCmd { get; private set; }
        //private string _loginStmt = "Bitte, Einloggen! :)";
        //public string LoginStmt
        //{
        //    get { return _loginStmt; }
        //    set { _loginStmt = value; OnPropertyChanged("LoginStmt"); }
        //}
        //-----TEST 19.07.2022 BEGIN------------------------------------------------------//
        //BUTTON ACTIVATE, DEACTIVATE, CurrentLogedInID, LoginStmt umsetzen

        /*Properties*/
        private Person _currentPerson;

        public Person CurrentPerson
        {
            get { return _currentPerson; }
            set { _currentPerson = value; }
        }

        private string _currentAccount;
        public string CurrentAccount
        {
            get { return _currentAccount; }
            set { _currentAccount = value; }
        }

        private string _greeting;
        public string Greeting
        {
            get { return _greeting; }
            set { _greeting = value; OnPropertyChanged("Greeting"); }
        }

        private bool _loginStmt = false;
        public bool LoginStmt
        {
            get { return _loginStmt; }

            set
            {
                _loginStmt = value;
                //abhangkeitlich IsEnable zustand wird wechselt.
                if (LoginStmt==true)
                {
                    IsLoginEnable = false;
                    IsLogoutEnable = true;
                    IsMeinKontoEnable = true;
                }
                else
                {
                    IsLoginEnable = true;
                    IsLogoutEnable = false;
                    IsMeinKontoEnable = false;
                }
            }
        }

        //IsLogoutEnable : true
        //IsLoginEnable : false
        private bool _isLoginEnable = true;
        public bool IsLoginEnable
        {
            get { return _isLoginEnable; }
            set { _isLoginEnable = value; OnPropertyChanged("IsLoginEnable"); }
        }
        
        private bool _isLogoutEnable = false;
        public bool IsLogoutEnable
        {
            get { return _isLogoutEnable; }
            set { _isLogoutEnable = value; OnPropertyChanged("IsLogoutEnable"); }
        }

        private bool _isMeinKontoEnable = false;

        public bool IsMeinKontoEnable
        {
            get { return _isMeinKontoEnable; }
            set { _isMeinKontoEnable = value; OnPropertyChanged("IsMeinKontoEnable"); }
        }


        /*Funktionen*/
        private void CallLoginFunction()
        {
            Views.LoginWindow L = new Views.LoginWindow();
            bool? res = L.ShowDialog();

            if (res == true)
            {
                //loginStmt : true
                LoginStmt = true;
                //CurrentLogedInID : L.ID
                CurrentPerson = L.CurrentPerson;
                //Greeting : Hello, %name
                Greeting = _loginBegruessenBuilder.CreateGreeting(L.CurrentPerson.ID);
                
            }
            else
            {
                Greeting = "Bitte, Einloggen! :)";
                LoginStmt = false;
                //Abhangigkeitliche an LoginStmt, alle Button werden aktivieren oder di-aktivieren. 
            }
        }
        
        private void CallLogoutFunction()
        {
            //LoginStmt : false
            LoginStmt = false;
            //CurrentlogedInID : NULL
            CurrentPerson = null;
            
            //IsLoginEnable : true
            //IsLoginEnable = true;
            //IsLogoutEnable : false
            //IsLogoutEnable = false;
            

            Greeting = "Bitte, Einloggen! :)";
        }

        private void CallRegisterFunction()
        {
            Views.RegisterWindow R = new Views.RegisterWindow();
            bool? res = R.ShowDialog();

            if (res == true)
            {
                //register done successfully return "WELCOME GREETING" 
                Greeting = _registerBegrussenBuilder.CreateRegisterBegruessen(R.ID);
            }
            else
            {
            }
        }

        private void CallMeinKontoFunction()
        {
            if (_loginStmt == true)
            {
                //Parameter for constructor : have been copied from LOGIN obj.
                Views.MeinKontoWindow MK = new Views.MeinKontoWindow(CurrentPerson);
                bool? res = MK.ShowDialog();

                //???? what should I write down here??? Probably Nothing
                if (res == true)
                {

                }
                else
                {
                
                }
            }
        } 
    }
}
