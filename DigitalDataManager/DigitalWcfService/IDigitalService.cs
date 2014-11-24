using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using DbController.Entityes;
using DigitalWcfService.Entityes;

namespace DigitalWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDigitalService
    {
        //[OperationContract]
        //string GetData(string value);
        
        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        Stream GetImage(string login, string imageName);

        [OperationContract]
        void AddNewImage(Stream imageDataStream);

        [OperationContract]
        void UpdateImage(Stream imageDataStream);

        [OperationContract]
        void UpdateCatalogVersion(string login, string xmlVersion);

        [OperationContract]
        UserDateVersion GetLastCatalogVersion(string login);

        // TODO: Add your service operations here

        [OperationContract]
        Stream GetFilePart(string login, string fileName, int partNumber);

        [OperationContract]
        bool AppendFile(Stream data);

        [OperationContract]
        long GetFileSize(string login, string fileName);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "DigitalWcfService.ContractType".
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}

    //[DataContract]
    //public class Version111
    //{
    //    [DataMember]
    //    public int UserId { get; set; }

    //    [DataMember]
    //    public string Xml { get; set; }

    //    [DataMember]
    //    public Stream Fstream { get; set; }
    //}
}
