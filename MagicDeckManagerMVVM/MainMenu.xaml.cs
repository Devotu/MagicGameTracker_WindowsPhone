using System;
using System.Windows;
using Microsoft.Phone.Controls;
using MagicGameTracker.ViewModel;
using MagicGameTracker.Logic.MagicEnums;

namespace MagicGameTracker
{
    public partial class MainMenu : PhoneApplicationPage
    {
        private MagicViewModel _mvm;

        public MainMenu()
        {
            InitializeComponent();
            this._mvm = new MagicViewModel(App.DBCONNECTION);
            DatabaseCondition databaseStatus = _mvm.CheckAndMaintainDatabase();
            if (databaseStatus != DatabaseCondition.Intact)
            {
                if (databaseStatus == DatabaseCondition.Repaired)
	            {
		             MessageBox.Show("Elements of your database have been repaired, please look through your decks to verify that it seems to be alright.");
	            } else
	            {
                    MessageBox.Show("Database integrity is compromised, please see About for support");
	            }
            }
        }

        private void bGoToNewDeck_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/NewDeck.xaml", UriKind.Relative));
        }

        private void bGoToDeckList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/DeckList.xaml", UriKind.Relative));
        }

        private void bGoToPlayerStatistics_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/PlayerPage.xaml", UriKind.Relative));
        }

        private void bGoToOpponents_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/OpponentList.xaml", UriKind.Relative));
        }

        private void bAbout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }

        private void bGoToExport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/ExportPage.xaml", UriKind.Relative));
        } 
    }
}