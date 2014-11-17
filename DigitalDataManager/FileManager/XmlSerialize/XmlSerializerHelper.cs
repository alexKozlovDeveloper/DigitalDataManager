using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileSystemManager.XmlSerialize
{
    public static class XmlSerializerHelper
    {
        public static Stream Serialize<T>(T obj)
        {
            var s = new XmlSerializer(typeof(T));

            var ms = new MemoryStream();

            s.Serialize(ms,obj);

            ms.Position = 0;

            return ms;
        }

        public static T Deserialize<T>(Stream ms)
        {
            var s = new XmlSerializer(typeof(T));

            var res = s.Deserialize(ms);

            return (T) res;
        }
    }
}
