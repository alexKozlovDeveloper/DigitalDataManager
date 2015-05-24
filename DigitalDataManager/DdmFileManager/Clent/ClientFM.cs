using DdmHelpers.FileTree;
using DdmHelpers.FileTree.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdmFileManager.Clent
{
    public class ClientFM
    {
        private string _rootPath;
        private Guid _userId;

        public FolderEntity CurrentFolderStruct { get; private set; }

        public ClientFM(string rootFolder, Guid userId)
        {
            _rootPath = rootFolder;
            _userId = userId;
        }

        public FolderEntity UpdateCurrentFolderStruct()
        {
            var folderStruct = FileTreeHelper.GetFolderTree(_rootPath);

            var service = new ServiceReference1.ServiceClient();

            var clientStruct = service.GetUserFolders(_userId);

            FileTreeHelper.SetAllFolderPath(clientStruct);

            CurrentFolderStruct = MergeTree.MergeFolders(clientStruct, folderStruct);

            return CurrentFolderStruct;
        }
    }
}
