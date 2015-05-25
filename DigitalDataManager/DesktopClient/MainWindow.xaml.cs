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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using DdmHelpers.FileTree;
using DdmHelpers.Processing;
using DesktopClient.DdmServiceReference;
using DesktopClient.Helpers;
using DesktopClient.Tree;
using FileSystemManager;
using FileSystemManager.FileVersionHelper;
using Image = System.Windows.Controls.Image;
using ImageConverter = DesktopClient.Helpers.ImageConverter;
using DesktopClient.Pages;
using DesktopClient.Windows;
using DdmHelpers.FileTree.Entity;
using DdmFileManager.Clent;
using DbController.Repositoryes;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ClientFileManager _manager;
        private readonly ClientFM _mf;

        private TabControlHelper _tabHelper;

        private SettingWindow _settingWindow;
        private AddNewFolder _addNewFolder;
        private AddNewTag _addNewTag;

        private bool _flg = false;

        private TreeViewer _tree;
        private ImagesViewer _imagesViewer;

        private ServiceReference1.ServiceClient service;

        public MainWindow()
        {
            InitializeComponent();

            service = new ServiceReference1.ServiceClient();

            var rep = new DdmRepository();

            var user = rep.GetUser("Alex");

            //service.AddTag(user.Id, "Minsk");
            //service.AddTag(user.Id, "Milan");
            //service.AddTag(user.Id, "Belarus");
            //service.AddTag(user.Id, "Russian");
            //service.AddTag(user.Id, "Nature");
            //service.AddTag(user.Id, "Tourism");

            ConfigController.CurrentUser = user;

            //var user = rep.CreateUser("Alex", "Alex", "Alex@mail.com");

            _manager = new ClientFileManager(@"D:\Ddm\Client");
            _mf = new ClientFM(@"C:\Ddm\TestStruct", user.Id);


            MainWindowObject.Icon = ImageConverter.ToBitmapImage(Properties.Resources.MainWindowIcon);

            _imagesViewer = new ImagesViewer(ScrollViewerFromFolder);

            var g = _mf.UpdateCurrentFolderStruct();

            //_tree = new TreeViewer(TreeView11, FileTreeHelper.GetFolderTree(@"D:\Ddm\Images"), _imagesViewer);
            _tree = new TreeViewer(TreeView11, g, _imagesViewer);
            ButtonSetting.Click += ButtonSetting_Click;

            Init();

            ButtonAddNewFolder.Click += ButtonAddNewFolder_Click;
            ButtonBlackWhite.Click += ButtonBlackWhite_Click;
            ButtonAplly.Click += ButtonAplly_Click;
            ButtonAddNewTag.Click += ButtonAddNewTag_Click;
            ButtonAddTagToImage.Click += ButtonAddTagToImage_Click;

            InitTagsCloud();
            InitTagsDropdownList();
        }

        void ButtonAddTagToImage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void ButtonAddNewTag_Click(object sender, RoutedEventArgs e)
        {
            _addNewTag = new AddNewTag(this, service, ConfigController.CurrentUser);

            _addNewTag.Show();
        }

        void ButtonAplly_Click(object sender, RoutedEventArgs e)
        {
            _imagesViewer.FilterByDate(DatePickerFrom.SelectedDate, DatePickerTo.SelectedDate);
        }

        void ButtonBlackWhite_Click(object sender, RoutedEventArgs e)
        {
            _imagesViewer.ProccessingAllSelectItems(new BlackWhiteProcessing());
        }

        void ButtonAddNewFolder_Click(object sender, RoutedEventArgs e)
        {
            _addNewFolder = new AddNewFolder(_tree, this);
            _addNewFolder.Show();
            //_tree.AddItem(TreeView11.SelectedItem as TreeViewItem, new FolderEntity { Name = "newfolder", Path = "sd"});
        }

        void ButtonSetting_Click(object sender, RoutedEventArgs e)
        {
            _settingWindow = new SettingWindow();
            _settingWindow.Show();
        }

        void GridTest_Drop(object sender, DragEventArgs e)
        {
            var obj = sender as Grid;

            var data = e.Data.GetData(typeof (Image));

            //GridTest.Children.Add(data as Image);
        }

        public void Init()
        {
            //var albums = _manager.GetAllAlbums();

            //_tabHelper = new TabControlHelper(AlbumTabControl);

            //foreach (var album in albums)
            //{
            //    //_tabHelper.AddTab(album.Name);

            //    //foreach (var file in album.Images)
            //    //{
            //    //    _tabHelper.AddImageToTab(album.Name, _manager.GetFilePath(file.Name));
            //    //}
            //}
        }

        public void InitTagsDropdownList()
        {           
            var tags = service.GetAllUserTags(ConfigController.CurrentUser.Id);

            ComboBoxTags.Items.Clear();

            foreach (var item in tags)
            {
                ComboBoxTags.Items.Add(item);
            }
        }

        public void InitTagsCloud()
        {
            var tags = new Dictionary<string, int>();

            var tagsVal = service.GetAllUserTags(ConfigController.CurrentUser.Id);

            var rnd = new Random();

            foreach (var item in tagsVal)
            {
                tags.Add(item.Name, rnd.Next(30,45));
            }

            var min = 20;
            var max = 50;

            var maxFon = 25;

            WrapPanelTags.Children.Clear();

            foreach (var tag in tags)
            {
                var s = (maxFon * (tag.Value - min)) / (max - min);

                var lab = new Label();
                lab.Content = tag.Key;
                lab.FontSize = s;

                WrapPanelTags.Children.Add(lab);
            }
        }
    }
}
