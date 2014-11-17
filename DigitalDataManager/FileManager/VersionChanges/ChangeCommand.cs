using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemManager.FileVersionHelper.FileVersionItems;

namespace FileSystemManager.VersionChanges
{
    public enum ChangeType
    {
        Remove,
        Create,
        Update
    }

    public class ChangeCommand
    {
        public ChangeType Type { get; set; }
        public FileVersion ActualVersion { get; set; }

        public ChangeCommand(ChangeType type, FileVersion actualVersion)
        {
            Type = type;
            ActualVersion = actualVersion;
        }
    }
}
