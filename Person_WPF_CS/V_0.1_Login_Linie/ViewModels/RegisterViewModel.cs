using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace Person_WPF_CS.ViewModels
{
    //public delegate void RequestCloseEventHandler(bool isOK);
    class RegisterViewModel /*: INotifyPropertyChanged*/
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        
        //Models.RegisterNidel aufrufen.
        //private Models.RegisterModel _registerModel;

        //Konstruktor
        public RegisterViewModel()
        {
            //_registerModel = new Models.RegisterModel();
            OKCmd = new RelayCommand(x => ExecuteClose(true));
            CancelCmd = new RelayCommand(x => ExecuteClose(false));
        }
        public string ID { get; set; }
        public string PW { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string EMail { get; set; }
        public string TelNr { get; set; }
        public string HausNr{ get; set; }
        public string PLZ { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }
        public ICommand OKCmd { get; private set; }
        public ICommand CancelCmd { get; private set; }

        public event RequestCloseEventHandler RequestClose;
        private void ExecuteClose(bool isOK)
        {
            RequestClose?.Invoke(isOK);
        }
    }
}
