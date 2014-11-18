using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWcfService.Entityes
{
    [DataContract]
    public class ImageData
    {
        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string AlbumName { get; set; }

        [DataMember]
        public string ImageName { get; set; }

        [DataMember]
        public Stream ImageStream { get; set; }
    }
}
