namespace OP_ClassLib
{
    /// <summary>
    /// Основные методы работы с документом
    /// </summary>
    interface IDocumentSetup
    {
        bool SetParticipants(string providerName, string clientName);
        bool SetDocId(string id);
        bool SetDocDate(string currDate);
        string Print();
        string HtmlPrint();
    }
}
