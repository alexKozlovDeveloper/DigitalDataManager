using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DigitalDataManager.DigitalServiceReference;
using FileSystemManager.FileReader;
using FileSystemManager.FileVersionHelper.FileVersionItems;
using FileSystemManager.XmlSerialize;

namespace DigitalDataManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ms = new MemoryStream();
            //var fs = System.IO.File.OpenRead(@"D:\test1.png");
            //fs.CopyTo(ms);
            //fs.Close();
            //ms.Position = 0;

            //var fd = System.IO.File.OpenWrite(@"D:\test2.png");
            //fd.Write(ms.ToArray(), 0, (int)ms.Length);

            //var fm = new FileSystemManager.FileManager("D:\\ddm");

            //var img = fm.GetImageStream("test1.png");

            //fm.CreateImage(img, "ololo.png");

            //var client = new DigitalServiceReference.DigitalServiceClient();

            //var t = client.GetData("lal");

            //var g = new CompositeType { BoolValue = true, StringValue = "gfgf" };

            //var h = client.GetDataUsingDataContract(g);

            var f = new FileVersion() { Checksum = "1", FileName = "2", FullPath = "3" };
            var d = new VersionNumber() { Number = 12 };
            var t = new CatalogVersion() { VersionNumber = d };
            t.Files = new List<FileVersion>();
            t.Files.Add(f);
            t.Files.Add(f);
            t.Files.Add(f);
            t.Files.Add(f);

            XmlVersionReader.WriteVeriosn(@"D:\ffff.xml",t);

            var h = XmlVersionReader.ReadVersion(@"D:\ffff.xml");

            //var stream = XmlSerializerHelper.Serialize<CatalogVersion>(t);

            //using (FileStream fileStream = File.Create(@"D:\Testr.xml", (int)stream.Length))
            //{
            //    // Размещает массив общим размером равным размеру потока
            //    // Могут быть трудности с выделением памяти для больших объемов
            //    byte[] data = new byte[stream.Length];

            //    stream.Read(data, 0, (int)data.Length);
            //    fileStream.Write(data, 0, data.Length);
            //}  


            //using (FileStream fileStream = File.Open(@"D:\Testr.xml",FileMode.Open))
            //{
            //    var data = new byte[fileStream.Length];

            //    fileStream.Read(data, 0, (int) data.Length);

            //    var ms = new MemoryStream();

            //    ms.Write(data, 0, data.Length);

            //    ms.Position = 0;

            //    var g = XmlSerializerHelper.Deserialize<CatalogVersion>(ms);
            //}

            Console.WriteLine("ololo");
            Console.ReadKey();
        }
    }
}
