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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvasFog.Width = e.NewSize.Width;
            canvasFog.Height = e.NewSize.Height;
        }

        private void Init_Canvas()
        {
            
        }

        private void canvasMap_Drop(object sender, DragEventArgs e)
        {
            var src = e.Data.GetData(typeof(DataObject));
        }
    }
}
