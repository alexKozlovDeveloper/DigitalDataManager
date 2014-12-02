using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DdmWebClient.DdmWcfServiceReference;
using DdmWebClient.Models;
using Album = DdmWebClient.Models.Album;

namespace DdmWebClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private readonly Guid _userId;

        public HomeController()
        {
            _userId = new Guid("c5a15e50-db46-4941-9312-c89bccaa10fe");
        }

        public ActionResult Index()
        {


            var client = new DdmServiceClient();

            var user = client.GetUser(_userId);

            var model = new TestModel();

            model.UserName = user.Name;

            model.Albums = new List<Album>();

            //var users = client.GetAllUsers();

            //var user = users[2];

            //var album = user.Albums[0];

            //var img = album.Files[1];

            //var model = new TestModel
            //{
            //    UserName = "alex",
            //    ImageSrc = "http://localhost:56338/Home/Image/?fileId=47c74322-eca8-405a-ad86-771888967337",
            //    Albums = new List<Album>
            //    {
            //        new Album
            //        {
            //            Name = "all",
            //            Images = new List<Image>
            //            {
            //                new Image
            //                {
            //                    Name = "test.jpg"
            //                }
            //            }
            //        }
            //    }
            //};


            return View(model);
        }

        public ActionResult Image(string fileId)
        {
            var id = new Guid(fileId);

            var client = new DdmServiceClient();

            var fs = client.GetFileStream(id);

            return File(fs, "image/gif");
        }

    }
}
