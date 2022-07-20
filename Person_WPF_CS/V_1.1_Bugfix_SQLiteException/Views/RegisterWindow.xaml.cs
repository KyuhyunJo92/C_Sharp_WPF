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
    /// Interaktionslogik für RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private ViewModels.RegisterViewModel _rvm;
        public RegisterWindow()
        {
            InitializeComponent();
            _rvm = new ViewModels.RegisterViewModel();
            DataContext = _rvm;

            _rvm.RequestClose += OnRequestClose;
        }
        public string ID { get; private set; }
        private void OnRequestClose(bool isOK)
        {
            if (isOK)
            {
                ID = _rvm.ID;

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
