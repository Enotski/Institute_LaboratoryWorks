using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;
using OP_ClassLib;

namespace Laba_3
{
    /// <summary>
    /// Сводное описание для DocumentsWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class DocumentsWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool SetDocumentBill(string[] data, Product[] products, string pathToFile)
        {
            if (data.Length != 5)
                return false;

            foreach (var s in data)
            {
                if (string.IsNullOrWhiteSpace(s))
                    return false;
            }

            Bill bill = new Bill(data[0], data[1], data[2], data[3], data[4]);
            bill.SetProductList(products.ToList());
            bill.CalcGoodsSum();

            SerializeXml(pathToFile, bill);
            return true;
        }
        [WebMethod]
        public bool SetDocumentInvoice(string[] data, Product[] products, string pathToFile)
        {
            if (data.Length != 6)
                return false;

            foreach (var s in data)
            {
                if (string.IsNullOrWhiteSpace(s))
                    return false;
            }

            Invoice invoice = new Invoice(data[0], data[1], data[2], data[3], data[4], data[5]);
            invoice.SetProductList(products.ToList());
            invoice.CalcGoodsSum();

            SerializeXml(pathToFile, invoice);
            return true;
        }
        [WebMethod]
        public bool SetDocumentReciept(string[] data, Product[] products, string pathToFile)
        {
            if (data.Length != 5)
                return false;

            foreach (var s in data)
            {
                if (string.IsNullOrWhiteSpace(s))
                    return false;
            }

            Reciept reciept = new Reciept(data[0], data[1], data[2], data[3], data[4]);
            reciept.SetProductList(products.ToList());
            reciept.CalcGoodsSum();

            SerializeXml(pathToFile, reciept);
            return true;

        }

        [WebMethod]
        public List<Document> GetAllDocuments(string pathToFile)
        {
            return DeserializeXml(pathToFile);
        }

        [WebMethod]
        public List<Document> GetSpecialDocuments(string pathToFile, string type)
        {
            var list = DeserializeXml(pathToFile);

            return list.Where(d => d.Type == type).ToList();
        }

        // xml десериализация
        public List<Document> DeserializeXml(string filePath)
        {
            List<Document> newList = new List<Document>();
            using (XmlReader reader = new XmlTextReader(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Document>));
                newList = (List<Document>)serializer.Deserialize(reader);
                reader.Close();
            }
            return newList;
        }
        // xml сереализация
        public void SerializeXml(string filePath, Document doc)
        {
            using(XmlWriter writer = new XmlTextWriter(filePath, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Document));
                serializer.Serialize(writer, doc);
                writer.Close();
            }   
        }
    }
}
