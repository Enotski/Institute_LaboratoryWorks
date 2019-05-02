using System.Collections.Generic;
using System.ServiceModel;

namespace OP_ClassLib
{
    /// <summary>
    /// Основные методы работы с продуктом/услугой
    /// </summary>
    [ServiceContract]
    [ServiceKnownType(typeof(Product))]
    interface IProductSetup
    {
        [OperationContract]
        void SetProduct(List<Product> products, Product item);
        [OperationContract]
        bool RemoveProduct(string productName, List<Product> Products);
        [OperationContract]
        bool SetProductName(string name, Product p);
        [OperationContract]
        bool SetProductMeasureUnit(string mUnit, Product p);
        [OperationContract]     
        bool SetProductCount(string count, Product p);
        [OperationContract]
        bool SetProductPrice(string price, Product p);
        [OperationContract]
        double CalcProductSum(int productIndex, List<Product> Products);
        [OperationContract]
        double CalcProductSum(string productName, List<Product> Products);
        [OperationContract]
        double CalcGoodsSum(List<Product> Products);
        [OperationContract]
        string ConsolePrintProducts(List<Product> products);
        [OperationContract]
        string HtmlPrintProducts(List<Product> products);
    }
}
