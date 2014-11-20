using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfStreamService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Stream GetFile(string name);

        [OperationContract]
        void AddFile(Stream fileStream);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here


        [OperationContract()]
        string[] GetPhotoList();

        [OperationContract]
        Stream GetPhotoStream(string photo);


        [OperationContract]
        void AppendFile(Stream info);

        [OperationContract]
        Stream GetFilePart(string filePath, int partNumber);

        [OperationContract]
        long GetFileSize(string filePath);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfStreamService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [Serializable]
    [DataContract]
    public class Info
    {
        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public Stream FileStream { get; set; }
    }
}
