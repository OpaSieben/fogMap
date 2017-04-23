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
        private const int CircleMaxSize = 215;
        private const int CircleMinSize = 31;
        private const int Step = 10;
        private bool _circleMovable = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvasMap_Drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            var files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (files != null) imageMap.Source = new BitmapImage(new Uri(files[0]));
            ShowFog();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (_circleMovable)
                CenterCanvasCircle();
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                IncreaseCanvasCircleSize();
            else if (e.Delta < 0)
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
            if (imageFog.Visibility == Visibility.Visible)
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
            if (imageFogCircle.RadiusX + Step < CircleMaxSize)
                imageFogCircle.RadiusX = imageFogCircle.RadiusY += Step;
        }

        private void DecreaseCanvasCircleSize()
        {
            if (imageFogCircle.RadiusY + Step > CircleMinSize)
                imageFogCircle.RadiusX = imageFogCircle.RadiusY -= Step;
        }

        private void fogButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleFogVisibility();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemPlus || e.Key == Key.Add)
            {
                IncreaseCanvasCircleSize();
            }


            if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
            {
                DecreaseCanvasCircleSize();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _circleMovable = true;
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _circleMovable = false;
        }
    }
}