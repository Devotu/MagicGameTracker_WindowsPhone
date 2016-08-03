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
using Microsoft.Phone.Controls;
using System.Xml;
using MagicGameTracker.Logic;

namespace MagicGameTracker.Sections
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            VersionFetcher versionFetcher = new VersionFetcher();

            this.tbVersion.DataContext = versionFetcher.getAppVersion();
        }

        private void AboutPivot_DoubleTap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/ExportPage.xaml", UriKind.Relative));
        }
    }
}