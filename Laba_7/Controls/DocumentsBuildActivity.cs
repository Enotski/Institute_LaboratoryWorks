using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using OP_ClassLib;

namespace Laba_7
{

    public sealed class DocumentsBuildActivity<TResult> : CodeActivity<TResult> where TResult : class
    {
        [RequiredArgument]
        public InArgument<IList<string>> Data { get; set; }
        [RequiredArgument]
        public InArgument<IList<Product>> Products { get; set; }
        [RequiredArgument]
        public InArgument<string> DocType { get; set; }
        //[RequiredArgument]
        public OutArgument<Document> NewDoc { get; set; }
        protected override TResult Execute(CodeActivityContext context)
        {
            Document responce = new Document();
            List<string> docData = context.GetValue(this.Data).ToList();
            List<Product> products = context.GetValue(this.Products).ToList();
            if(context.GetValue(this.DocType) == "Bill")
            {
                Bill bill = new Bill(docData[0], docData[1], docData[2], docData[3], docData[4]);
                bill.SetProductList(products);
                bill.CalcGoodsSum();
                responce = bill;
            }
            else if (context.GetValue(this.DocType) == "Invoice")
            {
                Invoice invoice = new Invoice(docData[0], docData[1], docData[2], docData[3], docData[4], docData[5]);
                invoice.SetProductList(products);
                invoice.CalcGoodsSum();
                responce = invoice;
            }
            else if (context.GetValue(this.DocType) == "Reciept")
            {
                Reciept reciept = new Reciept(docData[0], docData[1], docData[2], docData[3], docData[4]);
                reciept.SetProductList(products);
                reciept.CalcGoodsSum();
                responce = reciept;
            }
            NewDoc.Set(context, responce);
            return responce as TResult;
        }
    }
}
