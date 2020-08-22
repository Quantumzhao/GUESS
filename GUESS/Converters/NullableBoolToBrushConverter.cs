using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GUESS.Converters
{
	public class NullableBoolToBrushConverter : IValueConverter
	{
		public static NullableBoolToBrushConverter Singleton { get; } = new NullableBoolToBrushConverter();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var b = (bool?)value;
			Color color;

			switch (b)
			{
				case null:
					color = Color.FromUInt32(0xffade887);
					break;

				case true:
					color = Color.FromUInt32(0xffeae463);
					break;

				case false:
					color = Color.FromUInt32(0xfff26b6b);
					break;

				default:
					throw new ArgumentException();
			}

			return new SolidColorBrush(color);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return new BindingNotification(new NotSupportedException());
		}
	}
}
