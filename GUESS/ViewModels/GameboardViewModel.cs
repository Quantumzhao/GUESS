using GUESS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GUESS.ViewModels
{
	public class GameboardViewModel : ViewModelBase
	{
		public Gameboard Gameboard { get; set; } = new Gameboard();
	}
}
