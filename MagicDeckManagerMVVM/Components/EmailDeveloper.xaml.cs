using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using Microsoft.Phone.Tasks;
using MagicGameTracker.Logic;

namespace MagicGameTracker.Components
{
    public partial class EmailDeveloper : UserControl
    {
        public EmailDeveloper()
        {
            InitializeComponent();
        }

        private void bSendEmail_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;

            EmailComposeTask emailComposeTast = new EmailComposeTask();
            VersionFetcher versionFetcher = new VersionFetcher();

            emailComposeTast.Subject = this.tbSubject.Text;
            emailComposeTast.Body = this.tbCommentsToSend.Text +
                "\nI'm using Magic Game Tracker for Windows Phone version " +
                versionFetcher.getAppVersion();
            emailComposeTast.To = "devotu.developer@gmail.com";

            emailComposeTast.Show();
        }

        private void tbSubject_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbSubject.Text == "Subject")
            {
                tbSubject.Text = "";
                SolidColorBrush BrushActive = new SolidColorBrush();
                BrushActive.Color = Colors.Black;
                tbSubject.Foreground = BrushActive;
            }
        }

        private void tbSubject_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbSubject.Text == String.Empty)
            {
                tbSubject.Text = "Subject";
                SolidColorBrush BrushHint = new SolidColorBrush();
                BrushHint.Color = Colors.Gray;
                tbSubject.Foreground = BrushHint;
            }
        }

        private void tbCommentsToSend_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbCommentsToSend.Text == "Comment")
            {
                tbCommentsToSend.Text = "";
                SolidColorBrush BrushActive = new SolidColorBrush();
                BrushActive.Color = Colors.Black;
                tbCommentsToSend.Foreground = BrushActive;
            }
        }

        private void tbCommentsToSend_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbCommentsToSend.Text == String.Empty)
            {
                tbCommentsToSend.Text = "Comment";
                SolidColorBrush BrushHint = new SolidColorBrush();
                BrushHint.Color = Colors.Gray;
                tbCommentsToSend.Foreground = BrushHint;
            }
        }

        
    }
}
