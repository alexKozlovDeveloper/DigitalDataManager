using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesktopClient.Helpers
{
    class ImageItem
    {
        private readonly Thickness _imageMargin;

        private bool _isSelect;
        private readonly Grid _grid;
        private readonly string _imagePath;
        private readonly Image _image;

        public bool IsSelect 
        {
            get { return _isSelect; }
        }

        public string ImagePath 
        {
            get { return _imagePath; }
        }

        public string ImageName 
        {
            get { return Path.GetFileName(_imagePath); }
        }
        
        public ImageItem(Grid grid, string imagePath)
        {
            _grid = grid;
            _imagePath = imagePath;

            _imageMargin = new Thickness(10, 10, 10, 10);

            _image = new Image
            {
                Source = new BitmapImage(new Uri(imagePath)),
                Margin = _imageMargin,
                Width = grid.Width - _imageMargin.Left - _imageMargin.Right,
                Height = grid.Height - _imageMargin.Top - _imageMargin.Bottom
            };

            //_image.MouseLeftButtonUp += _image_MouseLeftButtonUp;
            _grid.MouseLeftButtonDown += _grid_MouseLeftButtonDown;

            _grid.Children.Add(_image);

            _isSelect = false;
            SetGridColor();
        }

        void _grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SelectSwitch();
        }
        
        //void _image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    SelectSwitch();
        //}

        private void SelectSwitch()
        {
            _isSelect = !_isSelect;
            SetGridColor();
        }

        private void SetGridColor()
        {
            if (_isSelect)
            {
                _grid.Background = new SolidColorBrush(Colors.SeaGreen);
            }
            else
            {
                _grid.Background = new SolidColorBrush(Colors.RoyalBlue);
            }
        }
    }
}
