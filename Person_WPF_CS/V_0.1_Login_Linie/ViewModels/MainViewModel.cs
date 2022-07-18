using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace Person_WPF_CS.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Models.LoginStmtBuilder _loginStmtBuilder;
        
        public MainViewModel()
        {
            _loginStmtBuilder = new Models.LoginStmtBuilder();
            LoginCmd = new RelayCommand(x => CallLoginFunction());
            //LogoutCmd = new RelayCommand(x => CallLogoutFunction());
            RegisterCmd = new RelayCommand(x => CallRegisterFunction());
        }
        // Command für Button
        public ICommand LoginCmd { get; private set; }
        public ICommand LogoutCmd { get; private set; }
        public ICommand RegisterCmd { get; private set; }

        private string _loginStmt = "Bitte, Einloggen! :)";

        public string LoginStmt
        {
            get { return _loginStmt; }
            set { _loginStmt = value; OnPropertyChanged("LoginStmt"); }
        }

        //if somebody logged in, actvate those functions(logout, kaufen..). 
        //If user try to login in loggedin phase, new login window is called,
        //success-> change loggedinId, fail->nothing has been changed.
        private void CallLoginFunction()
        {
            Views.LoginWindow L = new Views.LoginWindow();
            bool? res = L.ShowDialog();

            if(res == true)
            {
                LoginStmt = _loginStmtBuilder.CreateGreeting(L.ID);
            }
            else
            {
                LoginStmt = "Bitte, Einloggen! :)";
            }
        }

        //private void CallLogoutFunction(){}
        
        private void CallRegisterFunction()
        {
            Views.RegisterWindow R = new Views.RegisterWindow();
            bool? res = R.ShowDialog();

            //if(res == true)
            //{
            //}
            //else
            //{
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


    }
}
