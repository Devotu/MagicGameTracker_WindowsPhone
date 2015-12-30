using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;

namespace MagicGameTracker.View
{
    public partial class DeckDetails : UserControl
    {
        public DeckDetails()
        {
            InitializeComponent();
        }

        public void SetColors(string colorCode)
        {
            Image colorImage;

            for (int i = 0; i < 5; i++)
            {
                colorImage = VisualTreeHelper.GetChild(grColors, i) as Image;

                var colorIsActive = colorCode[i];

                if (colorIsActive == '1')
                {
                    switch (i)
                    {
                        case 0:
                            colorImage.Source = new BitmapImage(new Uri(@"\images\black_mana_big.png", UriKind.Relative));
                            break;
                        case 1:
                            colorImage.Source = new BitmapImage(new Uri(@"\images\white_mana_big.png", UriKind.Relative));
                            break;
                        case 2:
                            this.imRed.Source = new BitmapImage(new Uri(@"\images\red_mana_big.png", UriKind.Relative));
                            break;
                        case 3:
                            colorImage.Source = new BitmapImage(new Uri(@"\images\blue_mana_big.png", UriKind.Relative));
                            break;
                        case 4:
                            colorImage.Source = new BitmapImage(new Uri(@"\images\green_mana_big.png", UriKind.Relative));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
