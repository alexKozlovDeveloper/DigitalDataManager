﻿using DbController.Repositoryes;
using DbController.TableEntityes;
using Ddm.Db.TableEntityes;
using DdmHelpers.FileTree.Entity;
using DdmHelpers.Serialize;
using DdmWcfServiceLibrary.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DdmWcfServiceLibrary
{
    public class Service1 : IService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public FolderEntity GetUserFolders(Guid userId)
        {
            var rep = new DdmRepository();

            return rep.GetFolderStruct(userId);
        }

        public List<Tag> GetAllUserTags(Guid userId)
        {
            var rep = new DdmRepository();

            return rep.GetAllUserTags(userId);
        }

        public Tag AddTag(Guid userId, string name)
        {
            var rep = new DdmRepository();

            return rep.AddTag(userId, name);
        }

        public DigitalFile CreateFile(byte[] bytes, string name, string CheckSum)
        {
            var rep = new DdmRepository();

            var file = rep.AddFile(bytes, name, CheckSum);

            return file;
        }

        public FolderVsFile AddFileToFolder(Guid fileId, Guid folderId)
        {
            var rep = new DdmRepository();

            return rep.AddFileToFolder(fileId, folderId);
        }

        public Dictionary<string, Guid> UpdateFolderStruct(Guid userId, FolderEntity userFolder)
        {
            var rep = new DdmRepository();

            return rep.UpdateFolderStruct(userId, userFolder);
        }

        public User GetUser(string login)
        {
            var rep = new DdmRepository();

            return rep.GetUser(login);
        }
    }
}
