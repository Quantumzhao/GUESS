using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;
using GUESS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GUESS.Converters
{
	public class StatusToBrushConverter : IValueConverter
	{
		public static StatusToBrushConverter Singleton { get; } = new StatusToBrushConverter();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
			=> new SolidColorBrush(((Status)value) switch
		{
			Status.HalfHalf => Color.FromUInt32(0xffeae463),
			Status.Correct => Color.FromUInt32(0xffade887),
			Status.Wrong => Color.FromUInt32(0xfff26b6b),
			Status.None => Color.FromUInt32(0xfff4f4f4),
			_ => throw new NotSupportedException()
	});

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return new BindingNotification(new NotSupportedException());
		}
	}
}
