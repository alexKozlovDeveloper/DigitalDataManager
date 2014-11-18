using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DdmHelpers.Checksum;


namespace FileSystemManager.FileVersionHelper
{
    // legacy, use Catalog Version class
    public class FileVersionInfo
    {
        #region NodeNames
        public const string Head = "Head";
        public const string Name = "Name";
        public const string MainNode = "InfoOfFiles";
        public const string FileInfo = "FileInfo";
        public const string FullPath = "FullPath";
        public const string Checksum = "Checksum";
        public const string Version = "Version";
        public const string Time = "Time";
        #endregion

        public const string TimePattern = "yyyy.MM.dd hh:mm:ss.ffff";

        private readonly string _filePaht;
        private readonly XmlDocument _xmlDocument;

        public string FilePath 
        {
            get { return _filePaht; }
        }
        public XmlDocument XmlDocument
        {
            get { return _xmlDocument; }
        }

        public FileVersionInfo(string xmlFilePaht)
        {
            _filePaht = xmlFilePaht;

            if (!File.Exists(FilePath))
            {
                var xmlWriter = new XmlTextWriter(FilePath, Encoding.UTF8);

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(Head);
                xmlWriter.WriteEndElement();
                xmlWriter.Close();

                _xmlDocument = new XmlDocument();
                _xmlDocument.Load(FilePath);
                
                XmlNode version = _xmlDocument.CreateElement(Version);
                XmlNode time = _xmlDocument.CreateElement(Time);
                time.InnerText = DateTime.MinValue.ToString(TimePattern);

                version.AppendChild(time);

                _xmlDocument.DocumentElement.AppendChild(version);
                XmlNode mainNode = _xmlDocument.CreateElement(MainNode);
                _xmlDocument.DocumentElement.AppendChild(mainNode);
            }
            else
            {
                _xmlDocument = new XmlDocument();
                _xmlDocument.Load(FilePath);
            }

            _xmlDocument.Save(FilePath);
        }

        public void AddFileChecksum(string filePath)
        {
            var checksumOfFiles = _xmlDocument.DocumentElement.GetElementsByTagName(MainNode)[0];

            XmlNode fileInfo = _xmlDocument.CreateElement(FileInfo);

            XmlAttribute attribute = _xmlDocument.CreateAttribute(Name);
            attribute.Value = Path.GetFileNameWithoutExtension(filePath); 
            fileInfo.Attributes.Append(attribute);

            XmlNode checksum = _xmlDocument.CreateElement(Checksum);
            checksum.InnerText = CsHelper.GetFileChecksum(filePath);

            XmlNode path = _xmlDocument.CreateElement(FullPath);
            path.InnerText = filePath;

            fileInfo.AppendChild(checksum);
            fileInfo.AppendChild(path);

            checksumOfFiles.AppendChild(fileInfo);

            _xmlDocument.Save(FilePath);
        }

        public void UpdateFilesChecksum(IEnumerable<string> filePaths)
        {
            Clear();

            foreach (var filePath in filePaths)
            {
                AddFileChecksum(filePath);
            }
        }

        public void Clear()
        {
            var checksumOfFiles = _xmlDocument.DocumentElement.GetElementsByTagName(MainNode)[0];

            checksumOfFiles.RemoveAll();

            _xmlDocument.Save(FilePath);
        }

        public void UpdateVersionTime()
        {
            var time = _xmlDocument.DocumentElement.GetElementsByTagName(Time)[0];

            time.InnerText = DateTime.Now.ToString(TimePattern);

            _xmlDocument.Save(FilePath);
        }

        public void UpdateVersionTime(string newTime)
        {
            var time = _xmlDocument.DocumentElement.GetElementsByTagName(Time)[0];

            time.InnerText = newTime;

            _xmlDocument.Save(FilePath);
        }
    }
}
