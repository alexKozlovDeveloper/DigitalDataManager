using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFilesDbController.Entityes;
using UserFilesDbController.Tables;

namespace UserFilesDbController.Convert
{
    public static class DbConverter
    {
        public static T Convert<T, TS>(TS item) where T : new()
        {
            var result = new T();

            var fields = item.GetType().GetProperties();

            foreach (var propertyInfo in fields)
            {
                var resProp = result.GetType().GetProperty(propertyInfo.Name);

                if (resProp != null)
                {
                    if (propertyInfo.PropertyType == resProp.PropertyType)
                    {
                        var value = propertyInfo.GetValue(item);

                        result.GetType().GetProperty(propertyInfo.Name).SetValue(result, value);
                    }
                }
            }

            return result;
        }

        public static User GetUser(UserT item)
        {
            var res = Convert<User, UserT>(item);

            res.Albums = new List<Album>();

            foreach (var albumDbItem in item.Albums)
            {
                res.Albums.Add(GetAlbum(albumDbItem));
            }

            return res;
        }

        public static Album GetAlbum(AlbumT item)
        {
            var res = Convert<Album, AlbumT>(item);

            res.Files = new List<DigitalFile>();

            foreach (var albumDbItem in item.Files)
            {
                res.Files.Add(GetFile(albumDbItem));
            }

            return res;
        }

        public static DigitalFile GetFile(FileT item)
        {
            return Convert<DigitalFile, FileT>(item);
        }
    }
}
