using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DdmWebClient.Models
{
    public class TestModel // need rename
    {
        public string UserName { get; set; }

        public List<Album> Albums { get; set; }

        public string ImageSrc { get; set; }
    }

    public class Album
    {
        public string Name { get; set; }

        public List<Image> Images { get; set; }
    }

    public class Image
    {
        public string Name { get; set; }
    }
}