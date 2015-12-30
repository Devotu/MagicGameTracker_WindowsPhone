using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using MagicGameTracker.Model;

namespace MagicGameTracker.View
{
    public partial class AddOpponent : UserControl
    {
        public AddOpponent()
        {
            InitializeComponent();
        }

        private void tbOpponentName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbOpponentName.Text == "Opponent Name")
            {
                tbOpponentName.Text = "";
                SolidColorBrush BrushActive = new SolidColorBrush();
                BrushActive.Color = Colors.Black;
                tbOpponentName.Foreground = BrushActive;
            }
        }

        private void tbOpponentName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbOpponentName.Text == String.Empty)
            {
                tbOpponentName.Text = "Opponent Name";
                SolidColorBrush BrushHint = new SolidColorBrush();
                BrushHint.Color = Colors.Gray;
                tbOpponentName.Foreground = BrushHint;
            }
        }
    }
}
