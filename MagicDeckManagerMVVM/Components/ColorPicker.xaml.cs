using System.Windows.Controls;

namespace MagicGameTracker.Components
{
    public partial class ColorPicker : UserControl
    {
        private bool _hasCheckedChanged;

        public ColorPicker()
        {
            InitializeComponent();
        }

        void OnCheckedChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            _hasCheckedChanged = true;
        }

        public bool HasChanged() 
        {
            if (_hasCheckedChanged)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PresetColors(string colors)
        {
            cbBlack.IsChecked = System.Int32.Parse(colors.Substring(0, 1)) == 1 ? true : false;
            cbWhite.IsChecked = System.Int32.Parse(colors.Substring(1, 1)) == 1 ? true : false;
            cbRed.IsChecked = System.Int32.Parse(colors.Substring(2, 1)) == 1 ? true : false;
            cbBlue.IsChecked = System.Int32.Parse(colors.Substring(3, 1)) == 1 ? true : false;
            cbGreen.IsChecked = System.Int32.Parse(colors.Substring(4, 1)) == 1 ? true : false;
            cbDevoid.IsChecked = System.Int32.Parse(colors.Substring(5, 1)) == 1 ? true : false;
        }

        //HACK Inte så snyggt, men fugerar iaf
        public void SetChangedetectors()
        {

            this._hasCheckedChanged = false;

            if (this.cbBlack.IsChecked == true)
            {
                this.cbBlack.Unchecked += OnCheckedChanged;
            }
            else
            {
                this.cbBlack.Checked += OnCheckedChanged;
            }

            if (this.cbWhite.IsChecked == true)
            {
                this.cbWhite.Unchecked += OnCheckedChanged;
            }
            else
            {
                this.cbWhite.Checked += OnCheckedChanged;
            }

            if (this.cbRed.IsChecked == true)
            {
                this.cbRed.Unchecked += OnCheckedChanged;
            }
            else
            {
                this.cbRed.Checked += OnCheckedChanged;
            }

            if (this.cbBlue.IsChecked == true)
            {
                this.cbBlue.Unchecked += OnCheckedChanged;
            }
            else
            {
                this.cbBlue.Checked += OnCheckedChanged;
            }

            if (this.cbGreen.IsChecked == true)
            {
                this.cbGreen.Unchecked += OnCheckedChanged;
            }
            else
            {
                this.cbGreen.Checked += OnCheckedChanged;
            }

            if (this.cbDevoid.IsChecked == true)
            {
                this.cbDevoid.Unchecked += OnCheckedChanged;
            }
            else
            {
                this.cbDevoid.Checked += OnCheckedChanged;
            }
        }

        public void Collapse()
        {
            this.LayoutRoot.Height = 72;
            this.cbWhite.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            this.cbBlue.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            this.cbDevoid.VerticalAlignment = System.Windows.VerticalAlignment.Top;
        }

        public void Expand()
        {
            this.LayoutRoot.Height = 144;
            this.cbWhite.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            this.cbBlue.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            this.cbDevoid.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
        }
    }
}
