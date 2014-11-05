using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseController.Tables;
using DataBaseController.Tables.Context;

namespace DataBaseController
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DdmDbContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var user = new User { Login = "Alex", Password = "Alex" };
                db.Users.Add(user);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Users
                            orderby b.Login
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Login + " id["+item.Id+"]");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            } 
        }
    }
}
