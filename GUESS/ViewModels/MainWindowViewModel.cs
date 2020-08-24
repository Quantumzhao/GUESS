using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using GUESS.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using System.Collections.Specialized;
using Avalonia.Threading;
using GUESS.Misc;
using Avalonia.Input;
using System.Reactive.Linq;
using GUESS.Views;
using Avalonia.Animation;
using Avalonia.Animation.Easings;

namespace GUESS.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public MainWindowViewModel()
		{
			NewGame();

			GameManager.GameOver += b =>
			{
				DoesGameOverWindowOpen = true;
				DoesWin = b;
			};
		}

		public GameManager GameManager => GameManager.Singleton;
		public int TrialsRemainingCount => GameManager.MAX_TRIALS - GameManager.Gameboard.Trials.Count;
		public Colors[] Answer => GameManager.Gameboard.Answer;

		private GameboardViewModel _CurrentGameboardViewModel;
		public GameboardViewModel CurrentGameViewModel
		{
			get => _CurrentGameboardViewModel;
			private set => this.RaiseAndSetIfChanged(ref _CurrentGameboardViewModel, value);
		}

		private bool _DoesWin;
		public bool DoesWin 
		{ 
			get => _DoesWin;
			set => this.RaiseAndSetIfChanged(ref _DoesWin, value);
		}


		private bool _DoesGameOverWindowOpen = false;
		public bool DoesGameOverWindowOpen
		{
			get => _DoesGameOverWindowOpen;
			set => this.RaiseAndSetIfChanged(ref _DoesGameOverWindowOpen, value);
		}
		public void Next() => GameManager.Next();

		public void NewGame()
		{
			GameManager.StartNewGame();
			GameManager.Gameboard.Trials.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e)
				=> this.RaisePropertyChanged(nameof(TrialsRemainingCount));

			CurrentGameViewModel = new GameboardViewModel(GameManager.Gameboard);
			this.RaisePropertyChanged(nameof(TrialsRemainingCount));
			this.RaisePropertyChanged(nameof(Answer));
		}

		public void GameOverWindowButtonClicked()
		{
			DoesGameOverWindowOpen = false;
		}

		public void CloseWindow() => MainWindow.CloseWindow();
	}
}
