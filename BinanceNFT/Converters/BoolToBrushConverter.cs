using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace BinanceNFT.Converters
{
	public class BoolToBrushConverter : IValueConverter
	{
		private readonly SolidColorBrush _trueBrush = Brushes.LimeGreen;
		private readonly SolidColorBrush _falseBrush = Brushes.Transparent;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return DependencyProperty.UnsetValue;

			var sourceValue = (bool)value;
			return sourceValue ? _trueBrush : _falseBrush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
