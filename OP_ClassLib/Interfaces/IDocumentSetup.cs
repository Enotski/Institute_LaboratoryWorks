using System.ServiceModel;
namespace OP_ClassLib
{
    /// <summary>
    /// Основные методы работы с документом
    /// </summary>
    [ServiceContract]
    interface IDocumentSetup
    {
        [OperationContract]
        bool SetParticipants(string providerName, string clientName);
        [OperationContract]
        bool SetDocId(string id);
        [OperationContract]
        bool SetDocDate(string currDate);
    }
}
