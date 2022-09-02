using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWcfWebApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]   
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetData/{FirstName}/{MiddleName}/{LastName}",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        MotherClass GetData(String FirstName, String MiddleName, String LastName);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllPersonInformation",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        ClassToList GetAllPersonInformation();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllPersonInformationList",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        AllPersonInformationList GetAllPersonInformationList();


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/SearcInformationById/{Id}",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        SingleInformation SearcInformationById(String Id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/UpdateData/{FirstName}/{MiddleName}/{LastName}/{Id}",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        MotherClass UpdateData(String FirstName, String MiddleName, String LastName, String Id);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/DeleteData/{Id}",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        MotherClass DeleteData(String Id);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Login/{UserName}/{PassWord}",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        MotherClass Login(String UserName, String PassWord);
    }

 
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
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
}


