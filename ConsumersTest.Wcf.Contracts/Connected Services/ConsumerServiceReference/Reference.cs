﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsumersTest.Wcf.ConsumerServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Consumer", Namespace="http://schemas.datacontract.org/2004/07/Consumers.Service")]
    [System.SerializableAttribute()]
    public partial class Consumer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ConsumerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateOfBirthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
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
        public int ConsumerId {
            get {
                return this.ConsumerIdField;
            }
            set {
                if ((this.ConsumerIdField.Equals(value) != true)) {
                    this.ConsumerIdField = value;
                    this.RaisePropertyChanged("ConsumerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateOfBirth {
            get {
                return this.DateOfBirthField;
            }
            set {
                if ((this.DateOfBirthField.Equals(value) != true)) {
                    this.DateOfBirthField = value;
                    this.RaisePropertyChanged("DateOfBirth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ConsumerServiceReference.IConsumerService")]
    public interface IConsumerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConsumerService/GetAll", ReplyAction="http://tempuri.org/IConsumerService/GetAllResponse")]
        ConsumersTest.Wcf.ConsumerServiceReference.Consumer[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConsumerService/GetAll", ReplyAction="http://tempuri.org/IConsumerService/GetAllResponse")]
        System.Threading.Tasks.Task<ConsumersTest.Wcf.ConsumerServiceReference.Consumer[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConsumerService/Get", ReplyAction="http://tempuri.org/IConsumerService/GetResponse")]
        ConsumersTest.Wcf.ConsumerServiceReference.Consumer Get(int consumerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConsumerService/Get", ReplyAction="http://tempuri.org/IConsumerService/GetResponse")]
        System.Threading.Tasks.Task<ConsumersTest.Wcf.ConsumerServiceReference.Consumer> GetAsync(int consumerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConsumerService/Delete", ReplyAction="http://tempuri.org/IConsumerService/DeleteResponse")]
        void Delete(int consumerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConsumerService/Delete", ReplyAction="http://tempuri.org/IConsumerService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(int consumerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConsumerService/Add", ReplyAction="http://tempuri.org/IConsumerService/AddResponse")]
        void Add(ConsumersTest.Wcf.ConsumerServiceReference.Consumer consumer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConsumerService/Add", ReplyAction="http://tempuri.org/IConsumerService/AddResponse")]
        System.Threading.Tasks.Task AddAsync(ConsumersTest.Wcf.ConsumerServiceReference.Consumer consumer);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IConsumerServiceChannel : ConsumersTest.Wcf.ConsumerServiceReference.IConsumerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConsumerServiceClient : System.ServiceModel.ClientBase<ConsumersTest.Wcf.ConsumerServiceReference.IConsumerService>, ConsumersTest.Wcf.ConsumerServiceReference.IConsumerService {
        
        public ConsumerServiceClient() {
        }
        
        public ConsumerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConsumerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConsumerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConsumerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ConsumersTest.Wcf.ConsumerServiceReference.Consumer[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<ConsumersTest.Wcf.ConsumerServiceReference.Consumer[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public ConsumersTest.Wcf.ConsumerServiceReference.Consumer Get(int consumerId) {
            return base.Channel.Get(consumerId);
        }
        
        public System.Threading.Tasks.Task<ConsumersTest.Wcf.ConsumerServiceReference.Consumer> GetAsync(int consumerId) {
            return base.Channel.GetAsync(consumerId);
        }
        
        public void Delete(int consumerId) {
            base.Channel.Delete(consumerId);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(int consumerId) {
            return base.Channel.DeleteAsync(consumerId);
        }
        
        public void Add(ConsumersTest.Wcf.ConsumerServiceReference.Consumer consumer) {
            base.Channel.Add(consumer);
        }
        
        public System.Threading.Tasks.Task AddAsync(ConsumersTest.Wcf.ConsumerServiceReference.Consumer consumer) {
            return base.Channel.AddAsync(consumer);
        }
    }
}
