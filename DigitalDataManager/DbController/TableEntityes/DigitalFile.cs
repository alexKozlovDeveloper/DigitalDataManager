﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddm.Db.TableEntityes
{
    public class DigitalFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CheckSum { get; set; }
    }
}
