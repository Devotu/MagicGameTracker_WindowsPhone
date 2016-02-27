using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using MagicGameTracker.ViewModel;
using MagicGameTracker.Model;
using System.Windows.Controls;
using System.Windows.Media;

namespace MagicGameTracker.Sections
{
    public partial class AddAlterationPage : PhoneApplicationPage
    {
        int _activeDeckId;
        private MagicViewModel _mvm;
        private DeckItem _originalDeckItem;
        private bool _deckInfoEdited;

        public AddAlterationPage()
        {
            InitializeComponent();

            _deckInfoEdited = false; //Bör nog inte vara i onNavigatedTo ifall användaren går fram och tillbaka

            this.NewDeck.tbName.TextChanged += OnTextEdit;
            this.NewDeck.tbTheme.TextChanged += OnTextEdit;
            this.NewDeck.FormatPicker.lbFormatsToPick.SelectionChanged +=lbFormatsToPick_SelectionChanged;
            this.NewDeck.ColorPicker.Tap += ColorPicker_Tap;
        }

        void ColorPicker_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.NewDeck.ColorPicker.HasChanged())
            {
                _deckInfoEdited = true;
            }
        }

        void OnTextEdit(object sender, TextChangedEventArgs e)
        {
            this.OnEdit();
        }

        private void lbFormatsToPick_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.OnEdit();
        }

        private void OnEdit()
        {
            _deckInfoEdited = true;
            //Redan flaggat för att något har ändrats, ta bort överflödiga events
            this.NewDeck.tbName.TextChanged -= OnTextEdit;
            this.NewDeck.tbTheme.TextChanged -= OnTextEdit;
            this.NewDeck.FormatPicker.lbFormatsToPick.SelectionChanged -= lbFormatsToPick_SelectionChanged;
            this.NewDeck.ColorPicker.Tap -= ColorPicker_Tap;
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

            //Nytt 4.3
            //Minska ner NewDeck för att få plats med comment
            this.NewDeck.Collapse(90);
            this.NewDeck.Height = this.NewDeck.Height + 10; //HACK Padding verkar inte gå att sätta med kod

            this.AddDeckAlterationViewFull.Collapse(50);

            //Ladda Deck info
            _mvm.LoadFocusDeckById(_activeDeckId);
            _originalDeckItem = new DeckItem
            {
                DeckId = _mvm.FocusDeck.FirstOrDefault().DeckId,
                Name = _mvm.FocusDeck.FirstOrDefault().Name,
                Colors = _mvm.FocusDeck.FirstOrDefault().Colors,
                Format = _mvm.FocusDeck.FirstOrDefault().Format,
                Theme = _mvm.FocusDeck.FirstOrDefault().Theme,
                Active = _mvm.FocusDeck.FirstOrDefault().Active,
                DateCreated = _mvm.FocusDeck.FirstOrDefault().DateCreated
            };                

            this.NewDeck.tbName.Text = _originalDeckItem.Name;
            this.NewDeck.FormatPicker.PresetFormat(_originalDeckItem.Format);
            this.NewDeck.ColorPicker.PresetColors(_originalDeckItem.Colors);
            this.NewDeck.ColorPicker.SetChangedetectors();
            this.NewDeck.tbTheme.Text = _originalDeckItem.Theme;

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            AlterationItem newAlterationItem = new AlterationItem
            {
                Revision = (from DeckItem deck in _mvm.Decks where deck.DeckId == _activeDeckId select deck).Single().DeckAlterations.Last().Revision + 1,
                Date = DateTime.Now,
                Comment = "",
                AlterationDeck = _mvm.FocusDeck.First()
            };

            if (_deckInfoEdited)
            {
                //Name
                if (this.NewDeck.tbName.Text != _originalDeckItem.Name)
                {
                    _mvm.FocusDeck.First().Name = this.NewDeck.tbName.Text;
                    newAlterationItem.Comment = newAlterationItem.Comment + "Name changed from " + _originalDeckItem.Name + " to " + _mvm.FocusDeck.First().Name + ".";
                }

                //Format
                if (this.NewDeck.FormatPicker.lbFormatsToPick.SelectedItem != null &&
                    this.NewDeck.FormatPicker.lbFormatsToPick.SelectedItem.ToString() != _originalDeckItem.Format)
                {
                    _mvm.FocusDeck.First().Format = this.NewDeck.FormatPicker.lbFormatsToPick.SelectedItem.ToString();
                    if (newAlterationItem.Comment != "")
                    {
                        newAlterationItem.Comment = newAlterationItem.Comment + " ";
                    }
                    newAlterationItem.Comment = newAlterationItem.Comment + "Format changed from " + _originalDeckItem.Format + " to " + _mvm.FocusDeck.First().Format + ".";
                }

                //Color
                if (this.NewDeck.ColorPicker.HasChanged())
                {
                    string colors = "";
                    colors = this.NewDeck.ColorPicker.cbBlack.IsChecked == true ? colors + "1" : colors + "0";
                    colors = this.NewDeck.ColorPicker.cbWhite.IsChecked == true ? colors + "1" : colors + "0";
                    colors = this.NewDeck.ColorPicker.cbRed.IsChecked == true ? colors + "1" : colors + "0";
                    colors = this.NewDeck.ColorPicker.cbBlue.IsChecked == true ? colors + "1" : colors + "0";
                    colors = this.NewDeck.ColorPicker.cbGreen.IsChecked == true ? colors + "1" : colors + "0";
                    colors = this.NewDeck.ColorPicker.cbDevoid.IsChecked == true ? colors + "1" : colors + "0";
                    colors = colors == "000000" ? colors + "1" : colors + "0";

                    _mvm.FocusDeck.First().Colors = colors;
                    if (newAlterationItem.Comment != "")
                    {
                        newAlterationItem.Comment = newAlterationItem.Comment + " ";
                    }
                    newAlterationItem.Comment = newAlterationItem.Comment + "Colors changed from " + _originalDeckItem.Colors + " to " + _mvm.FocusDeck.First().Colors + ".";
                }

                //Theme
                if (this.NewDeck.tbTheme.Text != _originalDeckItem.Theme)
                {
                    _mvm.FocusDeck.First().Theme = this.NewDeck.tbTheme.Text;
                    if (newAlterationItem.Comment != "")
                    {
                        newAlterationItem.Comment = newAlterationItem.Comment + " ";
                    }
                    newAlterationItem.Comment = newAlterationItem.Comment + "Theme changed from " + _originalDeckItem.Theme + " to " + _mvm.FocusDeck.First().Theme + ".";
                }

                _mvm.SaveChangesToDB();

                if (this.AddDeckAlterationViewFull.tbComment.Text != "" && this.AddDeckAlterationViewFull.tbComment.Text != "Comment")
                {
                    if (newAlterationItem.Comment != "")
                    {
                        newAlterationItem.Comment = newAlterationItem.Comment + " ";
                    }
                    newAlterationItem.Comment = newAlterationItem.Comment + this.AddDeckAlterationViewFull.tbComment.Text;
                }

            }
            else
            {
                newAlterationItem.Comment = this.AddDeckAlterationViewQuick.tbComment.Text;
            }


            if (newAlterationItem != null)
            {
                _mvm.AddAlteration(newAlterationItem);

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