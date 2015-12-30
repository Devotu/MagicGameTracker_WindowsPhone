using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;
using MagicGameTracker.Logic;

namespace MagicGameTracker.Converters
{
    public class IntToLifeBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int _value = (int)value;
            Color brushColor = new Color();
            RatingColorValues rcv = new RatingColorValues();

            brushColor = _value > 0 ? rcv.GetRatingColorForValue(20) : rcv.GetRatingColorForValue(0);
            brushColor = _value >= 5 ? rcv.GetRatingColorForValue(40) : brushColor;
            brushColor = _value >= 10 ? rcv.GetRatingColorForValue(60) : brushColor;
            brushColor = _value >= 20 ? rcv.GetRatingColorForValue(80) : brushColor;

            SolidColorBrush brush = new SolidColorBrush(brushColor);

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
