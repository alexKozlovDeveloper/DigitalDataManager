﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesktopClient.DdmServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Version", Namespace="http://schemas.datacontract.org/2004/07/DigitalWcfService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    public partial class Version : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] XmlDocumentField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] XmlDocument {
            get {
                return this.XmlDocumentField;
            }
            set {
                if ((object.ReferenceEquals(this.XmlDocumentField, value) != true)) {
                    this.XmlDocumentField = value;
                    this.RaisePropertyChanged("XmlDocument");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DdmServiceReference.IDigitalService")]
    public interface IDigitalService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalService/GetData", ReplyAction="http://tempuri.org/IDigitalService/GetDataResponse")]
        string GetData(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalService/GetData", ReplyAction="http://tempuri.org/IDigitalService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalService/UpdateFileVersion", ReplyAction="http://tempuri.org/IDigitalService/UpdateFileVersionResponse")]
        void UpdateFileVersion(DesktopClient.DdmServiceReference.Version version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalService/UpdateFileVersion", ReplyAction="http://tempuri.org/IDigitalService/UpdateFileVersionResponse")]
        System.Threading.Tasks.Task UpdateFileVersionAsync(DesktopClient.DdmServiceReference.Version version);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDigitalServiceChannel : DesktopClient.DdmServiceReference.IDigitalService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DigitalServiceClient : System.ServiceModel.ClientBase<DesktopClient.DdmServiceReference.IDigitalService>, DesktopClient.DdmServiceReference.IDigitalService {
        
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
        
        public void UpdateFileVersion(DesktopClient.DdmServiceReference.Version version) {
            base.Channel.UpdateFileVersion(version);
        }
        
        public System.Threading.Tasks.Task UpdateFileVersionAsync(DesktopClient.DdmServiceReference.Version version) {
            return base.Channel.UpdateFileVersionAsync(version);
        }
    }
}
