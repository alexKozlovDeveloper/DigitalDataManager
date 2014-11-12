using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.Repositoryes;
using DbController.Tables.Context;
using DbController.Tables.DigitalDate;

namespace DbController
{
    class Program
    {
        static void Main()
        {
            using (var db = new DdmDateBaseContext())
            {
                // Create and save a new Blog 
                //Console.Write("Enter a name for a new Blog: ");
                //var name = Console.ReadLine();

                //var user = new User { Login = "Alex", Password = "Alex" };
                //db.Users.Add(user);
                //db.SaveChanges();

                //// Display all Blogs from the database 
                //var query = from b in db.Users
                //            orderby b.Login
                //            select b;

                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Login + " id[" + item.Id + "]");
                //}

                var rep = new Repository("");

                //rep.CreateUser("Admin", "Admin");

                //rep.CreateUser("Alex2", "Alex2");

                

                //var users = rep.GetAllUser();

                //foreach (var user in users)
                //{
                //    rep.CreateAlbum("Nature", user.Id);
                    
                //    Console.WriteLine(string.Format(" User: name [{0}] id [{1}]",user.Login, user.Id));

                //    var albums = rep.GetAllAlbums(user.Id);
                //    if (albums != null)
                //    {
                //        foreach (var album in albums)
                //        {
                //            Console.WriteLine(string.Format("    - Album: name [{0}] id [{1}]", album.Name, album.Id));
                //        }
                //    }
                //}

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
