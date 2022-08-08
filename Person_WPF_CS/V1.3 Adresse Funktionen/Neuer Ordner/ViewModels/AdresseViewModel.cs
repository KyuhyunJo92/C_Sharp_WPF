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
    
    class AdresseViewModel : ViewModelBase
    {
        AdresseModels AM;
        PersonModels PM;
        
        public AdresseViewModel(Person CurrentPerson)
        {
            PM = new PersonModels();
            this.CurrentPerson = PM.getPersonFromDB(CurrentPerson.ID);


            AM = new AdresseModels();
            //take AdrInfo from DB_tbl_Adr and Update Adr obj.

            //read DB and aktuallisieren AdrList mit aktuelle Datei.
            AdrList = AM.getAdrListVonDB(CurrentPerson.ID);
            
            //verbinden button und command. 
            AdrHinzufuegenCmd = new RelayCommand(x => CallAdrHinzufuegen());

            

            AdrBearbeiten = new RelayCommand(x => CallAdrBearbeiter(SelectedAdr));
            AdrEntfernen = new RelayCommand(x => CallAdrLoeschen(SelectedAdr));
            LieferadresseEinstellen = new RelayCommand(x => CallLieferadresseEinstellen(SelectedAdr));

            CancelCmd = new RelayCommand(x => ExecuteClose(false));
        }


        //Properties
        private List<Adresse> _adrList;
        public List<Adresse> AdrList
        {
            get { return _adrList; }
            set { _adrList = value; OnPropertyChanged("AdrList"); }
        }
        private Adresse _selectedAdr;
        public Adresse SelectedAdr
        {
            get { return _selectedAdr; }
            set { _selectedAdr = value; }
        }

        private Person _currentPerson;

        public Person CurrentPerson
        {
            get { return _currentPerson; }
            set { _currentPerson = value; OnPropertyChanged("CurrentPerson");}
        }
        //Command Declaration 
        
        //Column 1
        public ICommand AdrHinzufuegenCmd { get; private set; }

        //Column 3
        public ICommand AdrBearbeiten { get; private set; }
        public ICommand AdrEntfernen { get; private set; }
        public ICommand LieferadresseEinstellen { get; private set; }

        //Aktuelle FunKtionen von command
        private void CallAdrHinzufuegen()
        {
            AdresseHinzufuegenWindow AHW = new AdresseHinzufuegenWindow(CurrentPerson.ID);
            AHW.ShowDialog();
            AdrList = AM.getAdrListVonDB(CurrentPerson.ID);
        }

        private void CallAdrBearbeiter(Adresse SelectedAdr)
        {
            AdresseBearbeitenWindow ABW = new AdresseBearbeitenWindow(SelectedAdr,CurrentPerson.ID);
            ABW.ShowDialog();
            //aufrufen Funktionen fuer Fenster neu laden  
            AdrList = AM.getAdrListVonDB(CurrentPerson.ID);
        } 

        //Parameter Adr1 or Adr2, value of Memory = NULL.
        private void CallAdrLoeschen(Adresse SelectedAdr)
        {
            AdresseLoeschenWindow ALW = new AdresseLoeschenWindow(SelectedAdr, CurrentPerson.ID);
            ALW.ShowDialog();
            //aufrufen Funktionen fuer Fenster neu laden  
            AdrList = AM.getAdrListVonDB(CurrentPerson.ID);
        }

        private void CallLieferadresseEinstellen(Adresse SelectedAdr)
        {
            LieferadresseEinstellenWindow LEW = new LieferadresseEinstellenWindow(SelectedAdr,CurrentPerson.ID);
            LEW.ShowDialog();
            AdrList = AM.getAdrListVonDB(CurrentPerson.ID);
            this.CurrentPerson = PM.getPersonFromDB(CurrentPerson.ID);
        }

    }
}