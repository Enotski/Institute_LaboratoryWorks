using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml.Serialization;


namespace OP_ClassLib
{
    /// <summary>
    /// Класс Квитанция
    /// </summary>
    [Serializable]
    public class Reciept : Document
    {
        // объект и список, инициализируются в конструкторе данного класса 
        private Product _product;
        private ProductEditor _productEditor;

        public List<Product> Products { get; set; }
        public double GoodsSum { get; set; }
        public string PaymentName { get; set; }

        
        public Reciept(string docId, string date, string provider, string client, string paymentName) : base(docId, date, provider, client)
        {
            PaymentName = paymentName;
            _product = new Product();
            Products = new List<Product>();
            _productEditor = new ProductEditor();
        }
        public Reciept()
        {
            _product = new Product();
            Products = new List<Product>();
            _productEditor = new ProductEditor();
        }

        // установка заголовка квитанции и наименования продукта
        public bool SetPaymentName(string payment)
        {
            if (string.IsNullOrWhiteSpace(payment))
                return false;

            PaymentName = payment;
            return true;
        }

        // методы для конфигурации продукта
        public bool SetProduct(string pName, string mUnit, string price, int count)
        {
            if (!double.TryParse(price, out double tmpPrice))
                return false;

            _product = new Product(pName, mUnit, count, tmpPrice);

            if (Products.Any())
                Products.Clear();

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
        public bool RemoveProduct()
        {
            return _productEditor.RemoveProduct(PaymentName, Products);
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

            string result = $"| -Квитанция за {PaymentName}- |\n"
                + $"| Документ от - {DocDate.ToString("d")}|\n| № - {DocId} |\n"
                + $"| Исполнитель - {Provider} |\n"
                + $"| Заказчик - {Client} |\n"
                + $"| Продукт/услуга |\n\n"
                + $"{products} |";

            return result;
        }
        public override string HtmlPrint()
        {
            string products = _productEditor.HtmlPrintProducts(Products);

            string result = $"<h3 class='docHeader'>Квитанция за {PaymentName}</h3>"
                + $"<div class='docContent'><li>Документ от - {DocDate.ToString("d")}</li><li>№ - {DocId}</li>"
                + $"<li>Исполнитель - {Provider}</li>"
                + $"<li>Заказчик - {Client}</li></div>"
                + $"<div class='docProducts'><h4>Продукт/услуга</h4>"
                + $"{products}</div>";

            return result;
        }
        public void SetRecieptConsole()
        {
            SetDocumentConsole();
            Console.WriteLine("Введите наименование продукта/услуги");
            SetPaymentName(Console.ReadLine());
            Console.Clear();
            _productEditor.SetProductConsole(Products, _product);
            _productEditor.SetProduct(Products, _product);
        }
    }
}
