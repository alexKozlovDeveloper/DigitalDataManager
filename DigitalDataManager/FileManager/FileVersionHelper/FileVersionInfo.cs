using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FileSystemManager.ChecksumHelper;

namespace FileSystemManager.FileVersionHelper
{
    public class FileVersionInfo
    {
        private readonly string _filePaht;
        private XmlDocument _xmlDocument;

        public string FilePath {
            get { return _filePaht; }
        }

        public FileVersionInfo(string xmlFilePaht)
        {
            _filePaht = xmlFilePaht;

            if (!File.Exists(FilePath))
            {
                var xmlWriter = new XmlTextWriter(FilePath, Encoding.UTF8);

                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("Head");

                xmlWriter.WriteEndElement();

                xmlWriter.Close();
            }

            _xmlDocument = new XmlDocument();

            _xmlDocument.Load(FilePath);

            XmlNode element = _xmlDocument.CreateElement("ChecksumOfFiles");
            _xmlDocument.DocumentElement.AppendChild(element);
        }

        public void AddFileChecksum(string filePath)
        {
            var checksumOfFiles = _xmlDocument.DocumentElement.GetElementsByTagName("ChecksumOfFiles")[0];

            XmlNode fileInfo = _xmlDocument.CreateElement("FileInfo");

            XmlAttribute attribute = _xmlDocument.CreateAttribute("Name");
            attribute.Value = Path.GetFileNameWithoutExtension(filePath); 
            fileInfo.Attributes.Append(attribute); 

            XmlNode checksum = _xmlDocument.CreateElement("Checksum");
            checksum.InnerText = CsHelper.GetFileChecksum(filePath);

            XmlNode path = _xmlDocument.CreateElement("FullPath");
            path.InnerText = filePath;

            fileInfo.AppendChild(checksum);
            fileInfo.AppendChild(path);

            checksumOfFiles.AppendChild(fileInfo);

            _xmlDocument.Save(FilePath);
        }
    }
}
