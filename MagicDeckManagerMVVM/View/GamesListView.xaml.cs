using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using MagicGameTracker.Model;

namespace MagicGameTracker.View
{
    public partial class GamesListView : UserControl
    {
        public GamesListView()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var frame = App.Current.RootVisual as PhoneApplicationFrame;
            ListBox deckListBox = (ListBox)sender;
            GameItem game = (GameItem)deckListBox.SelectedItem;

            if (game != null)
            {
                frame.Navigate(new Uri("/Sections/GamePage.xaml?game_Id=" + game.GameId, UriKind.Relative));
            }  
        }
    }
}
