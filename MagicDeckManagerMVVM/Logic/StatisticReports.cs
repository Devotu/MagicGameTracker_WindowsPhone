using MagicGameTracker.Logic.MagicEnums;
using System.Collections.Generic;

namespace MagicGameTracker.Logic
{
    namespace StatisticsReports
    {
        public class DeckReport
        {
            public float Wins { get; set; }
            public float Losses { get; set; }
            public float WinSinceAltered { get; set; }
            public float LossesSinceAltered { get; set; }
            public ManaColor mostCommonWinColor { get; set; }
            public ManaColor mostCommonLossColor { get; set; }
            public decimal WinPercent { get; set; }
            public decimal LossPercent { get { return 100 - this.WinPercent; } }
            public decimal WinPercentSinceAltered { get; set; }
            public decimal LossPercentSinceAltered { get { return 100 - this.WinPercentSinceAltered; } }
            public double PerformancRating { get; set; }

            public DeckReport()
            {
                this.Wins = this.WinSinceAltered = 0;
                this.Losses = this.LossesSinceAltered = 0;
                this.WinPercent = this.WinPercentSinceAltered = 0;
                this.PerformancRating = 0;
            }
        }

        public class PlayerReport
        {
            public float Wins { get; set; }
            public float Losses { get; set; }
            public decimal WinPercent { get; set; }
            public decimal LossPercent { get { return 100 - this.WinPercent; } }
            public ManaColor mostCommonPlayColor { get; set; }
            public ManaColor mostCommonOppositionColor { get; set; }
            public ManaColor mostCommonWinColor { get; set; }
            public ManaColor mostCommonLossColor { get; set; }
            public List<double> colorsUsed;
            public List<double> colorsInDecks;

            public PlayerReport()
            {
                this.Wins = 0;
                this.Losses = 0;
                this.WinPercent = 0;
                this.colorsUsed = new List<double>{0, 0, 0, 0, 0};
                this.colorsInDecks = new List<double> { 0, 0, 0, 0, 0 };
            }
        }
    }
    
}
