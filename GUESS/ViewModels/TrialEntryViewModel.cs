using Avalonia;
using Avalonia.Interactivity;
using GUESS.Models;
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
		}

		public Trial Trial { get; }
		public List<bool?> Correctness => Trial.Correctness;
		public Point Position { get; }

		private bool _DoesShowSubmitButton = true;
		public bool DoesShowSubmitButton
		{
			get => _DoesShowSubmitButton;
			set => this.RaiseAndSetIfChanged(ref _DoesShowSubmitButton, value);
		}

		public Colors Peg1
		{
			get
			{
				return Trial.Balls[0];
			}

			set => this.RaiseAndSetIfChanged(ref Trial.Balls[0], value);
		}
		public Colors Peg2
		{
			get
			{
				return Trial.Balls[1];
			}

			set => this.RaiseAndSetIfChanged(ref Trial.Balls[1], value);
		}
		public Colors Peg3
		{
			get
			{
				return Trial.Balls[2];
			}

			set => this.RaiseAndSetIfChanged(ref Trial.Balls[2], value);
		}
		public Colors Peg4
		{
			get
			{
				return Trial.Balls[3];
			}

			set => this.RaiseAndSetIfChanged(ref Trial.Balls[3], value);
		}

		public void SubmitButtonClicked()
		{
			GameManager.Singleton.SubmitCurrent();
			DoesShowSubmitButton = false;
		}
	}
}
