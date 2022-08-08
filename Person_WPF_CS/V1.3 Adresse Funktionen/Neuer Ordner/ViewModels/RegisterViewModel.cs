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
    class RegisterViewModel : ViewModelBase
    {
        PersonModels PM;
        
        RegisterMessageBuilder RegMsgBldr;
        //public event PropertyChangedEventHandler PropertyChanged;

        //Models.RegisterNidel aufrufen.
        //private Models.RegisterModel _registerModel;

        //Konstruktor
        public RegisterViewModel()
        {
            Pers = new Person();
            PM = new PersonModels();
            //AM = new AdresseModels();
            RegMsgBldr = new RegisterMessageBuilder();
            //_registerModel = new Models.RegisterModel();
            OKCmd = new RelayCommand(x => ExecuteBestaetigen());
            CancelCmd = new RelayCommand(x => ExecuteClose(false));
        }

        private string _registerMessage;
        public string RegisterMessage
        {
            get { return _registerMessage; }
            set { _registerMessage = value; OnPropertyChanged("RegisterMessage"); }
        }
        private Person _pers;

        public Person Pers
        {
            get { return _pers; }
            private set { _pers = value; }
        }
        
        private void ExecuteBestaetigen()
        {
            
            //geben objekt ein  
            bool? IsRegisterGood = PM.IsRegistered(Pers);
            
            if (IsRegisterGood == true)
            {
                //AdresseModels AM = new AdresseModels();
                //AM.AdrHinzufuegen();
                //Wenn USER_ID ist gueltig,(ist Unique) registriert die Adresse auch.
                //Adresse Adr = new Adresse(HausNr, Strasse, PLZ, Stadt, Land);
                //AM.AdrHinzufuegen(ID,Adr,"AdrTyp1");
                RegisterMessage = RegMsgBldr.CreateRegisterBegruessen(Pers.ID);
                ExecuteClose(true);
            }
            else
            {
                RegisterMessage = "Die eingegebene ID wird bereits verwendet.";
            }
        }
    }
}
