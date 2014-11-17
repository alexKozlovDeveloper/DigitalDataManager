﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DigitalDataManager.DdmServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DdmServiceReference.IDigitalService")]
    public interface IDigitalService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalService/GetData", ReplyAction="http://tempuri.org/IDigitalService/GetDataResponse")]
        string GetData(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalService/GetData", ReplyAction="http://tempuri.org/IDigitalService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalService/UpdateCatalogVersion", ReplyAction="http://tempuri.org/IDigitalService/UpdateCatalogVersionResponse")]
        void UpdateCatalogVersion(string login, string xmlVersion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalService/UpdateCatalogVersion", ReplyAction="http://tempuri.org/IDigitalService/UpdateCatalogVersionResponse")]
        System.Threading.Tasks.Task UpdateCatalogVersionAsync(string login, string xmlVersion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalService/GetLastCatalogVersion", ReplyAction="http://tempuri.org/IDigitalService/GetLastCatalogVersionResponse")]
        string GetLastCatalogVersion(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalService/GetLastCatalogVersion", ReplyAction="http://tempuri.org/IDigitalService/GetLastCatalogVersionResponse")]
        System.Threading.Tasks.Task<string> GetLastCatalogVersionAsync(string login);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDigitalServiceChannel : DigitalDataManager.DdmServiceReference.IDigitalService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DigitalServiceClient : System.ServiceModel.ClientBase<DigitalDataManager.DdmServiceReference.IDigitalService>, DigitalDataManager.DdmServiceReference.IDigitalService {
        
        public DigitalServiceClient() {
        }
        
        public DigitalServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DigitalServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DigitalServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DigitalServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(string value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(string value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public void UpdateCatalogVersion(string login, string xmlVersion) {
            base.Channel.UpdateCatalogVersion(login, xmlVersion);
        }
        
        public System.Threading.Tasks.Task UpdateCatalogVersionAsync(string login, string xmlVersion) {
            return base.Channel.UpdateCatalogVersionAsync(login, xmlVersion);
        }
        
        public string GetLastCatalogVersion(string login) {
            return base.Channel.GetLastCatalogVersion(login);
        }
        
        public System.Threading.Tasks.Task<string> GetLastCatalogVersionAsync(string login) {
            return base.Channel.GetLastCatalogVersionAsync(login);
        }
    }
}
