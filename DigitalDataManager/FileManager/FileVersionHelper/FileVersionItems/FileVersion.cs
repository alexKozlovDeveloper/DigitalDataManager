﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemManager.FileVersionHelper.FileVersionItems
{
    public class FileVersion
    {
        public string Checksum { get; set; }
        public string FullPath { get; set; }
        public string FileName { get; set; }

        public FileVersion()
        {
            
        }
    }
}
