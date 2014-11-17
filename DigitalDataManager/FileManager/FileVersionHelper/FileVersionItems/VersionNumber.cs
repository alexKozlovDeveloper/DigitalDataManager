using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemManager.FileVersionHelper.FileVersionItems
{
    public class VersionNumber
    {
        public int Number { get; set; }

        public VersionNumber()
        {

        }

        public override bool Equals(object obj)
        {
            return this.Number == ((VersionNumber) obj).Number;
        }
    }
}
