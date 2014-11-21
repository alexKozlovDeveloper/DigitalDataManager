using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DdmHelpers.Serialize;

namespace DigitalWcfService.Entityes
{
    [Serializable]
    [DataContract]
    public class PartFileData
    {
        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string AlbumName { get; set; }

        [DataMember]
        public string ImageName { get; set; }

        [DataMember]
        public Stream ImageStream { get; set; }

        [DataMember]
        public int PartNumber { get; set; }
    }

    //public static class ImageDataHelper
    //{
    //    public static Stream ToStream(ImageData data, Stream imageStream)
    //    {
    //        var ms = new MemoryStream();

    //        var dataStream = BinarySerializerHelper.Serialize(data);

    //        var count = BinarySerializerHelper.Serialize(dataStream.Length);

    //        count.CopyTo(ms);
    //        dataStream.CopyTo(ms);
    //        imageStream.CopyTo(ms);

    //        return ms;
    //    }

    //    public static void ToObjects(Stream input, out ImageData data, out Stream imageStream)
    //    {
    //        int l = 58;

    //        var buffer = new byte[l];

    //        input.Read(buffer, 0, l);

    //        var countStream = new MemoryStream(buffer);

    //        var count = BinarySerializerHelper.Deserialize<int>(countStream);

    //        buffer = new byte[count];

    //        input.Read(buffer, l, count);

    //        var dataStream = new MemoryStream(buffer);

    //        data = BinarySerializerHelper.Deserialize<ImageData>(dataStream);

    //        buffer = new byte[input.Length - l - count];

    //        input.Read(buffer, l + count, (int)input.Length - l - count);

    //        imageStream = new MemoryStream(buffer);
    //    }
    //}
}
