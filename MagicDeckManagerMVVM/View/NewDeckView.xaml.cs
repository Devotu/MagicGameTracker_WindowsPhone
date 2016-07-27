using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using MagicGameTracker.Logic.MagicEnums;

namespace MagicGameTracker.View
{
    public partial class NewDeckView : UserControl
    {
        public NewDeckView()
        {
            InitializeComponent();
        }

        private void tbName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "Name")
            {
                tbName.Text = "";
                SolidColorBrush BrushActive = new SolidColorBrush();
                BrushActive.Color = Colors.Black;
                tbName.Foreground = BrushActive;
            }
        }

        private void tbName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == String.Empty)
            {
                tbName.Text = "Name";
                SolidColorBrush BrushHint = new SolidColorBrush();
                BrushHint.Color = Colors.Gray;
                tbName.Foreground = BrushHint;
            }
        }

        private void tbTheme_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbTheme.Text == "Theme")
            {
                tbTheme.Text = "";
                SolidColorBrush BrushActive = new SolidColorBrush();
                BrushActive.Color = Colors.Black;
                tbTheme.Foreground = BrushActive;
            }
        }

        private void tbTheme_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbTheme.Text == String.Empty)
            {
                tbTheme.Text = "Theme";
                SolidColorBrush BrushHint = new SolidColorBrush();
                BrushHint.Color = Colors.Gray;
                tbTheme.Foreground = BrushHint;
            }
        }

        public void Collapse(int reduction)
        {
            int left = reduction;
            int labelReduction = 10;
            this.lblName.Height = this.lblName.Height - labelReduction;
            left = left - labelReduction;
            this.lblTheme.Height = this.lblTheme.Height - labelReduction;
            left = left - labelReduction;
            this.ColorPicker.Collapse();
            left = left - 72;
            this.tbTheme.Height = this.tbTheme.Height -(left);
            this.LayoutRoot.Height = this.LayoutRoot.Height - reduction;
        }

        public void Expand(int expansion)
        {
            int left = expansion;
            this.LayoutRoot.Height = this.LayoutRoot.Height + expansion;
            int labelExpansion = 10;
            this.lblName.Height = this.lblName.Height + labelExpansion;
            left = left - labelExpansion;
            this.lblTheme.Height = this.lblTheme.Height + labelExpansion;
            left = left - labelExpansion;
            this.ColorPicker.Expand();
            left = left - 72;
            this.tbTheme.Height = this.tbTheme.Height + left;
        }
    }
}
