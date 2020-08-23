using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using GUESS.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using System.Collections.Specialized;
using Avalonia.Threading;

namespace GUESS.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public MainWindowViewModel()
		{
			NewGame();

			GameManager.Gameboard.Trials.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) 
				=> this.RaisePropertyChanged(nameof(TrialsRemainingCount));
		}

		public GameManager GameManager => GameManager.Singleton;
		public int TrialsRemainingCount => GameManager.MAX_TRIALS - GameManager.Gameboard.Trials.Count;

		private GameboardViewModel _CurrentGameboardViewModel;
		public GameboardViewModel CurrentGameViewModel 
		{
			get => _CurrentGameboardViewModel;
			private set => this.RaiseAndSetIfChanged(ref _CurrentGameboardViewModel, value);
		}

		public void Next() => GameManager.Next();

		public void NewGame()
		{
			GameManager.StartNewGame();
			CurrentGameViewModel = new GameboardViewModel(GameManager.Gameboard);
		}
	}
}
