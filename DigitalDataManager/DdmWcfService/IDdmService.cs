using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UserFilesDbController.Entityes;

namespace DdmWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDdmService
    {
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        Guid CreateUser(string userName, string password);

        [OperationContract]
        Guid CreateAlbum(string albumName);

        [OperationContract]
        Guid CreateFile(Stream dataStream);

        [OperationContract]
        void UpdateFile(Stream dataStream);

        [OperationContract]
        Stream GetFileStream(Guid fileId);

        [OperationContract]
        void AddAlbumToUser(Guid userId, Guid albumId);

        [OperationContract]
        void AddFileToAlbum(Guid albumId, Guid fileId);

        [OperationContract]
        void AddFriendLink(Guid userId, Guid friendId);


        [OperationContract]
        User GetUser(Guid userId);

        [OperationContract]
        Album GetAlbum(Guid albumId);

        [OperationContract]
        DigitalFile GetFile(Guid fileId);


        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        List<Album> GetAllAlbums();

        [OperationContract]
        List<DigitalFile> GetAllFiles();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "DdmWcfService.ContractType".
    //[DataContract]
    //public class CompositeType
    //{
    //    bool _boolValue = true;
    //    string _stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return _boolValue; }
    //        set { _boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return _stringValue; }
    //        set { _stringValue = value; }
    //    }
    //}
}
