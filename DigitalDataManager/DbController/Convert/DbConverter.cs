using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.Entityes;
using DbController.Tables.DigitalDate;
using DbController.Tables.Versions;
using DbController.TableEntityes;
using Ddm.Db.TableEntityes;

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

        public static DbController.Entityes.User GetUser(UserDbItem item)
        {
            var res = Convert<DbController.Entityes.User, UserDbItem>(item);

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

        public static ActivateCode GetActivateCode(ActivateCodeT item)
        {
            return Convert<ActivateCode, ActivateCodeT>(item);
        }

        public static Comment GetComment(CommentT item)
        {
            return Convert<Comment, CommentT>(item);
        }

        public static DigitalFile GetFile(DigitalFileT item)
        {
            return Convert<DigitalFile, DigitalFileT>(item);
        }

        public static FileVsTag GetFileVsTag(FileVsTagT item)
        {
            return Convert<FileVsTag, FileVsTagT>(item);
        }

        public static Folder GetFolder(FolderT item)
        {
            return Convert<Folder, FolderT>(item);
        }

        public static FolderVsFile GetFolderVsFile(FolderVsFileT item)
        {
            return Convert<FolderVsFile, FolderVsFileT>(item);
        }

        public static FolderVsUser GetFolderVsUser(FolderVsUserT item)
        {
            return Convert<FolderVsUser, FolderVsUserT>(item);
        }

        public static FriendLink GetFriendLink(FriendLinkT item)
        {
            return Convert<FriendLink, FriendLinkT>(item);
        }

        public static Message GetMessage(MessageT item)
        {
            return Convert<Message, MessageT>(item);
        }

        public static Tag GetTag(TagT item)
        {
            return Convert<Tag, TagT>(item);
        }

        public static DbController.TableEntityes.User GetUser(UserT item)
        {
            return Convert<DbController.TableEntityes.User, UserT>(item);
        }
    }
}
