using DbController.Repositoryes;
using System;
using System.Collections.Generic;
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

        public DdmHelpers.FileTree.Entity.FolderEntity GetUserFolders(Guid userId)
        {
            var rep = new DdmRepository();

            return rep.GetFolderStruct(userId);
        }
    }
}
