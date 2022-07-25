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
using Person_WPF_CS.Models;

namespace Person_WPF_CS.Views
{

    /// <summary>
    /// Interaktionslogik für AdresseWindow.xaml
    /// </summary>
    public partial class AdresseWindow : Window
    {
        private ViewModels.AdresseViewModel _AVM;
        string ID;
        public AdresseWindow(string _ID)
        {
            this.ID = _ID;
            InitializeComponent();
            _AVM = new ViewModels.AdresseViewModel(_ID);
            DataContext = _AVM;

            //_AVM.RequestClose += OnRequestClose;
        }

        /* public string ID { get; private set; }
         * 
         * private void OnRequestClose(bool isOK)
        {
            if(isOK)
            {
                ID = _AVM.ID;

                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
            Close();
        }*/
    }
}
