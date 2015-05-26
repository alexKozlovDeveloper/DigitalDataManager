using DbController.Repositoryes;
using DbController.TableEntityes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdmFileManager.Clent
{
    public class CacheFM
    {
        private string _root;
        private DdmFileManager.ServiceReference1.ServiceClient service;
        private User _user;

        private List<string> cacheFiles;

        public CacheFM(string root, User user, DdmFileManager.ServiceReference1.ServiceClient wcfService)
        {
            _root = root;
            _user = user;
            service = wcfService;

            cacheFiles = new List<string>();

            var f = Directory.GetFiles(_root);

            foreach (var item in f)
            {
                cacheFiles.Add(Path.GetFileName(item));
            }
        }

        public List<string> GetFilePathFromFolder(string folderName)
        {
            var res = new List<string>();

            var rep = new DdmRepository();

            var folder = rep.GetFolder(_user.Id, folderName);

            var files = rep.GetFileFromFolder(folder.Id);

            foreach (var item in files)
            {
                if (cacheFiles.Contains(item.Id + item.Name))
                {
                    res.Add(_root + "\\" + item.Id + item.Name);
                }
                else
                {
                    var path = _root + "\\" + item.Id + item.Name;

                    var bytes = rep.GetFileBytes(item.Id);

                    File.WriteAllBytes(path, bytes);

                    res.Add(path);

                    cacheFiles.Add(item.Id + item.Name);
                }
            }

            return res;
        }
    }
}
