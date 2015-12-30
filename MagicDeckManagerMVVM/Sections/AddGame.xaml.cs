using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using MagicGameTracker.ViewModel;
using MagicGameTracker.Model;
using Microsoft.Phone.Shell;

namespace MagicGameTracker.Sections
{
    public partial class AddGame : PhoneApplicationPage
    {
        int _activeDeckId;
        private MagicViewModel _mvm;

        public AddGame()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Defaultvärden
            string deck_Id_string = "0";

            //Hämta tillhörande lek-id
            NavigationContext.QueryString.TryGetValue("deck_Id", out deck_Id_string);
            _activeDeckId = Convert.ToInt32(deck_Id_string);

            _mvm = new MagicViewModel(App.DBCONNECTION);
            _mvm.LoadAllCollectionsFromDatabase();

            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;

            this.AddGameView.OpponentPicker.DataContext = _mvm.Opponents;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            GameItem newGameItem = GetGameItem();
            if (newGameItem != null)
            {
                _mvm.AddGame(newGameItem);

                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
            else
            {
                MessageBox.Show("Parameters missing, no game was added");
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Game was added");

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private GameItem GetGameItem()
        {
            var addGameView = this.AddGameView as View.AddGameView;

            if (addGameView.rbWin.IsChecked == true || addGameView.rbLoss.IsChecked == true)
            {
                string colors = "";
                var colorPicker = addGameView.ColorPicker;
                colors = (Convert.ToBoolean(colorPicker.cbBlack.IsChecked)) ? colors + "1" : colors + "0";
                colors = (Convert.ToBoolean(colorPicker.cbWhite.IsChecked)) ? colors + "1" : colors + "0";
                colors = (Convert.ToBoolean(colorPicker.cbRed.IsChecked)) ? colors + "1" : colors + "0";
                colors = (Convert.ToBoolean(colorPicker.cbBlue.IsChecked)) ? colors + "1" : colors + "0";
                colors = (Convert.ToBoolean(colorPicker.cbGreen.IsChecked)) ? colors + "1" : colors + "0";

                OpponentItem opponent = new OpponentItem();

                if (this.AddGameView.OpponentPicker.lbOpponentsToPick.SelectedItem != null)
                {
                    opponent = this.AddGameView.OpponentPicker.lbOpponentsToPick.SelectedItem as OpponentItem;
                }
                else
                {
                    opponent = _mvm.Opponents.First();
                }

                //Version 3.3.1.1
                string comment = addGameView.tbComment.Text;
                if (comment == "Comment")
                {
                    comment = "No Comment";
                }

                //Version 4.0.0.0


                GameItem newGameItem = new GameItem
                {
                    Colors = colors,
                    Win = (addGameView.rbWin.IsChecked == true) ? true : false,
                    Comment = comment,
                    Date = DateTime.Now,
                    GameDeck = (from DeckItem deck in _mvm.Decks where deck.DeckId == _activeDeckId select deck).Single(),
                    Opponent = opponent,
                    PerformanceRating = addGameView.slPerformanceRating.Value
                };

                return newGameItem;
            }
            else
            {
                return null;
            }
        }

        private void Pivot_LoadingPivotItem(object sender, PivotItemEventArgs e)
        {
            ApplicationBar.IsVisible = !((((Pivot)sender).SelectedIndex) == 1);
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }

        //Återställer screen mode
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Enabled;
        }
    }
}