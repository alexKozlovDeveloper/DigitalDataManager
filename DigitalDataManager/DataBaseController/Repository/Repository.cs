using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseController.Tables;
using DataBaseController.Tables.Context;
using FileSystemManager;

namespace DataBaseController.Repository
{
    public class Repository
    {
        private readonly ServerFileManager _manager;

        public Repository(string rootpath)
        {
            _manager = new ServerFileManager(rootpath);
        }

        public void AddImage(int albumId, MemoryStream imagStream, string imageName)
        {
            using (var db = new DdmDbContext())
            {
                var image = new Image { Name = imageName, Path = imageName };

                db.Images.Add(image);

                db.SaveChanges();

                _manager.CreateFile(imagStream, image.Path);
            }
        }
    }
}
