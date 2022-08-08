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
    /// Interaktionslogik für AdresseHinzufuegenWindow.xaml
    /// </summary>
    public partial class AdresseHinzufuegenWindow : Window
    {
        AdresseHinzufuegenViewModel AHVM;
        public AdresseHinzufuegenWindow(string CurrentAccount)
        {
            InitializeComponent();
            AHVM = new AdresseHinzufuegenViewModel(CurrentAccount);
            DataContext = AHVM;
            AHVM.RequestClose += OnRequestClose;
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
