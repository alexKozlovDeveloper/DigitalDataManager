using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;
using DesktopClient.Helpers;
using FileSystemManager;
using FileSystemManager.ChecksumHelper;
using FileSystemManager.FileVersionHelper;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ClientFileManager _manager;
        private readonly ImagesViewer _imagesViewer;

        public MainWindow()
        {
            InitializeComponent();

            _imagesViewer = new ImagesViewer(ImagesScrollViewer);
            _manager = new ClientFileManager(@"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Client");

            //FileInfo fi1 = new FileInfo(@"D:\TestDDM\32.jpg");
            //var _fileMD51 = GetHashMd5FromStream(fi1.OpenRead());

            //FileInfo fi2 = new FileInfo(@"D:\TestDDM\32C.jpg");
            //var _fileMD52 = GetHashMd5FromStream(fi2.OpenRead()); 

            var str1 = CsHelper.GetFileChecksum(@"D:\TestDDM\32.jpg");
            var str2 = CsHelper.GetFileChecksum(@"D:\TestDDM\32C.jpg");

            string pathToXml = @"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Client\FileVersion1.xml";

            var f = new FileVersionInfo(pathToXml);

            f.AddFileChecksum(@"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Client\testImage.jpg");


            Init();
        }



        public void Init()
        {
            _imagesViewer.Clear();

            var paths = _manager.GetAllFilePath();

            foreach (var path in paths)
            {
                var img = new System.Windows.Controls.Image
                {
                    Source = new BitmapImage(new Uri(path)),
                };

                _imagesViewer.AddImage(img);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _imagesViewer.Clear();
        }
    }
}
