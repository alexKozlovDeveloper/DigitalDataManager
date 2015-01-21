using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using DdmHelpers.FileTree.Entity;

namespace DesktopClient.Tree
{
    class TreeViewer
    {
        private TreeView _treeView;

        public TreeViewer(TreeView treeView, FolderEntity folder)
        {
            _treeView = treeView;

            var items = InitTree(folder);

            foreach (var item in items.ItemsSource)
            {
                _treeView.Items.Add(item);
            }
        }

        public TreeViewItem InitTree(FolderEntity folder)
        {
            var item = new TreeViewItem()
            {
                Header = folder.Name
            };

            var itemsSource = new List<TreeViewItem>();

            foreach (var folderEntity in folder.Folders)
            {
                itemsSource.Add(InitTree(folderEntity));
            }

            item.ItemsSource = itemsSource;

            //item.Background = new SolidColorBrush(Colors.Wheat);
            //item.BorderBrush = new SolidColorBrush(Colors.Wheat);

            item.MouseDoubleClick += item_MouseDoubleClick;

            return item;
        }

        void item_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
