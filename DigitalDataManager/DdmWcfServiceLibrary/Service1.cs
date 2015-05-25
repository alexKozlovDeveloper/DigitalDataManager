using DbController.Repositoryes;
using DbController.TableEntityes;
using DdmHelpers.FileTree.Entity;
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
    }
}
