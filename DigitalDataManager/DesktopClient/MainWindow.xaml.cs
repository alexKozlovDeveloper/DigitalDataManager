using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml;
using DesktopClient.DdmServiceReference;
using DesktopClient.Helpers;
using FileSystemManager;
using FileSystemManager.FileVersionHelper;
using ImageConverter = DesktopClient.Helpers.ImageConverter;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ClientFileManager _manager;
        private readonly ImagesViewer _imagesViewer;

        private TabControlHelper _tabHelper;

        private ImageContextMenuHelper im;

        public MainWindow()
        {
            InitializeComponent();

            //_imagesViewer = new ImagesViewer(ImagesScrollViewer);
            _manager = new ClientFileManager(@"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Client");


            var img = new System.Windows.Controls.Image
            {
                Source = ImageConverter.ToBitmapImage(Properties.Resources.AddIcon)
            };

            //AddImageButton.Source = new BitmapImage(new Uri("Add-icon.png"));

            //TestGrid.Children.Add(img);

            //ButtonTest.Content = img;
            
            var cm = new ContextMenu();
            TestMenuButton.ContextMenu = cm;
            im = new ImageContextMenuHelper(cm);


            Init();
        }

        public void Init()
        {
            //_imagesViewer.Clear();

            //var paths = _manager.GetAllFilePath();

            //foreach (var path in paths)
            //{
            //    var img = new System.Windows.Controls.Image
            //    {
            //        Source = new BitmapImage(new Uri(path)),
            //    };

            //    _imagesViewer.AddImage(img);
            //}

            //var albums = _manager.GetAllAlbums();

            //_tabHelper = new TabControlHelper(AlbumTabControl);

            //foreach (var album in albums)
            //{
            //    _tabHelper.AddTab(album.Name);

            //    foreach (var file in album.Images)
            //    {
            //        _tabHelper.AddImageToTab(album.Name, _manager.GetFilePath(file.Name));
            //    }
            //}
        }




        private void OnClosed(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnOpened(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
