using System.Collections.Generic;
using System.Linq;
using System;

namespace OP_ClassLib
{
    /// <summary>
    /// Класс Квитанция
    /// </summary>
    public class Reciept : Document
    {
        // объект и список, инициализируются в конструкторе данного класса 
        private Product _product;
        private ProductEditor _productEditor;
        private List<Product> _products;

        public double GoodsSum { get; set; }
        public string PaymentName { get; set; }

        
        public Reciept(string provider, string client, string docId, string date,  string paymentName) : base(provider, client, docId, date)
        {
            PaymentName = paymentName;
            _product = new Product();
            _products = new List<Product>();
            _productEditor = new ProductEditor();
        }
        public Reciept()
        {
            _product = new Product();
            _products = new List<Product>();
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

            if (_products.Any())
                _products.Clear();

            _productEditor.SetProduct(_products, _product);
            return true;
        }
        public bool RemoveProduct()
        {
            return _productEditor.RemoveProduct(PaymentName, _products);
        }
        public void CalcProductSum()
        {
            GoodsSum =  _productEditor.CalcProductSum(0, _products);
        }
        public override string Print()
        {
            string products = _productEditor.PrintProducts(_products);

            string result = $"| -Квитанция за {PaymentName}- |\n"
                + $"| Документ от - {DocDate.ToString("d")}|\n| № - {DocId} |\n"
                + $"| Исполнитель - {Provider} |\n"
                + $"| Заказчик - {Client} |\n"
                + $"| Продукт/услуга |\n\n"
                + $"| {products} |";

            return result;
        }
        
        public void SetRecieptConsole()
        {
            SetDocumentConsole();
            Console.WriteLine("Введите наименование продукта/услуги");
            SetPaymentName(Console.ReadLine());
            Console.Clear();
            _productEditor.SetProductConsole(_products, _product);
            _productEditor.SetProduct(_products, _product);
        }
    }
}
