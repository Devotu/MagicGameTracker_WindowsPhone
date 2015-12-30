using Microsoft.Phone.Controls;

using MagicGameTracker.ViewModel;
using MagicGameTracker.Logic;
using MagicGameTracker.Logic.StatisticsReports;
using System;

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
            this.PlayerWinrateView.PopulatePlayerStatistics(_pr);
            this.PlayerCommonColorsView.PopulatePlayerCommonColors(_pr);
            this.PlayerColorsUsedGraph.setTitle("Colors played");
            this.PlayerColorsUsedGraph.PopulateColorsUsed(_pr.colorsUsed);

            //Aktiva lekar
            _mvm.LoadAllGamesPlayedWithActiveDecks();
            _pr = statCalculator.CalculatePlayerStatistics(_mvm);
            this.ActivePlayerWinrateView.PopulatePlayerStatistics(_pr);
            this.ActiveCommonColorsView.PopulatePlayerCommonColors(_pr);
            this.ActiveColorsUsedGraph.setTitle("Colors played");
            this.ActiveColorsUsedGraph.PopulateColorsUsed(_pr.colorsUsed);

            //Dagens statistik
            _mvm.LoadAllTodaysGames();
            _pr = statCalculator.CalculatePlayerStatistics(_mvm);
            this.TodayPlayerWinrateView.PopulatePlayerStatistics(_pr);
            this.TodayPlayerCommonColorsView.PopulatePlayerCommonColors(_pr);
            this.TodayColorsUsedGraph.setTitle("Colors played");
            this.TodayColorsUsedGraph.PopulateColorsUsed(_pr.colorsUsed);

            //Colors
            //Active
            _mvm.LoadActiveDecksFromDatabase();
            _pr = statCalculator.CalculatePlayerStatistics(_mvm);
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