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
    class MainViewModel : INotifyPropertyChanged
    {
        private Models.GreetingBuilder _loginBegruessenBuilder;
        private RegisterMessageBuilder _registerBegrussenBuilder;
        public MainViewModel()
        {
            _registerBegrussenBuilder = new RegisterMessageBuilder();
            _loginBegruessenBuilder = new Models.GreetingBuilder();
            LoginCmd = new RelayCommand(x => CallLoginFunction());
            LogoutCmd = new RelayCommand(x => CallLogoutFunction());
            RegisterCmd = new RelayCommand(x => CallRegisterFunction());
        }
        // Command für Button
        public ICommand LoginCmd { get; private set; }
        public ICommand LogoutCmd { get; private set; }
        public ICommand RegisterCmd { get; private set; }

        //private string _loginStmt = "Bitte, Einloggen! :)";
        //public string LoginStmt
        //{
        //    get { return _loginStmt; }
        //    set { _loginStmt = value; OnPropertyChanged("LoginStmt"); }
        //}
        //-----TEST 19.07.2022 BEGIN------------------------------------------------------//
        //BUTTON ACTIVATE, DEACTIVATE, CurrentLogedInID, LoginStmt umsetzen
        private string _currentLogedInID;

        public string CurrentLogedInID
        {
            get { return _currentLogedInID; }
            set { _currentLogedInID = value; }
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
                if(LoginStmt==true)
                {
                    IsLoginEnable = false;
                    IsLogoutEnable = true;
                }
                else
                {
                    IsLoginEnable = true;
                    IsLogoutEnable = false;
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


        private void CallLoginFunction()
        {
            Views.LoginWindow L = new Views.LoginWindow();
            bool? res = L.ShowDialog();

            if (res == true)
            {
                //loginStmt : true
                LoginStmt = true;
                //CurrentLogedInID : L.ID
                CurrentLogedInID = L.ID;
                //Greeting : Hello, %name
                Greeting = _loginBegruessenBuilder.CreateGreeting(L.ID);

                //this is Hardcoding.. 
                //make a method what is triggered automatically itself,
                //when the loginStmt is changed.
                //IsLoginEnable = false;
                //IsLogoutEnable = true;
            }
            else
            {
                Greeting = "Bitte, Einloggen! :)";
                LoginStmt = false;
                //IsLoginEnable = true;
                //IsLogoutEnable = false;
            }
        }
        
        private void CallLogoutFunction()
        {
            //LoginStmt : false
            LoginStmt = false;
            //CurrentlogedInID : NULL
            CurrentLogedInID = "NULL";
            
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
                Greeting = _registerBegrussenBuilder.CreateRegisterBegruessen(R.ID);
            }
            else
            {
                //Greeting = "ID-Registrierung fehlgeschlagen.";
            }
        }

        //-----TEST 19.07.2022 END------------------------------------------------------//

        //if somebody logged in, actvate those functions(logout, kaufen..). 
        //If user try to login in loggedin phase, new login window is called,
        //success-> change loggedinId, fail->nothing has been changed.


        //private void CallLoginFunction()
        //{
        //    Views.LoginWindow L = new Views.LoginWindow();
        //    bool? res = L.ShowDialog();

        //    if(res == true)
        //    {
        //        LoginStmt = _loginStmtBuilder.CreateGreeting(L.ID);

        //    }
        //    else
        //    {
        //        LoginStmt = "Bitte, Einloggen! :)";
        //    }
        //}



        //private void CallRegisterFunction()
        //{
        //    Views.RegisterWindow R = new Views.RegisterWindow();
        //    bool? res = R.ShowDialog();

        //    //if(res == true)
        //    //{
        //    //}
        //    //else
        //    //{
        //    //}
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }   
    }
}
