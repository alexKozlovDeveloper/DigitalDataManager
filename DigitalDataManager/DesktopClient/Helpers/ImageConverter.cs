using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace DesktopClient.Helpers
{
    static class ImageConverter
    {
        public static BitmapImage ToBitmapImage(Bitmap img)
        {
            using (var memory = new MemoryStream())
            {
                img.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        public static Bitmap ToBitmap(BitmapImage img)
        {
            using (var outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(img));
                enc.Save(outStream);
                var bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }
    }
}
