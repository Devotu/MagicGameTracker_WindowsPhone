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
using MagicGameTracker.Model;
using MagicGameTracker.Logic;
using System.Globalization;

namespace MagicGameTracker.Converters
{
    public class DoubleToPerformanceRatingBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double _value = (double)value;
            return this.Convert(_value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }

        public SolidColorBrush Convert(double value)
        {
            Color brushColor = new Color();
            RatingColorValues rcv = new RatingColorValues();

            if (value != null)
            {
                brushColor = value > 20 ? rcv.GetRatingColorForValue(20) : rcv.GetRatingColorForValue(0);
                brushColor = value > 40 ? rcv.GetRatingColorForValue(40) : brushColor;
                brushColor = value > 60 ? rcv.GetRatingColorForValue(60) : brushColor;
                brushColor = value > 80 ? rcv.GetRatingColorForValue(80) : brushColor;
            }
            else
            {
                brushColor = rcv.GetRatingColorForValue(999);
            }

            SolidColorBrush brush = new SolidColorBrush(brushColor);

            return brush;
        }
    }
}
