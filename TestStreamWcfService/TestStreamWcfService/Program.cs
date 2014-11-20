using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfStreamService;

namespace TestStreamWcfService
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WcfServiceReference.Service1Client();

            //var ms = new MemoryStream();

            //using (var fs = File.Open(@"D:\test1.png", FileMode.Open))
            //{
            //    fs.CopyTo(ms);
            //}



            //var ms = client.GetFile(@"D:\drop.avi");//test1.png"

           // var t = BinarySerializerHelper.Deserialize<Info>(ms);

            //client.AddFile(ms);

            var lh = new LoadingHelper(client);

            //lh.LoadFileToServer(@"D:\TESTIMAGE.bmp");

            lh.DownloadFileToClient(@"D:\TESTIMAGE_1.bmp");

            //File.Delete(@"D:\test7.png");

            //const int thumbWidth = 400;
            //const int thumbHeight = 300;

            //System.Drawing.Image.GetThumbnailImageAbort myCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            //MyContractClient proxy = new MyContractClient("basicHttpBinding_IPhotoManagerService");

            //var s = client.GetPhotoList();//proxy.GetPhotoList();

            //Label1.Text = s[0] + " " + s[1];

            //var serverStream = client.GetPhotoStream(s[0]);

            //FileReaderHelper.WriteStreamInFile(serverStream, @"D:\test11.png");


            //Bitmap myBitmap = new Bitmap(serverStream);
            //System.Drawing.Image myThumbnail = myBitmap.GetThumbnailImage(thumbWidth, thumbHeight, myCallBack, IntPtr.Zero);
            //myThumbnail.Save(Server.MapPath("~/" + s[0]));
           // Image1.ImageUrl = "~/" + s[0];
            //myThumbnail.Dispose();
            //myBitmap.Dispose();

            //serverStream = client.GetPhotoStream(s[1]);

            //FileReaderHelper.WriteStreamInFile(serverStream, @"D:\test12.png");

            //myBitmap = new Bitmap(serverStream);
            //myThumbnail = myBitmap.GetThumbnailImage(thumbWidth, thumbHeight, myCallBack, IntPtr.Zero);
            //myThumbnail.Save(Server.MapPath("~/" + s[1]));
            //Image2.ImageUrl = "~/" + s[1];
            //myThumbnail.Dispose();
            //myBitmap.Dispose();

            //DataBind();
        }
    }

    //public static class FileReaderHelper
    //{
    //    public static void WriteStreamInFile(Stream stream, string filePath)
    //    {
    //        using (FileStream fileStream = File.Create(filePath, (int)stream.Length))
    //        {
    //            var data = new byte[stream.Length];

    //            stream.Read(data, 0, data.Length);
    //            fileStream.Write(data, 0, data.Length);
    //        }
    //    }

    //    public static Stream ReadStreamFromFile(string filePath)
    //    {
    //        using (FileStream fileStream = File.Open(filePath, FileMode.Open))
    //        {
    //            var data = new byte[fileStream.Length];

    //            fileStream.Read(data, 0, data.Length);

    //            var ms = new MemoryStream();

    //            ms.Write(data, 0, data.Length);

    //            ms.Position = 0;

    //            return ms;
    //        }
    //    }
    //}
}
