using Avalonia;
using GUESS.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
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

		public bool?[] CorrectnessPanel => Trial.Correctness.ToArray();
		public Point Position { get; }
	}
}
