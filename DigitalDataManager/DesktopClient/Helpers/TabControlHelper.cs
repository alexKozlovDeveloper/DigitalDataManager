using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DesktopClient.Helpers
{
    class TabControlHelper
    {
        private const int WidthDifferences = 10;
        private readonly TabControl _tabControl;

        private readonly List<TabItem> _tabs;
        private readonly Dictionary<string, ImagesViewer> _viewers;

        public TabControlHelper(TabControl tabControl)
        {
            _tabControl = tabControl;

            _tabs = new List<TabItem>();
            _viewers = new Dictionary<string, ImagesViewer>();
        }

        public void AddTab(string tabName)
        {
            var content = new ScrollViewer
            {
                Content = new Grid(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Width = _tabControl.Width - WidthDifferences,
                Height = _tabControl.Height - WidthDifferences
            };
            
            var tab = new TabItem
            {
                Header = tabName,
                Content = content
            };

            var viewer = new ImagesViewer(content);

            _tabs.Add(tab);
            _viewers.Add(tabName, viewer);

            _tabControl.Items.Add(tab);
        }

        public void AddImageToTab(string tabName, string imagePath)
        {
            var viewer = _viewers[tabName];

            viewer.AddImage(imagePath);
        }

        public void Clear()
        {
            _tabControl.Items.Clear();
            _tabs.Clear();
            _viewers.Clear();
        }

        //public void Clear(string tabName)
        //{
        //    TabItem tab = null;

        //    foreach (TabItem item in _tabControl.Items)
        //    {
        //        if (item.Header as string == tabName)
        //        {
        //            tab = item;
        //        }
        //    }


        //}
    }
}
