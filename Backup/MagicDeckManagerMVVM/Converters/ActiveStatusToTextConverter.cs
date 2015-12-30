using System;
using System.Globalization;
using System.Windows.Data;

namespace MagicGameTracker.Converters
{
    public class ActiveStatusToTextConverter : IValueConverter
    {
        public object Convert(object status, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Boolean)status)
            {
                return "Active";
            }
            else
            {
                return "Inactive";
            }
        }

        public object ConvertBack(object status, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)status == "Active")
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
