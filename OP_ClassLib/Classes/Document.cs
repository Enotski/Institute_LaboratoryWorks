using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OP_ClassLib
{
    /// <summary>
    /// класс Документ - базовый
    /// </summary>
    [DataContract]
    [Serializable]
    [KnownType(typeof(Invoice))]
    [KnownType(typeof(Bill))]
    [KnownType(typeof(Reciept))]
    [XmlInclude(typeof(Invoice))]
    [XmlInclude(typeof(Bill))]
    [XmlInclude(typeof(Reciept))]
    public class Document : IDocumentSetup
    {
        //св-ва
        [DataMember]
        public string DocId { get; set; }
        [DataMember]
        public DateTime DocDate { get; set; }
        [DataMember]
        public string Provider { get; set; }
        [DataMember]
        public string Client { get; set; }

        //конструкторы
        public Document(string docId, string date, string provider, string client)
        {
            Provider = provider;
            Client = client;
            DocId = docId;
            DateTime.TryParse(date, out DateTime curr);
            DocDate = curr;
        }
        public Document() { }

        //методы
        public bool SetDocId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            DocId = id;
            return true;
        }
        public bool SetDocDate(string currDate)
        {
            DateTime date = new DateTime();
            if (!DateTime.TryParse(currDate, out date))
                return false;
            DocDate = date;
            return true;
        }
        public bool SetParticipants(string providerName, string clientName)
        {
            if (string.IsNullOrWhiteSpace(providerName))
                return false;
            Provider = providerName;

            if (string.IsNullOrWhiteSpace(clientName))
                return false;
            Client = clientName;

            return true;
        }
        public virtual string Print() { return ""; }
        public virtual string HtmlPrint() { return ""; }

        public void SetDocumentConsole()
        {
            Console.WriteLine("Введите ФИО исполнителя");
            string provider = Console.ReadLine();
            Console.WriteLine("Введите ФИО заказчика");
            string client = Console.ReadLine();
            SetParticipants(provider, client);
            Console.WriteLine("Введите дату документа: дд/мм/гг");
            SetDocDate(Console.ReadLine());
            Console.WriteLine("Введите номер документа");
            SetDocId(Console.ReadLine());
        }
    }
}
