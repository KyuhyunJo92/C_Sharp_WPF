using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Person_WPF_CS.Models;
using System.Windows.Input;

namespace Person_WPF_CS.ViewModels
{
    //public delegate void RequestCloseEventHandler(bool isOK);
    class RegisterViewModel : INotifyPropertyChanged
    {
        RegisterModel RModel;
        RegisterMessageBuilder RegMsgBldr;
        //public event PropertyChangedEventHandler PropertyChanged;

        //Models.RegisterNidel aufrufen.
        //private Models.RegisterModel _registerModel;

        //Konstruktor
        public RegisterViewModel()
        {
            RModel = new RegisterModel();
            RegMsgBldr = new RegisterMessageBuilder();
            //_registerModel = new Models.RegisterModel();
            OKCmd = new RelayCommand(x => ExecuteBestaetigen());
            CancelCmd = new RelayCommand(x => ExecuteClose(false));
        }

        private string _registerErrorMessage;
        public string RegisterErrorMessage
        {
            get { return _registerErrorMessage; }
            set { _registerErrorMessage = value; OnPropertyChanged("RegisterErrorMessage"); }
        }

        public string ID { get; set; }
        public string PW { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string EMail { get; set; }
        public string TelNr { get; set; }
        public string HausNr { get; set; }
        public string PLZ { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }
        public ICommand OKCmd { get; private set; }
        public ICommand CancelCmd { get; private set; }

        public event RequestCloseEventHandler RequestClose;
        private void ExecuteBestaetigen()
        {
            Person p = new Person()
            {
                ID = this.ID,
                PW = this.PW,
                Vorname = this.Vorname,
                Nachname = this.Nachname,
                EMail = this.EMail,
                TelNr = this.TelNr,
                HausNr = this.HausNr,
                PLZ = this.PLZ,
                Stadt = this.Stadt,
                Land = this.Land
            };
            bool? IsRegisterGood = RModel.IsRegistered(p);

            if (IsRegisterGood == true)
            {
                RegisterErrorMessage = RegMsgBldr.CreateRegisterBegruessen(p.ID);
                ExecuteClose(true);
            }
            else
            {
                RegisterErrorMessage = "Die eingegebene ID wird bereits verwendet.";
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private void ExecuteClose(bool isOK)
        {
            RequestClose?.Invoke(isOK);
        }
    }
}
