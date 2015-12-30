using System;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using MagicGameTracker.Model;

namespace MagicGameTracker.View
{
    public partial class DeckListView : UserControl
    {
        public DeckListView()
        {
            InitializeComponent();
        }

        private void Deck_Selected(object sender, SelectionChangedEventArgs e)
        {            
            var frame = App.Current.RootVisual as PhoneApplicationFrame;
            ListBox deckListBox = (ListBox)sender;
            DeckItem deck = (DeckItem)deckListBox.SelectedItem;

            if (deck != null)
            {
                frame.Navigate(new Uri("/Sections/DeckPage.xaml?deck_Id=" + deck.DeckId, UriKind.Relative));
            }            
        }
    }
}
