using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DdmWebClient.DdmWcfServiceReference;

namespace DdmWebClient.Models.MainControllerModels
{
    public class UserInfoModel
    {
        public User UserInfo { get; set; }

        public string GetImagePath(Guid id)
        {
            return "http://localhost:56338/Home/Image/?fileId=" + id;
        }
    }
}