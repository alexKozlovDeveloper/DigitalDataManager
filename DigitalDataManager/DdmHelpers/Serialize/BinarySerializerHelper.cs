using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace DdmHelpers.Serialize
{
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
