using System;
using System.Collections.Generic;
using System.Drawing;
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
using DesktopClient.Helpers;
using FileSystemManager;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientFileManager _manager;
        private readonly ImagesViewer _imagesViewer;

        public MainWindow()
        {
            InitializeComponent();

            _imagesViewer = new ImagesViewer(ImagesScrollViewer);
            _manager = new ClientFileManager(@"D:\TestDDM\Client");

            var paths = _manager.GetAllFilePath();

            //MediaElement.Source = new Uri(@"D:\TestDDM\Server\sample_iPod.m4v");
            //MediaElement.SpeedRatio = 0.0;

            foreach (var path in paths)
            {
                var img = new System.Windows.Controls.Image
                {
                    Source = new BitmapImage(new Uri(path)),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };

                _imagesViewer.AddImage(img);
            }
        }

        public void UpdateImages(Grid imagesGrid)
        {
            var paths = _manager.GetAllFilePath();

            foreach (var path in paths)
            {
                var image = new System.Windows.Controls.Image
                {
                    Source = new BitmapImage(new Uri(path)),
                    Height = 100,
                    Width = 100,
                    Margin = new Thickness(10, 10, 10, 10),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var img = new System.Windows.Controls.Image
            {
                Source = new BitmapImage(new Uri(@"D:\test1.png")),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };

            _imagesViewer.AddImage(img);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //MediaElement.Position = new TimeSpan(0,0,1);

            //MediaElement.SpeedRatio = 1.0;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //MediaElement.SpeedRatio = 0.0;
            //MediaElement.Stop();
        }
    }
}
