﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFilesDbController.Tables
{
    public class FriendsLinkT
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid FriendUserId { get; set; }
    }
}
