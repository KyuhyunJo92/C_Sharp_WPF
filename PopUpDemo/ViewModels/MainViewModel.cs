using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PopUpDemo
{
	public class MainViewModel : INotifyPropertyChanged
	{
		// Einfaches Model als Beispiel:
		private GreetingBuilder _greetingBuilder;

		// ---------------------------------------------------------------------------
		// Konstruktor
		public MainViewModel()
		{
			_greetingBuilder = new GreetingBuilder();//Model Instance Initialize
			GetGreetingCmd = new RelayCommand(x => ExecuteGreeting());//LSP?
		}

		// ---------------------------------------------------------------------------
		// Command für Button:
		public ICommand GetGreetingCmd { get; private set; }//LSP?

        // ---------------------------------------------------------------------------
        // Text-Property für Begrüßung, die angezeigt wird
        private string _greeting = "";
		public string Greeting
		{
			get { return _greeting; }
			set { _greeting = value; OnPropertyChanged("Greeting"); }
		}

		// ---------------------------------------------------------------------------
		// Funktion, die durch das "Greeting"-Command ausgeführt wird
		private void ExecuteGreeting()
		{
			// neues Fenster anlegen und anzeigen
			PopupWindow p = new PopupWindow();
			bool? res = p.ShowDialog();

			if (res == true)
			{
				// OK wurde geklickt: Informationen aus PopupWindow abrufen an Model übergeben und Begrüßung anzeigen:
				Greeting = _greetingBuilder.CreateGreeting(p.UserName);
			}
			else
			{
				// Abbrechen wurde geklickt, oder Fenster wurde mit "X" geschlossen
				Greeting = ":(";
			}
		}

		// ---------------------------------------------------------------------------
		// PropertyChanged-Event:
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}
	}
}
