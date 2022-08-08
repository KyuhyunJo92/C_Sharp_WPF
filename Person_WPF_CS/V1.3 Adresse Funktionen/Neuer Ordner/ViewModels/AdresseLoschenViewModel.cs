using Person_WPF_CS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Person_WPF_CS.ViewModels
{
    class AdresseLoschenViewModel : ViewModelBase
    {
        private string _currentAccount;

        AdresseModels AM;

        public AdresseLoschenViewModel(Adresse SelectedAdr, string CurrentAccount)
        {
            this.SelectedAdr = SelectedAdr;
            this._currentAccount = CurrentAccount;

            AM = new AdresseModels();
            
            OKCmd = new RelayCommand(x => ExecuteOK());
            CancelCmd = new RelayCommand(x => ExecuteClose(false));
        }
        private Adresse _selectedAdr;
        public Adresse SelectedAdr
        {
            get { return _selectedAdr; }
            set { _selectedAdr = value; OnPropertyChanged("SelectedAdr"); }
        }
       
        //funktionen fuer btn Command
        private void ExecuteOK()
        {
            AM.AdresseLoeschen(SelectedAdr, _currentAccount);
            ExecuteClose(true);
        }
    }
}
