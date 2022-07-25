using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using Person_WPF_CS.Models;
using Person_WPF_CS.Views;
namespace Person_WPF_CS.ViewModels
{
    //Login ViewModel.cs, einmal deklariert schon. kann man nicht zweimal gleiche Dinge deklarieren.
    //public delegate void RequestCloseEventHandler(bool isOK);
    
    
    class AdresseViewModel : INotifyPropertyChanged
    {
        AdresseHinzufuegenModel AHM;

        AdresseBearbeitenModel ABM1;
        AdresseEntfernenModel AEM1;

        AdresseBearbeitenModel ABM2;
        AdresseEntfernenModel AEM2;
        
        UpdateAdresse UA;
        


        
        public AdresseViewModel(string _ID)
        {
            //take AdrInfo from DB_tbl_Adr and Update Adr obj.
            UA.Execute(Adr1, _ID, "AdrType1");
            UA.Execute(Adr2, _ID, "AdrType2");
            
            //currently logined ID
            this.ID = _ID;

            //verbinden button und command. 
            //reactive command about user's input
            CancelCmd = new RelayCommand(x => ExecuteClose(false));
            AdresseBearbeiten1 = new RelayCommand(x => ExecuteClose(false));
            AdresseBearbeiten2 = new RelayCommand(x => ExecuteClose(false));
            AdresseEntfernen1 = new RelayCommand(x => ExecuteClose(false));
            AdresseEntfernen2 = new RelayCommand(x => ExecuteClose(false));

            //make Instance and Initialization 
            //they will be used by each command of button.
            AHM = new AdresseHinzufuegenModel();

            ABM1 = new AdresseBearbeitenModel();
            AEM1 = new AdresseEntfernenModel();
            
            ABM2 = new AdresseBearbeitenModel();
            AEM2 = new AdresseEntfernenModel();

            //Adresse zeichnen auf fenster an.
            
        }
        //im Fenster, Zeigt werte von properties. 
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        //eventHandler Close
        public event RequestCloseEventHandler RequestClose;
        private void ExecuteClose(bool isOK)
        {
            RequestClose?.Invoke(isOK);
        }

        //Member Variables
        string ID;
        //properties
        private Adresse Adr1 { get; set; }
        private Adresse Adr2 { get; set; }


        //Command Declaration
        public ICommand CancelCmd { get; private set; }
        public ICommand AdresseBearbeiten1 { get; private set; }
        public ICommand AdresseBearbeiten2 { get; private set; }
        public ICommand AdresseEntfernen1 { get; private set; }
        public ICommand AdresseEntfernen2 { get; private set; }

        //Aktuelle FunKtionen von command
        private void CallAdrBearbeiter(string _adresseNummer)
        {
            string AdresseNummer = _adresseNummer;
            AdresseBearbeitenWindow AB = new AdresseBearbeitenWindow();

            //aufrufen Funktionen fuer Fenster neu laden     
        } 
        private void CallAdrDeleteModel(string _adresseNummer)
        {
            //aufrufen, AdresseEntfernenModel.
        }

        
    }
}
