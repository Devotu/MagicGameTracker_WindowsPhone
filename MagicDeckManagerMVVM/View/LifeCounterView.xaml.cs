using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MagicGameTracker.ViewModel;
using MagicGameTracker.Model;

namespace MagicGameTracker.View
{
    public partial class LifeCounterView : UserControl
    {
        private LifeCounterViewModel lcvm;

        public LifeCounterView()
        {
            InitializeComponent();
            this.lcvm = new LifeCounterViewModel();
            this.lcvm.InitializeCollection();
            this.lbLifeHistory.DataContext = lcvm.Life;

            lcvm.AddLifeChange(new LifeStatus(20,0));

            this.tbCurrentLifeDisplay.DataContext = lcvm.Life.First();

            lcvm.RemoveInitialLife();
        }

        private void ChangeLifeAmount(Boolean positive, int amount)
        {
            int sign = -1;
            if (positive)
            {
                sign = 1;
            }

            LifeStatus newLifeStatus;

            if (lcvm.Life.Count > 0)
            {
                newLifeStatus = new LifeStatus(sign * amount, lcvm.Life.First().currentLife);
            }
            else
            {
                newLifeStatus = new LifeStatus(sign * amount, 20);
            }
            
            lcvm.AddLifeChange(newLifeStatus);
            this.tbCurrentLifeDisplay.DataContext = lcvm.Life.First(); ;
        }

        private void bAddOne_Click(object sender, RoutedEventArgs e)
        {
            ChangeLifeAmount(true, 1);
        }

        private void bAddFive_Click(object sender, RoutedEventArgs e)
        {
            ChangeLifeAmount(true, 5);
        }

        private void bRemoveOne_Click(object sender, RoutedEventArgs e)
        {
            ChangeLifeAmount(false, 1);
        }

        private void bRemoveFive_Click(object sender, RoutedEventArgs e)
        {
            ChangeLifeAmount(false, 5);
        }
    }
}
