using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ddm.Db.Tables;
using Ddm.Db.Tables.Context;

namespace Ddm.Db.Repositoryes
{
    class DdmRepository
    {
        public Guid CreateUser(string login, string password, string email)
        {
            var id = Guid.NewGuid();

            using (var db = new DdmDbContextV1())
            {
                var user = new UserT
                {
                    Id = id,
                    Login = login,
                    Password = password,
                    Email = email
                };

                db.Users.Add(user);

                db.SaveChanges();
            }

            return id;
        }
    }
}
