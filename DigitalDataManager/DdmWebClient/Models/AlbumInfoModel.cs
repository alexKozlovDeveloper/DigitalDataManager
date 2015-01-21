using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DdmWebClient.DdmWcfServiceReference;
using UserFilesDbController.Entityes;

namespace DdmWebClient.Models
{
    public class AlbumInfoModel
    {
        public Album Album { get; set; }

        public string GetImagePath(Guid id)
        {
            return "http://localhost:56338/Home/Image/?fileId=" + id;
        }
    }
}