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
    /// Interaktionslogik für LieferadresseEinstellenWindow.xaml
    /// </summary>
    public partial class LieferadresseEinstellenWindow : Window
    {

        private LieferadresseEinstellenViewModel _lieferadrEinstellenVM;
        public LieferadresseEinstellenWindow(Adresse Adr, string UserID)
        {
            InitializeComponent();
            _lieferadrEinstellenVM = new LieferadresseEinstellenViewModel(Adr, UserID);
            DataContext = _lieferadrEinstellenVM;
            _lieferadrEinstellenVM.RequestClose += OnRequestClose;
        }
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
