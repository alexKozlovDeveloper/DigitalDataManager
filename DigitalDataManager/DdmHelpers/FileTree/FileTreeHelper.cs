using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DdmHelpers.FileTree.Entity;

namespace DdmHelpers.FileTree
{
    public static class FileTreeHelper
    {
        public static FolderEntity GetFolderTree(string folderPath, FolderEntity parrent = null)
        {
            var folder = new FolderEntity
            {
                FilesPath = Directory.GetFiles(folderPath).ToList(),
                Path = folderPath,
                Name = GetFolderName(folderPath),
                IsVirtual = false
            };

            if (parrent != null)
            {
                folder.Parrent = parrent;
            }

            var folders = Directory.GetDirectories(folderPath);

            foreach (var s in folders)
            {
                folder.Folders.Add(GetFolderTree(s, folder));
            }

            return folder;
        }

        public static string GetFolderName(string folderPath)
        {
            return folderPath.Substring(folderPath.LastIndexOf('\\') + 1);
        }

        public static void PrintFolderTreeToConsole(FolderEntity folder, string tab = "")
        {
            Console.WriteLine(tab + "Folder: " + folder.Name);

            foreach (var obj in folder.FilesPath)
            {
                Console.WriteLine(tab + "File: " + Path.GetFileName(obj));
            }

            foreach (var folderEntity in folder.Folders)
            {
                PrintFolderTreeToConsole(folderEntity, tab + "    ");
            }
        }

        public static IEnumerable<string> GetAllFileInFolderAndSubfolders(string folderPath)
        {
            var result = new List<string>();

            if (Directory.Exists(folderPath) == false)
            {
                return result;
            }

            result.AddRange(Directory.GetFiles(folderPath));

            var folders = Directory.GetDirectories(folderPath);

            foreach (var folder in folders)
            {
                result.AddRange(GetAllFileInFolderAndSubfolders(folder));
            }

            return result;
        }

        public static FolderEntity SetAllFolderPath(FolderEntity folder, string root = "")
        {
            folder.Path = root + "\\" + folder.Name;

            foreach (var item in folder.Folders)
            {
                SetAllFolderPath(item, folder.Path);
            }

            return folder;
        }
    }
}
