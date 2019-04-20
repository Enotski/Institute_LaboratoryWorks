using Laba_3.Models;
using OP_ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laba_3
{
    public partial class DocumentsWebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<RequestedDoc> docsId = new List<RequestedDoc>();

            using (document_dbEntities db = new document_dbEntities())
            {
                docsId.AddRange(db.Bills.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Счет" }).ToList());
                docsId.AddRange(db.Invoices.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Накладная" }).ToList());
                docsId.AddRange(db.Reciepts.Select(d => new RequestedDoc { DocId = d.DocId, Type = "Квитанция" }).ToList());
            }

            GridViewDocuments.DataSource = docsId;
            GridViewDocuments.DataBind();
        }

        protected void GridViewDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            string requestedDocId = GridViewDocuments.SelectedRow.Cells[1].Text;
            string requestedDocType = GridViewDocuments.SelectedRow.Cells[2].Text;
            Document docToResponce = null;
            using (document_dbEntities db = new document_dbEntities())
            {
                if (requestedDocType == "Счет")
                {
                   var doc = db.Bills.Find(requestedDocId);

                    if (doc == null)
                        return;
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
                else if (requestedDocType == "Квитанция")
                {
                   var doc = db.Reciepts.Find(requestedDocId);

                    if (doc == null)
                        return;
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
                else if (requestedDocType == "Накладная")
                {
                   var doc = db.Invoices.Find(requestedDocId);

                    if (doc == null)
                        return;
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

            LabelDocPrint.Text = docToResponce.HtmlPrint();
        }
    }
}