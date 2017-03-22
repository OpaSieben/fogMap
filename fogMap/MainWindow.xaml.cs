using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fogMap
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int circleMaxSize = 215;
        private int circleMinSize = 31;
        private int step = 10;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvasMap_Drop(object sender, DragEventArgs e)
        {
             if (e.Data.GetDataPresent(DataFormats.FileDrop))
              {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);     
                imageMap.Source = new BitmapImage(new Uri(files[0]));
                ShowFog();
              }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            CenterCanvasCircle();
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {

            if (e.Delta > 0 && imageFogCircle.RadiusX + step < circleMaxSize)
                IncreaseCanvasCircleSize();
            else if (e.Delta < 0 && imageFogCircle.RadiusY + step > circleMinSize)
                DecreaseCanvasCircleSize();

            CenterCanvasCircle();
        }



        private void CenterCanvasCircle()
        {
            var pos = Mouse.GetPosition(imageFog);
            imageFogCircle.Center = imageFogCircle.GradientOrigin = pos;
        }

        private void ToggleFogVisibility()
        {
            if(imageFog.Visibility == Visibility.Visible)
                HideFog();
             else
                ShowFog();
            
        }

        private void ShowFog()
        {
            imageFog.Visibility = Visibility.Visible;
        }

        private void HideFog()
        {
            imageFog.Visibility = Visibility.Hidden;
        }

        private void IncreaseCanvasCircleSize()
        {
            imageFogCircle.RadiusX = imageFogCircle.RadiusY += step;
        }

        private void DecreaseCanvasCircleSize()
        {
           imageFogCircle.RadiusX = imageFogCircle.RadiusY -= step;
        }

        private void fogButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleFogVisibility();
        }
    }
}
