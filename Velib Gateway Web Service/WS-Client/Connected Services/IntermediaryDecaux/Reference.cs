﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WS_Client.IntermediaryDecaux {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Stations", Namespace="http://schemas.datacontract.org/2004/07/IntermediaryWS")]
    [System.SerializableAttribute()]
    public partial class Stations : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LngField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Bikes {
            get {
                return this.BikesField;
            }
            set {
                if ((this.BikesField.Equals(value) != true)) {
                    this.BikesField = value;
                    this.RaisePropertyChanged("Bikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Lat {
            get {
                return this.LatField;
            }
            set {
                if ((this.LatField.Equals(value) != true)) {
                    this.LatField = value;
                    this.RaisePropertyChanged("Lat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Lng {
            get {
                return this.LngField;
            }
            set {
                if ((this.LngField.Equals(value) != true)) {
                    this.LngField = value;
                    this.RaisePropertyChanged("Lng");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="IntermediaryDecaux.IIntermediaryDecaux")]
    public interface IIntermediaryDecaux {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntermediaryDecaux/GetStationsInfoCity", ReplyAction="http://tempuri.org/IIntermediaryDecaux/GetStationsInfoCityResponse")]
        string GetStationsInfoCity(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntermediaryDecaux/GetStationsInfoCity", ReplyAction="http://tempuri.org/IIntermediaryDecaux/GetStationsInfoCityResponse")]
        System.Threading.Tasks.Task<string> GetStationsInfoCityAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntermediaryDecaux/FindStation", ReplyAction="http://tempuri.org/IIntermediaryDecaux/FindStationResponse")]
        double[] FindStation(string depart, string arrive);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntermediaryDecaux/FindStation", ReplyAction="http://tempuri.org/IIntermediaryDecaux/FindStationResponse")]
        System.Threading.Tasks.Task<double[]> FindStationAsync(string depart, string arrive);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntermediaryDecaux/GetAllCities", ReplyAction="http://tempuri.org/IIntermediaryDecaux/GetAllCitiesResponse")]
        string[] GetAllCities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntermediaryDecaux/GetAllCities", ReplyAction="http://tempuri.org/IIntermediaryDecaux/GetAllCitiesResponse")]
        System.Threading.Tasks.Task<string[]> GetAllCitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntermediaryDecaux/GetStationCity", ReplyAction="http://tempuri.org/IIntermediaryDecaux/GetStationCityResponse")]
        WS_Client.IntermediaryDecaux.Stations[] GetStationCity(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntermediaryDecaux/GetStationCity", ReplyAction="http://tempuri.org/IIntermediaryDecaux/GetStationCityResponse")]
        System.Threading.Tasks.Task<WS_Client.IntermediaryDecaux.Stations[]> GetStationCityAsync(string city);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IIntermediaryDecauxChannel : WS_Client.IntermediaryDecaux.IIntermediaryDecaux, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IntermediaryDecauxClient : System.ServiceModel.ClientBase<WS_Client.IntermediaryDecaux.IIntermediaryDecaux>, WS_Client.IntermediaryDecaux.IIntermediaryDecaux {
        
        public IntermediaryDecauxClient() {
        }
        
        public IntermediaryDecauxClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IntermediaryDecauxClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IntermediaryDecauxClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IntermediaryDecauxClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetStationsInfoCity(int value) {
            return base.Channel.GetStationsInfoCity(value);
        }
        
        public System.Threading.Tasks.Task<string> GetStationsInfoCityAsync(int value) {
            return base.Channel.GetStationsInfoCityAsync(value);
        }
        
        public double[] FindStation(string depart, string arrive) {
            return base.Channel.FindStation(depart, arrive);
        }
        
        public System.Threading.Tasks.Task<double[]> FindStationAsync(string depart, string arrive) {
            return base.Channel.FindStationAsync(depart, arrive);
        }
        
        public string[] GetAllCities() {
            return base.Channel.GetAllCities();
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllCitiesAsync() {
            return base.Channel.GetAllCitiesAsync();
        }
        
        public WS_Client.IntermediaryDecaux.Stations[] GetStationCity(string city) {
            return base.Channel.GetStationCity(city);
        }
        
        public System.Threading.Tasks.Task<WS_Client.IntermediaryDecaux.Stations[]> GetStationCityAsync(string city) {
            return base.Channel.GetStationCityAsync(city);
        }
    }
}
