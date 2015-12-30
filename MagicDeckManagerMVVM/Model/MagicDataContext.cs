
using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace MagicGameTracker.Model
{
    public class MagicDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public MagicDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table for the deck items.
        public Table<DeckItem> Decks;

        // Specify a table for the game items.
        public Table<GameItem> Games;

        // Specify a table for the game items.
        public Table<OpponentItem> Opponents;

        public Table<AlterationItem> Alterations;
    }

    [Table]
    public class DeckItem : INotifyPropertyChanged, INotifyPropertyChanging
    {
        // Define ID: private field, public property, and database column.
        private int _deckId;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int DeckId
        {
            get { return _deckId; }
            set
            {
                if (_deckId != value)
                {
                    NotifyPropertyChanging("DeckId");
                    _deckId = value;
                    NotifyPropertyChanged("DeckId");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _name;
        [Column]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    NotifyPropertyChanging("Name");
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private string _colors;
        [Column]
        public string Colors
        {
            get { return _colors; }
            set
            {
                if (_colors != value)
                {
                    NotifyPropertyChanging("Colors");
                    _colors = value;
                    NotifyPropertyChanged("Colors");
                }
            }
        }

        private string _format;
        [Column]
        public string Format
        {
            get { return _format; }
            set
            {
                if (_format != value)
                {
                    NotifyPropertyChanging("Format");
                    _format = value;
                    NotifyPropertyChanged("Format");
                }
            }
        }

        private string _theme;
        [Column]
        public string Theme
        {
            get { return _theme; }
            set
            {
                if (_theme != value)
                {
                    NotifyPropertyChanging("Theme");
                    _theme = value;
                    NotifyPropertyChanged("Theme");
                }
            }
        }

        private bool _active;
        [Column]
        public bool Active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    NotifyPropertyChanging("Active");
                    _active = value;
                    NotifyPropertyChanged("Active");
                }
            }
        }

        private DateTime _dateCreated;
        [Column]
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                {
                    NotifyPropertyChanging("DateCreated");
                    _dateCreated = value;
                    NotifyPropertyChanged("DateCreated");
                }
            }
        }

        #region DeckHandlers
        // Assign handlers for the add and remove operations, respectively.
        public DeckItem()
        {
            _deckGames = new EntitySet<GameItem>(
                new Action<GameItem>(this.attach_Game),
                new Action<GameItem>(this.detach_Game)
                );

            _deckAlterations = new EntitySet<AlterationItem>(
                new Action<AlterationItem>(this.attach_Alteration),
                new Action<AlterationItem>(this.detach_Alteration)
            );

        }
        #endregion

        #region DeckGames
        // Define the entity set for the collection side of the relationship.
        private EntitySet<GameItem> _deckGames;

        [Association(Storage = "_deckGames", OtherKey = "_gameDeckId", ThisKey = "DeckId")]
        public EntitySet<GameItem> DeckGames
        {
            get { return this._deckGames; }
            set { this._deckGames.Assign(value); }
        }

        // Called during an add operation
        private void attach_Game(GameItem game)
        {
            NotifyPropertyChanging("DeckGames");
            game.GameDeck = this;
        }

        // Called during a remove operation
        private void detach_Game(GameItem game)
        {
            NotifyPropertyChanging("DeckGames");
            game.GameDeck = null;
        }
        #endregion

        #region DeckAlterations
        // Define the entity set for the collection side of the relationship.
        private EntitySet<AlterationItem> _deckAlterations;

        [Association(Storage = "_deckAlterations", OtherKey = "_alterationDeckId", ThisKey = "DeckId")]
        public EntitySet<AlterationItem> DeckAlterations
        {
            get { return this._deckAlterations; }
            set { this._deckAlterations.Assign(value); }
        }

        // Called during an add operation
        private void attach_Alteration(AlterationItem alteration)
        {
            NotifyPropertyChanging("DeckAlterations");
            alteration.AlterationDeck = this;
        }

        // Called during a remove operation
        private void detach_Alteration(AlterationItem alteration)
        {
            NotifyPropertyChanging("DeckAlterations");
            alteration.AlterationDeck = null;
        }
        #endregion

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }

    [Table]
    public class GameItem : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _gameId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int GameId
        {
            get { return _gameId; }
            set
            {
                if (_gameId != value)
                {
                    NotifyPropertyChanging("GameId");
                    _gameId = value;
                    NotifyPropertyChanged("GameId");
                }
            }
        }

        // Internal column for the associated Deck ID value
        [Column]
        internal int _gameDeckId;

        // Entity reference, to identify the Deck "storage" table
        private EntityRef<DeckItem> _gameDeck;

        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "_gameDeck", ThisKey = "_gameDeckId", OtherKey = "DeckId", IsForeignKey = true)]
        public DeckItem GameDeck
        {
            get { return _gameDeck.Entity; }
            set
            {
                NotifyPropertyChanging("GameDeck");
                _gameDeck.Entity = value;

                if (value != null)
                {
                    _gameDeckId = value.DeckId;
                }
                
                NotifyPropertyChanging("GameDeck");
            }
        }

        private bool _win;
        [Column]
        public bool Win
        {
            get { return _win; }
            set
            {
                if (_win != value)
                {
                    NotifyPropertyChanging("Win");
                    _win = value;
                    NotifyPropertyChanged("Win");
                }
            }
        }

        private string _colors;
        [Column]
        public string Colors
        {
            get { return _colors; }
            set
            {
                if (_colors != value)
                {
                    NotifyPropertyChanging("Colors");
                    _colors = value;
                    NotifyPropertyChanged("Colors");
                }
            }
        }

        private string _comment;
        [Column]
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    NotifyPropertyChanging("Comment");
                    _comment = value;
                    NotifyPropertyChanged("Comment");
                }
            }
        }

        private DateTime _date;
        [Column]
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    NotifyPropertyChanging("Date");
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        private double _performanceRating;
        [Column]
        public double PerformanceRating
        {
            get { return _performanceRating; }
            set
            {
                if (_performanceRating != value)
                {
                    NotifyPropertyChanging("Rating");
                    _performanceRating = value;
                    NotifyPropertyChanged("Rating");
                }
            }
        }

        // Internal column for the associated Deck ID value
        [Column]
        internal int _gameOpponentId;

        // Entity reference, to identify the Deck "storage" table
        private EntityRef<OpponentItem> _opponent;

        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "_opponent", ThisKey = "_gameOpponentId", OtherKey = "OpponentId", IsForeignKey = true)]
        public OpponentItem Opponent
        {
            get { return _opponent.Entity; }
            set
            {
                NotifyPropertyChanging("Opponent");
                _opponent.Entity = value;

                if (value != null)
                {
                    _gameOpponentId = value.OpponentId;
                }

                NotifyPropertyChanging("Opponent");
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }

    [Table]
    public class OpponentItem : INotifyPropertyChanged, INotifyPropertyChanging
    {
        // Define ID: private field, public property, and database column.
        private int _opponentId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int OpponentId
        {
            get { return _opponentId; }
            set
            {
                if (_opponentId != value)
                {
                    NotifyPropertyChanging("OpponentId");
                    _opponentId = value;
                    NotifyPropertyChanged("OpponentId");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _name;
        [Column]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    NotifyPropertyChanging("Name");
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        #region OpponentGame
        // Define the entity set for the collection side of the relationship.
        private EntitySet<GameItem> _games;

        [Association(Storage = "_games", OtherKey = "_gameOpponentId", ThisKey = "OpponentId")]
        public EntitySet<GameItem> Games
        {
            get { return this._games; }
            set { this._games.Assign(value); }
        }


        // Assign handlers for the add and remove operations, respectively.
        public OpponentItem()
        {
            _games = new EntitySet<GameItem>(
                new Action<GameItem>(this.attach_Game), 
                new Action<GameItem>(this.detach_Game)
                );
        }

        // Called during an add operation
        private void attach_Game(GameItem game)
        {
            NotifyPropertyChanging("Games");
            game.Opponent = this;
        }

        // Called during a remove operation
        private void detach_Game(GameItem game)
        {
            NotifyPropertyChanging("Games");
            game.Opponent = null;
        }
        #endregion

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }

    [Table]
    public class AlterationItem : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _alterationId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int AlterationId
        {
            get { return _alterationId; }
            set
            {
                if (_alterationId != value)
                {
                    NotifyPropertyChanging("AlterationId");
                    _alterationId = value;
                    NotifyPropertyChanged("AlterationId");
                }
            }
        }

        // Internal column for the associated Deck ID value
        [Column]
        internal int _alterationDeckId;

        // Entity reference, to identify the Deck "storage" table
        private EntityRef<DeckItem> _alterationDeck;

        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "_alterationDeck", ThisKey = "_alterationDeckId", OtherKey = "DeckId", IsForeignKey = true)]
        public DeckItem AlterationDeck
        {
            get { return _alterationDeck.Entity; }
            set
            {
                NotifyPropertyChanging("AlterationDeck");
                _alterationDeck.Entity = value;

                if (value != null)
                {
                    _alterationDeckId = value.DeckId;
                }

                NotifyPropertyChanging("AlterationDeck");
            }
        }

        private int _revision;
        [Column]
        public int Revision
        {
            get { return _revision; }
            set
            {
                if (_revision != value)
                {
                    NotifyPropertyChanging("Revision");
                    _revision = value;
                    NotifyPropertyChanged("Revision");
                }
            }
        }

        private DateTime _date;
        [Column]
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    NotifyPropertyChanging("Date");
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        private string _comment;
        [Column]
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    NotifyPropertyChanging("Comment");
                    _comment = value;
                    NotifyPropertyChanged("Comment");
                }
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}
