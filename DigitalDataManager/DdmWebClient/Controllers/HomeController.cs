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

        public ActionResult Index()
        {
            var client = new DdmServiceClient();

            var users = client.GetAllUsers();

            var user = users[2];

            var album = user.Albums[0];

            var img = album.Files[1];

            var model = new TestModel
            {
                UserName = "alex",
                ImageSrc = "http://localhost:56338/Home/Image/dsafasdfsd",
                Albums = new List<Album>
                {
                    new Album
                    {
                        Name = "all",
                        Images = new List<Image>
                        {
                            new Image
                            {
                                Name = "test.jpg"
                            }
                        }
                    }
                }
            };


            return View(model);
        }

        public ActionResult Image(string fileId)
        {
            var id = new Guid("47c74322-eca8-405a-ad86-771888967337");

            var client = new DdmServiceClient();

            var fs = client.GetFileStream(id);

            return File(fs, "image/gif");
        }

    }
}
