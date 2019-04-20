using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OP_ClassLib
{
    /// <summary>
    /// Класс Накладная
    /// </summary>
    [Serializable]
    public class Invoice : Document
    {
        // объект и список, инициализируются в конструкторе данного класса 
        private Product _product;
        private ProductEditor _productEditor;

        public List<Product> Products { get; set; }
        public string ClientId { get; set; }
        public string ProviderId { get; set; }
        public double GoodsSum { get; set; }

        public Invoice(string docId, string date, string provider, string client, string providerId, string clientId) : base(docId, date, provider, client)
        {
            ClientId = clientId;
            ProviderId = providerId;
            _product = new Product();
            Products = new List<Product>();
            _productEditor = new ProductEditor();
        }
        public Invoice()
        {
            _product = new Product();
            Products = new List<Product>();
            _productEditor = new ProductEditor();
        }

        // установка свойств для данного документа
        public bool SetClientId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            ClientId = id;
            return true;
        }
        public bool SetProviderId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            ProviderId = id;
            return true;
        }

        // методы для конфигурации продукта
        public bool SetProduct(string pName, string mUnit, string price, int count)
        {
            if (!double.TryParse(price, out double tmpPrice))
                return false;

            _product = new Product(pName, mUnit, count, tmpPrice);
            _productEditor.SetProduct(Products, _product);
            return true;
        }
        public bool SetProduct(Product p)
        {
            if (p is null)
                return false;

            _product = p;
            _productEditor.SetProduct(Products, _product);
            return true;
        }
        public bool SetProductList(List<Product> pList)
        {
            if (pList.Count == 0)
                return false;

            Products = pList;;
            return true;
        }
        public bool RemoveProduct(string productName)
        {
            return _productEditor.RemoveProduct(productName, Products);
        }
        public double CalcProductSum(int productIndex)
        {
            return _productEditor.CalcProductSum(productIndex, Products);
        }
        public double CalcProductSum(string productName)
        {
            return _productEditor.CalcProductSum(productName, Products);
        }
        public void CalcGoodsSum()
        {
            GoodsSum = _productEditor.CalcGoodsSum(Products);
        }
        public override string Print()
        {
            string products = _productEditor.PrintProducts(Products);
            
            string result = "| -Накладная- |\n"
                + $"| Документ от - {DocDate.ToString("d")}|\n| № - {DocId} |\n"
                + $"| Исполнитель - {Provider} |\n| ИНН - {ProviderId} |\n"
                + $"| Заказчик - {Client}|\n| ИНН - {ClientId} |\n"
                + $"\n| Продукт/услуга |\n"
                + $"{products} |";

            return result;
        }
        public override string HtmlPrint()
        {
            string products = _productEditor.HtmlPrintProducts(Products);

            string result = "<h3>| -Накладная- |</h3>"
                + $"| Документ от - {DocDate.ToString("d")}|<br>| № - {DocId} |<br>"
                + $"| Исполнитель - {Provider} |<br>| ИНН - {ProviderId} |<br>"
                + $"| Заказчик - {Client}|<br>| ИНН - {ClientId} |<br>"
                + $"| Продукт/услуга |<br>"
                + $"<ol>{products}</ol>";

            return result;
        }

        public void SetInvoiceConsole()
        {
            SetDocumentConsole();
            Console.WriteLine("Введите ИНН заказчика");
            SetProviderId(Console.ReadLine());
            Console.WriteLine("Введите ИНН клиента");
            SetClientId(Console.ReadLine());
            Console.Clear();
            _productEditor.SetProductConsole(Products, _product);
            _productEditor.SetProduct(Products, _product);
        }
    }
}
