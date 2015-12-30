using System;
using System.Windows.Data;
using System.Globalization;

namespace MagicGameTracker.Converters
{
    public class WinToTextConverter : IValueConverter
    {
        public object Convert(object win, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)win)
            {
                return "Win";
            }
            else
            {
                return "Loss";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "Win")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
