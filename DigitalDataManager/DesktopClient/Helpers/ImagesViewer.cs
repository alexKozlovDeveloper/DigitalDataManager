using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DesktopClient.Helpers
{
    class ImagesViewer
    {
        private const int ScrollWidth = 17;

        private readonly ScrollViewer _viewer;
        private readonly Grid _grid;
        private readonly List<Image> _images;

        private readonly int _imageHeight;
        private readonly int _imageWidth;
        private readonly Thickness _imageMargin;

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
            this._grid = (Grid)_viewer.Content;

            _images = new List<Image>();

            _imageHeight = imageWidth;
            _imageWidth = imageHeight;
            _imageMargin = new Thickness(0, 0, 0, 0);

            _grid.Width = _viewer.Width + ScrollWidth;

            SetGridHeight();
        }

        public void AddImage(Image image)
        {
            image.Margin = _imageMargin;

            image.Height = _imageHeight;
            image.Width = _imageWidth;

            var h = _images.Count / HorizontalImageCount;
            var w = _images.Count - h * HorizontalImageCount;

            image.Margin = new Thickness(_imageMargin.Left + w * _imageWidth, _imageMargin.Top + h * _imageHeight, _imageMargin.Right, _imageMargin.Bottom);

            _images.Add(image);
            _grid.Children.Add(image);

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
    }
}
