using Microsoft.Phone.Controls;

using MagicGameTracker.ViewModel;
using MagicGameTracker.Logic;
using MagicGameTracker.Logic.StatisticsReports;
using System;
using MagicGameTracker.Model;
using System.Collections.Generic;
using System.Linq;

namespace MagicGameTracker.Sections
{
    public partial class PlayerPage : PhoneApplicationPage
    {
        private MagicViewModel _mvm;
        private PlayerReport _pr;

        public PlayerPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            StatisticsCalculator statCalculator = new StatisticsCalculator();

            _mvm = new MagicViewModel(App.DBCONNECTION);

            //Total statistik
            _mvm.LoadAllCollectionsFromDatabase();
            _pr = statCalculator.CalculatePlayerStatistics(_mvm);
            var games = from GameItem game in _mvm.Games select game;
            this.PlayerWinrateView.PopulatePlayerStatistics(_pr);
            this.PlayerWinrateGraph.PopulateWinrateHistory(games.ToList());
            this.PlayerColorsUsedGraph.setTitle("Colors played");
            this.PlayerColorsUsedGraph.PopulateColorsUsed(_pr.colorsUsed);

            //Aktiva lekar
            _mvm.LoadAllGamesPlayedWithActiveDecks();
            _pr = statCalculator.CalculatePlayerStatistics(_mvm);
            games = from GameItem game in _mvm.Games select game;
            this.ActivePlayerWinrateView.PopulatePlayerStatistics(_pr);
            this.ActiveWinrateGraph.PopulateWinrateHistory(games.ToList());
            this.ActiveColorsUsedGraph.setTitle("Colors played");
            this.ActiveColorsUsedGraph.PopulateColorsUsed(_pr.colorsUsed);

            //Dagens statistik
            _mvm.LoadAllTodaysGames();
            _pr = statCalculator.CalculatePlayerStatistics(_mvm);
            games = from GameItem game in _mvm.Games select game;
            this.TodayPlayerWinrateView.PopulatePlayerStatistics(_pr);
            this.TodayWinrateGraph.PopulateWinrateHistory(games.ToList());
            this.TodayColorsUsedGraph.setTitle("Colors played");
            this.TodayColorsUsedGraph.PopulateColorsUsed(_pr.colorsUsed);

            //Colors
            //Active
            _mvm.LoadActiveDecksFromDatabase();
            _pr = statCalculator.CalculatePlayerStatistics(_mvm);
            games = from GameItem game in _mvm.Games select game;
            this.ColorsFoundInAciveDecksGraph.setTitle("Times found in active decks");
            this.ColorsFoundInAciveDecksGraph.PopulateColorsUsed(_pr.colorsInDecks);

            //All
            _mvm.LoadAllDecksFromDatabase();
            _pr = statCalculator.CalculatePlayerStatistics(_mvm);
            this.ColorsFoundInAllDecksGraph.setTitle("Times found in all decks");
            this.ColorsFoundInAllDecksGraph.PopulateColorsUsed(_pr.colorsInDecks);

        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }
    }
}