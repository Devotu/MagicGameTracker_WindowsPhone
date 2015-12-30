using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Phone.Controls;

using MagicGameTracker.ViewModel;
using MagicGameTracker.Model;
using System.Windows;

namespace MagicGameTracker.Sections
{
    public partial class DeckPage : PhoneApplicationPage
    {
        private MagicViewModel _mvm;

        public DeckPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _mvm = new MagicViewModel(App.DBCONNECTION);
            _mvm.LoadAllCollectionsFromDatabase();

            //Defaultvärden
            string deck_Id_string = "0";
            int deck_Id = 0;

            //Hämta rätt lek
            NavigationContext.QueryString.TryGetValue("deck_Id", out deck_Id_string);
            deck_Id = Convert.ToInt32(deck_Id_string);
            _mvm.LoadFocusDeckById(deck_Id);

            this.DataContext = _mvm.FocusDeck.First();

            //Fyll i Deck specifika detaljer med komponenternas funktioner
            //Details
            DeckDetails.SetColors(_mvm.FocusDeck.First().Colors);

            //Statistics
            var games = from GameItem game in _mvm.FocusDeck.First().DeckGames select game;
            List<GameItem> orderedGames = new List<GameItem>();
            foreach (var game in games)
            {
                orderedGames.Add(game);
            }
            DeckStatistics.PopulateStatistics(_mvm.FocusDeck.First(), orderedGames);

            //Played games
            orderedGames.Reverse();
            DeckGamesPanel.DataContext = orderedGames;

            //Fulhack?
            DeckAlterationList.setDataContext(_mvm);

            //Flyttat till Initate för att få det rätt med ViewModels
            //var alterations = from AlterationItem alteration in _mvm.FocusDeck.First().DeckAlterations select alteration;
            //List<AlterationItem> orderedAlterations = new List<AlterationItem>();
            //foreach (var alteration in alterations)
            //{
            //    orderedAlterations.Add(alteration);
            //}
            //orderedAlterations.Reverse();
            //DeckAlterationsPanel.DataContext = orderedAlterations;
        }

        private void bAddGame_Click(object sender, EventArgs e)
        {
            var frame = App.Current.RootVisual as PhoneApplicationFrame;
            frame.Navigate(new Uri("/Sections/AddGame.xaml?deck_Id=" + _mvm.FocusDeck.First().DeckId, UriKind.Relative));
        }

        private void bRegisterChange_Click(object sender, EventArgs e)
        {
            var frame = App.Current.RootVisual as PhoneApplicationFrame;
            frame.Navigate(new Uri("/Sections/AddAlterationPage.xaml?deck_Id=" + _mvm.FocusDeck.First().DeckId, UriKind.Relative));
        }

        private void bToggleActive_Click(object sender, EventArgs e)
        {
            if (_mvm.ToggleDeckActiveStatus())
            {
                string status = "";
                if (_mvm.FocusDeck.First().Active)
                {
                    status = "Active";
                }
                else
                {
                    status = "Inactive";
                }
                MessageBox.Show("Deck toggled " + status);
            }
            else
            {
                MessageBox.Show("You cannot toggle this deck active/inactive");
            }
            
        }

        private void bDeleteDeck_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Delete Deck?", "Delete deck", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {                
                if (_mvm.DeleteDeck(_mvm.FocusDeck.First()))
                {
                    MessageBox.Show("Deck deleted");
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("This deck cannot be deleted");
                }                
            }            
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }
    }
}