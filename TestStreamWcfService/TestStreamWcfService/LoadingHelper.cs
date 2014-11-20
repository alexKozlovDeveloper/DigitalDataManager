using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using WcfStreamService;

namespace TestStreamWcfService
{
    public class LoadingHelper
    {
        public const int PartSize = 1000;

        private readonly WcfServiceReference.Service1Client _client;

        public LoadingHelper(WcfServiceReference.Service1Client client)
        {
            _client = client;
        }

        public void LoadFileToServer(string filePath)
        {
            using (var fs = File.OpenRead(filePath))
            {
                var n = 0;

                while (fs.Position < fs.Length)
                {
                    var bufferSize = PartSize;

                    if (fs.Length - PartSize * n < PartSize)
                    {
                        bufferSize = (int)fs.Length - PartSize * n;
                    }

                    var buffer = new byte[bufferSize];

                    fs.Read(buffer, 0, bufferSize);

                    var ms = new MemoryStream(buffer);

                    var info = new Info
                    {
                        FilePath = @"D:\TESTIMAGE_1.bmp",
                        FileStream = ms
                    };

                    _client.AppendFile(BinarySerializerHelper.Serialize(info));

                    n++;
                }
            }
        }

        public void DownloadFileToClient(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath))
                {

                }
            }

            using (var fs = File.OpenWrite(filePath))
            {
                const string serverFilePath = @"D:\TESTIMAGE.bmp";

                var size = _client.GetFileSize(serverFilePath);
                int n = 0;
                while (fs.Length < size)
                {
                    var item = BinarySerializerHelper.Deserialize<Info>(_client.GetFilePart(serverFilePath, n));

                    var buffer = new byte[item.FileStream.Length];

                    item.FileStream.Read(buffer, 0, (int)item.FileStream.Length);

                    if (fs.Length != 0)
                    {
                        fs.Position = fs.Length;
                    }

                    fs.Write(buffer, 0, (int)item.FileStream.Length);

                    n++;
                }
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
