using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Person_WPF_CS.ViewModels;
using Person_WPF_CS.Models;

namespace Person_WPF_CS.Views
{
    /// <summary>
    /// Interaktionslogik für AdresseBearbeitenWindow.xaml
    /// </summary>
    public partial class AdresseBearbeitenWindow : Window
    {
        private AdresseBearbeitenViewModel _AdrBearbeitenVM; 

        public AdresseBearbeitenWindow(Adresse Adr,string UserID)
        {
            InitializeComponent();
            _AdrBearbeitenVM = new AdresseBearbeitenViewModel(Adr,UserID);
            DataContext = _AdrBearbeitenVM;
            _AdrBearbeitenVM.RequestClose += OnRequestClose;
        }

        //cancel Command
        private void OnRequestClose(bool isOK)
        {
            if (isOK)
            {
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
            Close();
        }
    }
}
