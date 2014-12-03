using UserFilesDbController.Entityes;
using User = DdmWebClient.DdmWcfServiceReference.User;

namespace DdmWebClient.Models
{
    public class HomeIndexModel // need rename
    {
        public User User { get; set; }

        public string ImagePath { get; set; }
    }
}