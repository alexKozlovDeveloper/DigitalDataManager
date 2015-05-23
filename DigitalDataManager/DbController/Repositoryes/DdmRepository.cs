using DbController.Convert;
using DbController.TableEntityes;
using DbController.Tables.Context;
using DbController.Tables.DigitalDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Repositoryes
{
    class DdmRepository
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

        public ActivateCode CreateActivateCode(string login, string password, string email)
        {
            return new ActivateCode();
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

        public Folder AddFolder(Guid userId, string folderName, Guid ParrentFolder)
        {
            using (var db = new DdmDbContextV1())
            {
                var folder = new FolderT
                {
                    Id = Guid.NewGuid(),
                    CreateUserId = userId,
                    Name = folderName,
                    ParrentId = ParrentFolder
                };

                db.Folders.Add(folder);

                db.SaveChanges();

                return DbConverter.GetFolder(folder);
            }
        }
    }
}

