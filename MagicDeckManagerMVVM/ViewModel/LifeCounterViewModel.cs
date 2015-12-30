using System.Collections.ObjectModel;
using System.ComponentModel;
using MagicGameTracker.Model;

namespace MagicGameTracker.ViewModel
{
    public class LifeCounterViewModel
    {
        // All Deck items.
        private ObservableCollection<LifeStatus> _life;
        public ObservableCollection<LifeStatus> Life
        {
            get { return _life; }
            set
            {
                _life = value;
                NotifyPropertyChanged("Life");
            }
        }

        public void InitializeCollection()
        {
            this.Life = new ObservableCollection<LifeStatus>();
        }

        public void AddLifeChange(LifeStatus newLifeStatus)
        {
            this.Life.Insert(0, newLifeStatus);
        }

        public void RemoveInitialLife()
        {
            this.Life.Clear();
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
    }
}
