﻿using Ddm.Helpers.FileTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ddm.WpfApplication.Helpers
{
    class TreeViewer
    {
        private TreeView _treeView;
        private readonly ImagesViewer _imagesViewer;
        private readonly Dictionary<string, string> _folderPaths;

        public TreeViewer(TreeView treeView, FolderEntity folder, ImagesViewer imagesViewer)
        {
            _treeView = treeView;
            _imagesViewer = imagesViewer;

            _folderPaths = new Dictionary<string, string>();

            _treeView.SelectedItemChanged += _treeView_SelectedItemChanged;

            var items = InitTree(folder);

            _treeView.Items.Add(items);
        }

        void _treeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            var item = e.NewValue as TreeViewItem;

            _imagesViewer.Clear();

            var images = FileTreeHelper.GetAllFileInFolderAndSubfolders(_folderPaths[item.Header as string]);

            foreach (var image in images)
            {
                _imagesViewer.AddImage(image);
            }
        }

        public TreeViewItem InitTree(FolderEntity folder)
        {
            var grid = new Grid();

            var img = new Image
            {
                Source = new BitmapImage(new Uri(@"C:\Ddm\sample.jpg")),
                Margin = new Thickness(0, 0, 0, 0)
            };

            var tb = new Label
            {
                Content = folder.Name,
                Margin = new Thickness(10, 0, 0, 0)
                //Text = "folder.Name",
                //Margin = new Thickness(10, 0, 0, 0)
            };

            grid.Children.Add(img);
            grid.Children.Add(tb);

            var item = new TreeViewItem
            {
                Header = folder.Name
            };

            _folderPaths.Add(folder.Name, folder.Path);

            var itemsSource = new List<TreeViewItem>();

            foreach (var folderEntity in folder.Folders)
            {
                itemsSource.Add(InitTree(folderEntity));
            }

            item.ItemsSource = itemsSource;
            return item;
        }
    }
}
