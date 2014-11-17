using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemManager.FileVersionHelper.FileVersionItems;

namespace FileSystemManager.VersionChanges
{
    public static class VersionComparator
    {
        public static List<ChangeCommand> Compare(CatalogVersion oldVers, CatalogVersion newVers)
        {
            var result = new List<ChangeCommand>();

            if (oldVers.Equals(newVers))
            {
                return result;
            }

            foreach (var fileVersion in oldVers.Files)
            {
                if (newVers.Files.Contains(fileVersion) == false)
                {
                    result.Add(new ChangeCommand(ChangeType.Remove, fileVersion));
                }
                else
                {
                    foreach (var version in newVers.Files)
                    {
                        if (fileVersion.Equals(version) == true)
                        {
                            if (version.Checksum != fileVersion.Checksum)
                            {
                                result.Add(new ChangeCommand(ChangeType.Update, version));
                            }
                        }
                    }
                }
            }

            foreach (var fileVersion in newVers.Files)
            {
                if (oldVers.Files.Contains(fileVersion) == false)
                {
                    result.Add(new ChangeCommand(ChangeType.Create, fileVersion));
                }
            }

            return result;
        }
    }
}
