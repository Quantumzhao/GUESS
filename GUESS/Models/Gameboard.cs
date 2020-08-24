using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace GUESS.Models
{
	public class GameManager
	{
		public const int MAX_TRIALS = 10;
		public const int PEG_COUNTS = 4;

		public readonly static GameManager Singleton = new GameManager();
		public event Action<bool> GameOver;

		public Gameboard Gameboard { get; private set; }

		public void StartNewGame()
		{
			Gameboard = new Gameboard();
			Next();
		}

		public void SubmitCurrent()
		{
			var tempList = Gameboard.Answer.ToList().ToArray();
			var tempTrial = Gameboard.Current.Balls.ToArray();
			Func<Colors, int> find = c =>
			{
				for (int i = 0; i < PEG_COUNTS; i++)
				{
					if (tempList[i] == c)
					{
						return i;
					}
				}
				return -1;
			};

			for (int i = 0; i < PEG_COUNTS; i++)
			{
				if (Gameboard.Current.Balls[i] == tempList[i])
				{
					Gameboard.Current.Correctness[i] = Status.Correct;
					tempList[i] = Colors.None;
					tempTrial[i] = Colors.None;
				}
			}
			for (int i = 0; i < PEG_COUNTS; i++)
			{
				if (tempTrial[i] == Colors.None)
				{
					continue;
				}

				var pairIndex = find(Gameboard.Current.Balls[i]);
				if (pairIndex != -1)
				{
					Gameboard.Current.Correctness[i] = Status.HalfHalf;
					tempList[pairIndex] = Colors.None;
				}
				else
				{
					Gameboard.Current.Correctness[i] = Status.Wrong;
				}
			}
		}

		public void Next()
		{
			if (Gameboard.Current?.Correctness.All(e => e == Status.Correct) ?? false)
			{
				GameOver?.Invoke(true);
			}
			else if (MAX_TRIALS - Gameboard.Trials.Count == 0)
			{
				GameOver?.Invoke(false);
			}
			else
			{
				Gameboard.Trials.Add(new Trial());
			}
		}
	}

	public class Gameboard
	{
		public Gameboard()
		{
			for (int i = 0; i < GameManager.PEG_COUNTS; i++)
			{
				Answer[i] = (Colors)_Random.Next(1, 6);
			}
#if DEBUG
			//Answer = new Colors[] { Colors.Green, Colors.Red, Colors.Blue, Colors.Green };
#endif
		}

		private static Random _Random = new Random();
		public ObservableCollection<Trial> Trials { get; } = new ObservableCollection<Trial>();
		public Trial Current => Trials.Count == 0 ? null : Trials[^1];
		public Colors[] Answer { get; } = new Colors[GameManager.PEG_COUNTS];
	}

	public class Trial
	{
		public Colors[] Balls { get; } = new Colors[GameManager.PEG_COUNTS];
		public Status[] Correctness { get; } = new Status[GameManager.PEG_COUNTS];
		public void Fill(int index, Colors color)
		{
			Balls[index] = color;
		}
	}

	public enum Colors
	{
		None, 
		Red, 
		Yellow, 
		Blue, 
		Green, 
		Orange, 
		Purple
	}

	public enum Status
	{
		None,
		Correct,
		HalfHalf,
		Wrong
	}
}
