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
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using Microsoft.CSharp.Activities;
using System.Threading;

namespace Laba_7.Controls
{
    public class SideWorker
    {
        public static async Task CreateDocumentSequence(string type, string[] data, List<Product> products, List<Document> docs, string filePath)
        {
            var docT = new Variable<string>();
            var file = new Variable<string>();
            var docData = new Variable<IList<string>>();
            var docProducts = new Variable<IList<Product>>();
            var docAll = new Variable<IList<Document>>();
            var docNew = new Variable<Document>("NewDocument");

            Document resultDoc = new Document();
            
            Activity buildWorkFlow = new Sequence
            {  
                Variables = { docT, file, docData, docProducts, docAll, docNew },
                Activities =
                {
                    new Assign<string>
                    {
                        To = docT,
                        Value = new LambdaValue<string>(t => type)
                    },
                    new Assign<string>
                    {
                        To = file,
                        Value = new LambdaValue<string>(f => filePath)
                    },
                    new Assign<IList<string>>
                    {
                        To = docData,
                        Value = new LambdaValue<IList<string>>(d => data)
                    },
                    new Assign<IList<Product>>
                    {
                        To = docProducts,
                        Value = new LambdaValue<IList<Product>>(p => products)
                    },
                    new Assign<IList<Document>>
                    {
                        To = docAll,
                        Value = new LambdaValue<IList<Document>>(p => docs)
                    },
                    new Assign<Document>
                    {
                        To = docNew,
                        Value = new LambdaValue<Document>(d => resultDoc),
                    },
                    new DocumentsBuildActivity<Document>()
                    {
                        DocType = new InArgument<string>(docT),
                        Data =  new InArgument<IList<string>>(docData),
                        Products = new InArgument<IList<Product>>(docProducts),
                        Result = new OutArgument<Document>(docNew)
                    },
                    new AddToCollection<Document>()
                    {
                        Collection = new InArgument<ICollection<Document>>(docAll),
                        Item = new InArgument<Document>(docNew),
                    },
                    new DocumentsSerializeActivity()
                    {
                        FilePath = new InArgument<string>(file),
                        AllDocuments = new InArgument<IList<Document>>(docAll),
                    }
                },
            };

            await Task.Run(() =>
            {
                WorkflowInvoker.Invoke(buildWorkFlow);
            });
        }
        /// <summary>
        /// Xml десериализация
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async static Task<List<Document>> DeserializeActivity(string filePath)
        {
            List<Document> newList = await Task.Run(() =>
            {
                Activity deserealization = new DocumentsDeserializeActivity<Document>()
                {
                    FilePath = new LambdaValue<string>(f => filePath)
                };
                var results = WorkflowInvoker.Invoke(deserealization);
                return results["Result"] as List<Document>;
            });
            return newList;
        }
        /// <summary>
        /// Xml сереализация
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="docs"></param>
        /// <returns></returns>
        public static async Task SerializeActivity(List<Document> docs, string filePath)
        {
            await Task.Run(() =>
            {
                Activity serealization = new DocumentsSerializeActivity()
                {
                    FilePath = new LambdaValue<string>(f => filePath),
                    AllDocuments = new LambdaValue<IList<Document>>(l => docs)
                };
                WorkflowInvoker.Invoke(serealization);
            });
        }
        
        public static Document DocCreateForActivity(string[] docData, string docType)
        {
            Document result = new Document();
            if(docType == "Reciept")
            {
                result = new Reciept(docData[0], docData[1], docData[2], docData[3], docData[4]);
            }
            else if (docType == "Invoice")
            {
                result = new Invoice(docData[0], docData[1], docData[2], docData[3], docData[4], docData[5]);
            }
            else if (docType == "Bill")
            {
                result = new Bill(docData[0], docData[1], docData[2], docData[3], docData[4]);
            }
            return result;
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
        /// Клиентская инициализация документа
        /// </summary>
        /// <param name="data"></param>
        /// <param name="doc"></param>
        /// <param name="products"></param>
        public static void DocInotialize(string[] data, Document doc, List<Product> products)
        {
            if (doc.GetType() == typeof(Bill))
            {
                ((Bill)doc).SetDocId(data[0]);
                ((Bill)doc).SetDocDate(data[1]);
                ((Bill)doc).SetParticipants(data[2], data[3]);
                ((Bill)doc).SetClientId(data[4]);
                ((Bill)doc).SetProductList(products);
            }
            if (doc.GetType() == typeof(Reciept))
            {
                ((Reciept)doc).SetDocId(data[0]);
                ((Reciept)doc).SetDocDate(data[1]);
                ((Reciept)doc).SetParticipants(data[2], data[3]);
                ((Reciept)doc).SetPaymentName(data[4]);
                ((Reciept)doc).SetProductList(products);
            }
            if (doc.GetType() == typeof(Invoice))
            {
                ((Invoice)doc).SetDocId(data[0]);
                ((Invoice)doc).SetDocDate(data[1]);
                ((Invoice)doc).SetParticipants(data[2], data[3]);
                ((Invoice)doc).SetProviderId(data[4]);
                ((Invoice)doc).SetClientId(data[5]);
                ((Invoice)doc).SetProductList(products);
            }
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
