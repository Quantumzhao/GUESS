using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media;
using GUESS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace GUESS.Converters
{
	public class BoolToPromptConverter : IValueConverter
	{
		public static BoolToPromptConverter Singleton { get; } = new BoolToPromptConverter();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var doesWin = (bool)value;
			var section = (string)parameter;
			if (doesWin)
			{
				if (section == "Header")
				{
					return "That's a Win!";
				}
				else
				{
					return "Cool!";
				}
			}
			else
			{
				if (section == "Header")
				{
					return "That's a Lose";
				}
				else
				{
					return "Alright";
				}
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
