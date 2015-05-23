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

namespace Ddm.WpfApplication.Helpers
{
    class ImageItem
    {
        private readonly Thickness _imageMargin;

        private bool _isSelect;
        private readonly Grid _grid;
        private string _imagePath;
        private Image _image;

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

            _imageMargin = new Thickness(10, 10, 10, 10);

            Init(imagePath);

            //_image = new Image
            //{
            //    Source = new BitmapImage(new Uri(imagePath)),
            //    Margin = _imageMargin,
            //    Width = grid.Width - _imageMargin.Left - _imageMargin.Right,
            //    Height = grid.Height - _imageMargin.Top - _imageMargin.Bottom
            //};

            //_grid.MouseLeftButtonDown += _grid_MouseLeftButtonDown;
            //_grid.Drop += _grid_Drop;
            //_grid.AllowDrop = true;

            //_grid.Children.Add(_image);

            //_isSelect = false;
            //SetGridColor();
        }

        private void Init(string imagePath)
        {
            _imagePath = imagePath;

            _grid.Children.Clear();

            _image = new Image
            {
                Source = new BitmapImage(new Uri(imagePath)),
                Margin = _imageMargin,
                Width = _grid.Width - _imageMargin.Left - _imageMargin.Right,
                Height = _grid.Height - _imageMargin.Top - _imageMargin.Bottom
            };

            _grid.MouseLeftButtonDown += _grid_MouseLeftButtonDown;
            _grid.Drop += _grid_Drop;
            _grid.AllowDrop = true;

            _grid.Children.Add(_image);

            _isSelect = false;
            SetGridColor();
        }

        void _grid_Drop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(typeof(string)) as string;

            if (data != ImagePath)
            {
                Init(data);
            }
        }

        void _grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SelectSwitch();

            DragDrop.DoDragDrop(_grid, this.ImagePath, DragDropEffects.Copy);
        }

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
                //new SolidColorBrush(Color.FromArgb(90, 0xF0, 0x00, 0xFF));
            }
            else
            {
                _grid.Background = new SolidColorBrush(Colors.RoyalBlue);
            }
        }
    }
}
