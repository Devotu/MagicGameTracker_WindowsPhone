using MagicGameTracker.Logic.MagicEnums;
using MagicGameTracker.Logic.MagicEventArgs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MagicGameTracker.Components
{
    public partial class PickFormatComponent : UserControl
    {
        public PickFormatComponent()
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
            this.lbFormatsToPick.ItemsSource = deckFormats;

            this.lbFormatsToPick.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ShowFormats_Click(object sender, RoutedEventArgs e)
        {
            this.lbFormatsToPick.Visibility = System.Windows.Visibility.Visible;
            this.bShowFormats.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void lbFormatsToPick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.lbFormatsToPick.Visibility = System.Windows.Visibility.Collapsed;
            var choosenFormat = this.lbFormatsToPick.SelectedItem;
            this.bShowFormats.Content = choosenFormat.ToString();
            this.bShowFormats.Visibility = System.Windows.Visibility.Visible;

            //Null check makes sure the main page is attached to the event
            if (this.SelectedFormatChange != null)
            {
                FormatEventArgs args = new FormatEventArgs();
                args.format = (DeckFormats)Enum.Parse(typeof(DeckFormats), choosenFormat.ToString());
                this.SelectedFormatChange(new object(), args);
            }
                
        }

        public event EventHandler<FormatEventArgs> SelectedFormatChange;
        
    }

}
