using Laba_3.Models;
using OP_ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Script.Services;

namespace Laba_3
{
    
    public partial class DocumentsWebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetAllDocs()
        {
            List<RequestedDoc> docsId = new List<RequestedDoc>();
            string docsToResponce = "";

            using (document_dbEntities db = new document_dbEntities())
            {
                docsId.AddRange(db.Bills.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Счет" }).ToList());
                docsId.AddRange(db.Invoices.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Накладная" }).ToList());
                docsId.AddRange(db.Reciepts.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Квитанция" }).ToList());
            }
            int i = 1;
            foreach (var doc in docsId)
            {
                docsToResponce += $"<tr class=\"tbItem\" onclick=\"GetCurrentDoc(this.lastChild.innerHTML, this.childNodes[1].innerHTML)\"><th scope=\"row\">{i++}</th><td id=\"docType\">{doc.Type}</td><td id=\"docId\">{doc.DocId}</td></tr>";
            }

            return docsToResponce;
        }
        [WebMethod]
        public static string GetReciepts()
        {
            List<RequestedDoc> docsId = new List<RequestedDoc>();
            string docsToResponce = "";

            using (document_dbEntities db = new document_dbEntities())
            {
                docsId.AddRange(db.Reciepts.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Квитанция" }).ToList());
            }
            int i = 1;
            foreach (var doc in docsId)
            {
                docsToResponce += $"<tr class=\"tbItem\" onclick=\"GetCurrentDoc(this.lastChild.innerHTML, this.childNodes[1].innerHTML)\"><th scope=\"row\">{i++}</th><td id=\"docType\">{doc.Type}</td><td id=\"docId\">{doc.DocId}</td></tr>";
            }

            return docsToResponce;
        }
        [WebMethod]
        public static string GetBills()
        {
            List<RequestedDoc> docsId = new List<RequestedDoc>();
            string docsToResponce = "";

            using (document_dbEntities db = new document_dbEntities())
            {
                docsId.AddRange(db.Bills.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Счет" }).ToList());
            }
            int i = 1;
            foreach (var doc in docsId)
            {
                docsToResponce += $"<tr class=\"tbItem\" onclick=\"GetCurrentDoc(this.lastChild.innerHTML, this.childNodes[1].innerHTML)\"><th scope=\"row\">{i++}</th><td id=\"docType\">{doc.Type}</td><td id=\"docId\">{doc.DocId}</td></tr>";
            }

            return docsToResponce;
        }
        [WebMethod]
        public static string GetInvoices()
        {
            List<RequestedDoc> docsId = new List<RequestedDoc>();
            string docsToResponce = "";

            using (document_dbEntities db = new document_dbEntities())
            {
                docsId.AddRange(db.Invoices.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Накладная" }).ToList());
            }
            int i = 1;
            foreach (var doc in docsId)
            {
                docsToResponce += $"<tr class=\"tbItem\" onclick=\"GetCurrentDoc(this.lastChild.innerHTML, this.childNodes[1].innerHTML)\"><th scope=\"row\">{i++}</th><td id=\"docType\">{doc.Type}</td><td id=\"docId\">{doc.DocId}</td></tr>";
            }

            return docsToResponce;
        }
        [WebMethod]
        public static string GetSpecialDoc(string docId)
        {
            string docToResponce = "";
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
                    int i = 1;
                    foreach (var doc in bills)
                    {
                        docToResponce += $"<tr class=\"tbItem\" onclick=\"GetCurrentDoc(this.lastChild.innerHTML, this.childNodes[1].innerHTML)\"><th scope=\"row\">{i++}</th><td id=\"docType\">Счет</td><td id=\"docId\">{doc.DocId}</td></tr>";
                    }

                    return docToResponce;
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
                    int i = 1;
                    foreach (var doc in invoices)
                    {
                        docToResponce += $"<tr class=\"tbItem\" onclick=\"GetCurrentDoc(this.lastChild.innerHTML, this.childNodes[1].innerHTML)\"><th scope=\"row\">{i++}</th><td id=\"docType\">Накладная</td><td id=\"docId\">{doc.DocId}</td></tr>";
                    }

                    return docToResponce;
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
                    int i = 1;
                    foreach (var doc in reciepts)
                    {
                        docToResponce += $"<tr class=\"tbItem\" onclick=\"GetCurrentDoc(this.lastChild.innerHTML, this.childNodes[1].innerHTML)\"><th scope=\"row\">{i++}</th><td id=\"docType\">Квитанция</td><td id=\"docId\">{doc.DocId}</td></tr>";
                    }
                    return docToResponce;
                }
            }
            return docToResponce;
        }
        [WebMethod]
        public static string GetSelectedDocument(string docId, string docType)
        {
            Document docToResponce = null;
            using (document_dbEntities db = new document_dbEntities())
            {
                if (docType == "Счет")
                {
                    var doc = db.Bills.Find(docId);

                    if (doc != null)
                    {
                        docToResponce = new Bill(doc.DocId, doc.DocDate.ToString(), doc.Provider, doc.Client, doc.ClientId);
                        ((Bill)docToResponce).Products = doc.Products.Select(p => new Product
                        {
                            Name = p.Name,
                            MeasureUnit = p.MeasureUnit,
                            Count = p.Count,
                            Price = (double)p.Price,
                            Sum = (double)p.Sum
                        }).ToList();
                        ((Bill)docToResponce).CalcGoodsSum();
                    }
                 
                }
                else if (docType == "Квитанция")
                {
                    var doc = db.Reciepts.Find(docId);

                    if (doc == null)
                        return "";
                    docToResponce = new Reciept(doc.DocId, doc.DocDate.ToString(), doc.Provider, doc.Client, doc.PaymentName);
                    ((Reciept)docToResponce).Products = doc.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (double)p.Price,
                        Sum = (double)p.Sum
                    }).ToList();
                    ((Reciept)docToResponce).CalcGoodsSum();
                }
                else if (docType == "Накладная")
                {
                    var doc = db.Invoices.Find(docId);

                    if (doc == null)
                        return "";
                    docToResponce = new Invoice(doc.DocId, doc.DocDate.ToString(), doc.Provider, doc.Client, doc.ProviderId, doc.ClientId);
                    ((Invoice)docToResponce).Products = doc.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        MeasureUnit = p.MeasureUnit,
                        Count = p.Count,
                        Price = (double)p.Price,
                        Sum = (double)p.Sum
                    }).ToList();
                    ((Invoice)docToResponce).CalcGoodsSum();
                }
            }
            return docToResponce.HtmlPrint();
        }
    }
}