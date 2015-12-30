using System;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Data;
using MagicGameTracker.Logic;
using MagicGameTracker.Logic.StatisticsReports;
using MagicGameTracker.Model;

namespace MagicGameTracker.Converters
{
    public class DeckToRatingBrushConverter: IValueConverter
    {
        public object Convert(object deck, Type targetType, object parameter, CultureInfo culture)
        {
            
            Color brushColor = new Color();
            DeckItem deckItem = (DeckItem)deck;
            RatingColorValues rcv = new RatingColorValues();

            if (deckItem.DeckGames.Count >= 5)
            {
                StatisticsCalculator statCalculator = new StatisticsCalculator();
                DeckReport deckReport = statCalculator.CalculateDeckStatistics((DeckItem)deck);

                brushColor = deckReport.WinPercent > 20 ? rcv.GetRatingColorForValue(20) : rcv.GetRatingColorForValue(0);
                brushColor = deckReport.WinPercent > 40 ? rcv.GetRatingColorForValue(40) : brushColor;
                brushColor = deckReport.WinPercent > 60 ? rcv.GetRatingColorForValue(60) : brushColor;
                brushColor = deckReport.WinPercent > 80 ? rcv.GetRatingColorForValue(80) : brushColor;
            }
            else
            {
                brushColor = rcv.GetRatingColorForValue(999);
            }

            SolidColorBrush brush = new SolidColorBrush(brushColor);

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
