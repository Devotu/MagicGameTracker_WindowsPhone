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

namespace MagicGameTracker.Components
{
    public partial class ColorsUsedGraph : UserControl
    {
        private Double pch, pcw;

        public ColorsUsedGraph()
        {
            InitializeComponent();

            this.pch = this.ColorsUsedCanvas.Height;
            this.pcw = this.ColorsUsedCanvas.Width;
        }

        public void PopulateColorsUsed(List<Double> usages)
        {
            Double maxValue = usages.Max();

            for (int i = 0; i < 5; i++)
            {
                Canvas tmpCanvas = new Canvas();
                tmpCanvas.Width = (pcw / 5) - (pcw / 5 / 10) * 2;
                Double canvasHeight = 1;
                if (usages[i] > 0)
                {
                    canvasHeight = usages[i] / (maxValue / (pch - (pch / 20)));
                }
                tmpCanvas.Height = canvasHeight;
                Canvas.SetLeft(tmpCanvas, (((i + 1) * (pcw / 5)) - ((pcw / 10) + ((pcw / 10 / 5) * 4))));
                Canvas.SetTop(tmpCanvas, pch - canvasHeight);              

                switch (i)
                {
                    case 0:
                        tmpCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                        this.tbNumberOfBlack.Text = usages[i].ToString();
                        break;
                    case 1:
                        tmpCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                        this.tbNumberOfWhite.Text = usages[i].ToString();
                        break;
                    case 2:
                        tmpCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                        this.tbNumberOfRed.Text = usages[i].ToString();
                        break;
                    case 3:
                        tmpCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                        this.tbNumberOfBlue.Text = usages[i].ToString();
                        break;
                    case 4:
                        tmpCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                        this.tbNumberOfGreen.Text = usages[i].ToString();
                        break;
                    default:
                        tmpCanvas.Background = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
                        break;
                }

                this.ColorsUsedCanvas.Children.Add(tmpCanvas);
            }
        }

        public void setTitle(String newTitle)
        {
            this.tbViewTitle.Text = newTitle;
        }
    }
}
