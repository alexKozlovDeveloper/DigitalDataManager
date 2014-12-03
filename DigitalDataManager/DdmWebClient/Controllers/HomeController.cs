using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DdmWebClient.DdmWcfServiceReference;
using DdmWebClient.Models;
using UserFilesDbController.Entityes;

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

            var model = new HomeIndexModel
            {
                User = user
            };

            return View(model);
        }

        public ActionResult Image(string fileId)
        {
            var id = new Guid(fileId);

            var client = new DdmServiceClient();

            var fs = client.GetFileStream(id);

            return File(fs, "image/gif");
        }

        public ActionResult GetAlbumImages(Guid albumId)
        {
            var client = new DdmServiceClient();

            var album = client.GetAlbum(albumId);

            var model = new AlbumInfoModel
            {
                Album = album
            };

            return View(model);
        }
    }
}
