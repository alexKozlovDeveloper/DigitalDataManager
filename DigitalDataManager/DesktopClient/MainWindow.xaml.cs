﻿using System;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using DdmHelpers.FileTree;
using DesktopClient.DdmServiceReference;
using DesktopClient.Helpers;
using DesktopClient.Tree;
using FileSystemManager;
using FileSystemManager.FileVersionHelper;
using Image = System.Windows.Controls.Image;
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

        private bool _flg = false;

        public MainWindow()
        {
            InitializeComponent();

            _manager = new ClientFileManager(@"C:\Ddm\Client");//C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Client
            //_manager.UpdateFileVersion();
            MainWindowObject.Icon = ImageConverter.ToBitmapImage(Properties.Resources.MainWindowIcon);

            GridTest.Drop += GridTest_Drop;

            var t = new ImagesViewer(ScrollViewerFromFolder);

            var tree = new TreeViewer(TreeView11, FileTreeHelper.GetFolderTree(@"C:\Ddm\Images"), t);
            
            Init();
        }

        void GridTest_Drop(object sender, DragEventArgs e)
        {
            var obj = sender as Grid;

            var data = e.Data.GetData(typeof (Image));

            GridTest.Children.Add(data as Image);
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
