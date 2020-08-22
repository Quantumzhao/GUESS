using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;

namespace GUESS.Converters
{
	public class RemainingTrialsToBrushConverter : IValueConverter
	{
		public static RemainingTrialsToBrushConverter Singleton { get; } = new RemainingTrialsToBrushConverter();
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var count = (int)value;
			if (count <= 1)
			{
				return new SolidColorBrush(Color.FromUInt32(0xfff26b6b));
			}
			else if (count <= 4)
			{
				return new SolidColorBrush(Color.FromUInt32(0xffd3bb2f));
			}
			else
			{
				return new SolidColorBrush(Color.FromUInt32(0xff31e661));
			}
		}
		
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return new BindingNotification(new NotSupportedException());
		}
	}
}
