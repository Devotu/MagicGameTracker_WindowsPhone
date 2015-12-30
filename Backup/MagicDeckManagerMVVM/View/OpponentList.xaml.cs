using System.Windows.Controls;
using MagicGameTracker.Model;
using System.Windows;
using Microsoft.Phone.Controls;
using System;


namespace MagicGameTracker.View
{
    public partial class OpponentList : UserControl
    {
        public OpponentList()
        {
            InitializeComponent();
        }

        private void lbOpponentNames_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Delete Opponent?", "Delete opponent", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                ListBox opponentListBox = (ListBox)sender;
                OpponentItem opponentSelected = (OpponentItem)opponentListBox.SelectedItem;

                if (opponentSelected != null)
                {
                    if (App.MagicViewModel.DeleteOpponent(opponentSelected))
                    {
                        MessageBox.Show("Opponent deleted");
                    }
                    else
                    {
                        MessageBox.Show("This opponent cannot be deleted");
                    }
                }
            }
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var frame = App.Current.RootVisual as PhoneApplicationFrame;
            ListBox deckListBox = (ListBox)sender;
            OpponentItem opponent = (OpponentItem)deckListBox.SelectedItem;

            if (opponent != null)
            {
                frame.Navigate(new Uri("/Sections/OpponentPage.xaml?opponent_Id=" + opponent.OpponentId, UriKind.Relative));
            }
        }
    }
}
