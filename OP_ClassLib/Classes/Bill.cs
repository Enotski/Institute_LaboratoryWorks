using System.Collections.Generic;
using System;

namespace OP_ClassLib
{
    /// <summary>
    /// Класс Счет
    /// </summary>
    public class Bill : Document
    {
        // объект и список, инициализируются в конструкторе данного класса
        private Product _product;
        private ProductEditor _productEditor;
        private List<Product> _products;

        public string ClientId { get; set; }
        public double GoodsSum { get; set; }


        public Bill(string provider, string client, string docId, string date, string clientId) : base(provider, client, docId, date)
        {
            ClientId = clientId;
            _product = new Product();
            _products = new List<Product>();
            _productEditor = new ProductEditor();
        }
        public Bill()
        {
            _product = new Product();
            _products = new List<Product>();
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

        // методы для конфигурации продукта
        public bool SetProduct(string pName, string mUnit, string price, int count)
        {
            if (!double.TryParse(price, out double tmpPrice))
                return false;

            _product = new Product(pName, mUnit, count, tmpPrice);
            _productEditor.SetProduct(_products, _product);
            return true;
        }
        public bool RemoveProduct(string productName)
        {
            return _productEditor.RemoveProduct(productName, _products);
        }
        public double CalcProductSum(int productIndex)
        {
            return _productEditor.CalcProductSum(productIndex, _products);
        }
        public double CalcProductSum(string productName)
        {
            return _productEditor.CalcProductSum(productName, _products);
        }
        public void CalcGoodsSum()
        {
            GoodsSum = _productEditor.CalcGoodsSum(_products);
        }
        public override string Print()
        {
            
            string products =_productEditor.PrintProducts(_products);

            string result = "| -Счет- |\n"
                + $"| Документ от - {DocDate.ToString("d")}|\n| № - {DocId} |\n"
                + $"| Исполнитель - {Provider} |\n"
                + $"| Заказчик - {Client}|\n| ИНН - {ClientId} |\n"
                + $"| Продукт/услуга |\n\n"
                + $"| {products} |";
            return result;
        }

        public void SetBillConsole()
        {
            SetDocumentConsole();
            Console.WriteLine("Введите ИНН клиента");
            SetClientId(Console.ReadLine());
            Console.Clear();
            _productEditor.SetProductConsole(_products, _product);
            _productEditor.SetProduct(_products, _product);
        }
    }
}
