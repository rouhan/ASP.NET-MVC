﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationUserManagement.UserService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.IAccountWebService")]
    public interface IAccountWebService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountWebService/GetData", ReplyAction="http://tempuri.org/IAccountWebService/GetDataResponse")]
        WebApplicationUserManagement.Model.Account[] GetData(string searching);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountWebService/GetData", ReplyAction="http://tempuri.org/IAccountWebService/GetDataResponse")]
        System.Threading.Tasks.Task<WebApplicationUserManagement.Model.Account[]> GetDataAsync(string searching);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountWebServiceChannel : WebApplicationUserManagement.UserService.IAccountWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountWebServiceClient : System.ServiceModel.ClientBase<WebApplicationUserManagement.UserService.IAccountWebService>, WebApplicationUserManagement.UserService.IAccountWebService {
        
        public AccountWebServiceClient() {
        }
        
        public AccountWebServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountWebServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountWebServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountWebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebApplicationUserManagement.Model.Account[] GetData(string searching) {
            return base.Channel.GetData(searching);
        }
        
        public System.Threading.Tasks.Task<WebApplicationUserManagement.Model.Account[]> GetDataAsync(string searching) {
            return base.Channel.GetDataAsync(searching);
        }
    }
}
