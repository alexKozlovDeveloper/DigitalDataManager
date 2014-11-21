using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DdmHelpers.Serialize;
using DigitalWcfService.Entityes;

namespace FileSystemManager.DataLoading
{
    class LoadingHelper
    {
        public const int PartSize = 1000;

        private readonly DdmServiceReference.DigitalServiceClient _client;

        public LoadingHelper(DdmServiceReference.DigitalServiceClient client)
        {
            _client = client;
        }


        public void LoadFileToServer(PartFileData data, string filePath)
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

                    data.ImageStream = ms;

                    _client.AppendFile(BinarySerializerHelper.Serialize(data));

                    n++;
                }
            }
        }

        public void DownloadFileToClient(PartFileData data, string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }

            using (var fs = File.OpenWrite(filePath))
            {
                var size = _client.GetFileSize(BinarySerializerHelper.Serialize(data));

                var n = 0;

                while (fs.Length < size)
                {
                    var item = BinarySerializerHelper.Deserialize<PartFileData>(_client.GetFilePart(BinarySerializerHelper.Serialize(data)));

                    var buffer = new byte[item.ImageStream.Length];

                    item.ImageStream.Read(buffer, 0, (int)item.ImageStream.Length);

                    if (fs.Length != 0)
                    {
                        fs.Position = fs.Length;
                    }

                    fs.Write(buffer, 0, (int)item.ImageStream.Length);

                    n++;
                }
            }
        }
    }
}
