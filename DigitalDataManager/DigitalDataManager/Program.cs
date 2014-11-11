using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DigitalDataManager.DigitalServiceReference;

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

            //fm.CreateImage(img,"ololo.png");

            //var client = new DigitalServiceReference.DigitalServiceClient();

            //var t = client.GetData("lal");

            //var g = new CompositeType {BoolValue = true, StringValue = "gfgf"};

            //var h = client.GetDataUsingDataContract(g);

            Console.WriteLine("ololo");
            Console.ReadKey();
        }
    }
}
