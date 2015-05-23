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
        public static FolderEntity MergeFolders(FolderEntity folder1, FolderEntity folder2)
        {
            var newFolders = new List<FolderEntity>();

            foreach (var item in folder1.Folders)
            {
                if (folder2.Folders.Contains(item) == true)
                {
                    var fd = GetFolder(folder2.Folders, item.Name);

                    newFolders.Add(MergeFolders(item, fd));
                }
                else
                {
                    newFolders.Add(item);
                }
            }

            folder1.Folders.AddRange(newFolders);

            return folder1;
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
