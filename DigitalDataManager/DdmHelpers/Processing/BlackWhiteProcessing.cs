using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdmHelpers.Processing
{
    public class BlackWhiteProcessing : IProcessing
    {
        public BlackWhiteProcessing()
        {
            ProcessingName = "_BlackWhite";
        }

        public void Process(string sourceImage, string destImage)
        {
            var sourceBitmap = new Bitmap(sourceImage);

            var resBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            for (var i = 0; i < sourceBitmap.Width; i++)
            {
                for (var j = 0; j < sourceBitmap.Height; j++)
                {
                    var color = sourceBitmap.GetPixel(i, j);
                    var k = (color.R + color.G + color.B) / 3;
                    var resColor = Color.FromArgb(k, k, k);

                    resBitmap.SetPixel(i, j, resColor);
                }
            }

            resBitmap.Save(destImage);
        }

        public string ProcessingName { get; set; }
    }
}
