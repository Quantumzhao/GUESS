using Avalonia;
using GUESS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections.Specialized;

namespace GUESS.ViewModels
{
	public class GameboardViewModel : ViewModelBase
	{
		public GameboardViewModel(Gameboard gameboard)
		{
			Gameboard = gameboard;

			Gameboard.Trials.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
			{
				TrialEntryViewModels.Add(new TrialEntryViewModel(e.NewItems[0] as Trial, Gameboard.Trials.Count - 1));
			};
		}

		public Gameboard Gameboard { get; }
		public ObservableCollection<TrialEntryViewModel> TrialEntryViewModels { get; }
			= new ObservableCollection<TrialEntryViewModel>();
		public Point HighlightLocation { get; }
	}
}
