using Avalonia;
using Avalonia.Controls;
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
			Position = new Point(42, 48 + (12 + 94) * index);
		}

		public Point Position { get; }
		public Trial Trial { get; }
		public List<bool?> Correctness => Trial.Correctness;

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
			// test
			Peg1 = Colors.Red;
			Peg2 = Colors.Yellow;
			Peg3 = Colors.Blue;
			Peg4 = Colors.Green;
			DoesShowSubmitButton = false;
			GameManager.Singleton.SubmitCurrent();
			GameManager.Singleton.Next();
		}
	}
}
