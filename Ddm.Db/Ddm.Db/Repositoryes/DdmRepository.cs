using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ddm.Db.Convert;
using Ddm.Db.TableEntityes;
using Ddm.Db.Tables;
using Ddm.Db.Tables.Context;

namespace Ddm.Db.Repositoryes
{
    public class DdmRepository
    {
        public User CreateUser(string login, string password, string email)
        {
            using (var db = new DdmDbContextV1())
            {
                var user = new UserT
                {
                    Id = Guid.NewGuid(),
                    Login = login,
                    Password = password,
                    Email = email,
                    IsActivate = false
                };

                db.Users.Add(user);

                db.SaveChanges();

                return DbConverter.GetUser(user);
            }
        }

        public ActivateCode CreateActivateCode(Guid userId)
        {
            using (var db = new DdmDbContextV1())
            {
                var id = Guid.NewGuid();

                var code = new ActivateCodeT
                {
                    Id = id,
                    Date = DateTime.Now,
                    Code = id.ToString().Substring(9,4),
                    UserId = userId
                };

                db.ActivateCodes.Add(code);

                db.SaveChanges(); 

                return DbConverter.GetActivateCode(code);
            }
        }

        public void ActivateUser(Guid userId)
        {
            using (var db = new DdmDbContextV1())
            {
                var user = GetUserT(userId, db);

                user.IsActivate = true;

                db.SaveChanges();
            }
        }

        private UserT GetUserT(Guid userId, DdmDbContextV1 db)
        {
            var user = (from item in db.Users
                        where item.Id == userId
                        select item).FirstOrDefault();

            return user;
        }
    }
}
