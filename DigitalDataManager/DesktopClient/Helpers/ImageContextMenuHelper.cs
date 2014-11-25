using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopClient.Helpers
{
    class ImageContextMenuHelper
    {
        private readonly ContextMenu _menu;

        public ImageContextMenuHelper(ContextMenu menu)
        {
            _menu = menu;

            Init();
        }

        public void Init()
        {
            var mi1 = new MenuItem
            {
                Header = "Use Filter"
            };

            var mi11 = new MenuItem
            {
                Header = "SVG effects"
            };

            var mi12 = new MenuItem
            {
                Header = "CSS Filter Effects"
            };

            mi1.Items.Add(mi11);
            mi1.Items.Add(mi12);

            var mi2 = new MenuItem
            {
                Header = " Copy to album"
            };

            var mi21 = new MenuItem
            {
                Header = "All"
            };

            var mi22 = new MenuItem
            {
                Header = "New"
            };

            mi2.Items.Add(mi21);
            mi2.Items.Add(mi22);

            var mi3 = new MenuItem
            {
                Header = "Delete"
            };

            var img = new System.Windows.Controls.Image
            {
                Height = 16,
                Width = 16,
                Source = ImageConverter.ToBitmapImage(Properties.Resources.AddIcon)
            };

            mi3.Icon = img;

            _menu.Items.Add(mi1);
            _menu.Items.Add(mi2);
            _menu.Items.Add(mi3);
        }
    }
}
