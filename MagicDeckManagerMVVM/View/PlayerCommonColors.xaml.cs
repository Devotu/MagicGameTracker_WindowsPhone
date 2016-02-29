using System.Windows.Controls;
using System.Windows.Media;

using MagicGameTracker.Logic.StatisticsReports;
using MagicGameTracker.Logic.MagicEnums;

namespace MagicGameTracker.View
{
    public partial class PlayerCommonColors : UserControl
    {
        public PlayerCommonColors()
        {
            InitializeComponent();
        }

        public void PopulatePlayerCommonColors(PlayerReport pr)
        {
            elCommonPlayColor.Fill = GetColorBrush(pr.mostCommonPlayColor);
            elCommonResistanceColor.Fill = GetColorBrush(pr.mostCommonOppositionColor);
            elCommonWinColor.Fill = GetColorBrush(pr.mostCommonWinColor);
            elCommonLossColor.Fill = GetColorBrush(pr.mostCommonLossColor);
        }

        private SolidColorBrush GetColorBrush(ManaColor parsedColor)
        {
            SolidColorBrush returnBrush = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));

            switch (parsedColor)
            {
                case ManaColor.Black:
                    returnBrush.Color = Color.FromArgb(255, 0, 0, 0);
                    break;
                case ManaColor.White:
                    returnBrush.Color = Color.FromArgb(255, 255, 255, 255);
                    break;
                case ManaColor.Red:
                    returnBrush.Color = Color.FromArgb(255, 255, 0, 0);
                    break;
                case ManaColor.Blue:
                    returnBrush.Color = Color.FromArgb(255, 0, 0, 255);
                    break;
                case ManaColor.Green:
                    returnBrush.Color = Color.FromArgb(255, 0, 255, 0);
                    break;
                case ManaColor.Colorless:
                    returnBrush.Color = Color.FromArgb(255, 120, 120, 120);
                    break;
                default:
                    returnBrush.Color = Color.FromArgb(255, 120, 120, 120);
                    break;
            }
            
            return returnBrush;
        }
    }
}
