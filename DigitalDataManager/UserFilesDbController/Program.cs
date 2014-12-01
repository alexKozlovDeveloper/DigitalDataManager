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

namespace UserFilesDbController
{
    class Program
    {
        private static void Main(string[] args)
        {
            const string root = @"C:\Users\Aliaksei_Kazlou\Documents\DigitalDataManager\TestDBFolder\Server";

            var rep = new Repository(new UserFilesServerManager(root));

            var users = rep.GetAllUsers();

            var albums = rep.GetAllAlbums();

            var files = rep.GetAllFiles();

            Console.WriteLine("hello DbController");
            Console.ReadKey();
        }
    }
}
