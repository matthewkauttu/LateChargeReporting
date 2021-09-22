﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LateChargeReports.HCAUser {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://pasop.atlas.medcity.net", ConfigurationName="HCAUser.HCA_UserSoap")]
    public interface HCA_UserSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://pasop.atlas.medcity.net/ValidateUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        LateChargeReports.HCAUser.HCAUser ValidateUser(string UserId, string ApplicationName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://pasop.atlas.medcity.net/ValidateUser", ReplyAction="*")]
        System.Threading.Tasks.Task<LateChargeReports.HCAUser.HCAUser> ValidateUserAsync(string UserId, string ApplicationName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://pasop.atlas.medcity.net/AuthorizedFacilities", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet AuthorizedFacilities(string UserID, string ApplicationName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://pasop.atlas.medcity.net/AuthorizedFacilities", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> AuthorizedFacilitiesAsync(string UserID, string ApplicationName);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://pasop.atlas.medcity.net")]
    public partial class HCAUser : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool isValidUserField;
        
        private string applicationField;
        
        private string userErrorField;
        
        private string userIdField;
        
        private string userNameField;
        
        private int securityLevelField;
        
        private string teamField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool IsValidUser {
            get {
                return this.isValidUserField;
            }
            set {
                this.isValidUserField = value;
                this.RaisePropertyChanged("IsValidUser");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Application {
            get {
                return this.applicationField;
            }
            set {
                this.applicationField = value;
                this.RaisePropertyChanged("Application");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string UserError {
            get {
                return this.userErrorField;
            }
            set {
                this.userErrorField = value;
                this.RaisePropertyChanged("UserError");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string UserId {
            get {
                return this.userIdField;
            }
            set {
                this.userIdField = value;
                this.RaisePropertyChanged("UserId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
                this.RaisePropertyChanged("UserName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int SecurityLevel {
            get {
                return this.securityLevelField;
            }
            set {
                this.securityLevelField = value;
                this.RaisePropertyChanged("SecurityLevel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Team {
            get {
                return this.teamField;
            }
            set {
                this.teamField = value;
                this.RaisePropertyChanged("Team");
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
    public interface HCA_UserSoapChannel : LateChargeReports.HCAUser.HCA_UserSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HCA_UserSoapClient : System.ServiceModel.ClientBase<LateChargeReports.HCAUser.HCA_UserSoap>, LateChargeReports.HCAUser.HCA_UserSoap {
        
        public HCA_UserSoapClient() {
        }
        
        public HCA_UserSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HCA_UserSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HCA_UserSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HCA_UserSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public LateChargeReports.HCAUser.HCAUser ValidateUser(string UserId, string ApplicationName) {
            return base.Channel.ValidateUser(UserId, ApplicationName);
        }
        
        public System.Threading.Tasks.Task<LateChargeReports.HCAUser.HCAUser> ValidateUserAsync(string UserId, string ApplicationName) {
            return base.Channel.ValidateUserAsync(UserId, ApplicationName);
        }
        
        public System.Data.DataSet AuthorizedFacilities(string UserID, string ApplicationName) {
            return base.Channel.AuthorizedFacilities(UserID, ApplicationName);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> AuthorizedFacilitiesAsync(string UserID, string ApplicationName) {
            return base.Channel.AuthorizedFacilitiesAsync(UserID, ApplicationName);
        }
    }
}