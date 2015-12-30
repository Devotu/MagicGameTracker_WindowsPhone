using System.Windows;
using System.Windows.Controls;

namespace MagicGameTracker.Components
{
    public partial class PickFormatComponent : UserControl
    {
        public PickFormatComponent()
        {
            InitializeComponent();
            this.lbFormatsToPick.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ShowFormats_Click(object sender, RoutedEventArgs e)
        {
            this.lbFormatsToPick.Visibility = System.Windows.Visibility.Visible;
            this.bShowFormats.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void lbFormatsToPick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.lbFormatsToPick.Visibility = System.Windows.Visibility.Collapsed;
            string formatChoosen = (string)this.lbFormatsToPick.SelectedItem;
            this.bShowFormats.Content = formatChoosen;
            this.bShowFormats.Visibility = System.Windows.Visibility.Visible;
        }        
    }
}
