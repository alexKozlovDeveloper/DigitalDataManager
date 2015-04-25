using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ddm.Db.TableEntityes;

namespace Ddm.WpfApplication
{
    public static class ConfigController
    {
        public const string ConfigFilePath = "SystemConfig.xml";

        static ConfigController()
        {
            if (File.Exists(ConfigFilePath) == false)
            {
                CurrentUser = null;
            }


        }

        public static User CurrentUser { get; set; }
    }
}
