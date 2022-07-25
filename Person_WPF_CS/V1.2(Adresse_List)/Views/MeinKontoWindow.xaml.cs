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
    /// Interaktionslogik für MeinKontoWindow.xaml
    /// </summary>
    public partial class MeinKontoWindow : Window
    {
        private MeinKontoViewModel _MKVM;
        private string _ID;
        public MeinKontoWindow(string ID)
        {
            InitializeComponent();
            _MKVM = new MeinKontoViewModel(ID);
            this._ID = ID;
            DataContext = _MKVM;
        }
    }
}
