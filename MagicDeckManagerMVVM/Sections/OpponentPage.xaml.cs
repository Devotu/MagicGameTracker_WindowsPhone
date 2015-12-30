using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MagicGameTracker.ViewModel;
using MagicGameTracker.Logic.StatisticsReports;
using MagicGameTracker.Logic;

namespace MagicGameTracker.Sections
{
    public partial class OpponentPage : PhoneApplicationPage
    {
        private MagicViewModel _mvm;
        private PlayerReport _pr;

        public OpponentPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _mvm = new MagicViewModel(App.DBCONNECTION);

            //Defaultvärden
            string opponent_Id_string = "0";
            int opponent_Id = 0;

            //Hämta rätt lek
            NavigationContext.QueryString.TryGetValue("opponent_Id", out opponent_Id_string);
            opponent_Id = Convert.ToInt32(opponent_Id_string);

            _mvm.LoadAllCollectionsFromDatabase();

            //Motståndare
            _mvm.LoadOneOpponentById(opponent_Id);
            this.DataContext = _mvm.Opponents.First();

            //Statistik mot motståndare
            StatisticsCalculator statCalculator = new StatisticsCalculator();
            _mvm.LoadAllGamesAgainstOpponent(_mvm.Opponents.First());
            _pr = statCalculator.CalculatePlayerStatistics(_mvm);

            this.PlayerWinrateAgainstOpponentView.PopulatePlayerStatistics(_pr);
            this.PlayerColorsAgainstOpponentView.PopulatePlayerCommonColors(_pr);
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Delete Opponent?", "Delete Opponent", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                if (_mvm.DeleteOpponent(_mvm.Opponents.First()))
                    {
                        MessageBox.Show("Opponent deleted");
                    }
                    else
                    {
                        MessageBox.Show("This opponent cannot be deleted");
                    }

                NavigationService.GoBack();
            }
        }
    }
}