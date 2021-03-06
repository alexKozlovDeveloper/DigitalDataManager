﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddm.Helpers.FileTree
{
    public static class FileTreeHelper
    {
        public static FolderEntity GetFolderTree(string folderPath)
        {
            var folder = new FolderEntity
            {
                FilesPath = Directory.GetFiles(folderPath).ToList(),
                Path = folderPath,
                Name = GetFolderName(folderPath)
            };

            var folders = Directory.GetDirectories(folderPath);

            foreach (var s in folders)
            {
                folder.Folders.Add(GetFolderTree(s));
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

            result.AddRange(Directory.GetFiles(folderPath));

            var folders = Directory.GetDirectories(folderPath);

            foreach (var folder in folders)
            {
                result.AddRange(GetAllFileInFolderAndSubfolders(folder));
            }

            return result;
        }
    }
}
