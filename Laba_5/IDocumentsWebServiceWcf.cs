using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using OP_ClassLib;

namespace Laba_5
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IDocumentsWebServiceWcf" в коде и файле конфигурации.
    [ServiceContract]
    [XmlSerializerFormat()]
    public interface IDocumentsWebServiceWcf
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        bool SetDocumentBill(string[] data, Product[] productsPacket);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        bool SetDocumentInvoice(string[] data, Product[] productsPacket);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        bool SetDocumentReciept(string[] data, Product[] productsPacket);
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml)]
        List<Document> GetAllDocuments();
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml)]
        List<Document> GetSpecialDocuments(string type);
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml)]
        List<Document> GetSpecialDocument(string docId);
    }
}
