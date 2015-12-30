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
using MagicGameTracker.Model;
using MagicGameTracker.ViewModel;

namespace MagicGameTracker.View
{
    public partial class AlterationList : UserControl
    {
        private MagicViewModel _mvm;

        public AlterationList()
        {
            InitializeComponent();
        }

        // Version 3.4.2.0 Borttagen för att vara konsekvent med Games
        //private void ListBox_Hold(object sender, GestureEventArgs e)
        //{
        //    MessageBoxResult result = MessageBox.Show("Delete Alteration?", "Delete alteration", MessageBoxButton.OKCancel);
            
        //    if (result == MessageBoxResult.OK)
        //    {
        //        var frame = App.Current.RootVisual as PhoneApplicationFrame;
        //        ListBox alterationListBox = (ListBox)sender;
        //        AlterationItem alteration = (AlterationItem)alterationListBox.SelectedItem;

        //        if (alteration != null)
        //        {
        //            if (_mvm.DeleteAlteration(alteration, false))
        //            {
        //                MessageBox.Show("Alteration deleted");
        //            }
        //            else
        //            {
        //                MessageBox.Show("This alteration cannot be deleted");
        //            }
        //        }
        //    }
        //}

        //Fulhack?
        public void setDataContext(MagicViewModel sharedMVM)
        {
            this._mvm = sharedMVM;
            _mvm.LoadOrderedAlterationsForDeck(_mvm.FocusDeck.First().DeckId);
            this.DataContext = _mvm.Alterations;
        }
        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var frame = App.Current.RootVisual as PhoneApplicationFrame;
            ListBox alterationListBox = (ListBox)sender;
            AlterationItem alteration = (AlterationItem)alterationListBox.SelectedItem;

            if (alteration != null)
            {
                frame.Navigate(new Uri("/Sections/AlterationPage.xaml?alteration_Id=" + alteration.AlterationId, UriKind.Relative));
            } 
        }
    }
}
