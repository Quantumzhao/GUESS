using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GUESS.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public GameboardViewModel Gameboard { get; } = new GameboardViewModel();
	}
}
