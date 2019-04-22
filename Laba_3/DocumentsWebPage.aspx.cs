﻿using Laba_3.Models;
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
            List<RequestedDoc> docsId = new List<RequestedDoc>();
            string docsToResponce = "";

            using (document_dbEntities db = new document_dbEntities())
            {
                docsId.AddRange(db.Bills.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Счет" }).ToList());
                docsId.AddRange(db.Invoices.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Накладная" }).ToList());
                docsId.AddRange(db.Reciepts.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Квитанция" }).ToList());
            }
            int i = 1;
            foreach(var doc in docsId)
            {
                docsToResponce += $"<tr onclick=\"GetCurrentDoc(this.lastChild.innerHTML, this.childNodes[1].innerHTML)\"><th scope=\"row\">{i++}</th><td id=\"docType\">{doc.Type}</td><td id=\"docId\">{doc.DocId}</td></tr>";
            }

            Control tbMask = Page.FindControl("docs");
            if (tbMask is HtmlGenericControl)
            {
                HtmlGenericControl htmlCtrl = (HtmlGenericControl)tbMask;
                htmlCtrl.InnerHtml = docsToResponce;
            }
        }

        [WebMethod]
        public static string GetDocumentDataById(string docId, string docType)
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