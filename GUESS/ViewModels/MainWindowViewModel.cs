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
			NewGame = ReactiveCommand.Create(() =>
			{
				GameManager.StartNewGame();
				return GameManager.Gameboard;
			});

			GameManager.Gameboard.Trials.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) 
				=> this.RaisePropertyChanged(nameof(TrialsRemainingCount));
			
			NewGame.Subscribe(gb => CurrentGameViewModel = new GameboardViewModel(gb));
		}

		public GameManager GameManager => GameManager.Singleton;
		public int TrialsRemainingCount => GameManager.MAX_TRIALS - GameManager.Gameboard.Trials.Count;
		public ReactiveCommand<Unit, Gameboard> NewGame { get; }

		private GameboardViewModel _CurrentGameboardViewModel;
		public GameboardViewModel CurrentGameViewModel 
		{
			get => _CurrentGameboardViewModel;
			private set => this.RaiseAndSetIfChanged(ref _CurrentGameboardViewModel, value);
		}

		public void Next() => GameManager.Next();
	}
}
