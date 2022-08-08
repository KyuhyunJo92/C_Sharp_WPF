using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_WPF_CS.Models;
using System.ComponentModel;
using System.Windows.Input;


namespace Person_WPF_CS.ViewModels
{
    class AdresseBearbeitenViewModel : ViewModelBase
    {
        AdresseModels AM;

        //I don't want to have 2 parameter for one constructor,(because this is a bit complecate.) but SelectedAdr obj don't have any Primary key for saving new Adr on DB.
        //for that reason I should give UserID parameter(as a additional primary key for choosing specific line in the DB table.
        public AdresseBearbeitenViewModel(Adresse SelectedAdr,string CurrentAccount)
        {
            this.SelectedAdr = SelectedAdr;
            this._currentAccount = CurrentAccount;
            
            //AM initialisieren
            AM = new AdresseModels();

            OKCmd                = new RelayCommand(x=> ExecuteOK());
            CancelCmd            = new RelayCommand(x=> ExecuteClose(false));
        }
        public string _currentAccount { get; set; }
        private Adresse _selectedAdr;
        public Adresse SelectedAdr
        {
            get { return _selectedAdr; }
            set { _selectedAdr = value; OnPropertyChanged("SelectedAdr"); }
        }
        //funktionen fuer btn Command
        private void ExecuteOK()
        {
            AM.AdresseBearbeiten(SelectedAdr);
            ExecuteClose(true);
        }
    }
}
