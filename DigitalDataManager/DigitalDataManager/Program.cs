using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DbController.Repositoryes;
using DdmHelpers.Serialize;
using FileSystemManager;
using FileSystemManager.FileReader;
using FileSystemManager.FileVersionHelper.FileVersionItems;
using FileSystemManager.VersionChanges;

namespace DigitalDataManager
{
    [Serializable]
    public class Test
    {
        public Stream ImageStream { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var image = new MemoryStream();
            
            var test = new Test() {Login = "a", Name = "b", ImageStream = image};

            var t = BinarySerializerHelper.Serialize(test);

            var g = BinarySerializerHelper.Deserialize<Test>(t);

            //var formatter = new BinaryFormatter();

            //var res = new MemoryStream();

            //formatter.Serialize(res,test);

            //res.Position = 0;

            //var test2 = formatter.Deserialize(res);


            //// получаем поток, куда будем записывать сериализованный объект
            //using (var fs = new FileStream("persons.dat", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, person);

            //    Console.WriteLine("Объект сериализован");
            //}

            //// десериализация из файла persons.dat
            //using (FileStream fs = new FileStream("persons.dat", FileMode.OpenOrCreate))
            //{
            //    Person newPerson = (Person)formatter.Deserialize(fs);

            //    Console.WriteLine("Объект десериализован");
            //    Console.WriteLine("Имя: {0} --- Возраст: {1}", newPerson.Name, newPerson.Age);
            //}


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

            //var f = new FileVersion() { Checksum = "1", FileName = "2", FullPath = "3" };
            //var d = new VersionNumber() { Number = 12 };
            //var t = new CatalogVersion() { VersionNumber = d };
            //t.Files = new List<FileVersion>();
            //t.Files.Add(f);
            //t.Files.Add(f);
            //t.Files.Add(f);
            //t.Files.Add(f);

            //XmlVersionReader.WriteVeriosn(@"D:\ffff.xml",t);

            //var h = XmlVersionReader.ReadVersion(@"D:\ffff.xml");


            //var c = new CatalogVersion(@"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Client");

            //var a = new CatalogVersion(@"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Server");

            //var t = a.ToXmlString();

            //var g = XmlSerializerHelper.Deserialize<CatalogVersion>(t);

            //var yy = VersionComparator.Compare(c, a);

            //System.IO.File.SetAttributes(@"D:\Testr.xml", System.IO.FileAttributes.Hidden);

            //var stream = XmlSerializerHelper.Serialize<CatalogVersion>(t);

            //using (FileStream fileStream = File.Create(@"D:\Testr.xml", (int)stream.Length))
            //{
            //    // Размещает массив общим размером равным размеру потока
            //    // Могут быть трудности с выделением памяти для больших объемов
            //    byte[] data = new byte[stream.Length];

            //    stream.Read(data, 0, (int)data.Length);
            //    fileStream.Write(data, 0, data.Length);
            //}  


            //using (FileStream fileStream = File.Open(@"D:\Testr.xml", FileMode.Open))
            //{
            //    var data = new byte[fileStream.Length];

            //    fileStream.Read(data, 0, (int)data.Length);

            //    var ms = new MemoryStream();

            //    ms.Write(data, 0, data.Length);

            //    ms.Position = 0;

            //    var g = XmlSerializerHelper.Deserialize<CatalogVersion>(ms);
            //}

            //var fd = new DdmServiceReference.DigitalServiceClient();

            //var vers = fd.GetLastCatalogVersion("Alex");

            var fm = new ClientFileManager(@"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Client");

            //var rep = new Repository("");

            //var t = rep.GetUserByName("Alex");

            fm.UpdateFileVersion();






            Console.WriteLine("ololo");
            Console.ReadKey();
        }
    }
}
