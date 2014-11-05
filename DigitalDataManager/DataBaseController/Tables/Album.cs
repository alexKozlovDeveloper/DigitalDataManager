﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseController.Tables
{
    class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Image> Images { get; set; }
    }
}
