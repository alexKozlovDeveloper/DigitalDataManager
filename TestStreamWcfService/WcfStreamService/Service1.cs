using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.Text;

namespace WcfStreamService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public const int PartSize = 1000;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Stream GetFile(string path)
        {
            var info = new Info { FileStream = FileReaderHelper.ReadStreamFromFile(path) };

            return BinarySerializerHelper.Serialize(info);
        }

        public void AddFile(Stream infoStream)
        {
            var info = BinarySerializerHelper.Deserialize<Info>(infoStream);

            FileReaderHelper.WriteStreamInFile(info.FileStream, @"D:\cookieNew.avi");
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        
        public string[] GetPhotoList()
        {
            var photoList = new string[3];
            photoList[0] = @"D:\test1.png";
            photoList[1] = @"D:\test1.png";

            return photoList;
        }

        public Stream GetPhotoStream(string photo)
        {
            string photoFile = photo;//String.Format("{0}\\{1}", "C:\\", photo);

            var fi = new FileInfo(photoFile);

            if (!fi.Exists)
                throw new FileNotFoundException("File does not exist: {0}. Check host configuration for 'PhotoPath' setting.", photo);

            FileStream fs = null;
            try
            {
                fs = new FileStream(photoFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch
            {
                if (fs != null)
                    fs.Close();
            }

            return fs;
        }

        public void AppendFile(Stream info)
        {
            var item = BinarySerializerHelper.Deserialize<Info>(info);
            
            if (!File.Exists(item.FilePath))
            {
                using (File.Create(item.FilePath))
                {

                }
            }
            
            using (var fs = File.OpenWrite(item.FilePath))
            {
                var buffer = new byte[item.FileStream.Length];

                item.FileStream.Read(buffer, 0, (int)item.FileStream.Length);

                if (fs.Length != 0)
                {
                    fs.Position = fs.Length;
                }

                fs.Write(buffer, 0, (int)item.FileStream.Length);
            }
        }

        public Stream GetFilePart(string filePath, int partNumber)
        {
            using (var fs = File.OpenRead(filePath))
            {
                fs.Position = PartSize*partNumber;

                var size = PartSize;

                if (fs.Length - PartSize*partNumber < PartSize)
                {
                    size = (int)fs.Length - PartSize*partNumber;
                }

                var buffer = new byte[size];

                fs.Read(buffer, 0, size);

                var ms = new MemoryStream(buffer);

                var info = new Info
                {
                    FilePath = filePath,
                    FileStream = ms
                };

                return BinarySerializerHelper.Serialize(info);
            }
        }

        public long GetFileSize(string filePath)
        {
            using (var fs = File.OpenRead(filePath))
            {
                return fs.Length;
            }
        }
    }

    public static class FileReaderHelper
    {
        public static void WriteStreamInFile(Stream stream, string filePath)
        {
            using (FileStream fileStream = File.Create(filePath, (int)stream.Length))
            {
                var data = new byte[stream.Length];

                stream.Read(data, 0, data.Length);
                fileStream.Write(data, 0, data.Length);
            }
        }

        public static Stream ReadStreamFromFile(string filePath)
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var data = new byte[fileStream.Length];

                fileStream.Read(data, 0, data.Length);

                var ms = new MemoryStream();

                ms.Write(data, 0, data.Length);

                ms.Position = 0;

                return ms;
            }
        }
    }

    public static class BinarySerializerHelper
    {
        public static Stream Serialize(object obj)
        {
            var formatter = new BinaryFormatter();

            var res = new MemoryStream();

            formatter.Serialize(res, obj);

            res.Position = 0;

            return res;
        }

        public static T Deserialize<T>(Stream ms)
        {
            var formatter = new BinaryFormatter();

            var res = formatter.Deserialize(ms);

            return (T)res;
        }
    }
}
