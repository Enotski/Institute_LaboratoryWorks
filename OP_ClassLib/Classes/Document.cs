using System;
using System.Xml.Serialization;

namespace OP_ClassLib
{
    /// <summary>
    /// класс Документ - базовый
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Invoice))]
    [XmlInclude(typeof(Bill))]
    [XmlInclude(typeof(Reciept))]
    public abstract class Document : IDocumentSetup
    {
        //св-ва
        public string DocId { get; set; }
        public DateTime DocDate { get; set; }
        public string Provider { get; set; }
        public string Client { get; set; }
        public string Type { get
            {
                return this.GetType().Name;
            }
        }

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
        public abstract string Print();
        public abstract string HtmlPrint();

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
