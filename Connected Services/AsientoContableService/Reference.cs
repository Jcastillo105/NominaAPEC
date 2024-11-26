﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsientoContableService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AsientoContableService.AsientoContableServiceSoap")]
    public interface AsientoContableServiceSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RegistrarAsiento", ReplyAction="*")]
        System.Threading.Tasks.Task<AsientoContableService.RegistrarAsientoResponse> RegistrarAsientoAsync(AsientoContableService.RegistrarAsientoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RegistrarAsientoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RegistrarAsiento", Namespace="http://tempuri.org/", Order=0)]
        public AsientoContableService.RegistrarAsientoRequestBody Body;
        
        public RegistrarAsientoRequest()
        {
        }
        
        public RegistrarAsientoRequest(AsientoContableService.RegistrarAsientoRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class RegistrarAsientoRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int idAuxiliar;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string descripcion;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int cuentaDB;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int cuentaCR;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public decimal monto;
        
        public RegistrarAsientoRequestBody()
        {
        }
        
        public RegistrarAsientoRequestBody(int idAuxiliar, string descripcion, int cuentaDB, int cuentaCR, decimal monto)
        {
            this.idAuxiliar = idAuxiliar;
            this.descripcion = descripcion;
            this.cuentaDB = cuentaDB;
            this.cuentaCR = cuentaCR;
            this.monto = monto;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RegistrarAsientoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RegistrarAsientoResponse", Namespace="http://tempuri.org/", Order=0)]
        public AsientoContableService.RegistrarAsientoResponseBody Body;
        
        public RegistrarAsientoResponse()
        {
        }
        
        public RegistrarAsientoResponse(AsientoContableService.RegistrarAsientoResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class RegistrarAsientoResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int RegistrarAsientoResult;
        
        public RegistrarAsientoResponseBody()
        {
        }
        
        public RegistrarAsientoResponseBody(int RegistrarAsientoResult)
        {
            this.RegistrarAsientoResult = RegistrarAsientoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface AsientoContableServiceSoapChannel : AsientoContableService.AsientoContableServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class AsientoContableServiceSoapClient : System.ServiceModel.ClientBase<AsientoContableService.AsientoContableServiceSoap>, AsientoContableService.AsientoContableServiceSoap
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public AsientoContableServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(AsientoContableServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), AsientoContableServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AsientoContableServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(AsientoContableServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AsientoContableServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(AsientoContableServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AsientoContableServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AsientoContableService.RegistrarAsientoResponse> AsientoContableService.AsientoContableServiceSoap.RegistrarAsientoAsync(AsientoContableService.RegistrarAsientoRequest request)
        {
            return base.Channel.RegistrarAsientoAsync(request);
        }
        
        public System.Threading.Tasks.Task<AsientoContableService.RegistrarAsientoResponse> RegistrarAsientoAsync(int idAuxiliar, string descripcion, int cuentaDB, int cuentaCR, decimal monto)
        {
            AsientoContableService.RegistrarAsientoRequest inValue = new AsientoContableService.RegistrarAsientoRequest();
            inValue.Body = new AsientoContableService.RegistrarAsientoRequestBody();
            inValue.Body.idAuxiliar = idAuxiliar;
            inValue.Body.descripcion = descripcion;
            inValue.Body.cuentaDB = cuentaDB;
            inValue.Body.cuentaCR = cuentaCR;
            inValue.Body.monto = monto;
            return ((AsientoContableService.AsientoContableServiceSoap)(this)).RegistrarAsientoAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.AsientoContableServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.AsientoContableServiceSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.AsientoContableServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://asientocontablews.somee.com/AsientoContableService.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.AsientoContableServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://asientocontablews.somee.com/AsientoContableService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            AsientoContableServiceSoap,
            
            AsientoContableServiceSoap12,
        }
    }
}
