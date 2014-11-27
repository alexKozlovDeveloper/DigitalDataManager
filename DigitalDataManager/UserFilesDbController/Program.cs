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

            //var users = rep.GetAllUsers();

            //var albums = rep.GetAllAlbums();

            //var files = rep.GetAllFiles();


            //using (var db = new DdmDataBase())
            //{
            //    var users = from item in db.Users
            //                select item;

            //    Console.WriteLine(" Users: ");

            //    var tab = "\t";

            //    foreach (var user in users)
            //    {
            //        Console.WriteLine(String.Format(" {0}", user.Name));

            //        Console.WriteLine(tab + " Albums: ");

            //        foreach (var album in user.Albums)
            //        {
            //            Console.WriteLine(tab + string.Format(" {0}", album.Name));

            //            Console.WriteLine(tab + tab + " Images: ");

            //            foreach (var fileTable in album.Files)
            //            {
            //                Console.WriteLine(tab + tab + tab + string.Format(" {0}", fileTable.Name));
            //            }
            //        }

            //        Console.WriteLine(tab + " friends: ");

            //        var links = from item in db.FriendLinks
            //                   where item.UserId == user.Id
            //                    select item;

            //        foreach (var friendsLinkT in links)
            //        {
            //             var friend = (from item in db.Users
            //                   where item.Id == friendsLinkT.FriendUserId
            //                    select item).FirstOrDefault();

            //             Console.WriteLine(tab + tab + " {0}", friend.Name);
            //        }

            //        //foreach (var friend in user.FriendsId)
            //        //{
            //        //    Console.WriteLine(tab + tab + " {0}", friend.User.Name);
            //        //}
            //    }
            //}

            //Console.WriteLine("hello DbController");
            Console.ReadKey();
        }
    }
}
