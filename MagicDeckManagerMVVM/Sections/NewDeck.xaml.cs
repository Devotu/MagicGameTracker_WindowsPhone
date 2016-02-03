using System;
using System.Windows;
using Microsoft.Phone.Controls;

using MagicGameTracker.Model;
using System.Windows.Media;
using System.Windows.Controls;

namespace MagicGameTracker
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void bAddDeck_Click(object sender, EventArgs e)
        {
            string _colors = "";

            //Kontrollera att ett namn finns
            if (NewDeck.tbName.Text.Length > 0)
            {
                DateTime dateCreated = DateTime.Now;
                var colorPicker = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(NewDeck.ColorPanel, 0), 0);
                int count = VisualTreeHelper.GetChildrenCount(colorPicker);
                bool colored = false;
                //För varje Color Checkbox
                for (int i = 0; i < count; i++)
                {
                    //Om checked så registrera som etta, annars noll
                    CheckBox colorCheckbox = VisualTreeHelper.GetChild(colorPicker, i) as CheckBox;
                    if (Convert.ToBoolean(colorCheckbox.IsChecked))
                    {
                        _colors = _colors + "1";
                        colored = true;
                    }
                    else
                    {
                        _colors = _colors + "0";
                    }
                }
                _colors = !colored ? _colors = _colors + "1" : _colors = _colors + "0";

                string format = "Standard";
                if (this.NewDeck.FormatPicker.lbFormatsToPick.SelectedItem != null)
                {
                    format = this.NewDeck.FormatPicker.lbFormatsToPick.SelectedItem.ToString();
                }

                DeckItem newDeckItem = new DeckItem
                {
                    Name = NewDeck.tbName.Text,
                    Colors = _colors,
                    Theme = NewDeck.tbTheme.Text,
                    DateCreated = dateCreated,
                    Format = format,
                    Active = true
                };

                App.MagicViewModel.AddDeck(newDeckItem);

                AlterationItem newAlterationItem = new AlterationItem
                {
                    Revision = 0,
                    Date = dateCreated,
                    Comment = "Deck created",
                    AlterationDeck = newDeckItem
                };

                App.MagicViewModel.AddAlteration(newAlterationItem);

                MessageBox.Show("New deck " + NewDeck.tbName.Text + " was added");

                (Application.Current.RootVisual as PhoneApplicationFrame).GoBack();

            };
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No deck was created");

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}