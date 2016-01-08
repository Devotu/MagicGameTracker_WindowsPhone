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
using MagicGameTracker.Model;
using MagicGameTracker.Converters;

namespace MagicGameTracker.Components
{
    public partial class WinrateHistoryGraphSlim : UserControl
    {
        private Double gh, gw, percent;
        private SolidColorBrush defaultColor;
        int strokeThickness;

        public WinrateHistoryGraphSlim()
        {
            InitializeComponent();

            this.gh = this.WinrateHistoryCanvas.Height;
            this.gw = this.WinrateHistoryCanvas.Width;
            this.percent = 100;

            this.defaultColor = new SolidColorBrush(Colors.White);
            this.strokeThickness = 4;
        }

        public void PopulateWinrateHistory(List<GameItem> games){

            this.WinrateHistoryCanvas.Children.Clear();

            if (games.Count > 1)
            {
                this.tbThen.Text = games.Count + " games ago";

                games.OrderBy(game => game.Date);

                List<GameItem> gamesPlayed = new List<GameItem>();
                List<ColorPoint> instances = new List<ColorPoint>();

                DoubleToPerformanceRatingBrushConverter converter = new DoubleToPerformanceRatingBrushConverter();

                for (int i = 0; i < games.Count; i++)
                {
                    gamesPlayed.Add(games[i]);
                    double winrate = CalculateWinrate(gamesPlayed);

                    SolidColorBrush ratingBrush;
                    if (gamesPlayed.Count > 4)
                    {
                        ratingBrush = (SolidColorBrush)converter.Convert(winrate);
                    }
                    else
                    {
                        ratingBrush = defaultColor;
                    }
                    
                    double y = gh - (winrate * (gh/percent));
                    double x = i * ((gw-10) / (games.Count-1));
                    instances.Add(new ColorPoint(x, y, ratingBrush));
                }

                ColorPoint lastPoint = instances.First();
                foreach (ColorPoint point in instances)
                {
                    if (lastPoint != point)
                    {
                        Line line = new Line();
                        line.Stroke = point.brush;
                        line.StrokeThickness = strokeThickness;

                        line.X1 = lastPoint.x;
                        line.Y1 = lastPoint.y;
                        line.X2 = point.x;
                        line.Y2 = point.y;

                        this.WinrateHistoryCanvas.Children.Add(line);
                    }
                    lastPoint = point;
                } 
            }
        }

        private double CalculateWinrate(List<GameItem> gamesPlayed)
        {
            double wins, losses;
            wins = losses= 0;
            
            foreach (GameItem game in gamesPlayed)
            {
                if (game.Win)
                {
                    wins = wins + 1;
                }
                else
                {
                    losses = losses + 1;
                }
            }

            double winrate = percent * (wins / (wins + losses));

            return winrate;
        }

        private class ColorPoint
        {
            public double x { get; set; }
            public double y { get; set; }
            public SolidColorBrush brush { get; set; }

            public ColorPoint(double x, double y, SolidColorBrush brush)
            {
                this.x = x;
                this.y = y;
                this.brush = brush;
            }
        }

    }
}
