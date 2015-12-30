using System;
using System.Windows.Media;
using System.Windows.Data;
using System.Globalization;

namespace MagicGameTracker.Converters
{
    public class WinToBrushConverter : IValueConverter
    {
        public object Convert(object win, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush();

            if ((bool)win)
            {
                brush.Color = Color.FromArgb(255, 0, 255, 0);
            }
            else
            {
                brush.Color = Color.FromArgb(255, 255, 0, 0);
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(Color.FromArgb(255,255,0,0));
        }
    }
}