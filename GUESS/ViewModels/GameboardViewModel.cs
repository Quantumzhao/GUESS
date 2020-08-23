using Avalonia;
using GUESS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections.Specialized;
using Avalonia.Controls.Shapes;
using ReactiveUI;
using Avalonia.Controls;

namespace GUESS.ViewModels
{
	public class GameboardViewModel : ViewModelBase
	{
		public GameboardViewModel(Gameboard gameboard)
		{
			Gameboard = gameboard;
			Gameboard.Trials.CollectionChanged += 
				(object sender, NotifyCollectionChangedEventArgs e) => AddNewVm(e.NewItems[0] as Trial, gameboard.Trials.Count - 1);
			AddNewVm(gameboard.Current, 0);
		}

		public Gameboard Gameboard { get; }
		public ObservableCollection<TrialEntryViewModel> TrialEntryViewModels { get; }
			= new ObservableCollection<TrialEntryViewModel>();
		public ObservableCollection<string> test { get; set; } 
			= new ObservableCollection<string> { "Hello" };

		private Point _HighlightPosition;
		public Point HighlightPosition
		{ 
			get => _HighlightPosition; 
			set => this.RaiseAndSetIfChanged(ref _HighlightPosition, value); 
		}

		private double _GameboardHeight = 617;
		public double GameboardHeight
		{
			get => _GameboardHeight;
			set => this.RaiseAndSetIfChanged(ref _GameboardHeight, value);
		}

		private void AddNewVm(Trial trial, int index)
		{
			var vm = new TrialEntryViewModel(trial, index);
			TrialEntryViewModels.Add(vm);
			HighlightPosition = new Point(vm.Position.X - 17, vm.Position.Y - 17);
			if (index >= 5)
			{
				GameboardHeight += 104;
			}
		}
	}
}
