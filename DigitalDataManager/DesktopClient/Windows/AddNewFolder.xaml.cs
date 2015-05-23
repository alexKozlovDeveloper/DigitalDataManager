using DdmHelpers.FileTree.Entity;
using DesktopClient.Tree;
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
using System.Windows.Shapes;

namespace DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for AddNewFolder.xaml
    /// </summary>
    public partial class AddNewFolder : Window
    {
        private TreeViewer _tree;
        private MainWindow _mainWindow;

        public AddNewFolder(TreeViewer tree, MainWindow mainWindow)
        {
            InitializeComponent();

            _tree = tree;
            _mainWindow = mainWindow;

            ButtonCancel.Click += ButtonCancel_Click;
            ButtonAdd.Click += ButtonAdd_Click;
        }

        void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _tree.AddItem(_mainWindow.TreeView11.SelectedItem as TreeViewItem, new FolderEntity { Name = TextBoxFolderName.Text });

            this.Hide();
        }

        void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
