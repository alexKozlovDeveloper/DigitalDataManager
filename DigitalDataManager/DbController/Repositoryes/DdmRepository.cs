using DbController.Convert;
using DbController.TableEntityes;
using DbController.Tables.Context;
using DbController.Tables.DigitalDate;
using Ddm.Db.TableEntityes;
using DdmHelpers.FileTree.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Repositoryes
{
    public class DdmRepository
    {
        public User CreateUser(string login, string password, string email)
        {
            using (var db = new DdmDbContextV3())
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
            using (var db = new DdmDbContextV3())
            {
                var id = Guid.NewGuid();

                var code = new ActivateCodeT
                {
                    Id = id,
                    Date = DateTime.Now,
                    Code = id.ToString().Substring(9, 4),
                    UserId = userId
                };

                db.ActivateCodes.Add(code);

                db.SaveChanges();

                return DbConverter.GetActivateCode(code);
            }
        }

        public void ActivateUser(Guid userId)
        {
            using (var db = new DdmDbContextV3())
            {
                var user = GetUserT(userId, db);

                user.IsActivate = true;

                db.SaveChanges();
            }
        }

        private UserT GetUserT(Guid userId, DdmDbContextV3 db)
        {
            var user = (from item in db.Users
                        where item.Id == userId
                        select item).FirstOrDefault();

            return user;
        }

        private FolderT GetFolderT(Guid folderId, DdmDbContextV3 db)
        {
            var folder = (from item in db.Folders
                          where item.Id == folderId
                          select item).FirstOrDefault();

            return folder;
        }

        public Folder AddFolder(Guid userId, string folderName, Guid ParrentFolder)
        {
            using (var db = new DdmDbContextV3())
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

        public Tag AddTag(Guid userId, string name)
        {
            using (var db = new DdmDbContextV3())
            {
                var tag = new TagT
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    UserId = userId
                };

                db.Tags.Add(tag);

                db.SaveChanges();

                return DbConverter.GetTag(tag);
            }
        }

        public FolderEntity GetFolderStruct(Guid userId)
        {
            using (var db = new DdmDbContextV3())
            {
                var root = new FolderEntity
                {
                    Name = "root",
                    Path = "",
                    Parrent = null,
                    IsVirtual = true
                };

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
                        var fe = new FolderEntity
                        {
                            Name = item.Name,
                            Parrent = root,
                            IsVirtual = true
                        };

                        fe.Folders = GetChildFolder(item.Id, fe, db);

                        var files = GetFileFromFolder(item.Id);

                        foreach (var f in files)
                        {
                            fe.FilesPath.Add(f.Name);
                        }

                        root.Folders.Add(fe);
                    }
                }

                return root;
            }
        }

        private List<FolderEntity> GetChildFolder(Guid folderId, FolderEntity parrent, DdmDbContextV3 db)
        {
            var res = new List<FolderEntity>();

            foreach (var item in db.Folders)
            {
                if (item.ParrentId == folderId)
                {
                    var fe = new FolderEntity();

                    fe.Name = item.Name;
                    fe.Parrent = parrent;
                    fe.IsVirtual = true;
                    fe.Folders.AddRange(GetChildFolder(item.Id, fe, db));

                    var files = GetFileFromFolder(item.Id);

                    foreach (var f in files)
                    {
                        fe.FilesPath.Add(f.Name);
                    }

                    res.Add(fe);
                }
            }

            return res;
        }

        public User GetUser(string login)
        {
            using (var db = new DdmDbContextV3())
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

        public Folder GetFolder(Guid folderId)
        {
            using (var db = new DdmDbContextV3())
            {
                FolderT res = null;

                foreach (var item in db.Folders)
                {
                    if (item.Id == folderId)
                    {
                        res = item;
                        break;
                    }
                }

                return DbConverter.GetFolder(res);
            }
        }

        public List<DigitalFile> GetFileFromFolder(Guid folderId)
        { 
            var res = new List<DigitalFile>();

            using (var db = new DdmDbContextV3())
            {
                foreach (var item in db.FolderVsFiles)
                {
                    if (item.FolderId == folderId)
                    {
                        res.Add(GetFile(item.FileId));
                    }
                }
            }

            return res;
        }

        public DigitalFile GetFile(Guid fileId)
        {
            DigitalFileT res = null;

            using (var db = new DdmDbContextV3())
            {
                foreach (var item in db.Files)
                {
                    if (item.Id == fileId)
                    {
                        res = item;
                        break;
                    }
                }
            }

            return DbConverter.GetFile(res);
        }

        public FolderVsFile AddFileToFolder(Guid fileId, Guid folderId)
        {
            using (var db = new DdmDbContextV3())
            {
                var fvf = new FolderVsFileT
                {
                    Id = Guid.NewGuid(),
                    FileId = fileId,
                    FolderId = folderId
                };

                db.FolderVsFiles.Add(fvf);

                db.SaveChanges();

                return DbConverter.GetFolderVsFile(fvf);
            }
        }

        public Folder GetFolder(Guid UserId, string folderName)
        {
            using (var db = new DdmDbContextV3())
            {
                FolderT res = null;

                foreach (var item in db.Folders)
                {
                    if (item.CreateUserId == UserId && item.Name == folderName)
                    {
                        res = item;
                        break;
                    }
                }

                return DbConverter.GetFolder(res);
            }
        }

        public List<Tag> GetAllUserTags(Guid userId)
        {
            using (var db = new DdmDbContextV3())
            {
                var res = new List<Tag>();

                foreach (var item in db.Tags)
                {
                    if (item.UserId == userId)
                    {
                        res.Add(DbConverter.GetTag(item));
                    }
                }

                return res;
            }
        }

        public Dictionary<string, Guid> UpdateFolderStruct(Guid userId, FolderEntity userFolder)
        {
            var dbFolder = GetFolderStruct(userId);

            var notLoadFiles = new Dictionary<string, Guid>();

            UpdateFolderStructRecurs(userId, userFolder, dbFolder, notLoadFiles);

            return notLoadFiles;
        }

        private FolderEntity UpdateFolderStructRecurs(Guid userId, FolderEntity userFolder, FolderEntity dbFolder, Dictionary<string, Guid> notLoadFiles)
        {
            var newFolders = new List<FolderEntity>();
            var changeFolders = new List<FolderEntity>();

            foreach (var item in userFolder.Folders)
            {
                if (dbFolder.Folders.Contains(item) == true)
                {
                    var fd = GetFolder(dbFolder.Folders, item.Name);

                    changeFolders.Add(UpdateFolderStructRecurs(userId, item, fd, notLoadFiles));
                }
                else
                {
                    newFolders.Add(item);
                }
            }

            foreach (var item in changeFolders)
            {
                dbFolder.Folders.Remove(item);
            }

            dbFolder.Folders.AddRange(newFolders);
            dbFolder.Folders.AddRange(changeFolders);

            foreach (var item in newFolders)
            {
                Guid par = Guid.Empty;

                if (dbFolder.Name != "root")
                {
                    par = GetFolder(userId, dbFolder.Name).Id;
                }

                var newfolder = AddFolder(userId, item.Name, par);

                foreach (var f in item.FilesPath)
                {
                    notLoadFiles.Add(f, newfolder.Id);
                }
            }

            var fg = GetFolder(userId, dbFolder.Name);

            if (fg != null)
            {
                foreach (var item in userFolder.FilesPath)
                {
                    var path = Path.GetFileName(item);

                    if (dbFolder.FilesPath.Contains(path) == false)
                    {
                        notLoadFiles.Add(item, fg.Id);
                    }
                }
            }

            return dbFolder;
        }

        private FolderEntity GetFolder(List<FolderEntity> folders, string name)
        {
            FolderEntity res = null;

            foreach (var item in folders)
            {
                if (item.Name == name)
                {
                    res = item;
                    break;
                }
            }

            return res;
        }

        public DigitalFile AddFile(byte[] bytes, string name, string checkSum)
        {
            using (var db = new DdmDbContextV3())
            {
                var file = new DigitalFileT
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    CheckSum = checkSum
                };

                db.Files.Add(file);

                db.SaveChanges();

                ServerFM.WriteFile(bytes, file.Id, Path.GetExtension(name));

                return DbConverter.GetFile(file);
            }
        }

        public Stream GetFileStream(Guid fileId)
        {
            var file = GetFile(fileId);

            var res = ServerFM.ReadFile(fileId, Path.GetExtension(file.Name));

            return res;
        }
    }
}

