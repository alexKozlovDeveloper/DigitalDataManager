﻿using Ddm.Db.TableEntityes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
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