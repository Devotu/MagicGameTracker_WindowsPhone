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

namespace MagicGameTracker.View
{
    public partial class AddDeckAlterationView : UserControl
    {
        public AddDeckAlterationView()
        {
            InitializeComponent();
        }

        private void tbComment_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbComment.Text == "Comment")
            {
                tbComment.Text = "";
                SolidColorBrush BrushActive = new SolidColorBrush();
                BrushActive.Color = Colors.Black;
                tbComment.Foreground = BrushActive;
            }
        }

        private void tbComment_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbComment.Text == String.Empty)
            {
                tbComment.Text = "Comment";
                SolidColorBrush BrushHint = new SolidColorBrush();
                BrushHint.Color = Colors.Gray;
                tbComment.Foreground = BrushHint;
            }
        }
    }
}
