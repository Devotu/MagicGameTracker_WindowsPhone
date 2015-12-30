using System.Windows;
using System.Windows.Controls;

namespace MagicGameTracker.View.About
{
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();

            this.EmailDeveloper.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void bShowCommentView_Click(object sender, RoutedEventArgs e)
        {
            this.EmailDeveloper.Visibility = System.Windows.Visibility.Visible;

            this.bShowCommentView.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
