using DbController.Convert;
using DbController.TableEntityes;
using DbController.Tables.Context;
using DbController.Tables.DigitalDate;
using DdmHelpers.FileTree.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Repositoryes
{
    public class DdmRepository
    {
        public User CreateUser(string login, string password, string email)
        {
            using (var db = new DdmDbContextV2())
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
            using (var db = new DdmDbContextV2())
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
            using (var db = new DdmDbContextV2())
            {
                var user = GetUserT(userId, db);

                user.IsActivate = true;

                db.SaveChanges();
            }
        }
        
        private UserT GetUserT(Guid userId, DdmDbContextV2 db)
        {
            var user = (from item in db.Users
                        where item.Id == userId
                        select item).FirstOrDefault();

            return user;
        }

        private FolderT GetFolderT(Guid folderId, DdmDbContextV2 db)
        {
            var folder = (from item in db.Folders
                        where item.Id == folderId
                        select item).FirstOrDefault();

            return folder;
        }

        public Folder AddFolder(Guid userId, string folderName, Guid ParrentFolder)
        {
            using (var db = new DdmDbContextV2())
            {
                var folder = new FolderT
                {
                    Id = Guid.NewGuid(),
                    CreateUserId = userId,
                    Name = folderName,
                    ParrentId = ParrentFolder
                };

                var folderToUser = new FolderVsUserT
                {
                    Id = Guid.NewGuid(),
                    FolderId = folder.Id,
                    UserId = userId
                };

                db.Folders.Add(folder);
                db.FolderVsUsers.Add(folderToUser);

                db.SaveChanges();

                return DbConverter.GetFolder(folder);
            }
        }

        public FolderEntity GetFolderStruct(Guid userId)
        {
            using (var db = new DdmDbContextV2())
            {
                var root = new FolderEntity();

                var allfolder = new List<Folder>();

                foreach (var item in db.FolderVsUsers)
                {
                    if (item.UserId == userId)
                    {
                        allfolder.Add(DbConverter.GetFolder(GetFolderT(item.FolderId, db)));
                    }
                }

                foreach (var item in allfolder)
                {
                    if (item.ParrentId == Guid.Empty)
                    {
                        root.Folders.Add(new FolderEntity 
                        { 
                            Name = item.Name,
                            Folders = GetChildFolder(item.Id, db)
                        });
                    }
                }

                return root;
            }
        }

        private List<FolderEntity> GetChildFolder(Guid folderId, DdmDbContextV2 db)
        {
            var res = new List<FolderEntity>();

            foreach (var item in db.Folders)
            {
                if (item.ParrentId == folderId)
                {
                    var fe = new FolderEntity();

                    fe.Name = item.Name;
                    fe.Folders.AddRange(GetChildFolder(item.Id, db));

                    res.Add(fe);
                }
            }

            return res;
        }

        public User GetUser(string login)
        {
            using (var db = new DdmDbContextV2())
            {
                UserT res = null;

                foreach (var item in db.Users)
                {
                    if (item.Login == login)
                    {
                        res = item;
                        break;
                    }
                }

                return DbConverter.GetUser(res);
            }
        }
    }
}

