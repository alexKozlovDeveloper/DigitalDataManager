using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ddm.WpfApplication.Helpers
{
    class ImagesViewer
    {
        private const int ScrollWidth = 17;

        private readonly ScrollViewer _viewer;
        private readonly Grid _grid;

        private readonly int _imageHeight;
        private readonly int _imageWidth;
        private readonly Thickness _imageMargin;

        private readonly List<ImageItem> _images;

        public int HorizontalImageCount
        {
            get { return (int)_grid.Width / _imageWidth; }
        }
        public int VerticalImageCount
        {
            get
            {
                if (_images.Count % HorizontalImageCount > 0)
                {
                    return _images.Count / HorizontalImageCount + 1;
                }
                else
                {
                    return _images.Count / HorizontalImageCount;
                }
            }
        }

        public ImagesViewer(ScrollViewer viewer, int imageWidth = 150, int imageHeight = 150)
        {
            this._viewer = viewer;
            this._grid = _viewer.Content as Grid;

            _images = new List<ImageItem>();

            _imageHeight = imageWidth;
            _imageWidth = imageHeight;
            _imageMargin = new Thickness(0, 0, 0, 0);

            _grid.Width = _viewer.Width + ScrollWidth;

            SetGridHeight();
        }

        public void AddImage(string imagePath)
        {
            var h = _images.Count / HorizontalImageCount;
            var w = _images.Count - h * HorizontalImageCount;

            var imageGrid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Height = _imageHeight,
                Width = _imageWidth,
                Margin =
                    new Thickness(_imageMargin.Left + w * _imageWidth, _imageMargin.Top + h * _imageHeight,
                        _imageMargin.Right, _imageMargin.Bottom)
            };

            var img = new ImageItem(imageGrid, imagePath);

            _images.Add(img);
            _grid.Children.Add(imageGrid);

            SetGridHeight();
        }

        private void SetGridHeight()
        {
            var h = VerticalImageCount * _imageHeight;

            if (h < _viewer.Height)
            {
                _grid.Height = _viewer.Height;
            }
            else
            {
                _grid.Height = h;
            }
        }

        public void Clear()
        {
            _grid.Children.Clear();
            _images.Clear();
        }

        public List<ImageItem> GetAllSelectItems()
        {
            var res = new List<ImageItem>();

            foreach (var imageItem in _images)
            {
                if (imageItem.IsSelect)
                {
                    res.Add(imageItem);
                }
            }

            return res;
        }
    }
}
