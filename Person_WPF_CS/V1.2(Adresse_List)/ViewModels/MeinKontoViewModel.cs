using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;//ICommand
using Person_WPF_CS.Models;
using Person_WPF_CS.Views;
using System.Data.SQLite;

namespace Person_WPF_CS.ViewModels
{
    class MeinKontoViewModel
    {
        public MeinKontoViewModel(string _ID)
        {
            this.ID = _ID;
            MeineBestellungenBtnCmd = new RelayCommand(x => CallMeinBestrellungenWindow());
            AdresseBtnCmd = new RelayCommand(x => CallAdresseWindow());
            MeineZahlungenBtnCmd = new RelayCommand(x => CallMeineZahlungenWindow());
            ZumStartbildschirmBtnCmd = new RelayCommand( x=> CallZumMainWindow());
        }
        string ID;

        public ICommand MeineBestellungenBtnCmd { get; set; }
        public ICommand AdresseBtnCmd { get; set; }
        public ICommand MeineZahlungenBtnCmd { get; set; }
        public ICommand AnmeldenUndSicherheitBtnCmd { get; set; }
        public ICommand ZumStartbildschirmBtnCmd { get; set; }


        private void CallMeinBestrellungenWindow()
        {
            //declaration
            //with new Keyword. Erstellen einen Instanze.
            //Benutzen showDialog function
        }
        private void CallAdresseWindow()
        {
            //declaration
            AdresseWindow A = new AdresseWindow(ID);
            //with new Keyword. Erstellen einen Instanze.
            bool? res = A.ShowDialog();
            //Benutzen showDialog function
        }
        private void CallMeineZahlungenWindow()
        {
            //declaration
            //with new Keyword. Erstellen einen Instanze.
            //Benutzen showDialog function
        }
        private void CallZumMainWindow()
        {

        }

        

            
    }
}
