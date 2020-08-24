using System;
using System.Collections.Generic;
using System.Linq;
using GUESS.Models;

namespace CLI
{
	class Program
	{
		private static readonly Dictionary<char, Colors> _ColorMap = new Dictionary<char, Colors>();
		static void Main(string[] args)
		{
			var gamemanager = new GameManager();
			gamemanager.StartNewGame();
			_ColorMap.Add('r', Colors.Red);
			_ColorMap.Add('y', Colors.Yellow);
			_ColorMap.Add('b', Colors.Blue);
			_ColorMap.Add('g', Colors.Green);
			_ColorMap.Add('o', Colors.Orange);
			_ColorMap.Add('p', Colors.Purple);
			gamemanager.GameOver += b =>
			{
				if (b)
				{
					Console.WriteLine("Win\n");
				}
				else
				{
					Console.WriteLine($"Lose: {new string(gamemanager.Gameboard.Answer.Select(c => c.ToString()[0]).ToArray())}\n");
				}
				gamemanager.StartNewGame();
			};

			while (true)
			{
				Console.WriteLine("Enter a sequence of: R Y B G O P");
				var entry = Console.ReadLine();
				for (int i = 0; i < entry.Length; i++)
				{
					gamemanager.Gameboard.Current.Balls[i] = _ColorMap[entry[i]];
				}
				gamemanager.SubmitCurrent();
				Console.WriteLine($"{entry}: {new Func<IEnumerable<char>, string>(c => new string(c.ToArray(), 0, c.Count()))(gamemanager.Gameboard.Current.Correctness.Select(s => s.ToString()[0]))}");
				gamemanager.Next();
			}
		}
	}
}
