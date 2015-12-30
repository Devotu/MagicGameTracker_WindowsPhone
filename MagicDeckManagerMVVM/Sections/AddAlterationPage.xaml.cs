using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using MagicGameTracker.ViewModel;
using MagicGameTracker.Model;

namespace MagicGameTracker.Sections
{
    public partial class AddAlterationPage : PhoneApplicationPage
    {
        int _activeDeckId;
        private MagicViewModel _mvm;

        public AddAlterationPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Defaultvärden
            string deck_Id_string = "0";

            //Hämta tillhörande lek-id
            NavigationContext.QueryString.TryGetValue("deck_Id", out deck_Id_string);
            _activeDeckId = Convert.ToInt32(deck_Id_string);

            _mvm = new MagicViewModel(App.DBCONNECTION);
            _mvm.LoadAllCollectionsFromDatabase();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            AlterationItem newAlteration = GetAlterationItem();
            if (newAlteration != null)
            {
                _mvm.AddAlteration(newAlteration);

                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
            else
            {
                MessageBox.Show("Parameters missing, no game was added");
            }
        }

        private AlterationItem GetAlterationItem()
        {
            AlterationItem newAlterationItem = new AlterationItem
            {
                Revision = (from DeckItem deck in _mvm.Decks where deck.DeckId == _activeDeckId select deck).Single().DeckAlterations.Last().Revision +1,
                Date = DateTime.Now,
                Comment = this.AddDeckAlterationView.tbComment.Text,
                AlterationDeck = (from DeckItem deck in _mvm.Decks where deck.DeckId == _activeDeckId select deck).Single(),
            };

            return newAlterationItem;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No alteration was recorded");

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }
    }
}