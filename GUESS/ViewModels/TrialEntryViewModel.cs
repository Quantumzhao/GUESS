using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using GUESS.Misc;
using GUESS.Models;
using GUESS.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace GUESS.ViewModels
{
	public class TrialEntryViewModel : ViewModelBase
	{
		public TrialEntryViewModel(Trial trial, int index)
		{
			Trial = trial;
			Position = new Point(42 - 17, 48 + 94 * index - 17);
		}

		private bool _DoesShowSubmitButton = true;
		public Point Position { get; }
		public Trial Trial { get; }
		public TrialEntryView View { get; set; }
		public Status[] Correctness => Trial.Correctness;

		public bool DoesShowSubmitButton
		{
			get => _DoesShowSubmitButton;
			set => this.RaiseAndSetIfChanged(ref _DoesShowSubmitButton, value);
		}

		public Colors Peg0
		{
			get => Trial.Balls[0];
			set => this.RaiseAndSetIfChanged(ref Trial.Balls[0], value);
		}
		public Colors Peg1
		{
			get => Trial.Balls[1];
			set => this.RaiseAndSetIfChanged(ref Trial.Balls[1], value);
		}
		public Colors Peg2
		{
			get => Trial.Balls[2];
			set => this.RaiseAndSetIfChanged(ref Trial.Balls[2], value);
		}
		public Colors Peg3
		{
			get => Trial.Balls[3];
			set => this.RaiseAndSetIfChanged(ref Trial.Balls[3], value);
		}

		public Status Indicator0 => Correctness[0];
		public Status Indicator1 => Correctness[1];
		public Status Indicator2 => Correctness[2];
		public Status Indicator3 => Correctness[3];

		public void SubmitButtonClicked()
		{
			DoesShowSubmitButton = false;
			GameManager.Singleton.SubmitCurrent();
			for (int i = 0; i < GameManager.PEG_COUNTS; i++)
			{
				this.RaisePropertyChanged($"Indicator{i}");
				var indicator = View.FindControl<Border>($"Indicator{i}");
				indicator.Classes.Add((Correctness[i] == Status.Correct).ToString());
			}

			GameManager.Singleton.Next();
		}
	}
}
