using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Laba_5.Models;
using OP_ClassLib;

namespace Laba_5
{

    public class DocumentsWebServiceWcf : IDocumentsWebServiceWcf
    {
        public List<Document> GetAllDocuments()
        {
            List<Document> list_To_Client = new List<Document>();
            using (document_dbEntities db = new document_dbEntities())
            {
                var bills = db.Bills.Select(bill => new Bill
                {
                    DocId = bill.DocId,
                    DocDate = bill.DocDate,
                    Provider = bill.Provider,
                    Client = bill.Client,
                    ClientId = bill.ClientId,
                    GoodsSum = (double)bill.GoodsSum,
                    Products = bill.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (double)p.Price,
                        Sum = (double)p.Sum
                    }).ToList()
                }).ToList();
                var invoices = db.Invoices.Select(invoice => new Invoice
                {
                    DocId = invoice.DocId,
                    DocDate = invoice.DocDate,
                    Provider = invoice.Provider,
                    Client = invoice.Client,
                    ProviderId = invoice.ProviderId,
                    ClientId = invoice.ClientId,
                    GoodsSum = (double)invoice.GoodsSum,
                    Products = invoice.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (double)p.Price,
                        Sum = (double)p.Sum
                    }).ToList()
                }).ToList();
                var reciepts = db.Reciepts.Select(reciept => new Reciept
                {
                    DocId = reciept.DocId,
                    DocDate = reciept.DocDate,
                    Provider = reciept.Provider,
                    Client = reciept.Client,
                    PaymentName = reciept.PaymentName,
                    GoodsSum = (double)reciept.GoodSum,
                    Products = reciept.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (double)p.Price,
                        Sum = (double)p.Sum
                    }).ToList()
                }).ToList();

                list_To_Client.AddRange(bills);
                list_To_Client.AddRange(invoices);
                list_To_Client.AddRange(reciepts);
            }

            return list_To_Client;
        }

        public List<Document> GetSpecialDocument(string docId)
        {
            List<Document> list_To_Client = new List<Document>();
            if (string.IsNullOrWhiteSpace(docId))
                return null;

            using (document_dbEntities db = new document_dbEntities())
            {
                var bills = db.Bills.Where(doc => doc.DocId == docId).Select(bill => new Bill
                {
                    DocId = bill.DocId,
                    DocDate = bill.DocDate,
                    Provider = bill.Provider,
                    Client = bill.Client,
                    ClientId = bill.ClientId,
                    GoodsSum = (double)bill.GoodsSum,
                    Products = bill.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (double)p.Price,
                        Sum = (double)p.Sum
                    }).ToList()
                }).ToList();
                if (bills.Count != 0)
                {
                    list_To_Client.AddRange(bills);
                    return list_To_Client;
                }

                var invoices = db.Invoices.Where(doc => doc.DocId == docId).Select(invoice => new Invoice
                {
                    DocId = invoice.DocId,
                    DocDate = invoice.DocDate,
                    Provider = invoice.Provider,
                    Client = invoice.Client,
                    ProviderId = invoice.ProviderId,
                    ClientId = invoice.ClientId,
                    GoodsSum = (double)invoice.GoodsSum,
                    Products = invoice.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (double)p.Price,
                        Sum = (double)p.Sum
                    }).ToList()
                }).ToList();
                if (invoices.Count != 0)
                {
                    list_To_Client.AddRange(invoices);
                    return list_To_Client;
                }

                var reciepts = db.Reciepts.Where(doc => doc.DocId == docId).Select(reciept => new Reciept
                {
                    DocId = reciept.DocId,
                    DocDate = reciept.DocDate,
                    Provider = reciept.Provider,
                    Client = reciept.Client,
                    PaymentName = reciept.PaymentName,
                    GoodsSum = (double)reciept.GoodSum,
                    Products = reciept.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (double)p.Price,
                        Sum = (double)p.Sum
                    }).ToList()
                }).ToList();
                if (reciepts.Count != 0)
                {
                    list_To_Client.AddRange(reciepts);
                    return list_To_Client;
                }
            }
            return null;
        }

        public List<Document> GetSpecialDocuments(string type)
        {
            List<Document> list_To_Client = new List<Document>();
            if (string.IsNullOrWhiteSpace(type))
                return null;

            if (type == "Bill")
            {
                using (document_dbEntities db = new document_dbEntities())
                {
                    var bills = db.Bills.Select(bill => new Bill
                    {
                        DocId = bill.DocId,
                        DocDate = bill.DocDate,
                        Provider = bill.Provider,
                        Client = bill.Client,
                        ClientId = bill.ClientId,
                        GoodsSum = (double)bill.GoodsSum,
                        Products = bill.Products.Select(p => new Product
                        {
                            Name = p.Name,
                            MeasureUnit = p.MeasureUnit,
                            Count = p.Count,
                            Price = (double)p.Price,
                            Sum = (double)p.Sum
                        }).ToList()
                    }).ToList();
                    list_To_Client.AddRange(bills);
                }
            }
            else if (type == "Invoice")
            {
                using (document_dbEntities db = new document_dbEntities())
                {
                    var invoices = db.Invoices.Select(invoice => new Invoice
                    {
                        DocId = invoice.DocId,
                        DocDate = invoice.DocDate,
                        Provider = invoice.Provider,
                        Client = invoice.Client,
                        ProviderId = invoice.ProviderId,
                        ClientId = invoice.ClientId,
                        GoodsSum = (double)invoice.GoodsSum,
                        Products = invoice.Products.Select(p => new Product
                        {
                            Name = p.Name,
                            MeasureUnit = p.MeasureUnit,
                            Count = p.Count,
                            Price = (double)p.Price,
                            Sum = (double)p.Sum
                        }).ToList()
                    }).ToList();
                    list_To_Client.AddRange(invoices);
                }
            }
            else if (type == "Reciept")
            {
                using (document_dbEntities db = new document_dbEntities())
                {
                    var reciepts = db.Reciepts.Select(reciept => new Reciept
                    {
                        DocId = reciept.DocId,
                        DocDate = reciept.DocDate,
                        Provider = reciept.Provider,
                        Client = reciept.Client,
                        PaymentName = reciept.PaymentName,
                        GoodsSum = (double)reciept.GoodSum,
                        Products = reciept.Products.Select(p => new Product
                        {
                            Name = p.Name,
                            MeasureUnit = p.MeasureUnit,
                            Count = p.Count,
                            Price = (double)p.Price,
                            Sum = (double)p.Sum
                        }).ToList()
                    }).ToList();
                    list_To_Client.AddRange(reciepts);
                }
            }
            else
            {
                using (document_dbEntities db = new document_dbEntities())
                {
                    var reciepts = db.Reciepts.Select(reciept => new Reciept
                    {
                        DocId = reciept.DocId,
                        DocDate = reciept.DocDate,
                        Provider = reciept.Provider,
                        Client = reciept.Client,
                        PaymentName = reciept.PaymentName,
                        GoodsSum = (double)reciept.GoodSum,
                        Products = reciept.Products.Select(p => new Product
                        {
                            Name = p.Name,
                            MeasureUnit = p.MeasureUnit,
                            Count = p.Count,
                            Price = (double)p.Price,
                            Sum = (double)p.Sum
                        }).ToList()
                    }).ToList();
                    list_To_Client.AddRange(reciepts);
                }
            }
            return list_To_Client;
        }

        public bool SetDocumentBill(string[] data, Product[] productsPacket)
        {
            if (data.Length != 5)
                return false;

            foreach (var s in data)
            {
                if (string.IsNullOrWhiteSpace(s))
                    return false;
            }

            Bill bill = new Bill(data[0], data[1], data[2], data[3], data[4]);
            bill.SetProductList(productsPacket.ToList());
            bill.CalcGoodsSum();
            using (document_dbEntities db = new document_dbEntities())
            {
                _ = db.Database.Connection;
                Bills bill_To_Db = new Bills
                {
                    DocId = bill.DocId,
                    DocDate = bill.DocDate,
                    Provider = bill.Provider,
                    Client = bill.Client,
                    ClientId = bill.ClientId,
                    GoodsSum = (decimal)bill.GoodsSum,
                };
                db.Bills.Add(bill_To_Db);
                db.SaveChanges();

                List<Products> products_To_Db = new List<Products>();
                foreach (Product p in productsPacket)
                {
                    products_To_Db.Add(new Products
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (decimal)p.Price,
                        Sum = (decimal)p.Sum,
                        Bills = bill_To_Db
                    });
                }
                db.Products.AddRange(products_To_Db);
                db.SaveChanges();
            }
            return true;
        }

        public bool SetDocumentInvoice(string[] data, Product[] productsPacket)
        {
            if (data.Length != 6)
                return false;

            foreach (var s in data)
            {
                if (string.IsNullOrWhiteSpace(s))
                    return false;
            }

            Invoice invoice = new Invoice(data[0], data[1], data[2], data[3], data[4], data[5]);
            invoice.SetProductList(productsPacket.ToList());
            invoice.CalcGoodsSum();

            using (document_dbEntities db = new document_dbEntities())
            {
                Invoices invoice_To_Db = new Invoices
                {
                    DocId = invoice.DocId,
                    DocDate = invoice.DocDate,
                    Provider = invoice.Provider,
                    Client = invoice.Client,
                    ClientId = invoice.ClientId,
                    ProviderId = invoice.ProviderId,
                    GoodsSum = (decimal)invoice.GoodsSum,
                };
                db.Invoices.Add(invoice_To_Db);
                db.SaveChanges();

                List<Products> products_To_Db = new List<Products>();
                foreach (Product p in productsPacket)
                {
                    products_To_Db.Add(new Products
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (decimal)p.Price,
                        Sum = (decimal)p.Sum,
                        Invoices = invoice_To_Db
                    });
                }
                db.Products.AddRange(products_To_Db);
                db.SaveChanges();
            }
            return true;
        }

        public bool SetDocumentReciept(string[] data, Product[] productsPacket)
        {
            if (data.Length != 5)
                return false;

            foreach (var s in data)
            {
                if (string.IsNullOrWhiteSpace(s))
                    return false;
            }

            Reciept reciept = new Reciept(data[0], data[1], data[2], data[3], data[4]);
            reciept.SetProductList(productsPacket.ToList());
            reciept.CalcGoodsSum();

            using (document_dbEntities db = new document_dbEntities())
            {
                Reciepts reciept_To_Db = new Reciepts
                {
                    DocId = reciept.DocId,
                    DocDate = reciept.DocDate,
                    Provider = reciept.Provider,
                    Client = reciept.Client,
                    PaymentName = reciept.PaymentName,
                    GoodSum = (decimal)reciept.GoodsSum,
                };
                db.Reciepts.Add(reciept_To_Db);
                db.SaveChanges();

                List<Products> products_To_Db = new List<Products>();
                foreach (Product p in productsPacket)
                {
                    products_To_Db.Add(new Products
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (decimal)p.Price,
                        Sum = (decimal)p.Sum,
                        Reciepts = reciept_To_Db
                    });
                }
                db.Products.AddRange(products_To_Db);
                db.SaveChanges();
            }
            return true;

        }
    }
}
