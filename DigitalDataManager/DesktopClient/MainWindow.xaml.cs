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

        private TabControlHelper _tabHelper;

        public MainWindow()
        {
            InitializeComponent();
            
            _manager = new ClientFileManager(@"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Client");

            MainWindowObject.Icon = ImageConverter.ToBitmapImage(Properties.Resources.MainWindowIcon);

            Init();
        }

        public void Init()
        {
            var albums = _manager.GetAllAlbums();

            _tabHelper = new TabControlHelper(AlbumTabControl);

            foreach (var album in albums)
            {
                _tabHelper.AddTab(album.Name);

                foreach (var file in album.Images)
                {
                    _tabHelper.AddImageToTab(album.Name, _manager.GetFilePath(file.Name));
                }
            }
        }
    }
}
