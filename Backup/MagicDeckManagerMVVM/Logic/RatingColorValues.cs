using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MagicGameTracker.Logic
{
    public class RatingColorValues
    {
        public Color GetRatingColorForValue(double value)
        {
            Color returnColor = Color.FromArgb(255, 255, 113, 82);
            if (value >= 20)
            {
                returnColor = Color.FromArgb(255, 255, 200, 82);
            }
            if (value >= 40)
            {
                returnColor = Color.FromArgb(255, 255, 255, 82);
            } 
            if (value >= 60)
            {
                returnColor = Color.FromArgb(255, 200, 255, 82);
            }
            if (value >= 80)
            {
                returnColor = Color.FromArgb(255, 113, 255, 82);
            }
            if (value == 999)
            {
                returnColor = Color.FromArgb(255, 127, 127, 127);
            }

            return returnColor;
        }
    }
}
