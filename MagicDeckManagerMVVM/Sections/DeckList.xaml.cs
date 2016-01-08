using System;
using Microsoft.Phone.Controls;
using MagicGameTracker.ViewModel;
using System.Windows;
using MagicGameTracker.Logic.MagicEventArgs;

namespace MagicGameTracker.Sections
{
    public partial class DeckList : PhoneApplicationPage
    {
        private MagicViewModel _mvm;

        public DeckList()
        {
            InitializeComponent();
            this.FormatPicker.SelectedFormatChange += new EventHandler<FormatEventArgs>(SelectedFormatChange_Handler); 
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

        private void bAddDeck_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/NewDeck.xaml", UriKind.Relative));
        }

        public void SelectedFormatChange_Handler(object sender, FormatEventArgs e)
        {
            _mvm.LoadDecksByFormatFromDatabase(e.format);
            _mvm.SortDecksByWinrate();
            this.FilterDecks.DataContext = _mvm.Decks;
        } 

    }
}