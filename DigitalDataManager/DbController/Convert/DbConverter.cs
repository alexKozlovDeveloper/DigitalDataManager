using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.Entityes;
using DbController.Tables.DigitalDate;
using DbController.Tables.Versions;

namespace DbController.Convert
{
    static class DbConverter
    {
        public static T Convert<T, TS>(TS item) where T : new()
        {
            if (item == null)
            {
                return new T();
            }

            var result = new T();

            var fields = item.GetType().GetProperties();

            foreach (var propertyInfo in fields)
            {
                var resProp = result.GetType().GetProperty(propertyInfo.Name);

                if (propertyInfo.PropertyType == resProp.PropertyType)
                {
                    var value = propertyInfo.GetValue(item);

                    result.GetType().GetProperty(propertyInfo.Name).SetValue(result, value);
                }
            }

            return result;
        }

        public static User GetUser(UserDbItem item)
        {
            var res = Convert<User, UserDbItem>(item);

            res.Albums = new List<Album>();

            foreach (var albumDbItem in item.Albums)
            {
                res.Albums.Add(GetAlbum(albumDbItem));
            }

            return res;
        }

        public static Album GetAlbum(AlbumDbItem item)
        {
            var res = Convert<Album, AlbumDbItem>(item);

            res.Images = new List<Image>();

            foreach (var albumDbItem in item.Images)
            {
                res.Images.Add(GetImage(albumDbItem));
            }

            return res;
        }

        public static Image GetImage(ImageDbItem item)
        {
            return Convert<Image, ImageDbItem>(item);
        }

        public static UserDateVersion GetVersion(UserDateVersionDbItem item)
        {
            return Convert<UserDateVersion, UserDateVersionDbItem>(item);
        }
    }
}
