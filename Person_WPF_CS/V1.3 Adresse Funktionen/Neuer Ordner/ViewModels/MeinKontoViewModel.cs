using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;//ICommand
using Person_WPF_CS.Models;
using Person_WPF_CS.Views;
using System.ComponentModel;

namespace Person_WPF_CS.ViewModels
{
    //public delegate void RequestCloseEventHandler(bool isOK);
    class MeinKontoViewModel : ViewModelBase
    {
        public MeinKontoViewModel(Person CurrentPerson)
        {
            this._currentPerson = CurrentPerson;
            MeineBestellungenBtnCmd = new RelayCommand(x => CallMeinBestrellungenWindow());
            AdresseBtnCmd = new RelayCommand(x => CallAdresseWindow());
            MeineZahlungenBtnCmd = new RelayCommand(x => CallMeineZahlungenWindow());
            AnmeldenUndSicherheitBtnCmd = new RelayCommand(x => CallAnmeldenUndSicherheitWindow());

            CancelCmd = new RelayCommand(x => ExecuteClose(false));
        }
        Person _currentPerson;

        public ICommand MeineBestellungenBtnCmd { get; set; }
        public ICommand AdresseBtnCmd { get; set; }
        public ICommand MeineZahlungenBtnCmd { get; set; }
        public ICommand AnmeldenUndSicherheitBtnCmd { get; set; }


        private void CallMeinBestrellungenWindow()
        {
        }
        private void CallAdresseWindow()
        {
            AdresseWindow A = new AdresseWindow(_currentPerson);
            bool? res = A.ShowDialog();
        }
        private void CallMeineZahlungenWindow()
        {
        }
        private void CallAnmeldenUndSicherheitWindow()
        {

        }
    }
}
