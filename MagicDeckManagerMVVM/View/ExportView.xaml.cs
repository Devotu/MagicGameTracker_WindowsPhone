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
using System.Windows.Media;

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

        private void tbEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbEmail.Text == "Email")
            {
                tbEmail.Text = "";
                SolidColorBrush BrushActive = new SolidColorBrush();
                BrushActive.Color = Colors.Black;
                tbEmail.Foreground = BrushActive;
            }
        }

        private void tbEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbEmail.Text == String.Empty)
            {
                tbEmail.Text = "Email";
                SolidColorBrush BrushHint = new SolidColorBrush();
                BrushHint.Color = Colors.Gray;
                tbEmail.Foreground = BrushHint;
            }
        }


        private void bExportData_Click(object sender, RoutedEventArgs e)
        {
            var csvOrSql = "SQL";

            //Prepare collections
            try
            {
                _mvm = new MagicViewModel(App.DBCONNECTION);
                _mvm.LoadAllCollectionsFromDatabase();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured trying to load collections from the database.");
            }

            var mailString = "No data gathered.";

            if (rbCSV.IsChecked == true)
            {
                #region CSV
                //Prepare email
                try
                {
                    mailString = "The database consists of four tables noted as csv. Convert into sqlite and rename as .mgt and transfer to phone\n";

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
                            + adjustAutoIndex(alteration._alterationDeckId) + ";"
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
                            + adjustAutoIndex(deck.DeckId) + ";"
                            + deck.Name + ";"
                            + assureValidFormat(deck.Format) + ";"
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
                            + adjustAutoIndex(game._gameDeckId) + ";"
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
                            + adjustAutoIndex(opponent.OpponentId) + ";"
                            + opponent.Name
                            + "\n";
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured trying to convert data into a valid format. Error msg: " + ex.Message);
                }

                #endregion
            }
            else
            {
                #region SQL script
                try
                {
                    //Initiate script
                    mailString = "Run the following sql script in sqlite and save the resulting database as exportedDB.mgt and transfer to phone\n\n";
                    mailString = mailString + "BEGIN TRANSACTION;" + "\n";
                    mailString = mailString + "CREATE TABLE android_metadata (locale TEXT);" + "\n";
                    mailString = mailString + "INSERT INTO `android_metadata` VALUES ('en_CA');" + "\n";

                    # region Email Alterations
                    mailString = mailString + "CREATE TABLE Alterations(Alteration_ID int PRIMARY KEY, Deck_Id int, Date String, Revision int, Comment String);" + "\n";

                    foreach (var alteration in _mvm.Alterations)
                    {
                        mailString = mailString + "INSERT INTO `Alterations` VALUES (" +
                            +alteration.AlterationId + ","
                            + adjustAutoIndex(alteration._alterationDeckId) + ","
                            + convertDate(alteration.Date) + ","
                            + alteration.Revision + ","
                            + "'" + alteration.Comment + "'"
                            + ");\n";
                    }
                    #endregion

                    # region Email Decks
                    mailString = mailString + "CREATE TABLE Decks(Deck_ID int PRIMARY KEY, Name String, Format Format, Colorset int, Theme String, Active int, DateCreated String);" + "\n";

                    foreach (var deck in _mvm.Decks)
                    {
                        mailString = mailString + "INSERT INTO `Decks` VALUES ("
                            + adjustAutoIndex(deck.DeckId) + ","
                            + "'" + deck.Name + "',"
                            + "'" + assureValidFormat(deck.Format) + "',"
                            + "'" + convertColorToColorset(deck.Colors) + "',"
                            + "'" + deck.Theme + "',"
                            + convertBoolToInt(deck.Active) + ","
                            + convertDate(deck.DateCreated)
                            + ");\n";
                    }
                    #endregion

                    # region Email Games
                    mailString = mailString + "CREATE TABLE Games(Game_ID int PRIMARY KEY, Deck_Id int, Win int, Colorset String, Comment String,Date String, Opponent_Id int, PerformanceRating int);" + "\n";

                    foreach (var game in _mvm.Games)
                    {
                        mailString = mailString + "INSERT INTO `Games` VALUES ("
                            + game.GameId + ","
                            + adjustAutoIndex(game._gameDeckId) + ","
                            + convertBoolToInt(game.Win) + ","
                            + "'" + convertColorToColorset(game.Colors) + "',"
                            + "'" + game.Comment + "',"
                            + convertDate(game.Date) + ","
                            + adjustAutoIndex(game._gameOpponentId) + ","
                            + "round(" + game.PerformanceRating + ")"
                            + ");\n";
                    }
                    #endregion

                    # region Email Opponents
                    mailString = mailString + "CREATE TABLE Opponents(Opponent_ID int PRIMARY KEY, Name String);" + "\n";

                    foreach (var opponent in _mvm.Opponents)
                    {
                        mailString = mailString + "INSERT INTO `Opponents` VALUES ("
                            + adjustAutoIndex(opponent.OpponentId) + ","
                            + "'" + opponent.Name + "'"
                            + ");\n";
                    }
                    #endregion

                    //End Script
                    mailString = mailString + "COMMIT;";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured trying to convert data into a valid format. Error msg: " + ex.Message);
                }                
                #endregion
            }

            //Send email
            try
            {
                EmailComposeTask emailComposeTask = new EmailComposeTask();

                emailComposeTask.Subject = "Magic game tracker " + csvOrSql + " data";
                emailComposeTask.Body = mailString;
                emailComposeTask.To = this.tbEmail.Text;

                emailComposeTask.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured trying to send the email.");
            }
        }

        private String convertDate(DateTime dateIn)
        {

            try
            {
                var convertedDate =
                        dateIn.Year.ToString().Substring(2)
                        + (dateIn.Month.ToString().Length == 1 ? ("0" + dateIn.Month.ToString()) : dateIn.Month.ToString())
                        + (dateIn.Day.ToString().Length == 1 ? ("0" + dateIn.Day.ToString()) : dateIn.Day.ToString())
                        + (dateIn.Hour.ToString().Length == 1 ? ("0" + dateIn.Hour.ToString()) : dateIn.Hour.ToString())
                        + (dateIn.Minute.ToString().Length == 1 ? ("0" + dateIn.Minute.ToString()) : dateIn.Minute.ToString());
                return convertedDate;
            }
            catch (Exception)
            {
                
                throw new System.Exception("An error occured trying to convert date information");
            }
        }

        private String convertColorToColorset(String colorsIn)
        {
            try
            {
                var convertedColorset = "";
                for (int i = 0; i < colorsIn.Length; i++)
                {
                    if (colorsIn[i].ToString() == "1")
                    {
                        string color = ((MagicGameTracker.Logic.MagicEnums.ManaColor)i).ToString();
                        color = color.ToUpper();
                        convertedColorset = convertedColorset + "," + color;
                    }
                }
                return convertedColorset;
            }
            catch (Exception)
            {
                
                throw new System.Exception("An error occured trying to convert color information");
            }
            
        }

        private int convertBoolToInt(Boolean boolIn)
        {
            try
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
            catch (Exception)
            {

                throw new System.Exception("An error occured trying to convert Boolean information");
            }
        }

        private String assureValidFormat(String formatIn)
        {
            try
            {
                if (formatIn == "Statistical collection")
                {
                    return "Collection";
                }
                else
                {
                    return formatIn;
                }
            }
            catch (Exception)
            {

                throw new System.Exception("An error occured trying to assure the Format");
            }
        }

        private int adjustAutoIndex(int deckIdIn)
        {
            try
            {
                return deckIdIn - 1;
            }
            catch (Exception)
            {

                throw new System.Exception("An error occured trying to adjust the AutoIndex");
            }
        }
    }
}
