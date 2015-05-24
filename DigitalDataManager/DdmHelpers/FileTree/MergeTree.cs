using DdmHelpers.FileTree.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdmHelpers.FileTree
{
    public static class MergeTree
    {
        public static FolderEntity MergeFolders(FolderEntity serverFolder, FolderEntity ClientFolder)
        {
            var newFolders = new List<FolderEntity>();
            var changeFolders = new List<FolderEntity>();

            foreach (var item in serverFolder.Folders)
            {
                if (ClientFolder.Folders.Contains(item) == true)
                {
                    var fd = GetFolder(ClientFolder.Folders, item.Name);

                    changeFolders.Add(MergeFolders(item, fd));
                }
                else
                {
                    newFolders.Add(item);
                }
            }

            foreach (var item in changeFolders)
            {
                ClientFolder.Folders.Remove(item);
            }

            ClientFolder.Folders.AddRange(newFolders);
            ClientFolder.Folders.AddRange(changeFolders);

            return ClientFolder;
        }

        private static FolderEntity GetFolder(List<FolderEntity> folders, string name)
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
    }
}
