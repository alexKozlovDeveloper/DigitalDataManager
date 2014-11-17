using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using DbController.Convert;
using DbController.Entityes;
using DbController.Repositoryes;
using DbController.Tables.Context;
using DbController.Tables.DigitalDate;

namespace DbController
{
    class Program
    {
        static void Main()
        {
            //var user = new UserDbItem
            //{
            //    Albums = new List<AlbumDbItem>(),
            //    Id = Guid.NewGuid(),
            //    Login = "lll",
            //    Password = "+++"
            //};

            //var album = new AlbumDbItem
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "gf",
            //    UserId = user.Id,
            //    Images = new List<ImageDbItem>()
            //};

            //var img = new ImageDbItem
            //{
            //    Id = Guid.NewGuid(), Name = "lol", Path = "jjj"
            //};

            //album.Images.Add(img);
            //user.Albums.Add(album);

            //var t = DbConverter.GetUser(user);

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

                //var albumsd = rep.GetAllAlbums();

                //foreach (var album in albumsd)
                //{
                //    Console.WriteLine(string.Format("    - Album: name [{0}] id [{1}]", album.Name, album.Id));
                //}

                //var users = rep.GetAllUser();

                //foreach (var user in users)
                //{
                //    rep.CreateAlbum("All", user.Id);
                //}

                var users = rep.GetAllUser();

                foreach (var user in users)
                {
                    Console.WriteLine(string.Format(" User: name [{0}] id [{1}]", user.Login, user.Id));

                    var albums = user.Albums; //rep.GetAllAlbums();//rep.GetAllAlbums(user.Id);//user.Albums;

                    foreach (var album in albums)
                    {
                        Console.WriteLine(string.Format("    - Album: name [{0}] id [{1}]", album.Name, album.Id));

                        foreach (var image in album.Images)
                        {
                            Console.WriteLine(string.Format("        - Image: name [{0}] id [{1}]", image.Name, image.Id));
                        }
                    }
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
