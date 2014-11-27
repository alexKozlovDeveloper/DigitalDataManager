using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserFilesDbController.Context;
using UserFilesDbController.Tables;

namespace UserFilesDbController
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new DdmDataBase())
            {
                //var user1 = new UserT
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "admin",
                //    Password = "admin"
                //};

                //var user2 = new UserT
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "alex",
                //    Password = "alex"
                //};

                //var user3 = new UserT
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "andrew",
                //    Password = "andrew"
                //};

                //var user4 = new UserT
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "artem",
                //    Password = "artem"
                //};

                //db.Users.Add(user1);
                //db.Users.Add(user2);
                //db.Users.Add(user3);
                //db.Users.Add(user4);
                //db.SaveChanges();

                //var users = from item in db.Users
                //            select item;

                //foreach (var userT in users)
                //{
                //    var albumAll = new AlbumT
                //    {
                //        Id = Guid.NewGuid(),
                //        Name = "All"
                //    };

                //    var albumNew = new AlbumT
                //    {
                //        Id = Guid.NewGuid(),
                //        Name = "New"
                //    };

                //    userT.Albums.Add(albumAll);
                //    userT.Albums.Add(albumNew);
                //}

                //db.SaveChanges();

                //var albums = from item in db.Albums
                //            select item;

                //foreach (var obj in albums)
                //{
                //    Console.WriteLine(" albun[{0}]", obj.Name);

                //    foreach (var userT in obj.Users)
                //    {
                //        Console.WriteLine("\t user[{0}]", userT.Name);
                //    }
                //}

                //var alex = (from item in db.Users
                //           where item.Name == "alex"
                //            select item).FirstOrDefault();

                //var admin = (from item in db.Users
                //           where item.Name == "admin"
                //            select item).FirstOrDefault();

                //var link1 = new FriendsLinkT
                //{
                //    Id = Guid.NewGuid(),
                //    UserId = alex.Id,
                //    FriendUserId = admin.Id
                //};

                //db.FriendLinks.Add(link1);

                //var link2 = new FriendsLinkT
                //{
                //    Id = Guid.NewGuid(),
                //    UserId = admin.Id,
                //    FriendUserId = alex.Id
                //};

                //db.FriendLinks.Add(link2);

                //db.SaveChanges();

                //foreach (var userT in users)
                //{
                //    foreach (var albumT in userT.Albums)
                //    {
                //        var img = new FileT
                //        {
                //            Id = Guid.NewGuid(),
                //            Name = "test.jpg"
                //        };

                //        albumT.Files.Add(img);
                //    }
                //}

                //db.SaveChanges();

                //var user = (from item in db.Users
                //            where item.Login == "alex"
                //            select item).FirstOrDefault();

                //user.Albums.Add(albumAll);
                //user.Albums.Add(albumNew);
                //db.SaveChanges();

                //var alex = (from item in db.Users
                //            where item.Login == "alex"
                //            select item).FirstOrDefault();

                //var artem = (from item in db.Users
                //             where item.Login == "artem"
                //             select item).FirstOrDefault();

                //alex.Friend.Add(artem);
                //artem.Friend.Add(alex);

                //db.SaveChanges();

                //var albums = from item in db.Albums
                //    where item.Name == "All"
                //    select item;

                //foreach (var album in albums)
                //{
                //    var img = new FileTable
                //    {
                //        Id = Guid.NewGuid(),
                //        Name = "TestImg.jpg"
                //    };

                //    album.Images.Add(img);
                //}

                //db.SaveChanges();
            }

            using (var db = new DdmDataBase())
            {
                var users = from item in db.Users
                            select item;

                Console.WriteLine(" Users: ");

                var tab = "\t";

                foreach (var user in users)
                {
                    Console.WriteLine(String.Format(" {0}", user.Name));

                    Console.WriteLine(tab + " Albums: ");

                    foreach (var album in user.Albums)
                    {
                        Console.WriteLine(tab + string.Format(" {0}", album.Name));

                        Console.WriteLine(tab + tab + " Images: ");

                        foreach (var fileTable in album.Files)
                        {
                            Console.WriteLine(tab + tab + tab + string.Format(" {0}", fileTable.Name));
                        }
                    }

                    Console.WriteLine(tab + " friends: ");

                    var links = from item in db.FriendLinks
                               where item.UserId == user.Id
                                select item;

                    foreach (var friendsLinkT in links)
                    {
                         var friend = (from item in db.Users
                               where item.Id == friendsLinkT.FriendUserId
                                select item).FirstOrDefault();

                         Console.WriteLine(tab + tab + " {0}", friend.Name);
                    }

                    //foreach (var friend in user.FriendsId)
                    //{
                    //    Console.WriteLine(tab + tab + " {0}", friend.User.Name);
                    //}
                }
            }

            //Console.WriteLine("hello DbController");
            Console.ReadKey();
        }
    }
}
