using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ServerFsManager.UserFilesManager;
using UserFilesDbController.Context;
using UserFilesDbController.Repositoryes;
using UserFilesDbController.Tables;
using DdmHelpers.FileReader;

namespace UserFilesDbController
{
    class Program
    {
        private static void Main()
        {
            const string root = @"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Server";

            var rep = new Repository(new UserFilesServerManager(root));

            //var fs = FileReaderHelper.ReadStreamFromFile(@"C:\Users\Aliaksei_Kazlou\Downloads\Sync.png");

            //var t = rep.CreateFile(fs, "Sync.png");



            var users = rep.GetAllUsers();

            var albums = rep.GetAllAlbums();

            //rep.AddFileToAlbum(albums[0].Id, t);

            //var albums = rep.GetAllAlbums();

            var files = rep.GetAllFiles();

            Console.WriteLine("hello DbController");
            Console.ReadKey();
        }
    }
}
