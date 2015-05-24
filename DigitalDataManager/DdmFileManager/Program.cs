﻿using DbController.Repositoryes;
using DdmFileManager.Clent;
using DdmHelpers.FileReader;
using DdmHelpers.FileTree;
using DdmHelpers.Serialize;
using System;
using System.Collections.Generic;
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

            var user = rep.GetUser("Alex");

            var folder = rep.GetFolderStruct(user.Id);

            FileTreeHelper.SetAllFolderPath(folder, "");

            //var fn = new ClientFM(@"C:\Ddm\TestStruct", user.Id);
            //fn.UpdateCurrentFolderStruct();
            //var st = fn.CurrentFolderStruct;

            //var folderStruct = FileTreeHelper.GetFolderTree(@"C:\Ddm\TestStruct");

            //var res = MergeTree.MergeFolders(folder, folderStruct);

            //var t = XmlSerializerHelper.Serialize(folder);

            //FileReaderHelper.WriteStreamInFile(t, @"D:\olo.xml");
        }
    }
}
