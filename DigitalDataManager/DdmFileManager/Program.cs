using DbController.Repositoryes;
using DdmFileManager.Clent;
using DdmHelpers.FileReader;
using DdmHelpers.FileTree;
using DdmHelpers.Processing;
using DdmHelpers.Serialize;
using DdmWcfServiceLibrary.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdmFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = new DdmRepository();

            //var user = rep.CreateUser("Alex", "Alex", "Alex@mail.com");

            //var a = rep.AddFolder(user.Id, "a", Guid.Empty);
            //var b = rep.AddFolder(user.Id, "b", Guid.Empty);
            //var c = rep.AddFolder(user.Id, "c", Guid.Empty);

            //var a1 = rep.AddFolder(user.Id, "a1", a.Id);
            //var a2 = rep.AddFolder(user.Id, "a2", a.Id);

            //var a11 = rep.AddFolder(user.Id, "a11", a1.Id);

            //var user = rep.GetUser("Alex");

            //var folder = rep.GetFolderStruct(user.Id);

            //FileTreeHelper.SetAllFolderPath(folder, "");

            //var fn = new ClientFM(@"C:\Ddm\TestStruct", user.Id);
            //fn.UpdateCurrentFolderStruct();
            //var st = fn.CurrentFolderStruct;

            //var folderStruct = FileTreeHelper.GetFolderTree(@"C:\Ddm\TestStruct");

            //var res = MergeTree.MergeFolders(folder, folderStruct);

            //var t = XmlSerializerHelper.Serialize(folder);

            //FileReaderHelper.WriteStreamInFile(t, @"D:\olo.xml");


            //var proc = new BlackWhiteProcessing();
            //proc.Process(@"D:\sample.jpg", @"D:\sample1.jpg");


        //////    var user = rep.GetUser("Alex");

        //////    var folderStruct = FileTreeHelper.GetFolderTree(@"C:\Ddm\TestStruct");

        //////    var t = rep.UpdateFolderStruct(user.Id, folderStruct);

        //////    foreach (var item in t)
        //////    {                
        //////        var fs = FileReaderHelper.ReadStreamFromFile(item.Key);

        //////        var client = new ServiceReference1.ServiceClient();

        //////        var data = new FileEntity 
        //////        { 
        //////            CheckSum = "",
        //////            FileStream = fs,
        //////            Name = Path.GetFileName(item.Key)
        //////        };

        //////        var file = client.CreateFile(BinarySerializerHelper.Serialize(data));
        //////        client.AddFileToFolder(file.Id, item.Value);
        //////        //var file = rep.AddFile(fs, Path.GetFileName(item.Key), "");
        //////        //rep.AddFileToFolder(file.Id, item.Value);
        //////    }

        //////    var s = rep.GetFolderStruct(user.Id);

            var client = new ServiceReference1.ServiceClient();

            var f = client.CreateFile(File.ReadAllBytes(@"C:\Ddm\sample.jpg"), "sample.jpg", "");

        }
    }
}
