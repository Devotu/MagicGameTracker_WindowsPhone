using System.Windows.Controls;

using MagicGameTracker.Model;
using MagicGameTracker.Converters;
using MagicGameTracker.Logic;
using MagicGameTracker.Logic.StatisticsReports;
using System.Collections.Generic;

namespace MagicGameTracker.View
{
    public partial class DeckStatisticsView : UserControl
    {
        public DeckStatisticsView()
        {
            InitializeComponent();
        }

        public void PopulateStatistics(DeckItem deck, List<GameItem> games)
        {
            StatisticsCalculator statCalculator = new StatisticsCalculator();
            DeckReport deckReport = statCalculator.CalculateDeckStatistics(deck);

            txtRecentWin.Text = deckReport.WinSinceAltered.ToString();
            txtRecentLoss.Text = deckReport.LossesSinceAltered.ToString();
            txtRecentPercent.Text = deckReport.WinPercentSinceAltered.ToString() + "%";

            txtTotalWin.Text = deckReport.Wins.ToString();
            txtTotalLoss.Text = deckReport.Losses.ToString();
            txtTotalPercent.Text = deckReport.WinPercent.ToString() + "%";

            DeckToPerformanceratingBrushConverter converter = new DeckToPerformanceratingBrushConverter();
            slAveragePerformanceRating.Value = deckReport.PerformancRating;
            slAveragePerformanceRating.Foreground = converter.GetPerformanceRatingBrush(deckReport.PerformancRating);

            WinrateHistoryGraph.PopulateWinrateHistory(games);
        }
    }
}
