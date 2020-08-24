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
			=> new SolidColorBrush(((Colors)value) switch
		{
			Colors.None => Color.FromUInt32(0xfff4f4f4),
			Colors.Red => Color.FromUInt32(0xffe6317f),
			Colors.Yellow => Color.FromUInt32(0xffffdb27),
			Colors.Blue => Color.FromUInt32(0xff5959ce),
			Colors.Green => Color.FromUInt32(0xff53d348),
			Colors.Orange => Color.FromUInt32(0xffef9029),
			Colors.Purple => Color.FromUInt32(0xff7831aa),
			_ => throw new NotSupportedException(),
		});

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var rgbColor = (value as SolidColorBrush).Color;
			switch (rgbColor.ToUint32())
			{
				case 0xfff4f4f4:
					return Colors.None;

				case 0xffe6317f:
					return Colors.Red;

				case 0xffffdb27:
					return Colors.Yellow;

				case 0xff5959ce:
					return Colors.Blue;

				case 0xff53d348:
					return Colors.Green;

				case 0xffef9029:
					return Colors.Orange;

				case 0xff7831aa:
					return Colors.Purple;

				default:
					throw new NotSupportedException();
			}
		}
	}
}
