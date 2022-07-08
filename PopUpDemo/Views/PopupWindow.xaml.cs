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

namespace PopUpDemo
{
	/// <summary>
	/// Interaction logic for PopupWindow.xaml
	/// </summary>
	public partial class PopupWindow : Window
	{
		private PopUpViewModel _vm;

		// ---------------------------------------------------------------------------
		// Konstruktor
		public PopupWindow()
		{
			InitializeComponent();
			_vm = new PopUpViewModel();
			DataContext = _vm;

			// Abonniert "RequestClose"-Event, um Benachrichtigung zu erhalten
			_vm.RequestClose += OnRequestClose;
		}

		// ---------------------------------------------------------------------------
		// Informationen, die das Fenster nach außen gibt
		public string UserName { get; private set; }

		// ---------------------------------------------------------------------------
		// Funktion, die "RequestClose"-Event abonniert hat:
		private void OnRequestClose(bool isOK)
		{
			if (isOK)
			{
				// OK-Button wurde geklickt: Eingegebenen Namen setzen
				UserName = _vm.Name;

				// Ergebnis des Fensters ist OK (true)
				DialogResult = true;
			}
			else
			{
				// Fenster wurde geschlossen oder es wurde "Abbrechen" geklickt
				// Ergebnis des Fenster ist nicht OK (false)
				DialogResult = false;
			}

			// Fenster schließen
			Close();
		}
	}
}
