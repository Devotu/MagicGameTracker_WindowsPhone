using System;
using Microsoft.Phone.Controls;
using MagicGameTracker.ViewModel;

namespace MagicGameTracker.Sections
{
    public partial class DeckList : PhoneApplicationPage
    {
        private MagicViewModel _mvm;

        public DeckList()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            this._mvm = new MagicViewModel(App.DBCONNECTION);
            _mvm.LoadAllDecksFromDatabase();
            _mvm.SortDecksByWinrate();
            this.AllDecks.DataContext = _mvm.Decks;

            _mvm.LoadActiveDecksFromDatabase();
            _mvm.SortDecksByWinrate();
            this.ActiveDecks.DataContext = _mvm.Decks;

            base.OnNavigatedTo(e);
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }
    }
}