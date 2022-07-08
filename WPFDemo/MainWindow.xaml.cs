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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo
{
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btn_calc_age(object sender, RoutedEventArgs e)
		{
			string dob = tb_dob.Text;
			DateTime birthday = DateTime.Parse(dob);

			int age = (int)((DateTime.Today - birthday).TotalDays / 365); // ignores leap years
			lbl_age.Text = string.Format("Du bist {0} Jahre alt.", age);
		}
	}
}
