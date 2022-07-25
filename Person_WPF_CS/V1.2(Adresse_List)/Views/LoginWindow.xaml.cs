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
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private ViewModels.LoginViewModel _lvm;
        public LoginWindow()
        {
            InitializeComponent();
            _lvm = new ViewModels.LoginViewModel();
            DataContext = _lvm;

            _lvm.RequestClose += OnRequestClose;
        }
        public string ID { get; private set; }
        public Person CurrentLogedInPerson;

        private void OnRequestClose(bool isOK)
        {
            if(isOK)
            {
                ID = _lvm.ID;
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
