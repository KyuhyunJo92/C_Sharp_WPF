using Person_WPF_CS.Models;
using Person_WPF_CS.ViewModels;
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

namespace Person_WPF_CS.Views
{
    /// <summary>
    /// Interaktionslogik für AdresseLoeschenWindow.xaml
    /// </summary>
    public partial class AdresseLoeschenWindow : Window
    {
        private AdresseLoschenViewModel _AdrLoeschenVM;
        public AdresseLoeschenWindow(Adresse Adr, string UserID)
        {
            InitializeComponent();
            _AdrLoeschenVM = new AdresseLoschenViewModel(Adr, UserID);
            DataContext = _AdrLoeschenVM;
            _AdrLoeschenVM.RequestClose += OnRequestClose;
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
