using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using MagicGameTracker.Logic.MagicEnums;

namespace MagicGameTracker.View
{
    public partial class NewDeckView : UserControl
    {
        public NewDeckView()
        {
            InitializeComponent();
            List<string> deckFormats = new List<string>();
            foreach (var f in typeof(DeckFormats).GetFields())
            {
                if (f.IsLiteral)
                {
                    deckFormats.Add(f.Name);
                }
            }
            this.FormatPicker.lbFormatsToPick.ItemsSource = deckFormats;
        }

        private void tbName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "Name")
            {
                tbName.Text = "";
                SolidColorBrush BrushActive = new SolidColorBrush();
                BrushActive.Color = Colors.Black;
                tbName.Foreground = BrushActive;
            }
        }

        private void tbName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == String.Empty)
            {
                tbName.Text = "Name";
                SolidColorBrush BrushHint = new SolidColorBrush();
                BrushHint.Color = Colors.Gray;
                tbName.Foreground = BrushHint;
            }
        }

        private void tbTheme_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbTheme.Text == "Theme")
            {
                tbTheme.Text = "";
                SolidColorBrush BrushActive = new SolidColorBrush();
                BrushActive.Color = Colors.Black;
                tbTheme.Foreground = BrushActive;
            }
        }

        private void tbTheme_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbTheme.Text == String.Empty)
            {
                tbTheme.Text = "Theme";
                SolidColorBrush BrushHint = new SolidColorBrush();
                BrushHint.Color = Colors.Gray;
                tbTheme.Foreground = BrushHint;
            }
        }
    }
}
