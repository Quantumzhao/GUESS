using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;
using GUESS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Colors = GUESS.Models.Colors;

namespace GUESS.Converters
{
	public class StdColorToBrushConverter : IValueConverter
	{
		public static StdColorToBrushConverter Singleton { get; } = new StdColorToBrushConverter();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var stdColor = (Colors)value;
			Color rgbColor;
			switch (stdColor)
			{
				case Colors.None:
					rgbColor = Color.FromUInt32(0xfff4f4f4);
					break;

				case Colors.Red:
					rgbColor = Color.FromUInt32(0xffe6317f);
					break;

				case Colors.Yellow:
					rgbColor = Color.FromUInt32(0xffffdb27);
					break;

				case Colors.Blue:
					rgbColor = Color.FromUInt32(0xff5959ce);
					break;

				case Colors.Green:
					rgbColor = Color.FromUInt32(0xff53d348);
					break;

				case Colors.Orange:
					rgbColor = Color.FromUInt32(0xffef9029);
					break;

				case Colors.Purple:
					rgbColor = Color.FromUInt32(0xff7831aa);
					break;

				default:
					throw new ArgumentException();
			}

			return new SolidColorBrush(rgbColor);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return new BindingNotification(new NotSupportedException());
		}
	}
}
