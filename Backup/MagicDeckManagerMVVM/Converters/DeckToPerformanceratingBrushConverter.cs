using System;
using System.Windows.Media;
using System.Windows.Data;
using System.Globalization;
using MagicGameTracker.Model;

namespace MagicGameTracker.Converters
{
    public class DeckToPerformanceratingBrushConverter : IValueConverter
    {
        public object Convert(object deck, Type targetType, object parameter, CultureInfo culture)
        {
            DeckItem deckItem = (DeckItem)deck;
            SolidColorBrush performanceBrush = new SolidColorBrush();

            return performanceBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }

        public SolidColorBrush GetPerformanceRatingBrush(double performancRatingValue)
        {
            return new SolidColorBrush(GetPerformanceRatingColor(performancRatingValue));
        }

        private Color GetPerformanceRatingColor(double performanceRating)
        {
            Color brushColor = new Color();

            brushColor = performanceRating > 20 ? Color.FromArgb(255, 255, 128, 0) : Color.FromArgb(255, 255, 0, 0);
            brushColor = performanceRating > 40 ? Color.FromArgb(255, 255, 255, 0) : brushColor;
            brushColor = performanceRating > 60 ? Color.FromArgb(255, 128, 255, 0) : brushColor;
            brushColor = performanceRating > 80 ? Color.FromArgb(255, 0, 255, 0) : brushColor;

            return brushColor;
        }
    }
}
