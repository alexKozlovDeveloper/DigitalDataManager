﻿using System;
using UserFilesDbController.Entityes;
using User = DdmWebClient.DdmWcfServiceReference.User;

namespace DdmWebClient.Models
{
    public class HomeIndexModel // need rename
    {
        public User User { get; set; }

        public string GetImagePath(Guid id)
        {
            return "http://localhost:56338/Home/Image/?fileId=" + id;
        }
    }
}