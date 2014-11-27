using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserFilesDbController.Context;
using UserFilesDbController.Repositoryes;
using UserFilesDbController.Tables;

namespace UserFilesDbController
{
    class Program
    {
        private static void Main(string[] args)
        {
            var rep = new Repository();

            var users = rep.GetAllUsers();

            var albums = rep.GetAllAlbums();

            var files = rep.GetAllFiles();

            Console.WriteLine("hello DbController");
            Console.ReadKey();
        }
    }
}
