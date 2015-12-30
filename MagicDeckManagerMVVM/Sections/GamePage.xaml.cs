using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using MagicGameTracker.ViewModel;

namespace MagicGameTracker.Sections
{
    public partial class GamePage : PhoneApplicationPage
    {
        private MagicViewModel _mvm;

        public GamePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _mvm = new MagicViewModel(App.DBCONNECTION);

            //Defaultvärden
            string game_Id_string = "0";
            int game_Id = 0;

            //Hämta rätt lek
            NavigationContext.QueryString.TryGetValue("game_Id", out game_Id_string);
            game_Id = Convert.ToInt32(game_Id_string);

            _mvm.LoadOneGameById(game_Id);
            this.DataContext = _mvm.Games.First();
            this.GameDetails.txtOpponent.DataContext = _mvm.Games.First().Opponent;
            this.GameDetails.SetColors(_mvm.Games.First().Colors);
        }

        private void bDeleteGame_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Delete Game?", "Delete this game", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    _mvm.DeleteGame(_mvm.Games.First());
                    MessageBox.Show("Game deleted");
                    NavigationService.GoBack();
                }
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }
    }
}