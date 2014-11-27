﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFilesDbController.Tables
{
    public class UserT
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public virtual List<AlbumT> Albums { get; set; }
    }
}
