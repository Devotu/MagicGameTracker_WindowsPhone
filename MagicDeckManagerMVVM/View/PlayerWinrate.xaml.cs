using System.Windows.Controls;

using MagicGameTracker.Logic.StatisticsReports;

namespace MagicGameTracker.View
{
    public partial class PlayerWinrate : UserControl
    {
        public PlayerWinrate()
        {
            InitializeComponent();
        }

        public void PopulatePlayerStatistics(PlayerReport pr)
        {
            txtTotal.Text = (pr.Wins + pr.Losses).ToString();
            txtWin.Text = pr.Wins.ToString();
            txtLoss.Text = pr.Losses.ToString();
            txtPercent.Text = pr.WinPercent.ToString();
        }
    }
}
