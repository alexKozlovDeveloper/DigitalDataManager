using System;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices.CompensatingResourceManager;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DdmWebClient.DdmWcfServiceReference;
using DdmWebClient.Models.MainControllerModels;

namespace DdmWebClient.Controllers
{
    public class MainController : Controller
    {
        private readonly Guid _userId;

        public MainController()
        {
            _userId = new Guid("c5a15e50-db46-4941-9312-c89bccaa10fe");
        }

        public ActionResult Index()
        {
            var client = new DdmServiceClient();

            var user = client.GetUser(_userId);

            var model = new UserInfoModel
            {
                UserInfo = user
            };

            return View(model);
        }

        public ActionResult AddNewFile(string albumId)
        {
            var id = new Guid(albumId);

            var client = new DdmServiceClient();

            var album = client.GetAlbum(id);

            var allFiles = client.GetAllFiles();

            var files = new List<DigitalFile>();

            foreach (var digitalFile in allFiles)
            {
                var flg = false;

                foreach (var file in album.Files)
                {
                    if (digitalFile.Id == file.Id)
                    {
                        flg = true;
                    }
                }

                if (flg == false)
                {
                    files.Add(digitalFile);
                }
            }

            var model = new AllFileInfoModel
            {
                AlbumInfo = album,
                Files = files
            };

            return View(model);
        }
        
        public ActionResult AddFileToAlbum(string ids)//string albumId, string fileId
        {
            var strs = ids.Split(':');

            var albumId = strs[0];
            var fileId = strs[1];

            var client = new DdmServiceClient();

            client.AddFileToAlbum(new Guid(albumId), new Guid(fileId));

            return Redirect("/Main/AddNewFile/?albumId=" + albumId);
        }

        public ActionResult AddNewFriend(string userId)
        {
            var id = new Guid(userId);

            var client = new DdmServiceClient();

            var user = client.GetUser(id);

            var allUsers = client.GetAllUsers();

            var users = new List<User>();

            foreach (var item in allUsers)
            {
                var flg = false;

                foreach (var friend in user.FriendsId)
                {
                    if (item.Id == friend)
                    {
                        flg = true;
                    }
                }

                if (id == item.Id)
                {
                    flg = true;
                }

                if (flg == false)
                {
                    users.Add(item);
                }
            }

            var model = new AllUserInfoModel
            {
                UserInfo = user,
                Users = users
            };

            return View(model);
        }

        public ActionResult AddUserInFriend(string ids)
        {
            var strs = ids.Split(':');

            var userId = strs[0];
            var friendId = strs[1];

            var client = new DdmServiceClient();

            client.AddFriendLink(new Guid(userId), new Guid(friendId));

            return Redirect("/Main/AddNewFriend/?userId=" + userId);
        }

        public Stream DownloadFile(string fileId) // dont work
        {
            var client = new DdmServiceClient();

            return client.GetFileStream(new Guid(fileId));
        }

        public ActionResult LoadToServer(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            foreach (var file in fileUpload)
            {
                if (file == null) continue;
                string path = @"D:\";//AppDomain.CurrentDomain.BaseDirectory + "UploadedFiles/";
                string filename = Path.GetFileName(file.FileName);
                if (filename != null) file.SaveAs(Path.Combine(path, filename));
            }

            return RedirectToAction("Index");
        }

        public FileStreamResult GetFile()
        {
            return File(System.IO.File.OpenRead(@"D:\Sync.png"), "image/png", "someFile");
        }
    }
}
