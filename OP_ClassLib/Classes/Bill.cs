using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace OP_ClassLib
{
    /// <summary>
    /// Класс Счет
    /// </summary>
    [Serializable]
    public class Bill : Document
    {
        // объект и список, инициализируются в конструкторе данного класса
        private Product _product;
        private ProductEditor _productEditor;

        public List<Product> Products { get; set; }
        public string ClientId { get; set; }
        public double GoodsSum { get; set; }


        public Bill(string provider, string client, string docId, string date, string clientId) : base(provider, client, docId, date)
        {
            ClientId = clientId;
            _product = new Product();
            Products = new List<Product>();
            _productEditor = new ProductEditor();
        }
        public Bill()
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

            Products = pList; ;
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
            
            string products =_productEditor.PrintProducts(Products);

            string result = "| -Счет- |\n"
                + $"| Документ от - {DocDate.ToString("d")}|\n| № - {DocId} |\n"
                + $"| Исполнитель - {Provider} |\n"
                + $"| Заказчик - {Client}|\n| ИНН - {ClientId} |\n"
                + $"| Продукт/услуга |\n\n"
                + $"{products} |";
            return result;
        }

        public void SetBillConsole()
        {
            SetDocumentConsole();
            Console.WriteLine("Введите ИНН клиента");
            SetClientId(Console.ReadLine());
            Console.Clear();
            _productEditor.SetProductConsole(Products, _product);
            _productEditor.SetProduct(Products, _product);
        }
    }
}
