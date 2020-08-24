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
			=> ((value as SolidColorBrush).Color.ToUint32()) switch
		{
			0xfff4f4f4 => Colors.None,
			0xffe6317f => Colors.Red,
			0xffffdb27 => Colors.Yellow,
			0xff5959ce => Colors.Blue,
			0xff53d348 => Colors.Green,
			0xffef9029 => Colors.Orange,
			0xff7831aa => Colors.Purple,
			_ => throw new NotSupportedException(),
		};
	}
}
