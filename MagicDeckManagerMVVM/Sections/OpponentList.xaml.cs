using Microsoft.Phone.Controls;
using System;
using MagicGameTracker.ViewModel;

namespace MagicGameTracker.Sections
{
    public partial class OpponentList : PhoneApplicationPage
    {
        private MagicViewModel _mvm;

        public OpponentList()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _mvm = new MagicViewModel(App.DBCONNECTION);
            _mvm.LoadAllOpponentsFromDatabase();
            this.DataContext = _mvm.Opponents;
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml?AboutPivot.SelectedIndex = 3", UriKind.Relative));
        }

        private void bAddOpponent_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AddOpponentPage.xaml", UriKind.Relative));
        }
    }
}