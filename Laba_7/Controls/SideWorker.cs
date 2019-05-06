using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using OP_ClassLib;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace Laba_7.Controls
{
    public class SideWorker
    {
        /// <summary>
        /// Xml десериализация
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static async Task<List<Document>> DeserializeXml(string filePath)
        {
            List<Document> newList = await Task.Run(() =>
            {
                XmlReader reader = new XmlTextReader(filePath);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Document>));
                var res = (List<Document>)serializer.Deserialize(reader);
                reader.Close();
                return res;
            });
            return newList;
        }
        /// <summary>
        /// Xml сереализация
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="bList"></param>
        /// <returns></returns>
        public static async Task SerializeXml(string filePath, BindingList<Document> bList)
        {
            await Task.Run(() =>
            {
                XmlWriter writer = new XmlTextWriter(filePath, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Document>));
                serializer.Serialize(writer, bList.ToList());
                writer.Close();
            });
        }
        /// <summary>
        /// Валидация формы
        /// </summary>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static bool ValidationForm(UIElementCollection controls)
        {
            foreach (var control in controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)control).Text))
                    {
                        ((TextBox)control).BorderBrush = Brushes.OrangeRed;
                        return false;
                    }
                    ((TextBox)control).BorderBrush = Brushes.LightGray;
                }
            }
            return true;
        }
        /// <summary>
        /// Перечисление сервисов
        /// </summary>
        public enum ServicesSwitcher
        {
            asmx,
            wcf,
            client
        }
        /// <summary>
        /// Перечисление типов документа
        /// </summary>
        public enum GetDocsSwitcher
        {
            all,
            invoices,
            bills,
            reciepts,
            special
        }

        /// <summary>
        /// Метод конструирования типов документа сервиса в типы документа клиента
        /// </summary>
        /// <param name="dataToCast"></param>
        /// <returns></returns>
        public static Document CastToClientDocuments(MyAsmxService.Document dataToCast)
        {
            // конструируем счет
            if (dataToCast is MyAsmxService.Bill)
            {
                Bill convertedBill = new Bill(dataToCast.DocId, dataToCast.DocDate.ToString(), dataToCast.Provider, dataToCast.Client, ((MyAsmxService.Bill)dataToCast).ClientId);


                foreach (var p in ((MyAsmxService.Bill)dataToCast).Products)
                {
                    var product = new Product(p.Name, p.MeasureUnit, p.Count, p.Price);
                    product.Sum = p.Sum;
                    convertedBill.Products.Add(product);
                }
                convertedBill.GoodsSum = ((MyAsmxService.Bill)dataToCast).GoodsSum;
                return convertedBill;
            }
            // конструируем квитанцию
            else if (dataToCast is MyAsmxService.Reciept)
            {
                Reciept convertedBill = new Reciept(dataToCast.DocId, dataToCast.DocDate.ToString(), dataToCast.Provider, dataToCast.Client, ((MyAsmxService.Reciept)dataToCast).PaymentName);

                foreach (var p in ((MyAsmxService.Reciept)dataToCast).Products)
                {
                    var product = new Product(p.Name, p.MeasureUnit, p.Count, p.Price);
                    product.Sum = p.Sum;
                    convertedBill.Products.Add(product);
                }
                convertedBill.GoodsSum = ((MyAsmxService.Reciept)dataToCast).GoodsSum;
                return convertedBill;
            }
            // конструируем накладную
            else if (dataToCast is MyAsmxService.Invoice)
            {
                Invoice convertedBill = new Invoice(dataToCast.DocId, dataToCast.DocDate.ToString(), dataToCast.Provider, dataToCast.Client, ((MyAsmxService.Invoice)dataToCast).ProviderId, ((MyAsmxService.Invoice)dataToCast).ClientId);

                foreach (var p in ((MyAsmxService.Invoice)dataToCast).Products)
                {
                    var product = new Product(p.Name, p.MeasureUnit, p.Count, p.Price);
                    product.Sum = p.Sum;
                    convertedBill.Products.Add(product);
                }
                convertedBill.GoodsSum = ((MyAsmxService.Invoice)dataToCast).GoodsSum;
                return convertedBill;
            }
            else
                return default;
        }
        public static Document CastToClientDocuments(MyWcfService.Document dataToCast)
        {
            // конструируем счет
            if (dataToCast is MyWcfService.Bill)
            {
                Bill convertedBill = new Bill(dataToCast.DocId, dataToCast.DocDate.ToString(), dataToCast.Provider, dataToCast.Client, ((MyWcfService.Bill)dataToCast).ClientId);


                foreach (var p in ((MyWcfService.Bill)dataToCast).Products)
                {
                    var product = new Product(p.Name, p.MeasureUnit, p.Count, p.Price);
                    product.Sum = p.Sum;
                    convertedBill.Products.Add(product);
                }
                convertedBill.GoodsSum = ((MyWcfService.Bill)dataToCast).GoodsSum;
                return convertedBill;
            }
            // конструируем квитанцию
            else if (dataToCast is MyWcfService.Reciept)
            {
                Reciept convertedBill = new Reciept(dataToCast.DocId, dataToCast.DocDate.ToString(), dataToCast.Provider, dataToCast.Client, ((MyWcfService.Reciept)dataToCast).PaymentName);

                foreach (var p in ((MyWcfService.Reciept)dataToCast).Products)
                {
                    var product = new Product(p.Name, p.MeasureUnit, p.Count, p.Price);
                    product.Sum = p.Sum;
                    convertedBill.Products.Add(product);
                }
                convertedBill.GoodsSum = ((MyWcfService.Reciept)dataToCast).GoodsSum;
                return convertedBill;
            }
            // конструируем накладную
            else if (dataToCast is MyWcfService.Invoice)
            {
                Invoice convertedBill = new Invoice(dataToCast.DocId, dataToCast.DocDate.ToString(), dataToCast.Provider, dataToCast.Client, ((MyWcfService.Invoice)dataToCast).ProviderId, ((MyWcfService.Invoice)dataToCast).ClientId);

                foreach (var p in ((MyWcfService.Invoice)dataToCast).Products)
                {
                    var product = new Product(p.Name, p.MeasureUnit, p.Count, p.Price);
                    product.Sum = p.Sum;
                    convertedBill.Products.Add(product);
                }
                convertedBill.GoodsSum = ((MyWcfService.Invoice)dataToCast).GoodsSum;
                return convertedBill;
            }
            else
                return default;
        }

        /// <summary>
        /// Метод конструирования типа продукта клиента в тип продукта сервиса
        /// </summary>
        /// <param name="dataToCast"></param>
        /// <returns></returns>
        public static MyAsmxService.Product CastToAsmxProducts(Product dataToCast)
        {
            MyAsmxService.Product productToSend = new MyAsmxService.Product();
            productToSend.Name = dataToCast.Name;
            productToSend.MeasureUnit = dataToCast.MeasureUnit;
            productToSend.Count = dataToCast.Count;
            productToSend.Price = dataToCast.Price;
            productToSend.Sum = dataToCast.Sum;
            return productToSend;
        }
        public static MyWcfService.Product CastToWcfProducts(Product dataToCast)
        {
            MyWcfService.Product productToSend = new MyWcfService.Product();
            productToSend.Name = dataToCast.Name;
            productToSend.MeasureUnit = dataToCast.MeasureUnit;
            productToSend.Count = dataToCast.Count;
            productToSend.Price = dataToCast.Price;
            productToSend.Sum = dataToCast.Sum;
            return productToSend;
        }
        public static Laba_7.Models.ModelProduct CastToModelProducts(Product dataToCast)
        {
            Laba_7.Models.ModelProduct productToSend = new Laba_7.Models.ModelProduct();
            productToSend.Name = dataToCast.Name;
            productToSend.MeasureUnit = dataToCast.MeasureUnit;
            productToSend.Count = dataToCast.Count;
            productToSend.Price = dataToCast.Price;
            productToSend.Sum = dataToCast.Sum;
            return productToSend;
        }
        public static Product CastToLibraryProducts(Laba_7.Models.ModelProduct dataToCast)
        {
            Product productToSend = new Product();
            productToSend.Name = dataToCast.Name;
            productToSend.MeasureUnit = dataToCast.MeasureUnit;
            productToSend.Count = dataToCast.Count;
            productToSend.Price = dataToCast.Price;
            productToSend.Sum = dataToCast.Sum;
            return productToSend;
        }
    }
}
