using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using MagicGameTracker.ViewModel;
using Microsoft.Phone.Tasks;

namespace MagicGameTracker.View
{
    public partial class ExportView : UserControl
    //HACK This is a temporary solution to get around Windows phone limitations
    {
        private MagicViewModel _mvm;

        public ExportView()
        {
            InitializeComponent();
        }

        private void bExportData_Click(object sender, RoutedEventArgs e)
        {
            //Prepare email
            var emailRecipient = this.tbEmail.Text;
            var mailString = "The database consists of four tables noted as csv. Convert into sqlite and rename as .mgt and transfer to phone\n";
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            //Prepare collections
            _mvm = new MagicViewModel(App.DBCONNECTION);
            _mvm.LoadAllCollectionsFromDatabase();

            # region Email Alterations
            mailString = mailString + "\nAlterations\n";
            mailString = mailString
                    + "Alteration_ID;"
                    + "Deck_Id;"
                    + "Date;"
                    + "Revision;"
                    + "Comment"
                    + "\n";

            foreach (var alteration in _mvm.Alterations)
            {
                mailString = mailString
                    + alteration.AlterationId + ";"
                    + alteration._alterationDeckId + ";"
                    + convertDate(alteration.Date) + ";"
                    + alteration.Revision + ";"
                    + alteration.Comment
                    + "\n";
            }
            #endregion

            # region Email Decks
            mailString = mailString + "\nDecks\n"
                    + "Deck_ID;"
                    + "Name;"
                    + "Format;"
                    + "Colorset;"
                    + "Theme;"
                    + "Active;"
                    + "DateCreated"
                    + "\n";

            foreach (var deck in _mvm.Decks)
            {
                mailString = mailString
                    + deck.DeckId + ";"
                    + deck.Name + ";"
                    + deck.Format + ";"
                    + convertColorToColorset(deck.Colors) + ";"
                    + deck.Theme + ";"
                    + convertBoolToInt(deck.Active) + ";"
                    + convertDate(deck.DateCreated)
                    + "\n";
            }
            #endregion

            # region Email Games
            mailString = mailString + "\nGames\n"
                    + "Game_ID;"
                    + "Deck_Id;"
                    + "Win;"
                    + "Colorset;"
                    + "Comment;"
                    + "Date;"
                    + "Opponent_Id;"
                    + "PerformanceRating"
                    + "\n";

            foreach (var game in _mvm.Games)
            {
                mailString = mailString
                    + game.GameId + ";"
                    + game._gameDeckId + ";"
                    + convertBoolToInt(game.Win) + ";"
                    + convertColorToColorset(game.Colors) + ";"
                    + game.Comment + ";"
                    + convertDate(game.Date) + ";"
                    + game._gameOpponentId + ";"
                    + game.PerformanceRating
                    + "\n";
            }
            #endregion

            # region Email Opponents
            mailString = mailString + "\nOpponents\n"
                    + "Opponent_ID;"
                    + "Name"
                    + "\n";

            foreach (var opponent in _mvm.Opponents)
            {
                mailString = mailString
                    + opponent.OpponentId + ";"
                    + opponent.Name
                    + "\n";
            }
            #endregion

            //Send email
            emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "Magic game tracker data";
            emailComposeTask.Body = mailString;
            emailComposeTask.To = emailRecipient;

            emailComposeTask.Show();
        }

        private String convertDate(DateTime dateIn)
        {
            var convertedDate =
                dateIn.Year.ToString().Substring(2)
                + (dateIn.Month.ToString().Length == 1 ? ("0" + dateIn.Month.ToString()) : dateIn.Month.ToString())
                + (dateIn.Day.ToString().Length == 1 ? ("0" + dateIn.Day.ToString()) : dateIn.Day.ToString())
                + dateIn.Hour
                + dateIn.Minute;
            return convertedDate;
        }

        private String convertColorToColorset(String colorsIn)
        {
            var convertedColorset = "";
            for (int i = 0; i < colorsIn.Length; i++)
            {
                if (colorsIn[i].ToString() == "1")
                {
                    convertedColorset = convertedColorset + "," + (MagicGameTracker.Logic.MagicEnums.ManaColor)i;
                }
            }
            return convertedColorset;
        }

        private int convertBoolToInt(Boolean boolIn)
        {
            if (boolIn)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
