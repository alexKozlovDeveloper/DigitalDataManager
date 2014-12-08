using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DdmWebClient.DdmWcfServiceReference;

namespace DdmWebClient.Models.MainControllerModels
{
    public class AllUserInfoModel
    {
        public User UserInfo { get; set; }
        public List<User> Users { get; set; }
    }
}