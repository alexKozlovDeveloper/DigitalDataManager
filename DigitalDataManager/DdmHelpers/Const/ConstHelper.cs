using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdmHelpers.Const
{
    public static class ConstHelper
    {
        public static int PartSize { get; set; }

        static ConstHelper()
        {
            PartSize = 1000;
        }
    }
}
