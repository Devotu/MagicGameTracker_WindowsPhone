using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

using MagicGameTracker.Model;

using System;
using MagicGameTracker.Logic.MagicEnums;

namespace MagicGameTracker.ViewModel
{
    public class MagicViewModel
    {
        // LINQ to SQL data context for the local database.
        private MagicDataContext _magicDb;

        // Class constructor, create the data context object.
        public MagicViewModel(string dbConnectionString)
        {
            _magicDb = new MagicDataContext(dbConnectionString);
        }


        //Head --------------------------------------------------------------------------------

        //Items -------------------------------------------------------------------------------
        #region Items
        
        // All Deck items.
        private ObservableCollection<DeckItem> _decks;
        public ObservableCollection<DeckItem> Decks
        {
            get { return _decks; }
            set
            {
                _decks = value;
                NotifyPropertyChanged("Decks");
            }
        }

        // One Deck items.
        private ObservableCollection<DeckItem> _focusDeck;
        public ObservableCollection<DeckItem> FocusDeck
        {
            get { return _focusDeck; }
            set
            {
                _focusDeck = value;
                NotifyPropertyChanged("FocusDeck");
            }
        }

        // All active Deck items.
        private ObservableCollection<DeckItem> _activeDecks;
        public ObservableCollection<DeckItem> ActiveDecks
        {
            get { return _activeDecks; }
            set
            {
                _activeDecks = value;
                NotifyPropertyChanged("ActiveDecks");
            }
        }

        // All Game items.
        private ObservableCollection<GameItem> _games;
        public ObservableCollection<GameItem> Games
        {
            get { return _games; }
            set
            {
                _games = value;
                NotifyPropertyChanged("Games");
            }
        }

        // All Opponent items.
        private ObservableCollection<OpponentItem> _opponents;
        public ObservableCollection<OpponentItem> Opponents
        {
            get { return _opponents; }
            set
            {
                _opponents = value;
                NotifyPropertyChanged("Opponents");
            }
        }

        // All Game items.
        private ObservableCollection<AlterationItem> _alterations;
        public ObservableCollection<AlterationItem> Alterations
        {
            get { return _alterations; }
            set
            {
                _alterations = value;
                NotifyPropertyChanged("Alterations");
            }
        }

        #endregion

        //Methods -----------------------------------------------------------------------------
        #region Methods

        #region Common Methods
                
        //Ladda samtliga collections
        public void LoadAllCollectionsFromDatabase()
        {
            LoadAllDecksFromDatabase();
            LoadAllGamesFromDatabase();
            LoadAllOpponentsFromDatabase();
            LoadAllAlterationsFromDatabase();
        }

        #endregion
        #region Deck Methods

        //Ladda lekar
        public void LoadAllDecksFromDatabase()
        {
            // Specify the query for all deck items in the database.
            var decksInDB = from DeckItem deck in _magicDb.Decks
                            select deck;

            // Query the database and load all deck items.
            Decks = new ObservableCollection<DeckItem>(decksInDB);
        }

        //Ladda bara aktiva lekar
        public void LoadActiveDecksFromDatabase()
        {
            var activeDecksInDB = from DeckItem deck in _magicDb.Decks where deck.Active select deck;

            Decks = new ObservableCollection<DeckItem>();

            foreach (var deck in activeDecksInDB)
            {
                Decks.Add(deck);
            }

            /*
            ActiveDecks = new ObservableCollection<DeckItem>();

            foreach (var deck in activeDecksInDB)
            {
                if (deck.Active)
                {
                    ActiveDecks.Add(deck);
                }
            }*/
        }

        //Hämta en specifik lek
        public void LoadFocusDeckById(int deckID)
        {
            // Specify the query for the deck of specified id.
            var selectedDeck = from DeckItem deck in _magicDb.Decks where deck.DeckId == deckID select deck;

            //Make into ObservableCollection
            FocusDeck = new ObservableCollection<DeckItem>(selectedDeck);
        }

        //Lägg till en lek
        public void AddDeck(DeckItem newDeckItem)
        {
            // Add a to-do item to the data context.
            _magicDb.Decks.InsertOnSubmit(newDeckItem);

            // Save changes to the database.
            _magicDb.SubmitChanges();

            // Add a to-do item to the "all" observable collection.
            Decks.Add(newDeckItem);
        }

        // Remove a deck item from the database and collections.
        public Boolean DeleteDeck(DeckItem deckForDelete)
        {
            if (deckForDelete.DeckId != 1)
            {
                //Se till att alla games först hamnar op Default Deck
                var orphanGames = from GameItem game in _magicDb.Games where game._gameDeckId == deckForDelete.DeckId select game;
                foreach (var game in orphanGames)
                {
                    game.GameDeck = _magicDb.Decks.First();
                }

                //Se till att alla tillhörande förändringar tas bort
                var orphanAlterations = from AlterationItem alteration in _magicDb.Alterations where alteration._alterationDeckId == deckForDelete.DeckId select alteration;
                foreach (var alteration in orphanAlterations)
                {
                    this.DeleteAlteration(alteration, true);
                };

                // Remove the to-do item from the "all" observable collection.
                Decks.Remove(deckForDelete);

                // Remove the to-do item from the data context.
                _magicDb.Decks.DeleteOnSubmit(deckForDelete);

                // Save changes to the database.
                _magicDb.SubmitChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        //Sortera lekar efter vinstprocent
        public void SortDecksByWinrate()
        {
            Decks = new ObservableCollection<DeckItem>(Decks.OrderByDescending(d => d.GetWinrate()));
        }

        //Sortera lekar efter vinstprocent
        public void SortActiveDecksByWinrate()
        {
            ActiveDecks = new ObservableCollection<DeckItem>(ActiveDecks.OrderByDescending(d => d.GetWinrate()));
        }

        //Slå på och av statusen aktiv
        public Boolean ToggleDeckActiveStatus()
        {
            if (this.FocusDeck != null & this.FocusDeck.First().DeckId != 1)//Default går inte att göra aktiv
            {
                Boolean status = this.FocusDeck.First().Active;

                this.FocusDeck.First().Active = status ? false : true;
                this.SaveChangesToDB();

                return true;
            }
            else
            {
                return false;
            }
        }

        ////Registrera en förändring
        //public Boolean RegisterDeckAlteration()
        //{
        //    if (this.FocusDeck != null)
        //    {
        //        this.FocusDeck.First().DateAltered = DateTime.Now;
        //        this.FocusDeck.First().Revision = this.FocusDeck.First().Revision + 1;
        //        this.SaveChangesToDB();

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        #endregion
        #region Game Methods

        //Ladda lekar
        public void LoadAllGamesFromDatabase()
        {
            // Specify the query for all game items in the database.
            var gamesInDB = from GameItem game in _magicDb.Games
                            select game;

            // Query the database and load all game items.
            Games = new ObservableCollection<GameItem>(gamesInDB);
        }

        //Ladda lekar mot en motståndare
        public void LoadAllGamesAgainstOpponent(OpponentItem opponent)
        {
            var gamesAgainstOpponent = from GameItem game in _magicDb.Games where game._gameOpponentId == opponent.OpponentId select game;

            Games = new ObservableCollection<GameItem>(gamesAgainstOpponent);
        }

        //Ladda lekar spelade under dagen
        public void LoadAllTodaysGames()
        {
            var gamesInDB = from GameItem game in _magicDb.Games select game;
            List<GameItem> todaysGames = new List<GameItem>();

            foreach (var game in gamesInDB)
            {
                if (game.Date.ToString("d") == DateTime.Today.ToString("d"))
                {
                    todaysGames.Add(game);
                }
            }

            Games = new ObservableCollection<GameItem>(todaysGames);
        }

        //Ladda lekar mot en motståndare
        public void LoadAllGamesPlayedWithActiveDecks()
        {
            var gamesWithActiveDecks = from GameItem game in _magicDb.Games where game.GameDeck.Active == true select game;

            Games = new ObservableCollection<GameItem>(gamesWithActiveDecks);
        }

        //Lägg till en lek
        public void AddGame(GameItem newGameItem)
        {
            // Add a to-do item to the data context.
            _magicDb.Games.InsertOnSubmit(newGameItem);

            // Save changes to the database.
            _magicDb.SubmitChanges();

            // Add a to-do item to the "all" observable collection.
            Games.Add(newGameItem);
        }

        //Ta bort en lek
        public void DeleteGame(GameItem gameForDelete)
        {
            // Remove the to-do item from the "all" observable collection.
            Games.Remove(gameForDelete);

            // Remove the to-do item from the data context.
            _magicDb.Games.DeleteOnSubmit(gameForDelete);

            // Save changes to the database.
            _magicDb.SubmitChanges();
        }

        //Hämta en specifik match
        public void LoadOneGameById(int gameID)
        {
            // Specify the query for the deck of specified id.
            var selectedGame = from GameItem game in _magicDb.Games where game.GameId == gameID select game;

            //Make into ObservableCollection
            Games = new ObservableCollection<GameItem>(selectedGame);
        }

        #endregion
        #region Opponent Methods

        //Ladda motståndare
        public void LoadAllOpponentsFromDatabase()
        {
            // Specify the query for all opponent items in the database.
            var opponentsInDB = from OpponentItem opponent in _magicDb.Opponents
                                select opponent;

            // Query the database and load all opponent items.
            Opponents = new ObservableCollection<OpponentItem>(opponentsInDB);
        }

        //Lägg till en motståndare
        public void AddOpponent(OpponentItem newOpponentItem)
        {
            // Add a to-do item to the data context.
            _magicDb.Opponents.InsertOnSubmit(newOpponentItem);

            // Save changes to the database.
            _magicDb.SubmitChanges();

            // Add a to-do item to the "all" observable collection.
            Opponents.Add(newOpponentItem);
        }

        //Hämta en specifik match
        public void LoadOneOpponentById(int opponentID)
        {
            // Specify the query for the deck of specified id.
            var selectedOpponent = from OpponentItem opponent in _magicDb.Opponents where opponent.OpponentId == opponentID select opponent;

            //Make into ObservableCollection
            Opponents = new ObservableCollection<OpponentItem>(selectedOpponent);
        }

        // Remove a deck item from the database and collections.
        public Boolean DeleteOpponent(OpponentItem opponentForDelete)
        {
            if (opponentForDelete.OpponentId != 1)
            {
                //Se till att alla games först hamnar op Default Deck
                var orphanGames = from GameItem game in _magicDb.Games where game._gameOpponentId == opponentForDelete.OpponentId select game;

                foreach (var game in orphanGames)
                {
                    game.Opponent = _magicDb.Opponents.First();
                }

                // Remove the to-do item from the "all" observable collection.
                Opponents.Remove(opponentForDelete);

                // Remove the to-do item from the data context.
                _magicDb.Opponents.DeleteOnSubmit(opponentForDelete);

                // Save changes to the database.
                _magicDb.SubmitChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion        
        #region Alteration Methods

        //Ladda förändringar
        public void LoadAllAlterationsFromDatabase()
        {
            // Specify the query for all game items in the database.
            var alterationsInDB = from AlterationItem alteration in _magicDb.Alterations
                                  select alteration;

            // Query the database and load all game items.
            Alterations = new ObservableCollection<AlterationItem>(alterationsInDB);//.OrderByDescending(d => d.Date)
        }

        //Lägg till en lek
        public void AddAlteration(AlterationItem newAlterationItem)
        {
            // Add a to-do item to the data context.
            _magicDb.Alterations.InsertOnSubmit(newAlterationItem);

            // Save changes to the database.
            _magicDb.SubmitChanges();

            // Add a to-do item to the "all" observable collection.
            Alterations.Add(newAlterationItem);
        }

        //Ta bort en förändring
        public Boolean DeleteAlteration(AlterationItem alterationForDelete, Boolean forcedRemoval)
        {
            //Lekens skapande är första ändringen, denna går inte att ta bort
            //Ändrat i version 3.5.7.1 -- DateTime.Compare(alterationForDelete.Date, alterationForDelete.AlterationDeck.DateCreated
            if (alterationForDelete.Revision != 0 | forcedRemoval)
            {
                // Remove the to-do item from the "all" observable collection.
                Alterations.Remove(alterationForDelete);

                // Remove the to-do item from the data context.
                _magicDb.Alterations.DeleteOnSubmit(alterationForDelete);

                // Save changes to the database.
                _magicDb.SubmitChanges();

                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Hämta en specifik förändring
        public void LoadOneAlterationById(int alterationID)
        {
            // Specify the query for the deck of specified id.
            var selectedAlteration = from AlterationItem alteration in _magicDb.Alterations where alteration.AlterationId == alterationID select alteration;

            //Make into ObservableCollection
            Alterations = new ObservableCollection<AlterationItem>(selectedAlteration);
        }

        //Hämta förändringar för en lek
        public void LoadOrderedAlterationsForDeck(int deckID)
        {
            // Specify the query for the deck of specified id.
            var selectedAlteration = from AlterationItem alteration in _magicDb.Alterations where alteration.AlterationDeck.DeckId == deckID select alteration;

            //Make into ObservableCollection
            Alterations = new ObservableCollection<AlterationItem>(selectedAlteration.OrderByDescending(d => d.Date));
        }

        #endregion

        #endregion

        //Utilities ---------------------------------------------------------------------------
        #region Utilities
        
        
        // Write changes in the data context to the database.
        public void SaveChangesToDB()
        {
            _magicDb.SubmitChanges();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the app that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public DatabaseCondition CheckAndMaintainDatabase()
        {
            try
            {
                DatabaseCondition status = DatabaseCondition.Intact;
                this.LoadAllCollectionsFromDatabase();

                foreach (DeckItem deck in Decks)
                {
                    if (deck.DeckAlterations.Count == 0)
                    {
                        AddAlteration(new AlterationItem
                        {
                            Revision = 0,
                            Date = DateTime.Now,
                            Comment = "Deck repaired",
                            AlterationDeck = deck
                        });

                        status = DatabaseCondition.Repaired;
                    }
                }

                return status;
            }
            catch (Exception)
            {
                return DatabaseCondition.Failed;
                throw;
            }            
        }
        
        #endregion
    }

    #region Private utility classes

    public static class SortableDeck
    {
        public static decimal GetWinrate(this DeckItem d)
        {
            decimal winrate = 0;
            int wins = 0;
            int losses = 0;

            foreach (var game in d.DeckGames)
            {
                if (game.Win)
                {
                    wins++;
                }
                else
                {
                    losses++;
                }
            }
            if (wins + losses != 0)
            {
                winrate = Decimal.Divide((decimal)wins, ((decimal)(wins + losses))) * 100;
            }

            return winrate;
        }
    }

    #endregion

}