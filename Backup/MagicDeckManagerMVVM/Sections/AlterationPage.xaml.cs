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

namespace MagicGameTracker.Sections
{
    public partial class AlterationPage : PhoneApplicationPage
    {
        private MagicViewModel _mvm;

        public AlterationPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _mvm = new MagicViewModel(App.DBCONNECTION);

            //Defaultvärden
            string alteration_Id_string = "0";
            int alteration_Id = 0;

            //Hämta rätt lek
            NavigationContext.QueryString.TryGetValue("alteration_Id", out alteration_Id_string);
            alteration_Id = Convert.ToInt32(alteration_Id_string);

            _mvm.LoadOneAlterationById(alteration_Id);
            this.DataContext = _mvm.Alterations.First();
        }

        private void bDeleteAlteration_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Delete Alteration?", "Delete this alteration", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                if (_mvm.DeleteAlteration(_mvm.Alterations.First(), false))
                {
                    MessageBox.Show("Alteration deleted");
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("This alteration cannot be deleted");
                }
            }
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sections/AboutPage.xaml", UriKind.Relative));
        }
    }
}