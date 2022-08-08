using Person_WPF_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Person_WPF_CS.ViewModels
{
    class AdresseHinzufuegenViewModel : ViewModelBase
    {
        string _currentAccount;
        AdresseModels AM;
        public AdresseHinzufuegenViewModel(string CurrentAccount)
        {
            this._currentAccount = CurrentAccount;

            AM = new AdresseModels();
            NeueAdr = new Adresse();

            OKCmd = new RelayCommand(x => ExecuteOK());
            CancelCmd = new RelayCommand(x => ExecuteClose(false));
        }
        public Adresse NeueAdr { get; set; }
        
        private void ExecuteOK()
        {
            AM.AdrHinzufuegen(_currentAccount, NeueAdr);
            ExecuteClose(true);
        }

    }
}
