using System.Windows;
using System.Windows.Controls;
using MagicGameTracker.Model;

namespace MagicGameTracker.Components
{
    public partial class PickOpponentComponent : UserControl
    {
        public PickOpponentComponent()
        {
            InitializeComponent();
            this.lbOpponentsToPick.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ShowOpponents_Click(object sender, RoutedEventArgs e)
        {
            this.lbOpponentsToPick.Visibility = System.Windows.Visibility.Visible;
            this.bShowOpponents.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void lbOpponentsToPick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.lbOpponentsToPick.Visibility = System.Windows.Visibility.Collapsed;
            OpponentItem opponentChoosen = (OpponentItem)this.lbOpponentsToPick.SelectedItem;
            this.bShowOpponents.Content = opponentChoosen.Name;
            this.bShowOpponents.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
