using System;
using System.Windows;
using Microsoft.Phone.Controls;
using MagicGameTracker.Model;
using MagicGameTracker.ViewModel;

namespace MagicGameTracker.Sections
{
    public partial class AddOpponentPage : PhoneApplicationPage
    {
        private MagicViewModel _mvm;

        public AddOpponentPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _mvm = new MagicViewModel(App.DBCONNECTION);
            _mvm.LoadAllOpponentsFromDatabase();
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            _mvm.AddOpponent(new OpponentItem { Name = this.AddOpponentView.tbOpponentName.Text });

            this.AddOpponentView.tbOpponentName.Text = "Opponent Name";

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Opponent was added");

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}