using System.Collections.Generic;
using System;

namespace OP_ClassLib
{
    public class ProductEditor: IProductSetup
    {
        public void SetProduct(List<Product> products, Product p)
        {
            products.Add(p);
        }

        public bool RemoveProduct(string productName, List<Product> products)
        {
            int current = products.FindIndex(p => p.Name == productName);
            if (current == -1)
                return false;
            products[current] = null;
            return true;
        }

        public double CalcProductSum(int productIndex, List<Product> products)
        {
            if (productIndex < 0 || productIndex >= products.Count)
                return -1;

            products[productIndex].Sum = products[productIndex].Count * products[productIndex].Price;

            return products[productIndex].Sum;
        }
        public double CalcProductSum(string productName, List<Product> products)
        {
            int productIndex = products.FindIndex(p => p.Name == productName);
            if (string.IsNullOrWhiteSpace(productName) || productIndex == -1)
                return -1;

            products[productIndex].Sum = products[productIndex].Count * products[productIndex].Price;

            return products[productIndex].Sum;
        }

        public double CalcGoodsSum(List<Product> products)
        {
            double sum = 0;
            for (int i = 0; i < products.Count; i++)
            {
                sum += CalcProductSum(i, products);
            }

            return sum;
        }

        public string PrintProducts(List<Product> products)
        {
            string result = null;
            foreach(var p in products)
            {
                result += $"{p.Name} | {p.Count} | {p.MeasureUnit} | {p.Price}$ | {CalcProductSum(p.Name, products)}$ |\n";
            }
            result += $"\n| общая сумма | {CalcGoodsSum(products)}$";

            return result;
        }


        public bool SetProductName(string name, Product p)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            p.Name = name;
            return true;
        }

        public bool SetProductMeasureUnit(string mUnit, Product p)
        {
            if (string.IsNullOrWhiteSpace(mUnit))
                return false;

            p.MeasureUnit = mUnit;
            return true;
        }

        public bool SetProductCount(string count, Product p)
        {
            if (!int.TryParse(count, out int num))
                return false;

            if (num == 0)
                return false;

            p.Count = num;
            return true;
        }

        public bool SetProductPrice(string price, Product p)
        {
            if (!double.TryParse(price, out double tmp))
                return false;
            p.Price = tmp;
            return true;
        }

        public void SetProductConsole(List<Product> products, Product p)
        {
            Console.WriteLine("Введите наименование продукта");
            SetProductName(Console.ReadLine(), p);
            Console.WriteLine("Введите еденицу измерения продукта");
            SetProductMeasureUnit(Console.ReadLine(), p);
            Console.WriteLine("Введите стоимость еденицы");
            SetProductPrice(Console.ReadLine(), p);
            Console.WriteLine("Введите количество продукции");
            SetProductCount(Console.ReadLine(), p);
        }
    }
}
