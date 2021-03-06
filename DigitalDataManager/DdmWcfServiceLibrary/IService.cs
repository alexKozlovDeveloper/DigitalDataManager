﻿using DbController.TableEntityes;
using Ddm.Db.TableEntityes;
using DdmHelpers.FileTree.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DdmWcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        FolderEntity GetUserFolders(Guid userId);

        [OperationContract]
        List<Tag> GetAllUserTags(Guid userId);

        [OperationContract]
        Tag AddTag(Guid userId, string name);

        [OperationContract]
        DigitalFile CreateFile(byte[] bytes, string name, string CheckSum);

        [OperationContract]
        FolderVsFile AddFileToFolder(Guid fileId, Guid folderId);

        [OperationContract]
        Dictionary<string, Guid> UpdateFolderStruct(Guid userId, FolderEntity userFolder);

        [OperationContract]
        User GetUser(string login);
    }
}
