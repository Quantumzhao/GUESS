using Avalonia.Controls.Shapes;
using Avalonia.Media;
using GUESS.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GUESS.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public GameboardViewModel CurrentGameViewModel { get; private set; }
		public GameManager GameManager { get; } = new GameManager();
		public int TrialsRemainingCount => GameManager.MAX_TRIALS - GameManager.Gameboard.Trials.Count;

		public void NewGame()
		{
			GameManager.StartNewGame();
			CurrentGameViewModel = new GameboardViewModel(GameManager.Gameboard);
		}

		public void Next() => GameManager.Next();
	}
}
