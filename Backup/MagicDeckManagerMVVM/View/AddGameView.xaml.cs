using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MagicGameTracker.Converters;

namespace MagicGameTracker.View
{
    public partial class AddGameView : UserControl
    {
        public AddGameView()
        {
            InitializeComponent();
        }

        private void slPerformanceRating_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slPerformanceRating != null)
            {
                DeckToPerformanceratingBrushConverter prToBrushConverter = new DeckToPerformanceratingBrushConverter();
                slPerformanceRating.Foreground = prToBrushConverter.GetPerformanceRatingBrush(e.NewValue);
            }
        }

        private void tbComment_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbComment.Text == "Comment")
            {
                tbComment.Text = "";
                SolidColorBrush BrushActive = new SolidColorBrush();
                BrushActive.Color = Colors.Black;
                tbComment.Foreground = BrushActive;
            }
        }

        private void tbComment_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbComment.Text == String.Empty)
            {
                tbComment.Text = "Comment";
                SolidColorBrush BrushHint = new SolidColorBrush();
                BrushHint.Color = Colors.Gray;
                tbComment.Foreground = BrushHint;
            }
        }
    }
}
