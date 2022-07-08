using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PopUpDemo
{
	// Event-Handler für RequestClose-Event
	public delegate void RequestCloseEventHandler(bool isOK);

	public class PopUpViewModel
	{
		// ---------------------------------------------------------------------------
		// Konstruktor
		public PopUpViewModel()
		{
			// Commands für Button
			OKCmd = new RelayCommand(x => ExecuteClose(true));
			CancelCmd = new RelayCommand(x => ExecuteClose(false));
		}

		// ---------------------------------------------------------------------------
		// Properties für Binding:
		public string Name { get; set; }
		public ICommand OKCmd { get; private set; }
		public ICommand CancelCmd { get; private set; }

		// ---------------------------------------------------------------------------
		// Event zur Benachrichtigung an das Fenster, damit dieses geschlossen wird
		public event RequestCloseEventHandler RequestClose;

		// ---------------------------------------------------------------------------
		// Funktion für Buttons:
		private void ExecuteClose(bool isOK)
		{
			// Löst Event aus, damit Fenster geschlossen wird:
			RequestClose?.Invoke(isOK);
		}
	}
}
