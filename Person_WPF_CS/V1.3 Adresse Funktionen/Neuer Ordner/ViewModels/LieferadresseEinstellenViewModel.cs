using Person_WPF_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_WPF_CS.ViewModels
{
    class LieferadresseEinstellenViewModel : ViewModelBase
    {
        private string _currentAccount;

        PersonModels PM;
        public LieferadresseEinstellenViewModel(Adresse SelectedAdr, string CurrentAccount)
        {
            this.SelectedAdr = SelectedAdr;
            this._currentAccount = CurrentAccount;

            PM = new PersonModels();

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
            PM.EinstellenLieferadresse(SelectedAdr, _currentAccount);
            ExecuteClose(true);
        }
    }
}
