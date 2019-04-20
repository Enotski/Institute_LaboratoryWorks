using System.Collections.Generic;

namespace OP_ClassLib
{
    /// <summary>
    /// Основные методы работы с продуктом/услугой
    /// </summary>
    interface IProductSetup
    {
        void SetProduct(List<Product> products, Product item);
        bool RemoveProduct(string productName, List<Product> Products);
        bool SetProductName(string name, Product p);
        bool SetProductMeasureUnit(string mUnit, Product p);
        bool SetProductCount(string count, Product p);
        bool SetProductPrice(string price, Product p);
        double CalcProductSum(int productIndex, List<Product> Products);
        double CalcProductSum(string productName, List<Product> Products);
        double CalcGoodsSum(List<Product> Products);
        string PrintProducts(List<Product> products);
        string HtmlPrintProducts(List<Product> products);
    }
}
